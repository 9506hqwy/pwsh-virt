namespace PwshVirt;

[OutputType(typeof(Network))]
[Cmdlet(VerbsLifecycle.Start, VerbsVirt.Network)]
public class StartVirtNetwork : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Network? Network { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.NetworkCreateAsync(this.Network!.Self, this.Cancellation!.Token);

        var active = await NetworkUtility.WaitForState(conn, this.Network, 1, this.Cancellation!.Token);

        var net = await conn.Client.NetworkLookupByNameAsync(this.Network.Name, this.Cancellation!.Token);

        var persistent = await conn.Client.NetworkIsPersistentAsync(net, this.Cancellation!.Token);

        var model = new Network(conn, net, active, persistent);

        this.SetResult(model);
    }
}

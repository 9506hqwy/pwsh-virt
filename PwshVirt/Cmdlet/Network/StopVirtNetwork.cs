namespace PwshVirt;

[OutputType(typeof(Network))]
[Cmdlet(VerbsLifecycle.Stop, VerbsVirt.Network)]
public class StopVirtNetwork : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Network? Network { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.NetworkDestroyAsync(this.Network!.Self, this.Cancellation!.Token).ConfigureAwait(false);

        var active = await NetworkUtility.WaitForState(conn, this.Network, 0, this.Cancellation!.Token).ConfigureAwait(false);

        var net = await conn.Client.NetworkLookupByNameAsync(this.Network.Name, this.Cancellation!.Token).ConfigureAwait(false);

        var persistent = await conn.Client.NetworkIsPersistentAsync(net, this.Cancellation!.Token).ConfigureAwait(false);

        var model = new Network(conn, net, active, persistent);

        this.SetResult(model);
    }
}

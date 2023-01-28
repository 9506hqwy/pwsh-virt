namespace PwshVirt;

[OutputType(typeof(Network))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.Network, DefaultParameterSetName = KeyAll)]
public class GetVirtNetwork : PwshVirtCmdlet
{
    private const string KeyAll = "All";

    private const string KeyName = "Name";

    [Parameter(ParameterSetName = KeyName)]
    public string? Name { get; set; }

    [Parameter(ParameterSetName = KeyAll)]
    [Parameter(ParameterSetName = KeyName)]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        switch (this.ParameterSetName)
        {
            case KeyAll:
                await this.GetAll(conn);
                break;
            case KeyName:
                await this.GetByName(conn, this.Name!);
                break;
            default:
                throw new InvalidProgramException();
        }
    }

    private async Task GetAll(Connection conn)
    {
        (var ifaces, var num) = await conn.Client.ConnectListAllNetworksAsync(1, 1 | 2, this.Cancellation!.Token);

        var models = new List<Network>();

        if (num != 0)
        {
            foreach (var net in ifaces)
            {
                var active = await conn.Client.NetworkIsActiveAsync(net, this.Cancellation!.Token);
                var persistent = await conn.Client.NetworkIsPersistentAsync(net, this.Cancellation!.Token);
                var model = new Network(conn, net, active, persistent);
                models.Add(model);
            }
        }

        this.SetResult(models, true);
    }

    private async Task GetByName(Connection conn, string name)
    {
        var net = await conn.Client.NetworkLookupByNameAsync(name, this.Cancellation!.Token);

        var active = await conn.Client.NetworkIsActiveAsync(net, this.Cancellation!.Token);

        var persistent = await conn.Client.NetworkIsPersistentAsync(net, this.Cancellation!.Token);

        var model = new Network(conn, net, active, persistent);

        this.SetResult(model);
    }
}

namespace PwshVirt;

using static Libvirt.Header.VirConnectListAllNetworksFlags;

[OutputType(typeof(Network))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.Network, DefaultParameterSetName = KeyAll)]
public class GetVirtNetwork : PwshVirtCmdlet
{
    private const string KeyAll = "All";

    private const string KeyName = "Name";

    [Parameter(Mandatory = true, ParameterSetName = KeyName)]
    public string? Name { get; set; }

    [Parameter(ParameterSetName = KeyAll)]
    [Parameter(ParameterSetName = KeyName)]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        switch (this.ParameterSetName)
        {
            case KeyAll:
                await this.GetAll(conn).ConfigureAwait(false);
                break;
            case KeyName:
                await this.GetByName(conn, this.Name!).ConfigureAwait(false);
                break;
            default:
                throw new InvalidProgramException();
        }
    }

    private async Task GetAll(Connection conn)
    {
        var flags = VirConnectListNetworksInactive | VirConnectListNetworksActive;
        (var ifaces, var num) = await conn.Client.ConnectListAllNetworksAsync(1, (uint)flags, this.Cancellation!.Token).ConfigureAwait(false);

        var models = new List<Network>();

        if (num != 0)
        {
            foreach (var net in ifaces)
            {
                var active = await conn.Client.NetworkIsActiveAsync(net, this.Cancellation!.Token).ConfigureAwait(false);
                var persistent = await conn.Client.NetworkIsPersistentAsync(net, this.Cancellation!.Token).ConfigureAwait(false);
                var model = new Network(conn, net, active, persistent);
                models.Add(model);
            }
        }

        this.SetResult(models, true);
    }

    private async Task GetByName(Connection conn, string name)
    {
        var net = await conn.Client.NetworkLookupByNameAsync(name, this.Cancellation!.Token).ConfigureAwait(false);

        var active = await conn.Client.NetworkIsActiveAsync(net, this.Cancellation!.Token).ConfigureAwait(false);

        var persistent = await conn.Client.NetworkIsPersistentAsync(net, this.Cancellation!.Token).ConfigureAwait(false);

        var model = new Network(conn, net, active, persistent);

        this.SetResult(model);
    }
}

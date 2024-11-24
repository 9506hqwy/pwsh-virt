namespace PwshVirt;

using static Libvirt.Header.VirConnectListAllInterfacesFlags;

[OutputType(typeof(NetworkInterface))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.NetworkInterface, DefaultParameterSetName = KeyAll)]
public class GetVirtNetworkInterface : PwshVirtCmdlet
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
        var flags = VirConnectListInterfacesInactive | VirConnectListInterfacesActive;
        (var ifaces, var num) = await conn.Client.ConnectListAllInterfacesAsync(1, (uint)flags, this.Cancellation!.Token);

        var models = new List<NetworkInterface>();

        if (num != 0)
        {
            foreach (var iface in ifaces)
            {
                var active = await conn.Client.InterfaceIsActiveAsync(iface, this.Cancellation!.Token);
                var model = new NetworkInterface(conn, iface, active);
                models.Add(model);
            }
        }

        this.SetResult(models, true);
    }

    private async Task GetByName(Connection conn, string name)
    {
        var iface = await conn.Client.InterfaceLookupByNameAsync(name, this.Cancellation!.Token);

        var active = await conn.Client.InterfaceIsActiveAsync(iface, this.Cancellation!.Token);

        var model = new NetworkInterface(conn, iface, active);

        this.SetResult(model);
    }
}

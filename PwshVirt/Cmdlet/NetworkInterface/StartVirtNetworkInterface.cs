namespace PwshVirt;

[OutputType(typeof(NetworkInterface))]
[Cmdlet(VerbsLifecycle.Start, VerbsVirt.NetworkInterface)]
public class StartVirtNetworkInterface : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public NetworkInterface? Interface { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.InterfaceCreateAsync(this.Interface!.Self, NotUsed, this.Cancellation!.Token);

        var state = await NetworkInterfaceUtility.WaitForState(conn, this.Interface, NetworkInterfaceState.Running, this.Cancellation!.Token);

        var iface = await conn.Client.InterfaceLookupByNameAsync(this.Interface.Name, this.Cancellation!.Token);

        var model = new NetworkInterface(conn, iface, state);

        this.SetResult(model);
    }
}

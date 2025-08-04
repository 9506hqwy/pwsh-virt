namespace PwshVirt;

[OutputType(typeof(NetworkInterface))]
[Cmdlet(VerbsLifecycle.Stop, VerbsVirt.NetworkInterface)]
public class StopVirtNetworkInterface : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public NetworkInterface? Interface { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.InterfaceDestroyAsync(this.Interface!.Self, NotUsed, this.Cancellation!.Token).ConfigureAwait(false);

        var state = await NetworkInterfaceUtility.WaitForState(conn, this.Interface, NetworkInterfaceState.Inactive, this.Cancellation!.Token).ConfigureAwait(false);

        var iface = await conn.Client.InterfaceLookupByNameAsync(this.Interface.Name, this.Cancellation!.Token).ConfigureAwait(false);

        var model = new NetworkInterface(conn, iface, state);

        this.SetResult(model);
    }
}

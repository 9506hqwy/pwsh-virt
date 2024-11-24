namespace PwshVirt;

[OutputType(typeof(string))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.NetworkInterfaceDescriptor)]
public class GetVirtNetworkInterfaceDescriptor : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public NetworkInterface? Interface { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var xml = await conn.Client.InterfaceGetXmlDescAsync(this.Interface!.Self, 0, this.Cancellation!.Token);

        this.SetResult(xml);
    }
}

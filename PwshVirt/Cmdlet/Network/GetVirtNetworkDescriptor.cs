namespace PwshVirt;

[OutputType(typeof(string))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.NetworkDescriptor)]
public class GetVirtNetworkDescriptor : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Network? Network { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var xml = await conn.Client.NetworkGetXmlDescAsync(this.Network!.Self, 0, this.Cancellation!.Token);

        this.SetResult(xml);
    }
}

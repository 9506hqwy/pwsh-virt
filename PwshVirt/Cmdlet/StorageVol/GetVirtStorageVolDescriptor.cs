namespace PwshVirt;

[OutputType(typeof(string))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.StorageVolDescriptor)]
public class GetVirtStorageVolDescriptor : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    [Parameter]
    public Connection? Server { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public StorageVol? Vol { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var xml = await conn.Client.StorageVolGetXmlDescAsync(this.Vol!.Self, NotUsed, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(xml);
    }
}

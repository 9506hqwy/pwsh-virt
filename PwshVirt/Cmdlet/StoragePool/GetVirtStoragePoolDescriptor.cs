namespace PwshVirt;

[OutputType(typeof(string))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.StoragePoolDescriptor)]
public class GetVirtStoragePoolDescriptor : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public StoragePool? Pool { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var xml = await conn.Client.StoragePoolGetXmlDescAsync(this.Pool!.Self, 0, this.Cancellation!.Token);

        this.SetResult(xml);
    }
}

namespace PwshVirt;

[OutputType(typeof(StorageVol))]
[Cmdlet(VerbsCommon.Clear, VerbsVirt.StorageVol)]
public class ClearVirtStorageVol : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public StorageVol? Vol { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.StorageVolWipeAsync(this.Vol!.Self, NotUsed, this.Cancellation!.Token);

        this.SetResult(this.Vol);
    }
}

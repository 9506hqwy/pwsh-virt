namespace PwshVirt;

[OutputType(typeof(StorageVol))]
[Cmdlet(VerbsData.Import, VerbsVirt.StorageVol)]
public class ImportVirtStorageVol : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public FileInfo? Path { get; set; }

    [Parameter(Mandatory = true)]
    public StorageVol? Destination { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        using (var file = File.Open(this.Path!.FullName, FileMode.Open, FileAccess.Read))
        {
            using var virStream = await conn.Client.StorageVolUploadAsync(this.Destination!.Self, 0, 0, 0, this.Cancellation!.Token);
            await file.CopyToAsync(virStream, 1 * 1024 * 1024, this.Cancellation!.Token);
            await virStream.WriteCompletedAsync(this.Cancellation!.Token);
        }

        this.SetResult(this.Destination);
    }
}

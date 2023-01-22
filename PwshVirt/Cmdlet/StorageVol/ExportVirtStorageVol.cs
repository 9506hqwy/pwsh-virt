namespace PwshVirt;

[OutputType(typeof(FileInfo))]
[Cmdlet(VerbsData.Export, VerbsVirt.StorageVol)]
public class ExportVirtStorageVol : PwshVirtCmdlet
{
    [Parameter(Mandatory = true)]
    public FileInfo? Destination { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public StorageVol? Vol { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        using (var file = File.Open(this.Destination!.FullName, FileMode.Create, FileAccess.Write))
        {
            using var virStream = await conn.Client.StorageVolDownloadAsync(this.Vol!.Self, 0, 0, 0, this.Cancellation!.Token);
            await virStream.CopyToAsync(file, 1 * 1024 * 1024, this.Cancellation!.Token);
            await file.FlushAsync(this.Cancellation!.Token);
        }

        this.SetResult(this.Destination);
    }
}

namespace PwshVirt;

[OutputType(typeof(FileInfo))]
[Cmdlet(VerbsData.Save, VerbsVirt.DomainScreenShot)]
public class SaveVirtDomainScreenShot : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    [Parameter(Mandatory = true)]
    public FileInfo? Destination { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public uint? Screen { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        uint screen = this.Screen ?? 0;
        (var virStream, var _) = await conn.Client.DomainScreenshotAsync(this.Domain!.Self, screen, NotUsed, this.Cancellation!.Token);

        using (virStream)
        {
            using (var file = File.Open(this.Destination!.FullName, FileMode.Create, FileAccess.Write))
            {
                await virStream.CopyToAsync(file, 1 * 1024 * 1024, this.Cancellation!.Token);
                await file.FlushAsync(this.Cancellation!.Token);
            }
        }

        this.SetResult(this.Destination);
    }
}

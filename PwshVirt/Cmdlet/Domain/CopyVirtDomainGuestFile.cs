namespace PwshVirt;

[OutputType(typeof(FileInfo))]
[Cmdlet(VerbsCommon.Copy, VerbsVirt.DomainGuestFile)]
public class CopyVirtDomainGuestFile : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    [Parameter(Mandatory = true)]
    public string? Destination { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public SwitchParameter GuestToLocal { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    [Parameter(Mandatory = true)]
    public string? Source { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var guestToLocal = this.GuestToLocal.IsPresent && this.GuestToLocal.ToBool();

        var guestFile = guestToLocal ? this.Source! : this.Destination!;
        var localFile = guestToLocal ? this.Destination! : this.Source!;
        var mode = guestToLocal ? "r" : "w";

        var handle = await this.OpenFile(conn, guestFile, mode);
        try
        {
            if (guestToLocal)
            {
                await this.CopyToLocal(conn, handle, localFile);
            }
            else
            {
                await this.CopyToGuest(conn, handle, localFile);
            }
        }
        finally
        {
            await this.CloseFile(conn, handle);
        }

        this.SetResult(new FileInfo(localFile));
    }

    private async Task CloseFile(Connection conn, int handle)
    {
        var input = new AgentCommandInput("guest-file-close")
        {
            Arguments = new GuesetFileCloseInput(handle),
        };

        var cmd = input.ToJson();

        _ = await conn.Client.DomainAgentCommandAsync(this.Domain!.Self, cmd, -2, NotUsed, this.Cancellation!.Token);
    }

    private async Task CopyToGuest(Connection conn, int handle, string path)
    {
        using var localFile = File.OpenRead(path);

        var eof = false;
        while (!eof)
        {
            var buffer = new byte[4096];
            var n = await localFile.ReadAsync(buffer, 0, buffer.Length);
            if (n == 0)
            {
                break;
            }

            var output = await this.WriteFile(conn, handle, [.. buffer.Take(n)]);

            eof = output.Eof;
        }

        await this.FlushFile(conn, handle);
    }

    private async Task CopyToLocal(Connection conn, int handle, string path)
    {
        using var localFile = File.OpenWrite(path);

        var eof = false;
        while (!eof)
        {
            var output = await this.ReadFile(conn, handle);

            await localFile.WriteAsync(output.BufBytes, 0, output.Count, this.Cancellation!.Token);

            eof = output.Eof;
        }

        await localFile.FlushAsync();
    }

    private async Task FlushFile(Connection conn, int handle)
    {
        var input = new AgentCommandInput("guest-file-flush")
        {
            Arguments = new GuesetFileFlushInput(handle),
        };

        var cmd = input.ToJson();

        _ = await conn.Client.DomainAgentCommandAsync(this.Domain!.Self, cmd, -2, NotUsed, this.Cancellation!.Token);
    }

    private async Task<int> OpenFile(Connection conn, string path, string mode)
    {
        var input = new AgentCommandInput("guest-file-open")
        {
            Arguments = new GuesetFileOpenInput(path)
            {
                Mode = mode,
            },
        };

        var cmd = input.ToJson();

        var output = await conn.Client.DomainAgentCommandAsync(this.Domain!.Self, cmd, -2, NotUsed, this.Cancellation!.Token);

        var handle = AgentCommandOutput<int>.ConvertFrom(output.Value);

        return handle!.Return;
    }

    private async Task<GuesetFileReadOutput> ReadFile(Connection conn, int handle)
    {
        var input = new AgentCommandInput("guest-file-read")
        {
            Arguments = new GuesetFileReadInput(handle),
        };

        var cmd = input.ToJson();

        var output = await conn.Client.DomainAgentCommandAsync(this.Domain!.Self, cmd, -2, NotUsed, this.Cancellation!.Token);

        var readed = AgentCommandOutput<GuesetFileReadOutput>.ConvertFrom(output.Value);

        return readed!.Return!;
    }

    private async Task<GuesetFileWriteOutput> WriteFile(Connection conn, int handle, byte[] bytes)
    {
        var input = new AgentCommandInput("guest-file-write")
        {
            Arguments = new GuesetFileWriteInput(handle, bytes),
        };

        var cmd = input.ToJson();

        var output = await conn.Client.DomainAgentCommandAsync(this.Domain!.Self, cmd, -2, NotUsed, this.Cancellation!.Token);

        var wrote = AgentCommandOutput<GuesetFileWriteOutput>.ConvertFrom(output.Value);

        return wrote!.Return!;
    }
}

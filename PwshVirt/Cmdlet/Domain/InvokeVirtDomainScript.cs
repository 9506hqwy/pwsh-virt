namespace PwshVirt;

[OutputType(typeof(string))]
[Cmdlet(VerbsLifecycle.Invoke, VerbsVirt.DomainScript)]
public class InvokeVirtDomainScript : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    [Parameter]
    public string[]? Arguments { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter(Mandatory = true)]
    public string? Path { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var pid = await this.InvokeCmd(conn);

        var output = await this.GetResult(conn, pid);

        this.SetResult(output);
    }

    private async Task<string> GetResult(Connection conn, int pid)
    {
        var input = new AgentCommandInput("guest-exec-status")
        {
            Arguments = new GuestExecStatusInput(pid),
        };

        var cmd = input.ToJson();

        var output = await conn.Client.DomainAgentCommandAsync(this.Domain!.Self, cmd, -2, NotUsed, this.Cancellation!.Token);

        var status = AgentCommandOutput<GuestExecStatusOutput>.ConvertFrom(output.Value);

        if (status!.Return!.Exitcode != 0)
        {
            throw new PwshVirtException(status.Return.ErrString!, ErrorCategory.InvalidOperation);
        }

        return status.Return.OutString!;
    }

    private async Task<int> InvokeCmd(Connection conn)
    {
        var input = new AgentCommandInput("guest-exec")
        {
            Arguments = new GuestExecInput(this.Path!)
            {
                Arg = this.Arguments,
                CaptureOutput = true,
            },
        };

        var cmd = input.ToJson();

        var output = await conn.Client.DomainAgentCommandAsync(this.Domain!.Self, cmd, -2, NotUsed, this.Cancellation!.Token);

        var pid = AgentCommandOutput<GuestExecOutput>.ConvertFrom(output.Value);

        return pid!.Return!.Pid!.Value;
    }
}

namespace PwshVirt;

using Newtonsoft.Json;
using System.Text;

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

        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
        };

        var cmd = JsonConvert.SerializeObject(input, settings);

        var output = await conn.Client.DomainAgentCommandAsync(this.Domain!.Self, cmd, -2, NotUsed, this.Cancellation!.Token);

        var status = JsonConvert.DeserializeObject<AgentCommandOutput<GuestExecStatusOutput>>(output.Value);

        if (status!.Return!.Exitcode != 0)
        {
            var errBytes = Convert.FromBase64String(status.Return.ErrData!);
            var err = Encoding.UTF8.GetString(errBytes);
            throw new PwshVirtException(err, ErrorCategory.InvalidOperation);
        }

        var outputBytes = Convert.FromBase64String(status.Return.OutData!);
        return Encoding.UTF8.GetString(outputBytes);
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

        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
        };

        var cmd = JsonConvert.SerializeObject(input, settings);

        var output = await conn.Client.DomainAgentCommandAsync(this.Domain!.Self, cmd, -2, NotUsed, this.Cancellation!.Token);

        var pid = JsonConvert.DeserializeObject<AgentCommandOutput<GuestExecOutput>>(output.Value);

        return pid!.Return!.Pid!.Value;
    }

    private class AgentCommandInput
    {
        internal AgentCommandInput(string execute)
        {
            this.Execute = execute;
        }

        [JsonProperty("execute")]
        public string Execute { get; set; }

        [JsonProperty("arguments")]
        public object? Arguments { get; set; }
    }

    private class AgentCommandOutput<T>
    {
        [JsonProperty("return")]
        public T? Return { get; set; }
    }

    private class GuestExecInput
    {
        internal GuestExecInput(string path)
        {
            this.Path = path;
        }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("arg")]
        public string[]? Arg { get; set; }

        [JsonProperty("input-data")]
        public string? InputData { get; set; }

        [JsonProperty("capture-output")]
        public bool CaptureOutput { get; set; }
    }

    private class GuestExecOutput
    {
        [JsonProperty("pid")]
        public int? Pid { get; set; }
    }

    private class GuestExecStatusInput
    {
        internal GuestExecStatusInput(int pid)
        {
            this.Pid = pid;
        }

        [JsonProperty("pid")]
        public int Pid { get; set; }
    }

    private class GuestExecStatusOutput
    {
        [JsonProperty("exited")]
        public bool Exited { get; set; }

        [JsonProperty("exitcode")]
        public int? Exitcode { get; set; }

        [JsonProperty("signal")]
        public int? Signal { get; set; }

        [JsonProperty("out-data")]
        public string? OutData { get; set; }

        [JsonProperty("err-data")]
        public string? ErrData { get; set; }

        [JsonProperty("out-truncated")]
        public bool? OutTruncated { get; set; }

        [JsonProperty("err-truncated")]
        public bool? ErrTruncated { get; set; }
    }
}

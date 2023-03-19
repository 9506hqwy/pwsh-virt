namespace PwshVirt;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.Set, VerbsVirt.Domain)]
public class SetVirtDomain : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public uint? NumCpu { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        if (this.NumCpu.HasValue)
        {
            await this.SetCpu(conn, this.NumCpu.Value);
        }

        var model = await DomainUtility.GetDomain(conn, this.Domain!.Name, (int)DomainState.Last, 0, this.Cancellation!.Token);

        this.SetResult(model);
    }

    private async Task SetCpu(Connection conn, uint numCpu)
    {
        // change maximum number.
        await conn.Client.DomainSetVcpusFlagsAsync(this.Domain!.Self, numCpu, 0x02 | 0x04, this.Cancellation!.Token);

        // change current number (config).
        await conn.Client.DomainSetVcpusFlagsAsync(this.Domain.Self, numCpu, 0x02, this.Cancellation.Token);

        var isActive = await conn.Client.DomainIsActiveAsync(this.Domain.Self, this.Cancellation.Token);
        if (isActive != 0)
        {
            // change current number (active).
            await conn.Client.DomainSetVcpusFlagsAsync(this.Domain.Self, numCpu, 0x01, this.Cancellation.Token);
        }
    }
}

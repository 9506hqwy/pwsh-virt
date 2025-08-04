namespace PwshVirt;

using static Libvirt.Header.VirDomainMemoryModFlags;
using static Libvirt.Header.VirDomainVcpuFlags;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.Set, VerbsVirt.Domain)]
public class SetVirtDomain : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public string? Memory { get; set; }

    [Parameter]
    public uint? NumCpu { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        if (this.Memory is not null)
        {
            await this.SetMemory(conn, this.GetMemoryKB()).ConfigureAwait(false);
        }

        if (this.NumCpu.HasValue)
        {
            await this.SetCpu(conn, this.NumCpu.Value).ConfigureAwait(false);
        }

        var model = await DomainUtility.GetDomain(conn, this.Domain!.Name, -1, 0, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(model);
    }

    private ulong GetMemoryKB()
    {
        return Utility.GetScaledSizeToBytes(this.Memory!) / 1024;
    }

    private async Task SetCpu(Connection conn, uint numCpu)
    {
        // change maximum number.
        var flags = VirDomainVcpuConfig | VirDomainVcpuMaximum;
        await conn.Client.DomainSetVcpusFlagsAsync(this.Domain!.Self, numCpu, (uint)flags, this.Cancellation!.Token).ConfigureAwait(false);

        // change current number (config).
        await conn.Client.DomainSetVcpusFlagsAsync(this.Domain.Self, numCpu, (uint)VirDomainVcpuConfig, this.Cancellation.Token).ConfigureAwait(false);

        var isActive = await conn.Client.DomainIsActiveAsync(this.Domain.Self, this.Cancellation.Token).ConfigureAwait(false);
        if (isActive != 0)
        {
            // change current number (active).
            await conn.Client.DomainSetVcpusFlagsAsync(this.Domain.Self, numCpu, (uint)VirDomainVcpuLive, this.Cancellation.Token).ConfigureAwait(false);
        }
    }

    private async Task SetMemory(Connection conn, ulong capacityKB)
    {
        // change maximum number.
        var flags = VirDomainMemConfig | VirDomainMemMaximum;
        await conn.Client.DomainSetMemoryFlagsAsync(this.Domain!.Self, capacityKB, (uint)flags, this.Cancellation!.Token).ConfigureAwait(false);

        // change current number (config).
        await conn.Client.DomainSetMemoryFlagsAsync(this.Domain.Self, capacityKB, (uint)VirDomainMemConfig, this.Cancellation.Token).ConfigureAwait(false);

        var isActive = await conn.Client.DomainIsActiveAsync(this.Domain.Self, this.Cancellation.Token).ConfigureAwait(false);
        if (isActive != 0)
        {
            // change current number (active).
            await conn.Client.DomainSetMemoryFlagsAsync(this.Domain.Self, capacityKB, (uint)VirDomainMemLive, this.Cancellation.Token).ConfigureAwait(false);
        }
    }
}

namespace PwshVirt;

using static Libvirt.Header.VirDomainSaveRestoreFlags;
using static Libvirt.Header.VirDomainState;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsLifecycle.Stop, VerbsVirt.Domain, DefaultParameterSetName = KeyPowerOff)]
public class StopVirtDomain : PwshVirtCmdlet
{
    private const string KeyHibernate = "Hibernate";

    private const string KeyPowerOff = "PowerOff";

    private const string KeyShutdown = "Shutdown";

    [Parameter(ParameterSetName = KeyHibernate)]
    public SwitchParameter BypassCache { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyHibernate, ValueFromPipeline = true)]
    [Parameter(Mandatory = true, ParameterSetName = KeyPowerOff, ValueFromPipeline = true)]
    [Parameter(Mandatory = true, ParameterSetName = KeyShutdown, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyHibernate)]
    public SwitchParameter Hibernate { get; set; }

    [Parameter(ParameterSetName = KeyHibernate)]
    public SwitchParameter Paused { get; set; }

    [Parameter(ParameterSetName = KeyHibernate)]
    public SwitchParameter Running { get; set; }

    [Parameter(ParameterSetName = KeyHibernate)]
    [Parameter(ParameterSetName = KeyPowerOff)]
    [Parameter(ParameterSetName = KeyShutdown)]
    public Connection? Server { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyShutdown)]
    public SwitchParameter Shutdown { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        switch (this.ParameterSetName)
        {
            case KeyHibernate:
                await this.Save(conn);
                break;
            case KeyPowerOff:
                await this.Destroy(conn);
                break;
            case KeyShutdown:
                await this.ShutdownGuest(conn);
                break;
            default:
                throw new InvalidProgramException();
        }
    }

    private async Task Destroy(Connection conn)
    {
        await conn.Client.DomainDestroyAsync(this.Domain!.Self, this.Cancellation!.Token);

        (var state, var stateReason) = await DomainUtility.WaitForState(conn, this.Domain, VirDomainShutoff, this.Cancellation!.Token);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, state, stateReason, this.Cancellation!.Token);

        this.SetResult(model);
    }

    private async Task Save(Connection conn)
    {
        uint flags = 0;

        if (this.BypassCache.IsPresent && this.BypassCache.ToBool())
        {
            flags |= (uint)VirDomainSaveBypassCache;
        }

        if (this.Running.IsPresent && this.Running.ToBool())
        {
            flags |= (uint)VirDomainSaveRunning;
        }

        if (this.Paused.IsPresent && this.Paused.ToBool())
        {
            flags |= (uint)VirDomainSavePaused;
        }

        var task = conn.Client.DomainManagedSaveAsync(this.Domain!.Self, flags, this.Cancellation!.Token);

        await this.WaitForTaskCompleted(conn, task, KeyHibernate);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, -1, 0, this.Cancellation!.Token);

        this.SetResult(model);
    }

    private async Task ShutdownGuest(Connection conn)
    {
        await conn.Client.DomainShutdownAsync(this.Domain!.Self, this.Cancellation!.Token);

        (var state, var stateReason) = await DomainUtility.WaitForState(conn, this.Domain, VirDomainShutoff, this.Cancellation!.Token);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, state, stateReason, this.Cancellation!.Token);

        this.SetResult(model);
    }

    private async Task WaitForTaskCompleted(Connection conn, Task task, string taskName)
    {
        this.SetProgress(taskName, 0);

        try
        {
            while (!task.IsCompleted)
            {
                var info = await conn.Client.DomainGetJobInfoAsync(this.Domain!.Self, this.Cancellation!.Token);

                var percentRemain = info.DataTotal == 0 ? 100 : (int)(info.DataRemaining * 100 / info.DataTotal);
                percentRemain =
                    percentRemain < 0 ?
                    0 :
                    percentRemain > 100 ?
                    100 :
                    percentRemain;

                this.SetProgress(taskName, 100 - percentRemain);

                await Task.Delay(500);
            }
        }
        catch (VirtException e) when (e.Error.Code == 55)
        {
            // VIR_ERR_OPERATION_INVALID  = 55
        }

        this.SetProgress(taskName, 100);

        await task;
    }
}

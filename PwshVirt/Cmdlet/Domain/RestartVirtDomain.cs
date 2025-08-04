namespace PwshVirt;

using static Libvirt.Header.VirDomainRebootFlagValues;
using static Libvirt.Header.VirDomainState;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsLifecycle.Restart, VerbsVirt.Domain, DefaultParameterSetName = KeyReset)]
public class RestartVirtDomain : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    private const string KeyReboot = "Reboot";

    private const string KeyReset = "Reset";

    [Parameter(Mandatory = true, ParameterSetName = KeyReboot, ValueFromPipeline = true)]
    [Parameter(Mandatory = true, ParameterSetName = KeyReset, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyReboot)]
    public SwitchParameter Reboot { get; set; }

    [Parameter(ParameterSetName = KeyReboot)]
    [Parameter(ParameterSetName = KeyReset)]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        switch (this.ParameterSetName)
        {
            case KeyReboot:
                await this.RebootGuest(conn).ConfigureAwait(false);
                break;
            case KeyReset:
                await this.Reset(conn).ConfigureAwait(false);
                break;
            default:
                throw new InvalidProgramException();
        }
    }

    private async Task RebootGuest(Connection conn)
    {
        await conn.Client.DomainRebootAsync(this.Domain!.Self, (uint)VirDomainRebootDefault, this.Cancellation!.Token).ConfigureAwait(false);

        (var state, var stateReason) = await DomainUtility.WaitForState(conn, this.Domain, VirDomainRunning, this.Cancellation!.Token).ConfigureAwait(false);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, state, stateReason, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(model);
    }

    private async Task Reset(Connection conn)
    {
        await conn.Client.DomainResetAsync(this.Domain!.Self, NotUsed, this.Cancellation!.Token).ConfigureAwait(false);

        (var state, var stateReason) = await DomainUtility.WaitForState(conn, this.Domain, VirDomainRunning, this.Cancellation!.Token).ConfigureAwait(false);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, state, stateReason, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(model);
    }
}

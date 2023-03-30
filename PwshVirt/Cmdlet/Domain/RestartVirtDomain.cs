namespace PwshVirt;

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

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        switch (this.ParameterSetName)
        {
            case KeyReboot:
                await this.RebootGuest(conn);
                break;
            case KeyReset:
                await this.Reset(conn);
                break;
            default:
                throw new InvalidProgramException();
        }
    }

    private async Task RebootGuest(Connection conn)
    {
        await conn.Client.DomainRebootAsync(this.Domain!.Self, 0x00, this.Cancellation!.Token);

        (var state, var stateReason) = await DomainUtility.WaitForState(conn, this.Domain, DomainState.Running, this.Cancellation!.Token);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, state, stateReason, this.Cancellation!.Token);

        this.SetResult(model);
    }

    private async Task Reset(Connection conn)
    {
        await conn.Client.DomainResetAsync(this.Domain!.Self, NotUsed, this.Cancellation!.Token);

        (var state, var stateReason) = await DomainUtility.WaitForState(conn, this.Domain, DomainState.Running, this.Cancellation!.Token);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, state, stateReason, this.Cancellation!.Token);

        this.SetResult(model);
    }
}

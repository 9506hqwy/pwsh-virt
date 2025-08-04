namespace PwshVirt;

using static Libvirt.Header.VirDomainState;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsLifecycle.Resume, VerbsVirt.Domain)]
public class ResumeVirtDomain : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.DomainResumeAsync(this.Domain!.Self, this.Cancellation!.Token).ConfigureAwait(false);

        (var state, var stateReason) = await DomainUtility.WaitForState(conn, this.Domain, VirDomainRunning, this.Cancellation!.Token).ConfigureAwait(false);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, state, stateReason, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(model);
    }
}

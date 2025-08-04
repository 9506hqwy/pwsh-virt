namespace PwshVirt;

using static Libvirt.Header.VirDomainState;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsLifecycle.Suspend, VerbsVirt.Domain)]
public class SuspendVirtDomain : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.DomainSuspendAsync(this.Domain!.Self, this.Cancellation!.Token).ConfigureAwait(false);

        (var state, var stateReason) = await DomainUtility.WaitForState(conn, this.Domain, VirDomainPaused, this.Cancellation!.Token).ConfigureAwait(false);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, state, stateReason, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(model);
    }
}

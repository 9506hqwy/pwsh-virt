namespace PwshVirt;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsLifecycle.Resume, VerbsVirt.Domain)]
public class ResumeVirtDomain : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.DomainResumeAsync(this.Domain!.Self, this.Cancellation!.Token);

        var state = await DomainUtility.WaitForState(conn, this.Domain, DomainState.Running, this.Cancellation!.Token);

        var dom = await conn.Client.DomainLookupByNameAsync(this.Domain.Name, this.Cancellation!.Token);

        var model = new Domain(conn, dom, (int)state);

        this.SetResult(model);
    }
}

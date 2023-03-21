namespace PwshVirt;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.Domain, DefaultParameterSetName = KeyAll)]
public class GetVirtDomain : PwshVirtCmdlet
{
    private const string KeyAll = "All";

    private const string KeyName = "Name";

    [Parameter(Mandatory = true, ParameterSetName = KeyName)]
    public string? Name { get; set; }

    [Parameter(ParameterSetName = KeyAll)]
    [Parameter(ParameterSetName = KeyName)]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        switch (this.ParameterSetName)
        {
            case KeyAll:
                await this.GetAll(conn);
                break;
            case KeyName:
                await this.GetByName(conn, this.Name!);
                break;
            default:
                throw new InvalidProgramException();
        }
    }

    private async Task GetAll(Connection conn)
    {
        (var doms, var num) = await conn.Client.ConnectListAllDomainsAsync(1, 1 | 2, this.Cancellation!.Token);

        var models = new List<Domain>();

        if (num != 0)
        {
            foreach (var dom in doms)
            {
                var model = await DomainUtility.GetDomain(conn, dom.Name, (int)DomainState.Last, 0, this.Cancellation!.Token);
                models.Add(model);
            }
        }

        this.SetResult(models, true);
    }

    private async Task GetByName(Connection conn, string name)
    {
        var model = await DomainUtility.GetDomain(conn, name, (int)DomainState.Last, 0, this.Cancellation!.Token);

        this.SetResult(model);
    }
}

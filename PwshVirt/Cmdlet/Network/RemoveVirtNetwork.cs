namespace PwshVirt;

[OutputType(typeof(Network))]
[Cmdlet(VerbsCommon.Remove, VerbsVirt.Network)]
public class RemoveVirtNetwork : PwshVirtCmdlet
{
    [Parameter(ValueFromPipeline = true)]
    public Network? Network { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.NetworkUndefineAsync(this.Network!.Self, this.Cancellation!.Token);

        this.SetResult(this.Network);
    }
}

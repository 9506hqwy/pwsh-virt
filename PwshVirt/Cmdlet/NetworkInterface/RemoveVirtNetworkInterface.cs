namespace PwshVirt;

[OutputType(typeof(NetworkInterface))]
[Cmdlet(VerbsCommon.Remove, VerbsVirt.NetworkInterface)]
public class RemoveVirtNetworkInterface : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public NetworkInterface? Interface { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.InterfaceUndefineAsync(this.Interface!.Self, this.Cancellation!.Token);

        this.SetResult(this.Interface);
    }
}

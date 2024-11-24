namespace PwshVirt;

[OutputType(typeof(StoragePool))]
[Cmdlet(VerbsCommon.Remove, VerbsVirt.StoragePool)]
public class RemoveVirtStoragePool : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public StoragePool? Pool { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.StoragePoolUndefineAsync(this.Pool!.Self, this.Cancellation!.Token);

        this.SetResult(this.Pool);
    }
}

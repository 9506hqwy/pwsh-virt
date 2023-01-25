namespace PwshVirt;

[OutputType(typeof(StoragePool))]
[Cmdlet(VerbsLifecycle.Stop, VerbsVirt.StoragePool)]
public class StopVirtStoragePool : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public StoragePool? Pool { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        await conn.Client.StoragePoolDestroyAsync(this.Pool!.Self, this.Cancellation!.Token);

        var state = await StoragePoolUtility.WaitForState(conn, this.Pool, StoragePoolState.Inactive, this.Cancellation!.Token);

        var pool = await conn.Client.StoragePoolLookupByNameAsync(this.Pool.Name, this.Cancellation!.Token);

        var model = new StoragePool(conn, pool, state);

        this.SetResult(model);
    }
}

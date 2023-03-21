namespace PwshVirt;

[OutputType(typeof(StorageVol))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.StorageVol, DefaultParameterSetName = KeyPool)]
public class GetVirtStorageVol : PwshVirtCmdlet
{
    private const string KeyKey = "Key";

    private const string KeyPool = "Pool";

    private const uint NotUsed = 0;

    [Parameter(Mandatory = true, ParameterSetName = KeyKey)]
    public string? Key { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyPool, ValueFromPipeline = true)]
    public StoragePool? Pool { get; set; }

    [Parameter(ParameterSetName = KeyKey)]
    [Parameter(ParameterSetName = KeyPool)]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        switch (this.ParameterSetName)
        {
            case KeyKey:
                await this.GetByKey(conn, this.Key!);
                break;
            case KeyPool:
                await this.GetByPool(conn, this.Pool!);
                break;
            default:
                throw new InvalidProgramException();
        }
    }

    private async Task GetByKey(Connection conn, string key)
    {
        var vol = await conn.Client.StorageVolLookupByKeyAsync(key, this.Cancellation!.Token);

        (var type, var _, var _) = await conn.Client.StorageVolGetInfoAsync(vol, this.Cancellation!.Token);

        var model = new StorageVol(conn, vol, type);

        this.SetResult(model);
    }

    private async Task GetByPool(Connection conn, StoragePool pool)
    {
        (var vols, var num) = await conn.Client.StoragePoolListAllVolumesAsync(pool.Self, 1, NotUsed, this.Cancellation!.Token);

        var models = new List<StorageVol>();

        if (num != 0)
        {
            foreach (var vol in vols)
            {
                (var type, var _, var _) = await conn.Client.StorageVolGetInfoAsync(vol, this.Cancellation!.Token);
                var model = new StorageVol(conn, vol, type);
                models.Add(model);
            }
        }

        this.SetResult(models, true);
    }
}

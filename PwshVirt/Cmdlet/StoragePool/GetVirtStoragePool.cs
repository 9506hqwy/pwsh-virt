namespace PwshVirt;

[OutputType(typeof(StoragePool))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.StoragePool, DefaultParameterSetName = KeyAll)]
public class GetVirtStoragePool : PwshVirtCmdlet
{
    private const string KeyAll = "All";

    private const string KeyName = "Name";

    [Parameter(ParameterSetName = KeyName)]
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
        (var pools, var num) = await conn.Client.ConnectListAllStoragePoolsAsync(1, 1 | 2, this.Cancellation!.Token);

        var models = new List<StoragePool>();

        if (num != 0)
        {
            foreach (var pool in pools)
            {
                (var state, var _, var _, var _) = await conn.Client.StoragePoolGetInfoAsync(pool, this.Cancellation!.Token);
                var model = new StoragePool(conn, pool, state);
                models.Add(model);
            }
        }

        this.SetResult(models, true);
    }

    private async Task GetByName(Connection conn, string name)
    {
        var pool = await conn.Client.StoragePoolLookupByNameAsync(name, this.Cancellation!.Token);

        (var state, var _, var _, var _) = await conn.Client.StoragePoolGetInfoAsync(pool, this.Cancellation!.Token);

        var model = new StoragePool(conn, pool, state);

        this.SetResult(model);
    }
}

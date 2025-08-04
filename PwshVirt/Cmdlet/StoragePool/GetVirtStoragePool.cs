namespace PwshVirt;

using static Libvirt.Header.VirConnectListAllStoragePoolsFlags;

[OutputType(typeof(StoragePool))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.StoragePool, DefaultParameterSetName = KeyAll)]
public class GetVirtStoragePool : PwshVirtCmdlet
{
    private const string KeyAll = "All";

    private const string KeyName = "Name";

    private const string KeyVol = "Vol";

    [Parameter(Mandatory = true, ParameterSetName = KeyName)]
    public string? Name { get; set; }

    [Parameter(ParameterSetName = KeyAll)]
    [Parameter(ParameterSetName = KeyName)]
    [Parameter(ParameterSetName = KeyVol)]
    public Connection? Server { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyVol)]
    public StorageVol? Vol { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        switch (this.ParameterSetName)
        {
            case KeyAll:
                await this.GetAll(conn).ConfigureAwait(false);
                break;
            case KeyName:
                await this.GetByName(conn, this.Name!).ConfigureAwait(false);
                break;
            case KeyVol:
                await this.GetByVolume(conn, this.Vol!).ConfigureAwait(false);
                break;
            default:
                throw new InvalidProgramException();
        }
    }

    private async Task GetAll(Connection conn)
    {
        var flags = VirConnectListStoragePoolsInactive | VirConnectListStoragePoolsActive;
        (var pools, var num) = await conn.Client.ConnectListAllStoragePoolsAsync(1, (uint)flags, this.Cancellation!.Token).ConfigureAwait(false);

        var models = new List<StoragePool>();

        if (num != 0)
        {
            foreach (var pool in pools)
            {
                var model = await StoragePoolUtility.GetPool(conn, pool, this.Cancellation!.Token).ConfigureAwait(false);
                models.Add(model);
            }
        }

        this.SetResult(models, true);
    }

    private async Task GetByName(Connection conn, string name)
    {
        var pool = await conn.Client.StoragePoolLookupByNameAsync(name, this.Cancellation!.Token).ConfigureAwait(false);

        var model = await StoragePoolUtility.GetPool(conn, pool, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(model);
    }

    private async Task GetByVolume(Connection conn, StorageVol volume)
    {
        var pool = await conn.Client.StoragePoolLookupByVolumeAsync(volume.Self, this.Cancellation!.Token).ConfigureAwait(false);

        var model = await StoragePoolUtility.GetPool(conn, pool, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(model);
    }
}

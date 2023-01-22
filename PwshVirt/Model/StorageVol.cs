namespace PwshVirt;

public class StorageVol : VirtObject
{
    private readonly byte type;

    internal StorageVol(
        Connection conn,
        RemoteNonnullStorageVol vol,
        byte type)
        : base(conn)
    {
        this.Self = vol;
        this.type = type;
    }

    public string Key => this.Self.Key;

    public string Name => this.Self.Name;

    public string Pool => this.Self.Pool;

    public StorageVolType Type => (StorageVolType)Enum.ToObject(typeof(StorageVolType), this.type);

    internal RemoteNonnullStorageVol Self { get; }
}

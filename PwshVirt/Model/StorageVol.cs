namespace PwshVirt;

using Libvirt.Header;

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

    public VirStorageVolType Type => (VirStorageVolType)Enum.ToObject(typeof(VirStorageVolType), this.type);

    internal RemoteNonnullStorageVol Self { get; }
}

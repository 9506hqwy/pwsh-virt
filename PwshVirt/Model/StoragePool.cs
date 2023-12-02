namespace PwshVirt;

using Libvirt.Header;

public class StoragePool : VirtObject
{
    private readonly uint state;

    internal StoragePool(
        Connection conn,
        RemoteNonnullStoragePool pool,
        uint state)
        : base(conn)
    {
        this.Self = pool;
        this.state = state;
    }

    public string Name => this.Self.Name;

    public VirStoragePoolState Status => (VirStoragePoolState)Enum.ToObject(typeof(VirStoragePoolState), this.state);

    public Guid Uuid => new Guid(this.Self.Uuid);

    internal RemoteNonnullStoragePool Self { get; }
}

namespace PwshVirt;

public class Network : VirtObject
{
    private readonly int active;

    private readonly int persistent;

    internal Network(
        Connection conn,
        RemoteNonnullNetwork net,
        int active,
        int persistent)
        : base(conn)
    {
        this.Self = net;
        this.active = active;
        this.persistent = persistent;
    }

    public bool IsActive => this.active != 0;

    public bool IsPersistent => this.persistent != 0;

    public string Name => this.Self.Name;

    public Guid Uuid => new(this.Self.Uuid);

    internal RemoteNonnullNetwork Self { get; }
}

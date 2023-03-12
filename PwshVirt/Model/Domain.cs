namespace PwshVirt;

public class Domain : VirtObject
{
    private readonly int state;

    internal Domain(
        Connection conn,
        RemoteNonnullDomain dom,
        int state,
        bool hasManagedSave)
        : base(conn)
    {
        this.Self = dom;
        this.state = state;
        this.HasManagedSave = hasManagedSave;
    }

    public int? Id => this.Self.Id > 0 ? this.Self.Id : null;

    public bool HasManagedSave { get; }

    public string Name => this.Self.Name;

    public DomainState Status => (DomainState)Enum.ToObject(typeof(DomainState), this.state);

    public Guid Uuid => new (this.Self.Uuid);

    internal RemoteNonnullDomain Self { get; }
}

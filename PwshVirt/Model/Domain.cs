namespace PwshVirt;

using Libvirt.Header;

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

    public VirDomainState Status => (VirDomainState)Enum.ToObject(typeof(VirDomainState), this.state);

    public Guid Uuid => new(this.Self.Uuid);

    internal RemoteNonnullDomain Self { get; }
}

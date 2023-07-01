namespace PwshVirt;

public class CdDrive : VirtObject
{
    internal CdDrive(
        Connection conn,
        RemoteNonnullDomain dom,
        Libvirt.Model.DomainDisk drive)
        : base(conn)
    {
        this.Domain = dom;
        this.Self = drive;
    }

    public string TargetDev => this.Self.Target.Dev;

    internal RemoteNonnullDomain Domain { get; }

    internal Libvirt.Model.DomainDisk Self { get; }
}

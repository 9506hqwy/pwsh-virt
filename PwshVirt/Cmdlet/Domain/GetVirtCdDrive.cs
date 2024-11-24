namespace PwshVirt;

using static Libvirt.Header.VirDomainXmlflags;

[OutputType(typeof(CdDrive))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.CdDrive)]
public class GetVirtCdDrive : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var xml = await conn.Client.DomainGetXmlDescAsync(this.Domain!.Self, (uint)VirDomainXmlInactive, this.Cancellation!.Token);

        var model = Serializer.Deserialize<Libvirt.Model.Domain>(xml);

        var drives = model
            .Devices?
            .Disk?
            .Where(d => d.Device == Libvirt.Model.DomainDiskDevice.Cdrom)
            .Select(d => new CdDrive(conn, this.Domain.Self, d))
            .ToArray();

        if (drives is not null)
        {
            this.SetResult(drives, true);
        }
    }
}

namespace PwshVirt;

using Libvirt.Model;
using static Libvirt.Header.VirDomainXmlflags;

[OutputType(typeof(CdDrive))]
[Cmdlet(VerbsCommon.New, VerbsVirt.CdDrive)]
public class NewVirtCdDrive : PwshVirtCmdlet
{
    [Parameter(Mandatory = true)]
    public string? DeviceFile { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var drive = new DomainDisk
        {
            Type = DomainDiskType.File,
            TypeSpecified = true,
            Device = DomainDiskDevice.Cdrom,
            DeviceSpecified = true,

            Target = new DomainDiskTarget
            {
                Dev = this.DeviceFile,

                Bus = DomainDiskTargetBus.Sata,
                BusSpecified = true,
            },

            Readonly = new DomainDiskReadonly(),
        };

        var xml = Serializer.Serialize(drive);

        await DomainUtility.AttachDevice(conn, this.Domain!, xml, this.Cancellation!.Token);

        var model = await DomainUtility.GetDomain(conn, this.Domain!.Name, -1, 0, this.Cancellation.Token);

        var domainXml = await conn.Client.DomainGetXmlDescAsync(this.Domain.Self, (uint)VirDomainXmlInactive, this.Cancellation.Token);

        var domainModel = Serializer.Deserialize<Libvirt.Model.Domain>(domainXml);

        var newDrive = domainModel.Devices.Disk.FirstOrDefault(d => d.Target.Dev == this.DeviceFile);
        var newModel = new CdDrive(conn, this.Domain.Self, newDrive);

        this.SetResult(newModel);
    }
}

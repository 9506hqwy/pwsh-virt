namespace PwshVirt;

using static Libvirt.Header.VirDomainXmlflags;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.Set, VerbsVirt.CdDrive, DefaultParameterSetName = KeyInsert)]
public class SetVirtCdDrive : PwshVirtCmdlet
{
    private const string KeyEject = "Eject";

    private const string KeyInsert = "Insert";

    [Parameter(Mandatory = true, ParameterSetName = KeyEject, ValueFromPipeline = true)]
    [Parameter(Mandatory = true, ParameterSetName = KeyInsert, ValueFromPipeline = true)]
    public CdDrive? Drive { get; set; }

    [Parameter(ParameterSetName = KeyEject)]
    public SwitchParameter Eject { get; set; }

    [Parameter(ParameterSetName = KeyInsert)]
    public string? IsoPath { get; set; }

    [Parameter(ParameterSetName = KeyEject)]
    [Parameter(ParameterSetName = KeyInsert)]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var xml = await conn.Client.DomainGetXmlDescAsync(this.Drive!.Domain, (uint)VirDomainXmlInactive, this.Cancellation!.Token);

        var model = Serializer.Deserialize<Libvirt.Model.Domain>(xml);

        var drive = (model
            .Devices?
            .Disk?
            .Where(d => d.Device == Libvirt.Model.DomainDiskDevice.Cdrom)
            .FirstOrDefault(d => d.Target.Dev == this.Drive.TargetDev)) ?? throw new PwshVirtException(
                string.Format(Resource.ERR_NotFoundDomainDevice, this.Drive.TargetDev),
                ErrorCategory.InvalidOperation);
        switch (this.ParameterSetName)
        {
            case KeyEject:
                if (drive.Source is not null)
                {
                    drive.Source.File = null;
                }

                break;

            case KeyInsert:
                drive.Source ??= new Libvirt.Model.DomainDiskSource();
                drive.Source.File = this.IsoPath;
                break;

            default:
                throw new InvalidProgramException();
        }

        var newXml = Serializer.Serialize(drive);

        var domain = new Domain(conn, this.Drive.Domain, 0, false);
        await DomainUtility.UpdateDevice(conn, domain, newXml, this.Cancellation.Token);

        var newModel = await DomainUtility.GetDomain(conn, this.Drive.Domain.Name, -1, 0, this.Cancellation.Token);

        this.SetResult(newModel);
    }
}

namespace PwshVirt;

using Libvirt.Header;
using static Libvirt.Header.VirDomainDeviceModifyFlags;
using static Libvirt.Header.VirDomainXmlflags;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.Remove, VerbsVirt.HardDisk)]
public class RemoveVirtHardDisk : PwshVirtCmdlet
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

        // config
        await this.RemoveDisk(conn, VirDomainDeviceModifyConfig, this.DeviceFile!);

        var isActive = await conn.Client.DomainIsActiveAsync(this.Domain!.Self, this.Cancellation!.Token);
        if (isActive != 0)
        {
            // active
            await this.RemoveDisk(conn, VirDomainDeviceModifyLive, this.DeviceFile!);
        }

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, -1, 0, this.Cancellation!.Token);

        this.SetResult(model);
    }

    private async Task<Libvirt.Model.Domain> GetDomainModel(Connection conn, VirDomainDeviceModifyFlags flags)
    {
        uint xflags = (flags == VirDomainDeviceModifyLive) ? 0 : (uint)VirDomainXmlInactive;

        var xml = await conn.Client.DomainGetXmlDescAsync(this.Domain!.Self, xflags, this.Cancellation!.Token);
        return Serializer.Deserialize<Libvirt.Model.Domain>(xml);
    }

    private async Task RemoveDisk(Connection conn, VirDomainDeviceModifyFlags flags, string targetDev)
    {
        var dom = await this.GetDomainModel(conn, flags);

        var disk = dom.Devices.Disk.FirstOrDefault(i => i.Target.Dev == targetDev);
        if (disk is null)
        {
            return;
        }

        var xml = Serializer.Serialize(disk);

        await conn.Client.DomainDetachDeviceFlagsAsync(this.Domain!.Self, xml, (uint)flags, this.Cancellation!.Token);
    }
}

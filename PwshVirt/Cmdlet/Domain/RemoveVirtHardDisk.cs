namespace PwshVirt;

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

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        // config
        await this.RemoveDisk(conn, 0x02, this.DeviceFile!);

        var isActive = await conn.Client.DomainIsActiveAsync(this.Domain!.Self, this.Cancellation!.Token);
        if (isActive != 0)
        {
            // active
            await this.RemoveDisk(conn, 0x01, this.DeviceFile!);
        }

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, (int)DomainState.Last, 0, this.Cancellation!.Token);

        this.SetResult(model);
    }

    private async Task<Libvirt.Model.Domain> GetDomainModel(Connection conn, uint flags)
    {
        flags = (flags == 0x01) ? 0 : flags;

        var xml = await conn.Client.DomainGetXmlDescAsync(this.Domain!.Self, flags, this.Cancellation!.Token);
        return Serializer.Deserialize<Libvirt.Model.Domain>(xml);
    }

    private async Task RemoveDisk(Connection conn, uint flags, string targetDev)
    {
        var dom = await this.GetDomainModel(conn, flags);

        var disk = dom.Devices.Disk.FirstOrDefault(i => i.Target.Dev == targetDev);
        if (disk is null)
        {
            return;
        }

        var xml = Serializer.Serialize(disk);

        await conn.Client.DomainDetachDeviceFlagsAsync(this.Domain!.Self, xml, flags, this.Cancellation!.Token);
    }
}

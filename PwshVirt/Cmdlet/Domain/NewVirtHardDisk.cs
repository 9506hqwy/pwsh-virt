namespace PwshVirt;

using Libvirt.Model;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.New, VerbsVirt.HardDisk)]
public class NewVirtHardDisk : PwshVirtCmdlet
{
    [Parameter(Mandatory = true)]
    public string? DeviceFile { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public string? Driver { get; set; }

    [Parameter]
    public DomainDevicesDiskDiskDriverType? DriverType { get; set; }

    [Parameter(Mandatory = true)]
    public StorageVol? Vol { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var disk = new DomainDevicesDisk
        {
            Type = DomainDevicesDiskType.File,
            Device = DomainDevicesDiskDevice.Disk,
            Source = new DomainDevicesDiskSource
            {
                File = this.Vol!.Key,
            },
            Target = new DomainDevicesDiskDiskTarget
            {
                Dev = this.DeviceFile,
            },
        };

        if (this.Driver is not null)
        {
            disk.Driver ??= new DomainDevicesDiskDiskDriver();
            disk.Driver.Name = this.Driver;
        }

        if (this.DriverType.HasValue)
        {
            disk.Driver ??= new DomainDevicesDiskDiskDriver();
            disk.Driver.Type = this.DriverType.Value;
            disk.Driver.TypeSpecified = true;
        }

        var xml = Serializer.Serialize(disk);

        await DomainUtility.AttachDevice(conn, this.Domain!, xml, this.Cancellation!.Token);

        var model = await DomainUtility.GetDomain(conn, this.Domain!.Name, (int)DomainState.Last, 0, this.Cancellation!.Token);

        this.SetResult(model);
    }
}

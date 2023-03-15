namespace PwshVirt;

using Libvirt.Model;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.New, VerbsVirt.HardDisk)]
public class NewVirtHardDisk : PwshVirtCmdlet
{
    [Parameter]
    public SwitchParameter Config { get; set; }

    [Parameter(Mandatory = true)]
    public string? DeviceFile { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public string? Driver { get; set; }

    [Parameter]
    public DriverFormat? DriverType { get; set; }

    [Parameter(Mandatory = true)]
    public StorageVol? Vol { get; set; }

    [Parameter]
    public SwitchParameter Live { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var disk = new DomainDisk
        {
            Type = "file",
            Device = "disk",
            Source = new DomainDiskSourceNetworkProtocolHttps
            {
                File = this.Vol!.Key,
            },
            Target = new DomainDiskTarget
            {
                Dev = this.DeviceFile,
            },
        };

        if (this.Driver is not null)
        {
            disk.Driver ??= new DomainDiskDriver();
            disk.Driver.Name = this.Driver;
        }

        if (this.DriverType.HasValue)
        {
            disk.Driver ??= new DomainDiskDriver();
            disk.Driver.Type = this.DriverType.Value;
            disk.Driver.TypeSpecified = true;
        }

        uint flags = 0;

        if (this.Live.IsPresent && this.Live.ToBool())
        {
            flags |= 0x01;
        }

        if (this.Config.IsPresent && this.Config.ToBool())
        {
            flags |= 0x02;
        }

        var xml = Serializer.Serialize(disk);

        await conn.Client.DomainAttachDeviceFlagsAsync(this.Domain!.Self, xml, flags, this.Cancellation!.Token);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, (int)DomainState.Last, 0, this.Cancellation!.Token);

        this.SetResult(model);
    }
}

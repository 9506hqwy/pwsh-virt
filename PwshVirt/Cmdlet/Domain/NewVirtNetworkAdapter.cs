namespace PwshVirt;

using Libvirt.Model;
using System.Net.NetworkInformation;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.New, VerbsVirt.NetworkAdapter)]
public class NewVirtNetworkAdapter : PwshVirtCmdlet
{
    [Parameter]
    public SwitchParameter Config { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public SwitchParameter Live { get; set; }

    [Parameter]
    public PhysicalAddress? MacAddress { get; set; }

    [Parameter]
    public string? Model { get; set; }

    [Parameter(Mandatory = true)]
    public string? NetworkName { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    [Parameter(Mandatory = true)]
    public NetworkAdapterType? Type { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var adapter = new DomainInterface
        {
            Type = this.Type.ToString().ToLowerInvariant(),
            Source = new DomainInterfaceSource(),
        };

        switch (this.Type)
        {
            case NetworkAdapterType.Network:
                adapter.Source.Network = this.NetworkName;
                break;
            case NetworkAdapterType.Bridge:
                adapter.Source.Bridge = this.NetworkName;
                break;
            default:
                throw new InvalidProgramException();
        }

        if (this.MacAddress is not null)
        {
            var macHexBytes = this.MacAddress.GetAddressBytes().Select(b => b.ToString("X2"));
            adapter.Mac = new DomainInterfaceOptionsMac
            {
                Address = string.Join(":", macHexBytes),
            };
        }

        if (this.Model is not null)
        {
            adapter.Model = new DomainInterfaceOptionsModel
            {
                Type = this.Model,
            };
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

        var xml = Serializer.Serialize(adapter);

        await conn.Client.DomainAttachDeviceFlagsAsync(this.Domain!.Self, xml, flags, this.Cancellation!.Token);

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, (int)DomainState.Last, 0, this.Cancellation!.Token);

        this.SetResult(model);
    }
}

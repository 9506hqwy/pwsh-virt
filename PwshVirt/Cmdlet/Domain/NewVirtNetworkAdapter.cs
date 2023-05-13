namespace PwshVirt;

using Libvirt.Model;
using System.Net.NetworkInformation;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.New, VerbsVirt.NetworkAdapter, DefaultParameterSetName = KeyNetwork)]
public class NewVirtNetworkAdapter : PwshVirtCmdlet
{
    private const string KeyBridge = "Bridge";

    private const string KeyNetwork = "Network";

    [Parameter(Mandatory = true, ParameterSetName = KeyBridge)]
    public string? BridgeName { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyBridge, ValueFromPipeline = true)]
    [Parameter(Mandatory = true, ParameterSetName = KeyNetwork, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter(ParameterSetName = KeyBridge)]
    [Parameter(ParameterSetName = KeyNetwork)]
    public PhysicalAddress? MacAddress { get; set; }

    [Parameter(ParameterSetName = KeyBridge)]
    [Parameter(ParameterSetName = KeyNetwork)]
    public string? Model { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyNetwork)]
    public string? NetworkName { get; set; }

    [Parameter(ParameterSetName = KeyBridge)]
    [Parameter(ParameterSetName = KeyNetwork)]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var adapter = new DomainInterface
        {
            Source = new DomainInterfaceSource(),
        };

        switch (this.ParameterSetName)
        {
            case KeyBridge:
                adapter.Type = DomainInterfaceType.Bridge;
                adapter.Source.Bridge = this.BridgeName;
                break;
            case KeyNetwork:
                adapter.Type = DomainInterfaceType.Network;
                adapter.Source.Network = this.NetworkName;
                break;
            default:
                throw new InvalidProgramException();
        }

        if (this.MacAddress is not null)
        {
            var macHexBytes = this.MacAddress.GetAddressBytes().Select(b => b.ToString("X2"));
            adapter.Mac = new DomainInterfaceMac
            {
                Address = string.Join(":", macHexBytes),
            };
        }

        if (this.Model is not null)
        {
            adapter.Model = new DomainInterfaceModel
            {
                Type = this.Model,
            };
        }

        var xml = Serializer.Serialize(adapter);

        await DomainUtility.AttachDevice(conn, this.Domain!, xml, this.Cancellation!.Token);

        var model = await DomainUtility.GetDomain(conn, this.Domain!.Name, (int)DomainState.Last, 0, this.Cancellation!.Token);

        this.SetResult(model);
    }
}

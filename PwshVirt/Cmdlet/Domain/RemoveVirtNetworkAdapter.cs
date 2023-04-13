namespace PwshVirt;

using System.Net.NetworkInformation;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.Remove, VerbsVirt.NetworkAdapter)]
public class RemoveVirtNetworkAdapter : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter(Mandatory = true)]
    public PhysicalAddress? MacAddress { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var macHexBytes = this.MacAddress!.GetAddressBytes().Select(b => b.ToString("X2"));
        var macAddress = string.Join(":", macHexBytes).ToLowerInvariant();

        // config
        await this.RemoveInterface(conn, 0x02, macAddress);

        var isActive = await conn.Client.DomainIsActiveAsync(this.Domain!.Self, this.Cancellation!.Token);
        if (isActive != 0)
        {
            // active
            await this.RemoveInterface(conn, 0x01, macAddress);
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

    private async Task RemoveInterface(Connection conn, uint flags, string macAddress)
    {
        var dom = await this.GetDomainModel(conn, flags);

        var adapter = dom.Devices.Interface.FirstOrDefault(i => i.Mac.Address.ToLowerInvariant() == macAddress);
        if (adapter is null)
        {
            return;
        }

        var xml = Serializer.Serialize(adapter);

        await conn.Client.DomainDetachDeviceFlagsAsync(this.Domain!.Self, xml, flags, this.Cancellation!.Token);
    }
}

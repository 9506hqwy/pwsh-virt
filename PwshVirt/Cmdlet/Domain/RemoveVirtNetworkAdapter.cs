namespace PwshVirt;

using Libvirt.Header;
using System.Globalization;
using System.Net.NetworkInformation;
using static Libvirt.Header.VirDomainDeviceModifyFlags;
using static Libvirt.Header.VirDomainXmlflags;

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

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var macHexBytes = this.MacAddress!.GetAddressBytes().Select(b => b.ToString("X2", CultureInfo.InvariantCulture));
        var macAddress = string.Join(":", macHexBytes).ToLowerInvariant();

        // config
        await this.RemoveInterface(conn, VirDomainDeviceModifyConfig, macAddress).ConfigureAwait(false);

        var isActive = await conn.Client.DomainIsActiveAsync(this.Domain!.Self, this.Cancellation!.Token).ConfigureAwait(false);
        if (isActive != 0)
        {
            // active
            await this.RemoveInterface(conn, VirDomainDeviceModifyLive, macAddress).ConfigureAwait(false);
        }

        var model = await DomainUtility.GetDomain(conn, this.Domain.Name, -1, 0, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(model);
    }

    private async Task<Libvirt.Model.Domain> GetDomainModel(Connection conn, VirDomainDeviceModifyFlags flags)
    {
        uint xflags = (flags == VirDomainDeviceModifyLive) ? 0 : (uint)VirDomainXmlInactive;

        var xml = await conn.Client.DomainGetXmlDescAsync(this.Domain!.Self, xflags, this.Cancellation!.Token).ConfigureAwait(false);
        return Serializer.Deserialize<Libvirt.Model.Domain>(xml);
    }

    private async Task RemoveInterface(Connection conn, VirDomainDeviceModifyFlags flags, string macAddress)
    {
        var dom = await this.GetDomainModel(conn, flags).ConfigureAwait(false);

        var adapter = dom.Devices.Interface.FirstOrDefault(i => string.Equals(i.Mac.Address, macAddress, StringComparison.OrdinalIgnoreCase));
        if (adapter is null)
        {
            return;
        }

        var xml = Serializer.Serialize(adapter);

        await conn.Client.DomainDetachDeviceFlagsAsync(this.Domain!.Self, xml, (uint)flags, this.Cancellation!.Token).ConfigureAwait(false);
    }
}

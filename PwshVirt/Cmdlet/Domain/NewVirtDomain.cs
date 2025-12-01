namespace PwshVirt;

using System.Globalization;
using Libvirt.Model;
using static Libvirt.Header.VirDomainDefineFlags;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.New, VerbsVirt.Domain)]
public class NewVirtDomain : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    [Parameter]
    public string? Memory { get; set; }

    [Parameter(Mandatory = true)]
    public string? Name { get; set; }

    [Parameter]
    public uint? NumCpu { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var guestCaps = await this.GetGuestCaps(conn).ConfigureAwait(false);

        var domCaps = await this.GetDomainCaps(conn, guestCaps).ConfigureAwait(false);

        var domain = guestCaps.GetDomainDefault(domCaps);

        this.SetDomain(domain, domCaps);

        var domainXml = Serializer.Serialize(domain);

        var dom = await conn.Client.DomainDefineXmlFlagsAsync(domainXml, (uint)VirDomainDefineValidate, this.Cancellation!.Token).ConfigureAwait(false);

        var model = await DomainUtility.GetDomain(conn, dom.Name, -1, 0, this.Cancellation.Token).ConfigureAwait(false);

        this.SetResult(model);
    }

    private async Task<DomainCapabilities> GetDomainCaps(Connection conn, CapabilitiesGuestcaps guestCaps)
    {
        var emulatorbin = guestCaps.Arch.Emulator;
        var arch = Utility.ConvertXmlEnumToString<Archnames>(guestCaps.Arch.Name);
        var machine = guestCaps.GetRecommendedMachine();
        var virtType = Utility.ConvertXmlEnumToString<Virttype>(guestCaps.GetRecommendedDomainType());

        var domCapsXml = await conn.Client.ConnectGetDomainCapabilitiesAsync(
            new Xdr.XdrOption<string>(emulatorbin),
            new Xdr.XdrOption<string>(arch),
            new Xdr.XdrOption<string>(machine),
            new Xdr.XdrOption<string>(virtType),
            NotUsed,
            this.Cancellation!.Token).ConfigureAwait(false);

        return Serializer.Deserialize<DomainCapabilities>(domCapsXml);
    }

    private async Task<CapabilitiesGuestcaps> GetGuestCaps(Connection conn)
    {
        var capsXml = await conn.Client.ConnectGetCapabilitiesAsync(this.Cancellation!.Token).ConfigureAwait(false);
        var caps = Serializer.Deserialize<Capabilities>(capsXml);
        return caps.GetRecommendedGuest();
    }

    private void SetDomain(Libvirt.Model.Domain domain, DomainCapabilities domCaps)
    {
        domain.Name = this.Name;

        domain.Uuid = Guid.NewGuid().ToString();

        SetDomainDisk(domain, domCaps);

        this.SetDomainMemory(domain);

        this.SetDomainVcpu(domain);
    }

    private static void SetDomainDisk(Libvirt.Model.Domain domain, DomainCapabilities domCaps)
    {
        domain.Devices.Disk =
        [
            domCaps.GetRecommendedCdrom(),
        ];
    }

    private void SetDomainMemory(Libvirt.Model.Domain domain)
    {
        var capacityKB = this.Memory is not null ?
            Utility.GetScaledSizeToBytes(this.Memory!) / 1024 :
            128 * 1024;

        domain.Memory = new DomainMemory
        {
            Unit = "KiB",
            Value = capacityKB.ToString(CultureInfo.InvariantCulture),
        };
    }

    private void SetDomainVcpu(Libvirt.Model.Domain domain)
    {
        var vcpu = this.NumCpu.HasValue ? this.NumCpu : 1;

        domain.Vcpu = new DomainVcpu
        {
            Value = vcpu?.ToString(CultureInfo.InvariantCulture),
        };
    }
}

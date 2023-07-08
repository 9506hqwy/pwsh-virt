namespace PwshVirt;

using Libvirt.Model;

internal static class CapabilitiesExtension
{
    internal static CapabilitiesGuestcaps GetRecommendedGuest(this Capabilities self)
    {
        var host = self.Host;
        return self.Guest.First(g =>
            g.Arch.Name == host.Cpu.Arch &&
            g.OsType == CapabilitiesOstype.Hvm);
    }
}

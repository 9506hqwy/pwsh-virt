namespace PwshVirt;

using Libvirt.Model;

internal static class CapabilitiesGuestcapsExtension
{
    internal static Libvirt.Model.Domain GetDomainDefault(
        this CapabilitiesGuestcaps self,
        DomainCapabilities domCaps)
    {
        var devices = new DomainDevices
        {
            Emulator = domCaps.Path,
        };

        devices.Graphics = domCaps.GetGraphicsDefault();
        devices.Video = domCaps.GetVideoDefault();
        devices.Input = domCaps.GetInputDefault();
        devices.Console = domCaps.GetConsoleDefault();
        devices.Controller = domCaps.GetControllerDefault();
        devices.Channel = domCaps.GetChannelDefualt();
        devices.Rng = domCaps.GetRngDefualt();
        devices.Memballoon = domCaps.GetMemballoonDefualt();
        devices.Sound = domCaps.GeSoundDefualt();
        devices.Redirdev = domCaps.GetRedirdevDefault();

        return new Libvirt.Model.Domain
        {
            Type = Utility.ConvertStringToXmlEnum<DomainHvs>(domCaps.Domain),
            Os = new DomainOs
            {
                Type = new DomainOsType
                {
                    Arch = Utility.ConvertStringToXmlEnum<DomainOsTypeArch>(domCaps.Arch),
                    ArchSpecified = true,
                    Machine = domCaps.Machine,
                    Value = Utility.ConvertXmlEnumToString<CapabilitiesOstype>(self.OsType),
                },
                FirmwareAttr = DomainOsFirmwareAttr.Efi,
                FirmwareAttrSpecified = domCaps.SupportUefi(),
                Boot = new[]
                {
                    new DomainOsbootdev
                    {
                        Dev = DomainOsbootdevDev.Network,
                    },
                    new DomainOsbootdev
                    {
                        Dev = DomainOsbootdevDev.Cdrom,
                    },
                    new DomainOsbootdev
                    {
                        Dev = DomainOsbootdevDev.Hd,
                    },
                },
            },
            Clock = domCaps.GetClockDefault(),
            Cpu = domCaps.GetGuestCpuDefault(),
            Features = self.GetFeaturesDefualt(),
            Pm = self.GetPmDefault(),
            Devices = devices,
        };
    }

    internal static DomainFeatures GetFeaturesDefualt(this CapabilitiesGuestcaps self)
    {
        var features = new DomainFeatures();

        if (self.Features.Acpi is not null &&
            self.Features.Acpi.Default == VirOnOff.On)
        {
            features.Acpi = new DomainFeaturesAcpi();
        }

        if (self.Features.Apic is not null &&
            self.Features.Apic.Default == VirOnOff.On)
        {
            features.Apic = new DomainFeaturesApic();
        }

        if (self.IsArchX86())
        {
            features.Vmport = new DomainFeaturesVmport
            {
                State = VirOnOff.Off,
                StateSpecified = true,
            };
        }

        return features;
    }

    internal static DomainPm? GetPmDefault(this CapabilitiesGuestcaps self)
    {
        if (!self.IsArchX86())
        {
            return null;
        }

        return new DomainPm
        {
            SuspendToDisk = new DomainPmSuspendToDisk
            {
                Enabled = VirYesNo.Yes,
                EnabledSpecified = true,
            },
            SuspendToMem = new DomainPmSuspendToMem
            {
                Enabled = VirYesNo.Yes,
                EnabledSpecified = true,
            },
        };
    }

    internal static CapabilitiesDomainType GetRecommendedDomainType(this CapabilitiesGuestcaps self)
    {
        if (self.Arch.Domain.Any(d => d.Type == CapabilitiesDomainType.Kvm))
        {
            return CapabilitiesDomainType.Kvm;
        }

        return self.Arch.Domain.First().Type;
    }

    internal static string GetRecommendedMachine(this CapabilitiesGuestcaps self)
    {
        if (self.IsArchArm())
        {
            var m = self.Arch.Machine.FirstOrDefault(m => m.Value == "virt");
            if (m is not null)
            {
                return m.Value;
            }
        }

        if (self.IsArchX86())
        {
            var m = self.Arch.Machine.FirstOrDefault(m => m.Value == "q35");
            if (m is not null)
            {
                return m.Value;
            }
        }

        return self.Arch.Machine.First(m => m.Value == "pc").Value;
    }

    internal static bool IsArchArm(this CapabilitiesGuestcaps self)
    {
        return self.IsArchArm32() || self.IsArchArm64();
    }

    internal static bool IsArchArm32(this CapabilitiesGuestcaps self)
    {
        return
            self.Arch.Name == Archnames.Armv6l ||
            self.Arch.Name == Archnames.Armv7l;
    }

    internal static bool IsArchArm64(this CapabilitiesGuestcaps self)
    {
        return self.Arch.Name == Archnames.Aarch64;
    }

    internal static bool IsArchX86(this CapabilitiesGuestcaps self)
    {
        return
            self.Arch.Name == Archnames.I686 ||
            self.Arch.Name == Archnames.X8664;
    }
}

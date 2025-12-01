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
            Graphics = domCaps.GetGraphicsDefault(),
            Video = domCaps.GetVideoDefault(),
            Input = domCaps.GetInputDefault(),
            Console = domCaps.GetConsoleDefault(),
            Controller = domCaps.GetControllerDefault(),
            Channel = domCaps.GetChannelDefualt(),
            Rng = domCaps.GetRngDefualt(),
            Memballoon = domCaps.GetMemballoonDefualt(),
            Sound = domCaps.GeSoundDefualt(),
            Redirdev = domCaps.GetRedirdevDefault()
        };

        return new Libvirt.Model.Domain
        {
            Type = Utility.ConvertStringToXmlEnum<Virttype>(domCaps.Domain),
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
                Boot =
                [
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
                ],
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
        return !self.IsArchX86()
            ? null
            : new DomainPm
            {
                SuspendToDisk = new DomainPmSuspendToDisk
                {
                    Enabled = VirYesNo.No,
                    EnabledSpecified = true,
                },
                SuspendToMem = new DomainPmSuspendToMem
                {
                    Enabled = VirYesNo.No,
                    EnabledSpecified = true,
                },
            };
    }

    internal static Virttype GetRecommendedDomainType(this CapabilitiesGuestcaps self)
    {
        return self.Arch.Domain.Any(d => d.Type == Virttype.Kvm) ? Virttype.Kvm : self.Arch.Domain.First().Type;
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
            self.Arch.Name is Archnames.Armv6l or
            Archnames.Armv7l;
    }

    internal static bool IsArchArm64(this CapabilitiesGuestcaps self)
    {
        return self.Arch.Name == Archnames.Aarch64;
    }

    internal static bool IsArchX86(this CapabilitiesGuestcaps self)
    {
        return
            self.Arch.Name is Archnames.I686 or
            Archnames.X8664;
    }
}

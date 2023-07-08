namespace PwshVirt;

using Libvirt.Model;

internal static class DomainCapabilitiesExtension
{
    internal static DomainChannel[] GetChannelDefualt(this DomainCapabilities self)
    {
        var ret = new List<DomainChannel>()
        {
            new DomainChannel
            {
                Type = QemucdevSrcTypeChoice.Unix,
                Target = new DomainChannelTarget
                {
                    Type = DomainChannelTargetType.Virtio,
                    Name = "org.qemu.guest_agent.0",
                },
                Source = new[]
                {
                    new DomainSerialSource
                    {
                        Mode = "bind",
                    },
                },
            },
        };

        if (self.SupportSpice())
        {
            ret.Add(new DomainChannel
            {
                Type = QemucdevSrcTypeChoice.Spicevmc,
                Target = new DomainChannelTarget
                {
                    Type = DomainChannelTargetType.Virtio,
                    Name = "com.redhat.spice.0",
                },
            });
        }

        return ret.ToArray();
    }

    internal static DomainClock GetClockDefault(this DomainCapabilities self)
    {
        var clock = new DomainClock
        {
            Offset = DomainClockOffset.Utc,
        };

        if (!self.IsArchX86())
        {
            return clock;
        }

        clock.Timer = new[]
        {
            new DomainTimer
            {
                Name = DomainTimerName.Rtc,
                Tickpolicy = DomainTimerTickpolicy.Catchup,
                TickpolicySpecified = true,
            },
            new DomainTimer
            {
                Name = DomainTimerName.Pit,
                Tickpolicy = DomainTimerTickpolicy.Delay,
                TickpolicySpecified = true,
            },
            new DomainTimer
            {
                Name = DomainTimerName.Hpet,
                Present = VirYesNo.No,
                PresentSpecified = true,
            },
        };

        return clock;
    }

    internal static DomainConsole[] GetConsoleDefault(this DomainCapabilities self)
    {
        return new[]
        {
            new DomainConsole
            {
                Type = QemucdevSrcTypeChoice.Pty,
                TypeSpecified = true,
            },
        };
    }

    internal static DomainController[] GetControllerDefault(this DomainCapabilities self)
    {
        return new[]
        {
            new DomainController
            {
              Type = DomainControllerType.Usb,
              ModelAttr = DomainControllerModelAttr.QemuXhci,
              ModelAttrSpecified = true,
              Ports = 15,
              PortsSpecified = true,
            },
            new DomainController
            {
              Type = DomainControllerType.Scsi,
              ModelAttr = DomainControllerModelAttr.VirtioScsi,
              ModelAttrSpecified = true,
            },
        };
    }

    internal static DomainGraphic[]? GetGraphicsDefault(this DomainCapabilities self)
    {
        var graphics = self.Devices?.Graphics;
        if (graphics is null || graphics.Supported == VirYesNo.No)
        {
            return null;
        }

        var types = graphics.Enum.First(e => e.Name == "type");

        var ret = new List<DomainGraphic>();

        if (types.Value.Any(v => v == "spice"))
        {
            ret.Add(new DomainGraphic
            {
                Type = DomainGraphicType.Spice,
                Port = -1,
                PortSpecified = true,
                TlsPort = -1,
                TlsPortSpecified = true,
                Autoport = DomainGraphicAutoport.Yes,
                AutoportSpecified = true,
                ListenAttr = "::1",
            });
        }

        if (types.Value.Any(v => v == "vnc"))
        {
            ret.Add(new DomainGraphic
            {
                Type = DomainGraphicType.Vnc,
                Port = -1,
                PortSpecified = true,
                ListenAttr = "127.0.0.1",
            });
        }

        return ret.Count != 0 ? ret.ToArray() : null;
    }

    internal static Guestcpu? GetGuestCpuDefault(this DomainCapabilities self)
    {
        var model = self.Cpu.Mode.FirstOrDefault(m => m.Name == DomainCapabilitiesCpuModeName.HostPassthrough);
        if (model is not null && model.Supported == DomainCapabilitiesCpuModeSupported.Yes)
        {
            return new Guestcpu
            {
                Mode = GuestcpuCpuMode.HostPassthrough,
                ModeSpecified = true,
                Check = GuestcpuCpuCheck.None,
                CheckSpecified = true,
            };
        }

        return null;
    }

    internal static DomainInput[]? GetInputDefault(this DomainCapabilities self)
    {
        var ret = new List<DomainInput>();

        if (self.IsArchArm() || self.IsArchX86())
        {
            ret.Add(new DomainInput
            {
                Type = DomainInputType.Tablet,
                Bus = DomainInputBus.Usb,
                BusSpecified = true,
            });
        }

        if (self.IsArchArm() && self.IsMachineVirt())
        {
            ret.Add(new DomainInput
            {
                Type = DomainInputType.Keyboard,
                Bus = DomainInputBus.Usb,
                BusSpecified = true,
            });
        }

        return ret.Count != 0 ? ret.ToArray() : null;
    }

    internal static DomainMemballoon GetMemballoonDefualt(this DomainCapabilities self)
    {
        return new DomainMemballoon
        {
            Model = DomainMemballoonModel.Virtio,
        };
    }

    internal static DomainDisk GetRecommendedCdrom(this DomainCapabilities self)
    {
        var bus = self.IsMachineQ35() ? DomainDiskTargetBus.Sata : DomainDiskTargetBus.Scsi;

        return new DomainDisk
        {
            Type = DomainDiskType.File,
            TypeSpecified = true,
            Device = DomainDiskDevice.Cdrom,
            DeviceSpecified = true,
            Target = new DomainDiskTarget
            {
                Dev = "sda",
                Bus = bus,
                BusSpecified = true,
            },
            Readonly = new DomainDiskReadonly(),
        };
    }

    internal static DomainRedirdev[]? GetRedirdevDefault(this DomainCapabilities self)
    {
        if (!self.IsArchX86())
        {
            return null;
        }

        if (!self.SupportSpice())
        {
            return null;
        }

        return new[]
        {
            new DomainRedirdev
            {
                Bus = DomainRedirdevBus.Usb,
                Type = QemucdevSrcTypeChoice.Spicevmc,
            },
            new DomainRedirdev
            {
                Bus = DomainRedirdevBus.Usb,
                Type = QemucdevSrcTypeChoice.Spicevmc,
            },
        };
    }

    internal static DomainRng[] GetRngDefualt(this DomainCapabilities self)
    {
        return new[]
        {
            new DomainRng
            {
                Model = DomainRngModel.Virtio,
                Backend = new DomainDevicesRngRngBackend
                {
                    Model = DomainDevicesRngRngBackendModel.Random,
                    Value = "/dev/urandom",
                },
            },
        };
    }

    internal static DomainSound[] GeSoundDefualt(this DomainCapabilities self)
    {
        return new[]
        {
            new DomainSound
            {
                Model = DomainSoundModel.Ich9,
            },
        };
    }

    internal static DomainVideo[]? GetVideoDefault(this DomainCapabilities self)
    {
        var video = self.Devices?.Video;
        if (video is null || video.Supported == VirYesNo.No)
        {
            return null;
        }

        var models = video.Enum.First(e => e.Name == "modelType");

        var ret = DomainVideoModelType.Vga;

        if (self.IsArchArm() && self.IsMachineVirt() && models.Value.Any(v => v == "virtio"))
        {
            ret = DomainVideoModelType.Virtio;
        }

        if (self.IsArchX86() && models.Value.Any(v => v == "qxl"))
        {
            ret = DomainVideoModelType.Qxl;
        }

        return new[]
        {
            new DomainVideo
            {
                Model = new DomainVideoModel
                {
                    Type = ret,
                },
            },
        };
    }

    internal static bool IsArchArm(this DomainCapabilities self)
    {
        return self.IsArchArm32() || self.IsArchArm64();
    }

    internal static bool IsArchArm32(this DomainCapabilities self)
    {
        return
            self.Arch == Utility.ConvertXmlEnumToString<Archnames>(Archnames.Armv6l) ||
            self.Arch == Utility.ConvertXmlEnumToString<Archnames>(Archnames.Armv7l);
    }

    internal static bool IsArchArm64(this DomainCapabilities self)
    {
        return self.Arch == Utility.ConvertXmlEnumToString<Archnames>(Archnames.Aarch64);
    }

    internal static bool IsArchX86(this DomainCapabilities self)
    {
        return
            self.Arch == Utility.ConvertXmlEnumToString<Archnames>(Archnames.I686) ||
            self.Arch == Utility.ConvertXmlEnumToString<Archnames>(Archnames.X8664);
    }

    internal static bool IsMachineQ35(this DomainCapabilities self)
    {
        return self.IsArchX86() && self.Machine.Contains("q35");
    }

    internal static bool IsMachineVirt(this DomainCapabilities self)
    {
        return self.Machine.Contains("virt");
    }

    internal static bool SupportSpice(this DomainCapabilities self)
    {
        return self.Devices?.Graphics?.Enum?
            .First(e => e.Name == "type")
            .Value
            .Any(v => v == "spice") ?? false;
    }

    internal static bool SupportUefi(this DomainCapabilities self)
    {
        return self.Os.Enum
            .First(e => e.Name == "firmware")
            .Value
            .Any(v => v == "efi");
    }
}

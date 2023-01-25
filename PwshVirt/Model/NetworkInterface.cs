namespace PwshVirt;

using System.Net.NetworkInformation;

public class NetworkInterface : VirtObject
{
    private readonly int state;

    internal NetworkInterface(
        Connection conn,
        RemoteNonnullInterface iface,
        int state)
        : base(conn)
    {
        this.Self = iface;
        this.state = state;
    }

    public PhysicalAddress Mac => PhysicalAddress.Parse(this.Self.Mac);

    public string Name => this.Self.Name;

    public NetworkInterfaceState Status => (NetworkInterfaceState)Enum.ToObject(typeof(NetworkInterfaceState), this.state);

    internal RemoteNonnullInterface Self { get; }
}

namespace PwshVirt;

internal static class NetworkInterfaceUtility
{
    internal static async Task<byte> WaitForState(
        Connection conn,
        NetworkInterface iface,
        NetworkInterfaceState desired,
        CancellationToken cancellationToken)
    {
        NetworkInterfaceState state;

        do
        {
            await Task.Delay(1000, cancellationToken).ConfigureAwait(false);

            var tmp = await conn.Client.InterfaceIsActiveAsync(iface.Self, cancellationToken).ConfigureAwait(false);
            state = (NetworkInterfaceState)Enum.ToObject(typeof(NetworkInterfaceState), tmp);
        }
        while (state != desired);

        return (byte)state;
    }
}

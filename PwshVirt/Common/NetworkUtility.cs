namespace PwshVirt;

internal static class NetworkUtility
{
    internal static async Task<int> WaitForState(
        Connection conn,
        Network net,
        int desired,
        CancellationToken cancellationToken)
    {
        int state;

        do
        {
            await Task.Delay(1000, cancellationToken).ConfigureAwait(false);

            state = await conn.Client.NetworkIsActiveAsync(net.Self, cancellationToken).ConfigureAwait(false);
        }
        while (state != desired);

        return state;
    }
}

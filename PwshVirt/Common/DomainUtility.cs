namespace PwshVirt;

internal static class DomainUtility
{
    internal static async Task<int> WaitForState(
        Connection conn,
        Domain dom,
        DomainState desired,
        CancellationToken cancellationToken)
    {
        DomainState state;

        do
        {
            await Task.Delay(1000, cancellationToken);

            (var tmp, var _) = await conn.Client.DomainGetStateAsync(dom.Self, 0, cancellationToken);
            state = (DomainState)Enum.ToObject(typeof(DomainState), tmp);
        }
        while (state != desired);

        return (int)state;
    }
}

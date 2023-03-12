namespace PwshVirt;

internal static class DomainUtility
{
    private const uint NotUsed = 0;

    internal static async Task<Domain> GetDomain(
        Connection conn,
        string name,
        int state,
        int stateReason,
        CancellationToken cancellationToken)
    {
        var dom = await conn.Client.DomainLookupByNameAsync(name, cancellationToken);

        if (state == (int)DomainState.Last)
        {
            (state, stateReason) = await conn.Client.DomainGetStateAsync(dom, NotUsed, cancellationToken);
        }

        var hasManagedSave = (state == (int)DomainState.Shutoff) ?
            await conn.Client.DomainHasManagedSaveImageAsync(dom, NotUsed, cancellationToken) :
            0;

        return new Domain(conn, dom, state, hasManagedSave == 1);
    }

    internal static async Task<Tuple<int, int>> WaitForState(
        Connection conn,
        Domain dom,
        DomainState desired,
        CancellationToken cancellationToken)
    {
        DomainState state;
        int stateReason;

        do
        {
            await Task.Delay(1000, cancellationToken);

            (var tmp, stateReason) = await conn.Client.DomainGetStateAsync(dom.Self, 0, cancellationToken);
            state = (DomainState)Enum.ToObject(typeof(DomainState), tmp);
        }
        while (state != desired);

        return new Tuple<int, int>((int)state, stateReason);
    }
}

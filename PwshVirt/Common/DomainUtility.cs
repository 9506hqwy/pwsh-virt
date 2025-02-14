﻿namespace PwshVirt;

using Libvirt.Header;
using static Libvirt.Header.VirDomainDeviceModifyFlags;

internal static class DomainUtility
{
    private const uint NotUsed = 0;

    internal static async Task AttachDevice(
        Connection conn,
        Domain dom,
        string device,
        CancellationToken cancellationToken)
    {
        // config
        await conn.Client.DomainAttachDeviceFlagsAsync(dom.Self, device, (uint)VirDomainDeviceModifyConfig, cancellationToken);

        var isActive = await conn.Client.DomainIsActiveAsync(dom.Self, cancellationToken);
        if (isActive != 0)
        {
            // active
            await conn.Client.DomainAttachDeviceFlagsAsync(dom.Self, device, (uint)VirDomainDeviceModifyLive, cancellationToken);
        }
    }

    internal static async Task<Domain> GetDomain(
        Connection conn,
        string name,
        int state,
        int _,
        CancellationToken cancellationToken)
    {
        var dom = await conn.Client.DomainLookupByNameAsync(name, cancellationToken);

        if (state < 0)
        {
            (state, _) = await conn.Client.DomainGetStateAsync(dom, NotUsed, cancellationToken);
        }

        var hasManagedSave = (state == (int)VirDomainState.VirDomainShutoff) ?
            await conn.Client.DomainHasManagedSaveImageAsync(dom, NotUsed, cancellationToken) :
            0;

        return new Domain(conn, dom, state, hasManagedSave == 1);
    }

    internal static async Task UpdateDevice(
        Connection conn,
        Domain dom,
        string device,
        CancellationToken cancellationToken)
    {
        // config
        await conn.Client.DomainUpdateDeviceFlagsAsync(dom.Self, device, (uint)VirDomainDeviceModifyConfig, cancellationToken);

        var isActive = await conn.Client.DomainIsActiveAsync(dom.Self, cancellationToken);
        if (isActive != 0)
        {
            // active
            await conn.Client.DomainUpdateDeviceFlagsAsync(dom.Self, device, (uint)VirDomainDeviceModifyLive, cancellationToken);
        }
    }

    internal static async Task<Tuple<int, int>> WaitForState(
        Connection conn,
        Domain dom,
        VirDomainState desired,
        CancellationToken cancellationToken)
    {
        VirDomainState state;
        int stateReason;

        do
        {
            await Task.Delay(1000, cancellationToken);

            (var tmp, stateReason) = await conn.Client.DomainGetStateAsync(dom.Self, NotUsed, cancellationToken);
            state = (VirDomainState)Enum.ToObject(typeof(VirDomainState), tmp);
        }
        while (state != desired);

        return new Tuple<int, int>((int)state, stateReason);
    }
}

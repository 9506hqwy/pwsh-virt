namespace PwshVirt;

internal static class StoragePoolUtility
{
    internal static async Task<StoragePool> GetPool(
        Connection conn,
        RemoteNonnullStoragePool pool,
        CancellationToken cancellationToken)
    {
        (var state, var _, var _, var _) = await conn.Client.StoragePoolGetInfoAsync(pool, cancellationToken);

        return new StoragePool(conn, pool, state);
    }

    internal static async Task<byte> WaitForState(
        Connection conn,
        StoragePool pool,
        StoragePoolState desired,
        CancellationToken cancellationToken)
    {
        StoragePoolState state;

        do
        {
            await Task.Delay(1000, cancellationToken);

            (var tmp, var _, var _, var _) = await conn.Client.StoragePoolGetInfoAsync(pool.Self, cancellationToken);
            state = (StoragePoolState)Enum.ToObject(typeof(StoragePoolState), tmp);
        }
        while (state != desired);

        return (byte)state;
    }
}

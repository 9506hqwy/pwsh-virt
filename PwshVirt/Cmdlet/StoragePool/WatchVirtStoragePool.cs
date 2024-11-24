namespace PwshVirt;

[OutputType(typeof(IVirtEvent))]
[Cmdlet(VerbsCommon.Watch, VerbsVirt.StoragePool)]
public class WatchVirtStoragePool : PwshVirtCmdlet
{
    [Parameter]
    public StoragePool? Pool { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out _);

        var pool = this.Pool is null ? null : new Xdr.XdrOption<RemoteNonnullStoragePool>(this.Pool.Self);
        var callbackId = await conn.Client.ConnectStoragePoolEventRegisterAnyAsync(0, pool, this.Cancellation!.Token);
        try
        {
            var eventStream = conn.Client.GetEventStream(callbackId);

            while (!this.Cancellation.IsCancellationRequested)
            {
                var e = await eventStream.ReadAsync(this.Cancellation.Token);
                this.SetResult(e);
            }
        }
        finally
        {
            _ = conn.Client.DeleteEventStream(callbackId);

            // use `default` because the token is already canceled.
            await conn.Client.ConnectStoragePoolEventDeregisterAnyAsync(callbackId, default);
        }
    }
}

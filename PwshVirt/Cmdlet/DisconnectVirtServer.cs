namespace PwshVirt;

[Cmdlet(VerbsCommunications.Disconnect, VerbsVirt.Server)]
public class DisconnectVirtServer : PwshVirtCmdlet
{
    [Parameter(ValueFromPipeline = true)]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var isDefault);

        await conn.Client.ConnectCloseAsync(this.Cancellation!.Token);

        conn.Dispose();

        if (isDefault)
        {
            this.SetVariable(Connection.DefaultVirtServer, null!);
        }
    }
}

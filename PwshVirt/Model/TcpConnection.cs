namespace PwshVirt;

using System.Net.Sockets;

public class TcpConnection : Connection
{
    private readonly TcpClient client;

    private readonly NetworkStream stream;

    private bool disposed;

    internal TcpConnection(TcpClient client)
        : base(TcpConnection.GetClient(client, out var stream))
    {
        this.disposed = false;

        this.client = client;
        this.stream = stream;
    }

    protected override void Dispose(bool disposing)
    {
        if (this.disposed)
        {
            return;
        }

        base.Dispose(disposing);

        if (disposing)
        {
            this.stream.Dispose();
            this.client.Dispose();
        }

        this.disposed = true;
    }

    private static VirtClient GetClient(
        TcpClient client,
        out NetworkStream stream)
    {
        stream = client.GetStream();
        return new VirtClient(stream);
    }
}

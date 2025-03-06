namespace PwshVirt;

using System.Net.Sockets;

public class UnixConnection : Connection
{
    private readonly Socket socket;

    private readonly NetworkStream stream;

    private bool disposed;

    internal UnixConnection(Socket socket)
        : base(UnixConnection.GetClient(socket, out var stream))
    {
        this.disposed = false;

        this.socket = socket;
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
            this.socket.Dispose();
        }

        this.disposed = true;
    }

    private static VirtClient GetClient(Socket socket, out NetworkStream stream)
    {
        stream = new NetworkStream(socket);
        return new VirtClient(stream);
    }
}

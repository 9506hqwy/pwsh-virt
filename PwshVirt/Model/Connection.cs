namespace PwshVirt;

public class Connection : IDisposable
{
    internal const string DefaultVirtServer = "DefaultVirtServer";

    private bool disposed;

    internal Connection(VirtClient client)
    {
        this.disposed = false;

        this.Client = client;
    }

    internal VirtClient Client { get; }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this.disposed)
        {
            return;
        }

        if (disposing)
        {
            this.Client.Dispose();
        }

        this.disposed = true;
    }
}

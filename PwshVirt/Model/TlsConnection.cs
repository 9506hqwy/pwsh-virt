namespace PwshVirt;

using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

public class TlsConnection : Connection
{
    private readonly TcpClient client;

    private readonly SslStream stream;

    private bool disposed;

    internal TlsConnection(TcpClient client, string hostName, bool noVerify, string? pkiPath)
        : base(new VirtClient(TlsConnection.GetSsl(client, hostName, noVerify, pkiPath, out var stream)))
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

    private static SslStream GetSsl(
        TcpClient client,
        string hostName,
        bool noVerify,
        string? pfxPath,
        out SslStream ssl)
    {
        var stream = client.GetStream();

        ssl = noVerify ?
#pragma warning disable CA5359
            new SslStream(stream, false, static (a, b, c, d) => true) :
#pragma warning restore CA5359
            new SslStream(stream);

        if (pfxPath is null)
        {
            ssl.AuthenticateAsClient(hostName);
        }
        else
        {
            var cert = new X509Certificate2(pfxPath);
            var certs = new X509CertificateCollection(new X509Certificate[] { cert });
#if NETSTANDARD2_0
            var protocols = SslProtocols.Default | SslProtocols.Tls12;
#else
            var protocols = SslProtocols.None;
#endif
            ssl.AuthenticateAsClient(hostName, certs, protocols, true);
        }

        // https://github.com/libvirt/libvirt/blob/v9.0.0/src/rpc/virnetclient.c#L986
        // At this point, the server is verifying _our_ certificate, IP address, etc.
        // If we make the grade, it will send us a '\1' byte.
        _ = ssl.ReadByte();

        return ssl;
    }
}

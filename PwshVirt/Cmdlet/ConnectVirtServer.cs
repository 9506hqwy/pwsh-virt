namespace PwshVirt;

using System.Net.Sockets;

[OutputType(typeof(Connection))]
[Cmdlet(VerbsCommunications.Connect, VerbsVirt.Server)]
public class ConnectVirtServer : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    private const string DefaultDriver = "qemu";

    private const int DefaultTcpPort = 16509;

    private const string DefaultPath = "/system";

    private const string DefaultServer = "127.0.0.1";

    private const int DefaultTlsPort = 16514;

#if NETSTANDARD2_1
    private const string DefaultTransport = "unix";
#else
    private const string DefaultTransport = "tls";
#endif

#if NETSTANDARD2_1
    private const string DefaultUnixDomain = "/var/run/libvirt/libvirt-sock";
#endif

    [Parameter]
    [ValidateSet("qemu")]
    public string? Driver { get; set; }

    [Parameter]
    public SwitchParameter Force { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public SwitchParameter NotDefault { get; set; }

    [Parameter]
    public FileInfo? PfxPath { get; set; }

    [Parameter]
    public int Port { get; set; }

    [Parameter]
    public string? Server { get; set; }

    [Parameter]
#if NETSTANDARD2_1
    [ValidateSet("tcp", "tls", "unix")]
#else
    [ValidateSet("tcp", "tls")]
#endif
    public string? Transport { get; set; }

    [Parameter]
    public Uri? Uri { get; set; }

    internal override async Task Execute()
    {
        var conn = await this.GetConnection();

        await this.Authenticate(conn);

        await conn.Client.ConnectOpenAsync(new Xdr.XdrOption<string>(this.GetName()), NotUsed, this.Cancellation!.Token);

        if (!this.NotDefault)
        {
            this.SetVariable(Connection.DefaultVirtServer, conn);
        }

        this.SetResult(conn);
    }

    private async Task Authenticate(Connection conn)
    {
        var authList = await conn.Client.AuthListAsync(this.Cancellation!.Token);
        if (authList is null)
        {
            return;
        }

        foreach (var auth in authList)
        {
            switch (auth)
            {
                case RemoteAuthType.RemoteAuthNone:
                    break;
                case RemoteAuthType.RemoteAuthPolkit:
                    _ = await conn.Client.AuthPolkitAsync(this.Cancellation.Token);
                    break;
                case RemoteAuthType.RemoteAuthSasl:
                    throw new NotSupportedException("Not support authentication method `SASL`");
                default:
                    break;
            }
        }
    }

    private async Task<Connection> GetConnection()
    {
        return this.GetTransport() switch
        {
            "tcp" => await this.GetTcp(),
            "tls" => await this.GetTls(),
#if NETSTANDARD2_1
            "unix" => await this.GetUnix(),
#endif
            _ => throw new InvalidProgramException(),
        };
    }

    private string GetDriver()
    {
        return
            !string.IsNullOrWhiteSpace(this.Driver) ?
            this.Driver! :
            this.Uri is not null ?
            this.Uri!.Scheme.Split('+').First() :
            DefaultDriver;
    }

    private string GetName()
    {
        var driver = this.GetDriver();

        return
            !string.IsNullOrWhiteSpace(this.Name) ?
            this.Name! :
            this.Uri is not null ?
            $"{driver}://{this.Uri.AbsolutePath}" :
            $"{DefaultDriver}://{DefaultPath}";
    }

    private int GetPort()
    {
        var transport = this.GetTransport();

        return transport == "unix"
            ? 0
            : this.Port != 0 ?
            this.Port :
            this.Uri is not null ?
            this.Uri!.Port :
            transport == "tls" ?
            DefaultTlsPort :
            DefaultTcpPort;
    }

    private string GetServer()
    {
        return
            !string.IsNullOrWhiteSpace(this.Server) ?
            this.Server! :
            this.Uri is not null ?
            this.Uri!.Host :
            DefaultServer;
    }

    private async Task<TcpConnection> GetTcp()
    {
        var tcp = new TcpClient();
        tcp.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

        await tcp.ConnectAsync(this.GetServer(), this.GetPort());
        return new TcpConnection(tcp);
    }

    private async Task<TlsConnection> GetTls()
    {
        var query = this.GetQuery();

        var noVerify =
            this.Force.ToBool() ||
            (query.TryGetValue("no_verify", out var noVerifyValue) && noVerifyValue == "1");

        _ = query.TryGetValue("pfxpath", out var queryFfxPath);
        var pfxPath = this.PfxPath?.FullName ?? queryFfxPath;

        var tcp = new TcpClient();
        tcp.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

        await tcp.ConnectAsync(this.GetServer(), this.GetPort());
        return new TlsConnection(tcp, this.GetServer(), noVerify, pfxPath);
    }

    private string GetTransport()
    {
        return
            !string.IsNullOrWhiteSpace(this.Transport) ?
            this.Transport! :
            this.Uri is not null ?
            this.Uri!.Scheme.Split(['+'], 2).Last() :
            DefaultTransport;
    }

#if NETSTANDARD2_1
    private async Task<UnixConnection> GetUnix()
    {
        var query = this.GetQuery();

        if (!query.TryGetValue("socket", out var socketPath))
        {
            socketPath = DefaultUnixDomain;
        }

        var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
        await socket.ConnectAsync(new UnixDomainSocketEndPoint(socketPath));
        return new UnixConnection(socket);
    }
#endif

    private IDictionary<string, string> GetQuery()
    {
        return this.Uri is null
            ? []
            : this.Uri.Query
            .TrimStart('?')
            .Split('&')
            .Select(q => q.Split(['='], 2))
            .Where(q => q.Length == 2)
            .ToDictionary(q => q[0], q => Uri.UnescapeDataString(q[1]));
    }
}

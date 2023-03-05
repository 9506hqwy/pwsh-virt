﻿namespace PwshVirt;

using System.Net.Sockets;

[OutputType(typeof(Connection))]
[Cmdlet(VerbsCommunications.Connect, VerbsVirt.Server)]
public class ConnectVirtServer : PwshVirtCmdlet
{
    private const string DefaultDriver = "qemu";

    private const int DefaultTcpPort = 16509;

    private const string DefaultPath = "/system";

    private const string DefaultServer = "127.0.0.1";

    private const int DefaultTlsPort = 16514;

    private const string DefaultTransport = "tls";

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
    [ValidateSet("tcp", "tls")]
    public string? Transport { get; set; }

    [Parameter]
    public Uri? Uri { get; set; }

    internal async override Task Execute()
    {
        var conn = await this.GetConnection();

        await conn.Client.ConnectOpenAsync(new Xdr.XdrOption<string>(this.GetName()), 0, this.Cancellation!.Token);

        if (!this.NotDefault)
        {
            this.SetVariable(Connection.DefaultVirtServer, conn);
        }

        this.SetResult(conn);
    }

    private async Task<Connection> GetConnection()
    {
        return this.GetTransport() switch
        {
            "tcp" => await this.GetTcp(),
            "tls" => await this.GetTls(),
            _ => throw new PwshVirtException(ErrorCategory.InvalidArgument),
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

        return
            this.Port != 0 ?
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

        query.TryGetValue("pfxpath", out var queryFfxPath);
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
            this.Uri!.Scheme.Split(new[] { '+' }, 2).Last() :
            DefaultTransport;
    }

    private IDictionary<string, string> GetQuery()
    {
        if (this.Uri is null)
        {
            return new Dictionary<string, string>();
        }

        return this.Uri.Query
            .TrimStart('?')
            .Split('&')
            .Select(q => q.Split(new[] { '=' }, 2))
            .Where(q => q.Length == 2)
            .ToDictionary(q => q[0], q => Uri.UnescapeDataString(q[1]));
    }
}

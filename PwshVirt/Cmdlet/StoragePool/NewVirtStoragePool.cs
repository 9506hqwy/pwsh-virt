namespace PwshVirt;

using Libvirt.Model;

[OutputType(typeof(StoragePool))]
[Cmdlet(VerbsCommon.New, VerbsVirt.StoragePool, DefaultParameterSetName = KeyDir)]
public class NewVirtStoragePool : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    private const string KeyDir = "Dir";

    private const string KeyDisk = "Disk";

    private const string KeyLogical = "Logical";

    private const string KeyNetfs = "Netfs";

    [Parameter(Mandatory = true, ParameterSetName = KeyNetfs)]
    public string? Address { get; set; }

    [Parameter(ParameterSetName = KeyDisk)]
    public PoolSourcefmtdiskType DeviceFormat { get; set; } = PoolSourcefmtdiskType.Dos;

    [Parameter(Mandatory = true, ParameterSetName = KeyDisk)]
    public string? DevicePath { get; set; }

    [Parameter(ParameterSetName = KeyNetfs)]
    public PoolSourcefmtnetfsType? ExportType { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyNetfs)]
    public string? ExportPath { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyDir)]
    [Parameter(Mandatory = true, ParameterSetName = KeyDisk)]
    [Parameter(Mandatory = true, ParameterSetName = KeyLogical)]
    [Parameter(Mandatory = true, ParameterSetName = KeyNetfs)]
    public string? Name { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyDir)]
    [Parameter(Mandatory = true, ParameterSetName = KeyDisk)]
    [Parameter(Mandatory = true, ParameterSetName = KeyNetfs)]
    public string? Path { get; set; }

    [Parameter(ParameterSetName = KeyDir)]
    [Parameter(ParameterSetName = KeyDisk)]
    [Parameter(ParameterSetName = KeyLogical)]
    [Parameter(ParameterSetName = KeyNetfs)]
    public Connection? Server { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = KeyLogical)]
    public string? VgName { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        try
        {
            await conn.Client.StoragePoolLookupByNameAsync(this.Name, this.Cancellation!.Token);
            throw new PwshVirtException(ErrorCategory.InvalidArgument);
        }
        catch (VirtException e) when (e.Error.Code == 49)
        {
            // VIR_ERR_NO_STORAGE_POOL = 49
        }

        var xml = this.ParameterSetName switch
        {
            KeyDir => this.NewPoolDir(),
            KeyDisk => this.NewPoolDisk(),
            KeyLogical => this.NewPoolLogical(),
            KeyNetfs => this.NewPoolNetfs(),
            _ => throw new InvalidProgramException(),
        };

        var pool = await conn.Client.StoragePoolDefineXmlAsync(xml, NotUsed, this.Cancellation!.Token);

        var model = await StoragePoolUtility.GetPool(conn, pool, this.Cancellation!.Token);

        this.SetResult(model);
    }

    private string NewPoolDir()
    {
        var pool = new Pooldir
        {
            Type = "dir",
            Name = this.Name,
            Target = new PoolTarget
            {
                Path = this.Path,
            },
        };

        return Serializer.Serialize(pool);
    }

    private string NewPoolDisk()
    {
        var pool = new Pooldisk
        {
            Type = "disk",
            Name = this.Name,
            Source = new PoolSourcedisk
            {
                Device = new PoolSourceinfodev
                {
                    Path = this.DevicePath,
                },
                Format = new PoolSourcefmtdisk
                {
                    Type = this.DeviceFormat,
                },
            },
            Target = new PoolTarget
            {
                Path = this.Path,
            },
        };

        return Serializer.Serialize(pool);
    }

    private string NewPoolLogical()
    {
        var pool = new Poollogical
        {
            Type = "logical",
            Name = this.Name,
            Source = new PoolSourcelogical
            {
                Name = new[] { this.VgName },
                Format = new PoolSourcefmtlogical
                {
                    Type = PoolSourcefmtlogicalType.Lvm2,
                },
            },
            Target = new PoolTargetlogical
            {
                Path = $"/dev/{this.VgName}",
            },
        };

        return Serializer.Serialize(pool);
    }

    private string NewPoolNetfs()
    {
        var pool = new Poolnetfs
        {
            Type = "netfs",
            Name = this.Name,
            Source = new PoolSourcenetfs
            {
                Host = new[]
                {
                    new PoolSourceinfohost
                    {
                        Name = this.Address,
                    },
                },
                Dir = new PoolSourceinfodir
                {
                    Path = this.ExportPath,
                },
                Format = new PoolSourcefmtnetfs
                {
                    Type = this.ExportType ?? PoolSourcefmtnetfsType.Auto,
                    TypeSpecified = this.ExportType.HasValue,
                },
            },
            Target = new PoolTarget
            {
                Path = this.Path,
            },
        };

        return Serializer.Serialize(pool);
    }
}

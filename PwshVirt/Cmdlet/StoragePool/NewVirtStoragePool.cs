namespace PwshVirt;

using Libvirt.Model;
using System.Globalization;

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
    public PoolSourceFormatType DeviceFormat { get; set; } = PoolSourceFormatType.Dos;

    [Parameter(Mandatory = true, ParameterSetName = KeyDisk)]
    public string? DevicePath { get; set; }

    [Parameter(ParameterSetName = KeyNetfs)]
    public PoolSourceFormatType? ExportType { get; set; }

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

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out _);

        try
        {
            _ = await conn.Client.StoragePoolLookupByNameAsync(this.Name, this.Cancellation!.Token).ConfigureAwait(false);
            throw new PwshVirtException(
                string.Format(CultureInfo.CurrentCulture, Resource.ERR_AlreadyExistStoragePool, this.Name),
                ErrorCategory.InvalidArgument);
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

        var pool = await conn.Client.StoragePoolDefineXmlAsync(xml, NotUsed, this.Cancellation!.Token).ConfigureAwait(false);

        var model = await StoragePoolUtility.GetPool(conn, pool, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(model);
    }

    private string NewPoolDir()
    {
        var pool = new Pool
        {
            Type = PoolType.Dir,
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
        var pool = new Pool
        {
            Type = PoolType.Disk,
            Name = this.Name,
            Source = new PoolSource
            {
                Device =
                [
                    new PoolSourceDevice
                    {
                        Path = this.DevicePath,
                    },
                ],
                Format = new PoolSourceFormat
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
        var pool = new Pool
        {
            Type = PoolType.Logical,
            Name = this.Name,
            Source = new PoolSource
            {
                Name = [this.VgName],
                Format = new PoolSourceFormat
                {
                    Type = PoolSourceFormatType.Lvm2,
                },
            },
            Target = new PoolTarget
            {
                Path = $"/dev/{this.VgName}",
            },
        };

        return Serializer.Serialize(pool);
    }

    private string NewPoolNetfs()
    {
        var pool = new Pool
        {
            Type = PoolType.Netfs,
            Name = this.Name,
            Source = new PoolSource
            {
                Host =
                [
                    new PoolSourcenetfsHost
                    {
                        Name = this.Address,
                    },
                ],
                Dir = new PoolSourceDir
                {
                    Path = this.ExportPath,
                },
                Format = new PoolSourceFormat
                {
                    Type = this.ExportType ?? PoolSourceFormatType.Auto,
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

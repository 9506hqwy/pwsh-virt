namespace PwshVirt;

using Libvirt.Model;

[OutputType(typeof(StorageVol))]
[Cmdlet(VerbsCommon.New, VerbsVirt.StorageVol)]
public class NewVirtStorageVol : PwshVirtCmdlet
{
    [Parameter]
    public string? Allocation { get; set; }

    [Parameter]
    public StorageVol? BackingVol { get; set; }

    [Parameter]
    public VolFormatType? BackingVolFormat { get; set; }

    [Parameter(Mandatory = true)]
    public string? Capacity { get; set; }

    [Parameter]
    public VolFormatType? Format { get; set; }

    [Parameter(Mandatory = true)]
    public string? Name { get; set; }

    [Parameter(Mandatory = true)]
    public StoragePool? Pool { get; set; }

    [Parameter]
    public SwitchParameter PreallocMetadata { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        try
        {
            await conn.Client.StorageVolLookupByNameAsync(this.Pool!.Self, this.Name, this.Cancellation!.Token);
            throw new PwshVirtException(ErrorCategory.InvalidArgument);
        }
        catch (VirtException e) when (e.Error.Code == 50)
        {
            // VIR_ERR_NO_STORAGE_VOL = 50
        }

        var schema = new Vol
        {
            Name = this.Name!,
            Capacity = new VolSizingCapacity
            {
                Value = this.GetCapacity(),
            },
            Target = new VolTarget(),
        };

        if (this.Allocation is not null)
        {
            schema.Allocation = new VolSizingAllocation
            {
                Value = this.GetAllocation(),
            };
        }

        if (this.Format.HasValue)
        {
            schema.Target.Format = new VolFormat
            {
                Type = this.Format.Value,
            };
        }

        if (this.BackingVol is not null)
        {
            schema.BackingStore = new VolBackingStore
            {
                Path = this.BackingVol.Key,
            };
        }

        if (this.BackingVolFormat.HasValue && schema.BackingStore is not null)
        {
            schema.BackingStore.Format = new VolFormat
            {
                Type = this.BackingVolFormat.Value,
            };
        }

        var xml = Serializer.Serialize(schema);

        uint flgas = 0;
        if (this.PreallocMetadata.IsPresent && this.PreallocMetadata.ToBool())
        {
            flgas |= 1;
        }

        var vol = await conn.Client.StorageVolCreateXmlAsync(this.Pool!.Self, xml, flgas, this.Cancellation!.Token);

        (var type, var _, var _) = await conn.Client.StorageVolGetInfoAsync(vol, this.Cancellation!.Token);

        var model = new StorageVol(conn, vol, type);

        this.SetResult(model);
    }

    private string GetAllocation()
    {
        return Utility.GetScaledSizeToBytes(this.Allocation!).ToString();
    }

    private string GetCapacity()
    {
        return Utility.GetScaledSizeToBytes(this.Capacity!).ToString();
    }
}

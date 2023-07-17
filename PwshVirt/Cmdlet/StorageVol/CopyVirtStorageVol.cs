namespace PwshVirt;

using System.Xml.Linq;
using System.Xml.XPath;
using static Libvirt.Header.VirStorageVolCreateFlags;

[OutputType(typeof(StorageVol))]
[Cmdlet(VerbsCommon.Copy, VerbsVirt.StorageVol)]
public class CopyVirtStorageVol : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    [Parameter(Mandatory = true)]
    public string? Name { get; set; }

    [Parameter]
    public SwitchParameter PreallocMetadata { get; set; }

    [Parameter]
    public SwitchParameter RefLink { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public StorageVol? Source { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var xml = await conn.Client.StorageVolGetXmlDescAsync(this.Source!.Self, NotUsed, this.Cancellation!.Token);

        using var reader = new StringReader(xml);

        var elem = XElement.Load(reader);

        var name = elem.XPathSelectElements("./name").FirstOrDefault();
        if (name is null)
        {
            throw new PwshVirtException(ErrorCategory.InvalidOperation);
        }

        name.Value = this.Name;

        var newXml = elem.ToString();

        var pool = await conn.Client.StoragePoolLookupByVolumeAsync(this.Source.Self, this.Cancellation.Token);

        uint flags = 0;

        if (this.PreallocMetadata.IsPresent && this.PreallocMetadata.ToBool())
        {
            flags |= (uint)VirStorageVolCreatePreallocMetadata;
        }

        if (this.RefLink.IsPresent && this.RefLink.ToBool())
        {
            flags |= (uint)VirStorageVolCreateReflink;
        }

        var newVol = await conn.Client.StorageVolCreateXmlFromAsync(pool, newXml, this.Source.Self, flags, this.Cancellation.Token);

        (var type, var _, var _) = await conn.Client.StorageVolGetInfoAsync(newVol, this.Cancellation!.Token);

        var model = new StorageVol(conn, newVol, type);

        this.SetResult(model);
    }
}

namespace PwshVirt;

using static Libvirt.Header.VirStorageVolDeleteFlags;

[OutputType(typeof(StorageVol))]
[Cmdlet(VerbsCommon.Remove, VerbsVirt.StorageVol)]
public class RemoveVirtStorageVol : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public StorageVol? Vol { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    [Parameter]
    public SwitchParameter WithSnapshot { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var flag = VirStorageVolDeleteNormal;
        if (this.WithSnapshot.IsPresent && this.WithSnapshot.ToBool())
        {
            flag |= VirStorageVolDeleteWithSnapshots;
        }

        await conn.Client.StorageVolDeleteAsync(this.Vol!.Self, (uint)flag, this.Cancellation!.Token).ConfigureAwait(false);

        this.SetResult(this.Vol);
    }
}

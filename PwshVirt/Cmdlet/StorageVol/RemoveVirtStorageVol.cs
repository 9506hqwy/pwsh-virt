namespace PwshVirt;

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

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        uint flag = 0;
        if (this.WithSnapshot.IsPresent && this.WithSnapshot.ToBool())
        {
            flag |= 2;
        }

        await conn.Client.StorageVolDeleteAsync(this.Vol!.Self, flag, this.Cancellation!.Token);

        this.SetResult(this.Vol);
    }
}

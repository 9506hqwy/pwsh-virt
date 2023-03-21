namespace PwshVirt;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.Remove, VerbsVirt.Domain)]
public class RemoveVirtDomain : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    [Parameter]
    public SwitchParameter WithCheckpointMetadata { get; set; }

    [Parameter]
    public SwitchParameter WithManagedSave { get; set; }

    [Parameter]
    public SwitchParameter WithNvram { get; set; }

    [Parameter]
    public SwitchParameter WithSnapshotMetadata { get; set; }

    [Parameter]
    public SwitchParameter WithTpm { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        uint flags = 0;

        if (this.WithManagedSave.IsPresent && this.WithManagedSave.ToBool())
        {
            flags |= 0x01;
        }

        if (this.WithSnapshotMetadata.IsPresent && this.WithSnapshotMetadata.ToBool())
        {
            flags |= 0x02;
        }

        if (this.WithNvram.IsPresent && this.WithNvram.ToBool())
        {
            flags |= 0x04;
        }

        if (this.WithCheckpointMetadata.IsPresent && this.WithCheckpointMetadata.ToBool())
        {
            flags |= 0x10;
        }

        if (this.WithTpm.IsPresent && this.WithTpm.ToBool())
        {
            flags |= 0x20;
        }

        await conn.Client.DomainUndefineFlagsAsync(this.Domain!.Self, flags, this.Cancellation!.Token);

        this.SetResult(this.Domain);
    }
}

namespace PwshVirt;

using static Libvirt.Header.VirDomainUndefineFlagsValues;

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

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        uint flags = 0;

        if (this.WithManagedSave.IsPresent && this.WithManagedSave.ToBool())
        {
            flags |= (uint)VirDomainUndefineManagedSave;
        }

        if (this.WithSnapshotMetadata.IsPresent && this.WithSnapshotMetadata.ToBool())
        {
            flags |= (uint)VirDomainUndefineSnapshotsMetadata;
        }

        if (this.WithNvram.IsPresent && this.WithNvram.ToBool())
        {
            flags |= (uint)VirDomainUndefineNvram;
        }

        if (this.WithCheckpointMetadata.IsPresent && this.WithCheckpointMetadata.ToBool())
        {
            flags |= (uint)VirDomainUndefineCheckpointsMetadata;
        }

        if (this.WithTpm.IsPresent && this.WithTpm.ToBool())
        {
            flags |= (uint)VirDomainUndefineTpm;
        }

        await conn.Client.DomainUndefineFlagsAsync(this.Domain!.Self, flags, this.Cancellation!.Token);

        this.SetResult(this.Domain);
    }
}

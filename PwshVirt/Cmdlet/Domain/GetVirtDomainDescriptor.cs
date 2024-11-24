namespace PwshVirt;

using static Libvirt.Header.VirDomainXmlflags;

[OutputType(typeof(string))]
[Cmdlet(VerbsCommon.Get, VerbsVirt.DomainDescriptor)]
public class GetVirtDomainDescriptor : PwshVirtCmdlet
{
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Domain { get; set; }

    [Parameter]
    public SwitchParameter Inactive { get; set; }

    [Parameter]
    public SwitchParameter Migratable { get; set; }

    [Parameter]
    public SwitchParameter Secure { get; set; }

    [Parameter]
    public SwitchParameter UpdateCpu { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        uint flag = 0;

        if (this.Secure.IsPresent && this.Secure.ToBool())
        {
            flag |= (uint)VirDomainXmlSecure;
        }

        if (this.Inactive.IsPresent && this.Inactive.ToBool())
        {
            flag |= (uint)VirDomainXmlInactive;
        }

        if (this.UpdateCpu.IsPresent && this.UpdateCpu.ToBool())
        {
            flag |= (uint)VirDomainXmlUpdateCpu;
        }

        if (this.Migratable.IsPresent && this.Migratable.ToBool())
        {
            flag |= (uint)VirDomainXmlMigratable;
        }

        var xml = await conn.Client.DomainGetXmlDescAsync(this.Domain!.Self, flag, this.Cancellation!.Token);

        this.SetResult(xml);
    }
}

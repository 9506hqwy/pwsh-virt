namespace PwshVirt;

using static Libvirt.Header.VirDomainState;
using static Libvirt.Header.VirDomainXmlflags;
using static Libvirt.Header.VirStorageVolDeleteFlags;
using System.Globalization;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.Copy, VerbsVirt.Domain)]
public class CopyVirtDomain : PwshVirtCmdlet
{
    private const uint NotUsed = 0;

    private readonly List<RemoteNonnullStorageVol> clonedVols = [];

    [Parameter(Mandatory = true)]
    public string? Name { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Source { get; set; }

    internal override async Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var srcDom = await DomainUtility.GetDomain(conn, this.Source!.Name, -1, 0, this.Cancellation!.Token).ConfigureAwait(false);
        if (srcDom.Status != VirDomainShutoff)
        {
            throw new PwshVirtException(
                string.Format(CultureInfo.CurrentCulture, Resource.ERR_ShouldPowerOffDomain, srcDom.Name),
                ErrorCategory.InvalidOperation);
        }

        var srcXml = await conn.Client.DomainGetXmlDescAsync(this.Source.Self, (uint)VirDomainXmlInactive, this.Cancellation.Token).ConfigureAwait(false);

        var newModel = Serializer.Deserialize<Libvirt.Model.Domain>(srcXml);

        this.InitDomain(newModel);

        try
        {
            await this.CopyDisks(conn, newModel, srcDom.Name).ConfigureAwait(false);

            var newXml = Serializer.Serialize(newModel);

            var newDom = await conn.Client.DomainDefineXmlAsync(newXml, this.Cancellation!.Token).ConfigureAwait(false);

            var model = await DomainUtility.GetDomain(conn, newDom.Name, -1, 0, this.Cancellation!.Token).ConfigureAwait(false);

            this.SetResult(model);
        }
        catch
        {
            await this.DeleteDisks(conn).ConfigureAwait(false);

            throw;
        }
    }

    private async Task<RemoteNonnullStorageVol> CopyDisk(Connection conn, Libvirt.Model.DomainDisk disk, string srcDomName)
    {
        var srcVol = await conn.Client.StorageVolLookupByKeyAsync(disk.Source.File, this.Cancellation!.Token).ConfigureAwait(false);
        var srcXml = await conn.Client.StorageVolGetXmlDescAsync(srcVol, NotUsed, this.Cancellation!.Token).ConfigureAwait(false);
        var srcPool = await conn.Client.StoragePoolLookupByVolumeAsync(srcVol, this.Cancellation.Token).ConfigureAwait(false);

        var model = Serializer.Deserialize<Libvirt.Model.Vol>(srcXml);
#pragma warning disable CA1307 // for .Net Standard 2.0 compatibility
        if (!model.Name.Contains(srcDomName))
#pragma warning restore CA1307
        {
            throw new PwshVirtException(
                string.Format(CultureInfo.CurrentCulture, Resource.ERR_CopyVirtDomain_ShouldContainDomainNameInDisk, model.Name),
                ErrorCategory.InvalidOperation);
        }

#pragma warning disable CA1307 // for .Net Standard 2.0 compatibility
        model.Name = model.Name.Replace(srcDomName, this.Name);
#pragma warning restore CA1307
        var dstXml = Serializer.Serialize(model);

        var dstVol = await conn.Client.StorageVolCreateXmlFromAsync(srcPool, dstXml, srcVol, 0, this.Cancellation.Token).ConfigureAwait(false);

        disk.Source.File = dstVol.Key;

        return dstVol;
    }

    private async Task CopyDisks(Connection conn, Libvirt.Model.Domain model, string srcDomName)
    {
        var disks = model.Devices?.Disk;
        if (disks is null)
        {
            return;
        }

        foreach (var disk in disks.Where(d => d.Device == Libvirt.Model.DomainDiskDevice.Disk))
        {
            var vol = await this.CopyDisk(conn, disk, srcDomName).ConfigureAwait(false);
            this.clonedVols.Add(vol);
        }
    }

    private async Task DeleteDisk(Connection conn, RemoteNonnullStorageVol vol)
    {
        await conn.Client.StorageVolDeleteAsync(vol, (uint)VirStorageVolDeleteNormal, this.Cancellation!.Token).ConfigureAwait(false);
    }

    private async Task DeleteDisks(Connection conn)
    {
        foreach (var vol in this.clonedVols)
        {
            await this.DeleteDisk(conn, vol).ConfigureAwait(false);
        }
    }

    private static void InitChannel(Libvirt.Model.Domain model)
    {
        var channels = model.Devices?.Channel;
        if (channels is null)
        {
            return;
        }

        foreach (var channel in channels)
        {
            if (channel.Type == Libvirt.Model.QemucdevSrcTypeChoice.Unix)
            {
                if (channel.Source is null)
                {
                    continue;
                }

                foreach (var source in channel.Source)
                {
                    source.Path = null;
                }
            }
        }
    }

    private void InitDomain(Libvirt.Model.Domain model)
    {
        model.Id = 0;
        model.Name = this.Name!;
        model.Title = null;
        model.Uuid = null;

        InitGraphics(model);
        InitMacAddress(model);
        InitChannel(model);
        InitNvram(model);
    }

    private static void InitGraphics(Libvirt.Model.Domain model)
    {
        var graphicses = model.Devices?.Graphics;
        if (graphicses is null)
        {
            return;
        }

        foreach (var graphics in graphicses)
        {
            if (graphics.PortSpecified)
            {
                graphics.Port = -1;
            }
        }
    }

    private static void InitMacAddress(Libvirt.Model.Domain model)
    {
        var ifaces = model.Devices?.Interface;
        if (ifaces is null)
        {
            return;
        }

        foreach (var iface in ifaces)
        {
            iface.Mac = null;
        }
    }

    private static void InitNvram(Libvirt.Model.Domain model)
    {
        var nvram = model.Os.Nvram;
        if (nvram is null)
        {
            return;
        }

        nvram.Source.Dev = null;
        nvram.Source.Dir = null;
        nvram.Source.File = null;
    }
}

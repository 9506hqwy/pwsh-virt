﻿namespace PwshVirt;

[OutputType(typeof(Domain))]
[Cmdlet(VerbsCommon.Copy, VerbsVirt.Domain)]
public class CopyVirtDomain : PwshVirtCmdlet
{
    private List<RemoteNonnullStorageVol> clonedVols = new List<RemoteNonnullStorageVol>();

    [Parameter(Mandatory = true)]
    public string? Name { get; set; }

    [Parameter]
    public Connection? Server { get; set; }

    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Domain? Source { get; set; }

    internal async override Task Execute()
    {
        var conn = this.GetConnection(this.Server, out var _);

        var srcDom = await DomainUtility.GetDomain(conn, this.Source!.Name, (int)DomainState.Last, 0, this.Cancellation!.Token);
        if (srcDom.Status != DomainState.Shutoff)
        {
            throw new PwshVirtException(ErrorCategory.InvalidOperation);
        }

        var srcXml = await conn.Client.DomainGetXmlDescAsync(this.Source.Self, 0x02, this.Cancellation.Token);

        var newModel = Serializer.Deserialize<Libvirt.Model.Domain>(srcXml);

        this.InitDomain(newModel);

        try
        {
            await this.CopyDisks(conn, newModel, srcDom.Name);

            var newXml = Serializer.Serialize(newModel);

            var newDom = await conn.Client.DomainDefineXmlAsync(newXml, this.Cancellation!.Token);

            var model = await DomainUtility.GetDomain(conn, newDom.Name, (int)DomainState.Last, 0, this.Cancellation!.Token);

            this.SetResult(model);
        }
        catch
        {
            await this.DeleteDisks(conn);

            throw;
        }
    }

    private async Task<RemoteNonnullStorageVol> CopyDisk(Connection conn, Libvirt.Model.DomainDisk disk, string srcDomName)
    {
        var srcVol = await conn.Client.StorageVolLookupByKeyAsync(disk.Source.File, this.Cancellation!.Token);
        var srcXml = await conn.Client.StorageVolGetXmlDescAsync(srcVol, 0, this.Cancellation!.Token);
        var srcPool = await conn.Client.StoragePoolLookupByVolumeAsync(srcVol, this.Cancellation.Token);

        var model = Serializer.Deserialize<Libvirt.Model.Vol>(srcXml);
        if (!model.Name.Contains(srcDomName))
        {
            throw new PwshVirtException(ErrorCategory.InvalidOperation);
        }

        model.Name = model.Name.Replace(srcDomName, this.Name);
        var dstXml = Serializer.Serialize(model);

        var dstVol = await conn.Client.StorageVolCreateXmlFromAsync(srcPool, dstXml, srcVol, 0, this.Cancellation.Token);

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

        foreach (var disk in disks)
        {
            var vol = await this.CopyDisk(conn, disk, srcDomName);
            this.clonedVols.Add(vol);
        }
    }

    private async Task DeleteDisk(Connection conn, RemoteNonnullStorageVol vol)
    {
        await conn.Client.StorageVolDeleteAsync(vol, 0, this.Cancellation!.Token);
    }

    private async Task DeleteDisks(Connection conn)
    {
        foreach (var vol in this.clonedVols)
        {
            await this.DeleteDisk(conn, vol);
        }
    }

    private void InitChannel(Libvirt.Model.Domain model)
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

        this.InitGraphics(model);
        this.InitMacAddress(model);
        this.InitChannel(model);
        this.InitNvram(model);
    }

    private void InitGraphics(Libvirt.Model.Domain model)
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

    private void InitMacAddress(Libvirt.Model.Domain model)
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

    private void InitNvram(Libvirt.Model.Domain model)
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
---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# New-VirtStoragePool

## SYNOPSIS
Create storage pool.

## SYNTAX

### Dir (Default)
```
New-VirtStoragePool -Name <String> -Path <String> [-Server <Connection>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Netfs
```
New-VirtStoragePool -Address <String> [-ExportType <PoolSourceFormatType>] -ExportPath <String> -Name <String>
 -Path <String> [-Server <Connection>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Disk
```
New-VirtStoragePool [-DeviceFormat <PoolSourceFormatType>] -DevicePath <String> -Name <String> -Path <String>
 [-Server <Connection>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Logical
```
New-VirtStoragePool -Name <String> [-Server <Connection>] -VgName <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create storage pool.

## EXAMPLES

### Example 1
```powershell
PS C:\> # create storage pool by specified name.
PS C:\> New-VirtStoragePool -Name 'PoolName' -Path '/var/lib/libvirt/images'
```

## PARAMETERS

### -Address
Specify address of remote host.

```yaml
Type: String
Parameter Sets: Netfs
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceFormat
Specify format of device.

```yaml
Type: PoolSourceFormatType
Parameter Sets: Disk
Aliases:
Accepted values: Auto, Bsd, Cifs, Dos, Dvh, Ext2, Ext3, Ext4, Gfs, Gfs2, Glusterfs, Gpt, HfsPlus, Iso9660, Lvm2, Mac, Nfs, Ocfs2, Pc98, Sun, Udf, Ufs, Unknown, Vfat, Vmfs, Xfs

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevicePath
Specify device file path.

```yaml
Type: String
Parameter Sets: Disk
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportPath
Specify path of remote host.

```yaml
Type: String
Parameter Sets: Netfs
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportType
Specify path type of remote host.

```yaml
Type: PoolSourceFormatType
Parameter Sets: Netfs
Aliases:
Accepted values: Auto, Bsd, Cifs, Dos, Dvh, Ext2, Ext3, Ext4, Gfs, Gfs2, Glusterfs, Gpt, HfsPlus, Iso9660, Lvm2, Mac, Nfs, Ocfs2, Pc98, Sun, Udf, Ufs, Unknown, Vfat, Vmfs, Xfs

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specify name of storage pool.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Specify local path.

```yaml
Type: String
Parameter Sets: Dir, Netfs, Disk
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Server
Specify session.
If omitted, use $DefaultVirtServer.

```yaml
Type: Connection
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VgName
Specify volume group of LVM.

```yaml
Type: String
Parameter Sets: Logical
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### PwshVirt.StoragePool

## NOTES

## RELATED LINKS

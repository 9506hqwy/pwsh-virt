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
New-VirtStoragePool -Name <String> -Path <String> [-Server <Connection>] [<CommonParameters>]
```

### Netfs
```
New-VirtStoragePool -Address <String> [-ExportType <PoolSourcefmtnetfsType>] -ExportPath <String>
 -Name <String> -Path <String> [-Server <Connection>] [<CommonParameters>]
```

### Disk
```
New-VirtStoragePool [-DeviceFormat <PoolSourcefmtdiskType>] -DevicePath <String> -Name <String> -Path <String>
 [-Server <Connection>] [<CommonParameters>]
```

### Logical
```
New-VirtStoragePool -Name <String> [-Server <Connection>] -VgName <String> [<CommonParameters>]
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
Type: PoolSourcefmtdiskType
Parameter Sets: Disk
Aliases:
Accepted values: Unknown, Dos, Dvh, Gpt, Mac, Bsd, Pc98, Sun, Lvm2

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
Type: PoolSourcefmtnetfsType
Parameter Sets: Netfs
Aliases:
Accepted values: Auto, Nfs, Cifs, Glusterfs

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### PwshVirt.StoragePool

## NOTES

## RELATED LINKS

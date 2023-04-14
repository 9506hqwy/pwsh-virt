---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# New-VirtHardDisk

## SYNOPSIS
Add hard disk to domain.

## SYNTAX

```
New-VirtHardDisk -DeviceFile <String> -Domain <Domain> [-Driver <String>]
 [-DriverType <DomainDevicesDiskDiskDriverType>] -Vol <StorageVol> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Add hard disk to domain.

## EXAMPLES

### Example 1
```powershell
PS C:\> # add hard disk to specified domain.
PS C:\> New-VirtHardDisk -Domain $dom －Vol $vol -DeviceFile 'vda'
```

## PARAMETERS

### -DeviceFile
Specify device file.

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

### -Domain
Specify domain.

```yaml
Type: Domain
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Driver
Specify driver.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DriverType
Specify driver type.

```yaml
Type: DomainDevicesDiskDiskDriverType
Parameter Sets: (All)
Aliases:
Accepted values: Aio, Bochs, Cloop, Cow, Dir, Dmg, Fat, Iso, Luks, Ploop, Qcow, Qcow2, Qed, Raw, Vdi, Vhd, Vmdk, Vpc

Required: False
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

### -Vol
Specify storage volume.

```yaml
Type: StorageVol
Parameter Sets: (All)
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

### PwshVirt.Domain

## OUTPUTS

### PwshVirt.Domain

## NOTES

## RELATED LINKS

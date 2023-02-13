---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# New-VirtStorageVol

## SYNOPSIS
Create storage volume.

## SYNTAX

```
New-VirtStorageVol [-Allocation <String>] [-BackingVol <StorageVol>] [-BackingVolFormat <VolFormatType>]
 -Capacity <String> [-Format <VolFormatType>] -Name <String> -Pool <StoragePool> [-PreallocMetadata]
 [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Create storage volume.

## EXAMPLES

### Example 1
```powershell
PS C:\> # create storage volume by specified name.
PS C:\> New-VirtStorageVol -Name 'VolumeName' -Capacity 10G -Pool $pool
```

## PARAMETERS

### -Allocation
Specify allocation size.

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

### -BackingVol
Specify backing storage volume.

```yaml
Type: StorageVol
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackingVolFormat
Specify format of backing storage volume.

```yaml
Type: VolFormatType
Parameter Sets: (All)
Aliases:
Accepted values: Unknown, Raw, Dir, Bochs, Cloop, Dmg, Iso, Vpc, Vdi, Fat, Vhd, Ploop, Luks, Cow, Qcow, Qcow2, Qed, Vmdk, None, Auto, Ext2, Ext3, Ext4, Ufs, Iso9660, Udf, Gfs, Gfs2, Vfat, HfsPlus, Xfs, Ocfs2, Vmfs, Linux, Fat16, Fat32, LinuxSwap, LinuxLvm, LinuxRaid, Extended

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Capacity
Specify capacity of storage volume.

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

### -Format
Specify format of storage volume.

```yaml
Type: VolFormatType
Parameter Sets: (All)
Aliases:
Accepted values: Unknown, Raw, Dir, Bochs, Cloop, Dmg, Iso, Vpc, Vdi, Fat, Vhd, Ploop, Luks, Cow, Qcow, Qcow2, Qed, Vmdk, None, Auto, Ext2, Ext3, Ext4, Ufs, Iso9660, Udf, Gfs, Gfs2, Vfat, HfsPlus, Xfs, Ocfs2, Vmfs, Linux, Fat16, Fat32, LinuxSwap, LinuxLvm, LinuxRaid, Extended

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specify name of storage volume.

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

### -Pool
Specify storage pool.

```yaml
Type: StoragePool
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreallocMetadata
Allocate metadata.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### PwshVirt.StorageVol

## NOTES

## RELATED LINKS

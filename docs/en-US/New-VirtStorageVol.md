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
New-VirtStorageVol [-Allocation <String>] [-BackingVol <StorageVol>] [-BackingVolFormat <VolTargetFormatType>]
 -Capacity <String> [-Format <VolTargetFormatType>] -Name <String> -Pool <StoragePool> [-PreallocMetadata]
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
Type: VolTargetFormatType
Parameter Sets: (All)
Aliases:
Accepted values: Auto, Bochs, Cloop, Cow, Dir, Dmg, Ext2, Ext3, Ext4, Extended, Fat, Fat16, Fat32, Gfs, Gfs2, HfsPlus, Iso, Iso9660, Linux, LinuxLvm, LinuxRaid, LinuxSwap, Luks, None, Ocfs2, Ploop, Qcow, Qcow2, Qed, Raw, Udf, Ufs, Unknown, Vdi, Vfat, Vhd, Vmdk, Vmfs, Vpc, Xfs

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
Type: VolTargetFormatType
Parameter Sets: (All)
Aliases:
Accepted values: Auto, Bochs, Cloop, Cow, Dir, Dmg, Ext2, Ext3, Ext4, Extended, Fat, Fat16, Fat32, Gfs, Gfs2, HfsPlus, Iso, Iso9660, Linux, LinuxLvm, LinuxRaid, LinuxSwap, Luks, None, Ocfs2, Ploop, Qcow, Qcow2, Qed, Raw, Udf, Ufs, Unknown, Vdi, Vfat, Vhd, Vmdk, Vmfs, Vpc, Xfs

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

---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# New-VirtStorageVol

## SYNOPSIS
ストレージボリュームを作成します。

## SYNTAX

```
New-VirtStorageVol [-Allocation <String>] [-BackingVol <StorageVol>] [-BackingVolFormat <VolTargetFormatType>]
 -Capacity <String> [-Format <VolTargetFormatType>] -Name <String> -Pool <StoragePool> [-PreallocMetadata]
 [-Server <Connection>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
ストレージボリュームを作成します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定した名前のストレージボリュームを作成します。
PS C:\> New-VirtStorageVol -Name 'VolumeName' -Capacity 10G -Pool $pool
```

## PARAMETERS

### -Allocation
ストレージボリュームの割り当てサイズを指定します。

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
バッキングストレージボリュームを指定します。

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
バッキングストレージボリュームの形式を指定します。

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
ストレージボリュームの容量を指定します。

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
ストレージボリュームの形式を指定します。

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
作成するストレージボリュームの名前を指定します。

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
ストレージプールを指定します。

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
メタデータを事前に割り当てます。

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
セッションを指定します。
省略した場合は $DefaultVirtServer を使用します。

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

### PwshVirt.StorageVol

## NOTES

## RELATED LINKS

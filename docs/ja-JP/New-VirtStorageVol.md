---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# New-VirtStorageVol

## SYNOPSIS

ストレージボリュームを作成します。

## SYNTAX

### Default (Default)

```
New-VirtStorageVol -Capacity <String> -Name <String> -Pool <StoragePool> [-Allocation <String>]
 [-BackingVol <StorageVol>] [-BackingVolFormat <VolTargetFormatType>]
 [-Format <VolTargetFormatType>] [-PreallocMetadata] [-Server <Connection>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### __AllParameterSets

```
New-VirtStorageVol -Capacity <string> -Name <string> -Pool <StoragePool> [-Allocation <string>]
 [-BackingVol <StorageVol>] [-BackingVolFormat <VolTargetFormatType>]
 [-Format <VolTargetFormatType>] [-PreallocMetadata] [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

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
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -BackingVol

バッキングストレージボリュームを指定します。

```yaml
Type: PwshVirt.StorageVol
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -BackingVolFormat

バッキングストレージボリュームの形式を指定します。

```yaml
Type: System.Nullable`1[Libvirt.Model.VolTargetFormatType]
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues:
- Auto
- Bochs
- Cloop
- Cow
- Dir
- Dmg
- Ext2
- Ext3
- Ext4
- Extended
- Fat
- Fat16
- Fat32
- Gfs
- Gfs2
- HfsPlus
- Iso
- Iso9660
- Linux
- LinuxLvm
- LinuxRaid
- LinuxSwap
- Luks
- None
- Ocfs2
- Ploop
- Qcow
- Qcow2
- Qed
- Raw
- Udf
- Ufs
- Unknown
- Vdi
- Vfat
- Vhd
- Vmdk
- Vmfs
- Vpc
- Xfs
HelpMessage: ''
```

### -Capacity

ストレージボリュームの容量を指定します。

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Format

ストレージボリュームの形式を指定します。

```yaml
Type: System.Nullable`1[Libvirt.Model.VolTargetFormatType]
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues:
- Auto
- Bochs
- Cloop
- Cow
- Dir
- Dmg
- Ext2
- Ext3
- Ext4
- Extended
- Fat
- Fat16
- Fat32
- Gfs
- Gfs2
- HfsPlus
- Iso
- Iso9660
- Linux
- LinuxLvm
- LinuxRaid
- LinuxSwap
- Luks
- None
- Ocfs2
- Ploop
- Qcow
- Qcow2
- Qed
- Raw
- Udf
- Ufs
- Unknown
- Vdi
- Vfat
- Vhd
- Vmdk
- Vmfs
- Vpc
- Xfs
HelpMessage: ''
```

### -Name

作成するストレージボリュームの名前を指定します。

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Pool

ストレージプールを指定します。

```yaml
Type: PwshVirt.StoragePool
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -PreallocMetadata

メタデータを事前に割り当てます。

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ProgressAction

{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
DefaultValue: None
SupportsWildcards: false
Aliases:
- proga
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Server

セッションを指定します。
省略した場合は $DefaultVirtServer を使用します。

```yaml
Type: PwshVirt.Connection
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### PwshVirt.StorageVol

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


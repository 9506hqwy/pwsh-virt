---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# New-VirtStorageVol

## SYNOPSIS

Create storage volume.

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

Specify backing storage volume.

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

Specify format of backing storage volume.

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

Specify capacity of storage volume.

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

Specify format of storage volume.

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

Specify name of storage volume.

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

Specify storage pool.

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

Allocate metadata.

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

Specify session.
If omitted, use $DefaultVirtServer.

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


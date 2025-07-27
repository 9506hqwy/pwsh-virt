---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# New-VirtStoragePool

## SYNOPSIS

Create storage pool.

## SYNTAX

### Dir (Default)

```
New-VirtStoragePool -Name <string> -Path <string> [-Server <Connection>] [<CommonParameters>]
```

### Netfs

```
New-VirtStoragePool -Address <string> -ExportPath <string> -Name <string> -Path <string>
 [-ExportType <PoolSourceFormatType>] [-Server <Connection>] [<CommonParameters>]
```

### Disk

```
New-VirtStoragePool -DevicePath <string> -Name <string> -Path <string>
 [-DeviceFormat <PoolSourceFormatType>] [-Server <Connection>] [<CommonParameters>]
```

### Logical

```
New-VirtStoragePool -Name <string> -VgName <string> [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

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
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Netfs
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -DeviceFormat

Specify format of device.

```yaml
Type: Libvirt.Model.PoolSourceFormatType
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Disk
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues:
- Auto
- Bsd
- Cifs
- Dos
- Dvh
- Ext2
- Ext3
- Ext4
- Gfs
- Gfs2
- Glusterfs
- Gpt
- HfsPlus
- Iso9660
- Lvm2
- Mac
- Nfs
- Ocfs2
- Pc98
- Sun
- Udf
- Ufs
- Unknown
- Vfat
- Vmfs
- Xfs
HelpMessage: ''
```

### -DevicePath

Specify device file path.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Disk
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ExportPath

Specify path of remote host.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Netfs
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ExportType

Specify path type of remote host.

```yaml
Type: System.Nullable`1[Libvirt.Model.PoolSourceFormatType]
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Netfs
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues:
- Auto
- Bsd
- Cifs
- Dos
- Dvh
- Ext2
- Ext3
- Ext4
- Gfs
- Gfs2
- Glusterfs
- Gpt
- HfsPlus
- Iso9660
- Lvm2
- Mac
- Nfs
- Ocfs2
- Pc98
- Sun
- Udf
- Ufs
- Unknown
- Vfat
- Vmfs
- Xfs
HelpMessage: ''
```

### -Name

Specify name of storage pool.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Dir
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Disk
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Logical
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Netfs
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Path

Specify local path.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Dir
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Disk
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Netfs
  Position: Named
  IsRequired: true
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
- Name: Dir
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Disk
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Logical
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Netfs
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -VgName

Specify volume group of LVM.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Logical
  Position: Named
  IsRequired: true
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

### PwshVirt.StoragePool

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


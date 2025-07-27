---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# New-VirtStoragePool

## SYNOPSIS

ストレージプールを作成します。

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

ストレージプールを作成します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # 指定した名前のストレージプールを作成します。
PS C:\> New-VirtStoragePool -Name 'PoolName' -Path '/var/lib/libvirt/images'
```

## PARAMETERS

### -Address

リモートホストのアドレスを指定します。

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

デバイスの形式を指定します。

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

デバイスファイルのパスを指定します。

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

リモートホストの公開パスを指定します。

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

リモートホストの公開パスの種別を指定します。

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

ストレージプールの名前を指定します。

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

ローカルホストのパスを指定します。

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

セッションを指定します。
省略した場合は $DefaultVirtServer を使用します。

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

LVM のボリュームグループを指定します。

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


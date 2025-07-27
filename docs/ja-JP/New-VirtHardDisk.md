---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# New-VirtHardDisk

## SYNOPSIS

ドメインにハードディスクを追加します。

## SYNTAX

### Default (Default)

```
New-VirtHardDisk -DeviceFile <String> -Domain <Domain> -Vol <StorageVol> [-Driver <String>]
 [-DriverType <DomainDiskDriverType>] [-Server <Connection>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### __AllParameterSets

```
New-VirtHardDisk -DeviceFile <string> -Domain <Domain> -Vol <StorageVol> [-Driver <string>]
 [-DriverType <DomainDiskDriverType>] [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ドメインにハードディスクを追加します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # 指定したドメインにハードディスクを追加します。
PS C:\> New-VirtHardDisk -Domain $dom -Vol $vol -DeviceFile 'vda'
```

## PARAMETERS

### -DeviceFile

デバイスファイルを指定します。

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

### -Domain

ドメインを指定します。

```yaml
Type: PwshVirt.Domain
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Driver

ドライバを指定します。

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

### -DriverType

ドライバの種別を指定します。

```yaml
Type: System.Nullable`1[Libvirt.Model.DomainDiskDriverType]
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
- Aio
- Bochs
- Cloop
- Cow
- Dir
- Dmg
- Fat
- Iso
- Luks
- Ploop
- Qcow
- Qcow2
- Qed
- Raw
- Vdi
- Vhd
- Vmdk
- Vpc
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

### -Vol

ストレージボリュームを指定します。

```yaml
Type: PwshVirt.StorageVol
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

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PwshVirt.Domain

## OUTPUTS

### PwshVirt.Domain

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


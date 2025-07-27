---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Set-VirtCdDrive

## SYNOPSIS

ドメインの光学ドライブを更新します。

## SYNTAX

### Insert (Default)

```
Set-VirtCdDrive -Drive <CdDrive> [-IsoPath <string>] [-Server <Connection>] [<CommonParameters>]
```

### Eject

```
Set-VirtCdDrive -Drive <CdDrive> [-Eject] [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ドメインの光学ドライブを更新します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # 指定した名前のドメインの光学ドライブに ISO ファイルをマウントします。
PS C:\> Get-VirtDomain -Name 'DomainName' | Get-VirtCdDrive | Set-VirtCdDrive -IsoPath /root/media.iso
```

### Example 2

```powershell
PS C:\> # 指定した名前のドメインの光学ドライブから ISO ファイルをアンマウントします。
PS C:\> Get-VirtDomain -Name 'DomainName' | Get-VirtCdDrive | Set-VirtCdDrive -Eject
```

## PARAMETERS

### -Drive

光学ドライブを指定します。

```yaml
Type: PwshVirt.CdDrive
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Eject
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Insert
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Eject

ISO ファイルを取り出します。

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Eject
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -IsoPath

ISO ファイルのパスを指定します。

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Insert
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
- Name: Eject
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Insert
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

### PwshVirt.CdDrive

## OUTPUTS

### PwshVirt.Domain

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


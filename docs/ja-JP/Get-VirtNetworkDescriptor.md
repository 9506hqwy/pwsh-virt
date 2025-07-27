---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Get-VirtNetworkDescriptor

## SYNOPSIS

ネットワークの XML 記述を取得します。

## SYNTAX

### Default (Default)

```
Get-VirtNetworkDescriptor -Network <Network> [-Server <Connection>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### __AllParameterSets

```
Get-VirtNetworkDescriptor -Network <Network> [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ネットワークの XML 記述を取得します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # 指定した名前のネットワークの XML 記述を取得します。
PS C:\> Get-VirtNetwork -Name 'NetworkName' | Get-VirtNetworkDescriptor
```

## PARAMETERS

### -Network

ネットワークを指定します。

```yaml
Type: PwshVirt.Network
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

### PwshVirt.Network

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


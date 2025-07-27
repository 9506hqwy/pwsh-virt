---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Remove-VirtNetworkInterface

## SYNOPSIS

ネットワークインターフェイスを削除します。

## SYNTAX

### Default (Default)

```
Remove-VirtNetworkInterface -Interface <NetworkInterface> [-Server <Connection>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### __AllParameterSets

```
Remove-VirtNetworkInterface -Interface <NetworkInterface> [-Server <Connection>]
 [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ネットワークインターフェイスを削除します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # $iface を削除します。
PS C:\> Remove-VirtNetworkInterface -Interface $iface
```

## PARAMETERS

### -Interface

対象のネットワークインターフェイスを指定します。

```yaml
Type: PwshVirt.NetworkInterface
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

### PwshVirt.NetworkInterface

## OUTPUTS

### PwshVirt.NetworkInterface

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


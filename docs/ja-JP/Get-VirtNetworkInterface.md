---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Get-VirtNetworkInterface

## SYNOPSIS

ネットワークインターフェイスを取得します。

## SYNTAX

### All (Default)

```
Get-VirtNetworkInterface [-Server <Connection>] [<CommonParameters>]
```

### Name

```
Get-VirtNetworkInterface -Name <string> [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ネットワークインターフェイスを取得します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # すべてのネットワークインターフェイスを取得します。
PS C:\> Get-VirtNetworkInterface
```

### Example 2

```powershell
PS C:\> # 指定した名前のネットワークインターフェイスを取得します。
PS C:\> Get-VirtNetworkInterface -Name 'InterfaceName'
```

## PARAMETERS

### -Name

インターフェイスの名前を指定します。

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Name
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
- Name: All
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Name
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

### PwshVirt.NetworkInterface

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


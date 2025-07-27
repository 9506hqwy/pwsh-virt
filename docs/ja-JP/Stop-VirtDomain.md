---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Stop-VirtDomain

## SYNOPSIS

ドメインを停止します。

## SYNTAX

### PowerOff (Default)

```
Stop-VirtDomain -Domain <Domain> [-Server <Connection>] [<CommonParameters>]
```

### Hibernate

```
Stop-VirtDomain -Domain <Domain> -Hibernate [-BypassCache] [-Paused] [-Running]
 [-Server <Connection>] [<CommonParameters>]
```

### Shutdown

```
Stop-VirtDomain -Domain <Domain> -Shutdown [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ドメインを停止します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # 指定した名前のドメインを停止します。
PS C:\> Get-VirtDomain -Name 'DomainName' | Stop-VirtDomain
```

### Example 2

```powershell
PS C:\> # 指定した名前のドメインをシャットダウンします。
PS C:\> Get-VirtDomain -Name 'DomainName' | Stop-VirtDomain -Shutdown
```

## PARAMETERS

### -BypassCache

ドメインの状態をファイルに出力するときにファイルシステムキャッシュを回避します。

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Hibernate
  Position: Named
  IsRequired: false
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
- Name: Hibernate
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: PowerOff
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Shutdown
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Hibernate

ドメインの状態をファイルに出力します。

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Hibernate
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Paused

ドメインの状態を復元するときに一時停止状態にします。

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Hibernate
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

### -Running

ドメインの状態を復元するときに起動状態にします。

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Hibernate
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
- Name: Hibernate
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: PowerOff
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Shutdown
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Shutdown

ゲスト OS をシャットダウンします。

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Shutdown
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


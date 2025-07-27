---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Copy-VirtDomain

## SYNOPSIS

Copy domain.

## SYNTAX

### Default (Default)

```
Copy-VirtDomain -Name <String> -Source <Domain> [-Server <Connection>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### __AllParameterSets

```
Copy-VirtDomain -Name <string> -Source <Domain> [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

Copy domain.

## EXAMPLES

### Example 1

```powershell
PS C:\> # copy domain by specified name.
PS C:\> Get-VirtDomain -Name 'DomainName' | Copy-VirtDomain -Name 'NewName'
```

## PARAMETERS

### -Name

Specify name of destination domain.

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

### -Source

Specify source domain.

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

- Only file type disk support.

## RELATED LINKS

{{ Fill in the related links here }}


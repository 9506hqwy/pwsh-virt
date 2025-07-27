---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Watch-VirtStoragePool

## SYNOPSIS

Watch storage pool lifecycle event.

## SYNTAX

### Default (Default)

```
Watch-VirtStoragePool [-Pool <StoragePool>] [-Server <Connection>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### __AllParameterSets

```
Watch-VirtStoragePool [-Pool <StoragePool>] [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

Watch storage pool lifecycle event.

## EXAMPLES

### Example 1

```powershell
PS C:\> # watch storage pool lifecycle event by specified pool.
PS C:\> Watch-VirtStoragePool -Pool $pool
```

## PARAMETERS

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

### Binding.IVirtEvent

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


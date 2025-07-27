---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Disconnect-VirtServer

## SYNOPSIS

Disconnect from the Libvirt server.

## SYNTAX

### Default (Default)

```
Disconnect-VirtServer [-Server <Connection>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### __AllParameterSets

```
Disconnect-VirtServer [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

Disconnect from the Libvirt server.

## EXAMPLES

### Example 1

```powershell
PS C:\> # disconnect from session of $DefaultVirtServer.
PS C:\> Disconnect-VirtServer
```

### Example 2

```powershell
PS C:\> Disconnect-VirtServer -Server $conn
```

## PARAMETERS

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

### PwshVirt.Connection

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


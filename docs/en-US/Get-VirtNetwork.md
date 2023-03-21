---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtNetwork

## SYNOPSIS
Get network.

## SYNTAX

### All (Default)
```
Get-VirtNetwork [-Server <Connection>] [<CommonParameters>]
```

### Name
```
Get-VirtNetwork -Name <String> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Get network.

## EXAMPLES

### Example 1
```powershell
PS C:\> # list all network.
PS C:\> Get-VirtNetwork
```

### Example 2
```powershell
PS C:\> # get network by specified name.
PS C:\> Get-VirtNetwork -Name 'NetworkName'
```

## PARAMETERS

### -Name
Specify name of network.

```yaml
Type: String
Parameter Sets: Name
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Server
Specify session.
If omitted, use $DefaultVirtServer.

```yaml
Type: Connection
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### PwshVirt.Network

## NOTES

## RELATED LINKS

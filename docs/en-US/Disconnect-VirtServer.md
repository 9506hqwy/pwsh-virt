---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Disconnect-VirtServer

## SYNOPSIS
Disconnect from the Libvirt server.

## SYNTAX

```
Disconnect-VirtServer [-Server <Connection>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

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
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PwshVirt.Connection
## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

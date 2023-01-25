---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtNetworkInterface

## SYNOPSIS
Get network interface.

## SYNTAX

### All (Default)
```
Get-VirtNetworkInterface [-Server <Connection>] [<CommonParameters>]
```

### Name
```
Get-VirtNetworkInterface [-Name <String>] [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Get network interface.

## EXAMPLES

### Example 1
```powershell
PS C:\> # list all network interface.
PS C:\> Get-VirtNetworkInterface
```

### Example 2
```powershell
PS C:\> # get network interface by specified name.
PS C:\> Get-VirtNetworkInterface -Name 'InterfaceName'
```

## PARAMETERS

### -Name
Specify name of network interface.

```yaml
Type: String
Parameter Sets: Name
Aliases:

Required: False
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

### PwshVirt.NetworkInterface

## NOTES

## RELATED LINKS

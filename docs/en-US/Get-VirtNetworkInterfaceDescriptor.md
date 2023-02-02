---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtNetworkInterfaceDescriptor

## SYNOPSIS
Get XML descriptor of network interface.

## SYNTAX

```
Get-VirtNetworkInterfaceDescriptor -Interface <NetworkInterface> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Get XML descriptor of network interface.

## EXAMPLES

### Example 1
```powershell
PS C:\> # get xml descriptor by specified name.
PS C:\> Get-VirtNetworkInterface -Name 'InterfaceName' | Get-VirtNetworkInterfaceDescriptor
```

## PARAMETERS

### -Interface
Specify network interface.

```yaml
Type: NetworkInterface
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### PwshVirt.NetworkInterface

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

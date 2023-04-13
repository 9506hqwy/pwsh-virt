---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Remove-VirtNetworkAdapter

## SYNOPSIS
Remove network adapter from domain.

## SYNTAX

```
Remove-VirtNetworkAdapter -Domain <Domain> -MacAddress <PhysicalAddress> [-Server <Connection>]
 [<CommonParameters>]
```

## DESCRIPTION
Remove network adapter from domain.

## EXAMPLES

### Example 1
```powershell
PS C:\> # remove network adapter from specified domain.
PS C:\> Remove-VirtNetworkAdapter -Domain $dom -MacAddress 00:11:22:33:44:55
```

## PARAMETERS

### -Domain
Specify domain.

```yaml
Type: Domain
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MacAddress
Specify MAC address of network adapter.

```yaml
Type: PhysicalAddress
Parameter Sets: (All)
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

### PwshVirt.Domain

## OUTPUTS

### PwshVirt.Domain

## NOTES

## RELATED LINKS

---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# New-VirtNetworkAdapter

## SYNOPSIS
Add network adapter to domain.

## SYNTAX

```
New-VirtNetworkAdapter -Domain <Domain> [-MacAddress <PhysicalAddress>] [-Model <String>] -NetworkName <String>
 [-Server <Connection>] -Type <NetworkAdapterType> [<CommonParameters>]
```

## DESCRIPTION
Add network adapter to domain.

## EXAMPLES

### Example 1
```powershell
PS C:\> # add network adapter to specified domain.
PS C:\> New-VirtNetworkAdapter -Domain $dom -Type Network -NetworkName 'default'
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

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Model
Specify model of network adapter.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkName
Specify name of destination network.

```yaml
Type: String
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

### -Type
Specify type of destination network.

```yaml
Type: NetworkAdapterType
Parameter Sets: (All)
Aliases:
Accepted values: Network, Bridge

Required: True
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

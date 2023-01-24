---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Stop-VirtDomain

## SYNOPSIS
Stop domain.

## SYNTAX

```
Stop-VirtDomain -Domain <Domain> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Stop domain.

## EXAMPLES

### Example 1
```powershell
PS C:\> # stop domain by specified name.
PS C:\> Get-VirtDomain -Name 'DomainName' | Stop-VirtDomain
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

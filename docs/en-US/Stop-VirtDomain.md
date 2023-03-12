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

### PowerOff (Default)
```
Stop-VirtDomain -Domain <Domain> [-Server <Connection>] [<CommonParameters>]
```

### Hibernate
```
Stop-VirtDomain [-BypassCache] -Domain <Domain> [-Hibernate] [-Paused] [-Running] [-Server <Connection>]
 [<CommonParameters>]
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

### -BypassCache
Specify whether avoid filesystem cache if writing domain state to file.

```yaml
Type: SwitchParameter
Parameter Sets: Hibernate
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Hibernate
Specify whether writing domain state to file.

```yaml
Type: SwitchParameter
Parameter Sets: Hibernate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Paused
Pause domain when resume domain state from file.

```yaml
Type: SwitchParameter
Parameter Sets: Hibernate
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Running
Start domain when resume domain state from file.

```yaml
Type: SwitchParameter
Parameter Sets: Hibernate
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

### PwshVirt.Domain
## OUTPUTS

### PwshVirt.Domain
## NOTES

## RELATED LINKS

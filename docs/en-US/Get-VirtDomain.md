---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtDomain

## SYNOPSIS
Get defined domain.

## SYNTAX

### All (Default)
```
Get-VirtDomain [-Server <Connection>] [<CommonParameters>]
```

### Name
```
Get-VirtDomain [-Name <String>] [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Get defined domain.

## EXAMPLES

### Example 1
```powershell
PS C:\> # list all defined domain.
PS C:\> Get-VirtDomain
```

### Example 2
```powershell
PS C:\> # get domain by specified name.
PS C:\> Get-VirtDomain -Name 'DomainName'
```

## PARAMETERS

### -Name
Specify name of domain.

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

### PwshVirt.Domain
## NOTES

## RELATED LINKS

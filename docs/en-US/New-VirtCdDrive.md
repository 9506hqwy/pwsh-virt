---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# New-VirtCdDrive

## SYNOPSIS
Add optical drive to domain.

## SYNTAX

```
New-VirtCdDrive -DeviceFile <String> -Domain <Domain> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Add optical drive to domain.

## EXAMPLES

### Example 1
```powershell
PS C:\> # add hard disk to specified domain.
PS C:\> New-VirtCdDrive -Domain $dom -DeviceFile 'vda'
```

## PARAMETERS

### -DeviceFile
Specify device file.

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

### PwshVirt.CdDrive

## NOTES

## RELATED LINKS

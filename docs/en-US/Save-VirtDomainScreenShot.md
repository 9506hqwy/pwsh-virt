---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Save-VirtDomainScreenShot

## SYNOPSIS
Take a console screenshot of guest OS.

## SYNTAX

```
Save-VirtDomainScreenShot -Destination <FileInfo> -Domain <Domain> [-Screen <UInt32>] [-Server <Connection>]
 [<CommonParameters>]
```

## DESCRIPTION
Take a console screenshot of guest OS.

## EXAMPLES

### Example 1
```powershell
PS C:\> # take a console screenshot by specified name.
PS C:\> Get-VirtDomain -Name 'DomainName' | Save-VirtDomainScreenShot -Destination 'console.ppm'
```

## PARAMETERS

### -Destination
Specify file path.

```yaml
Type: FileInfo
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

### -Screen
Specify index of screen.

```yaml
Type: UInt32
Parameter Sets: (All)
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

### System.IO.FileInfo

## NOTES

## RELATED LINKS

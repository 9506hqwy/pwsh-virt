---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtStorageVolDescriptor

## SYNOPSIS
Get XML descriptor of storage volume.

## SYNTAX

```
Get-VirtStorageVolDescriptor [-Server <Connection>] -Vol <StorageVol> [<CommonParameters>]
```

## DESCRIPTION
Get XML descriptor of storage volume.

## EXAMPLES

### Example 1
```powershell
PS C:\> # get xml descriptor by specified key.
PS C:\> Get-VirtStorageVol -Key 'VolumeKey' | Get-VirtStorageVolDescriptor
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
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vol
Specify storage volume.

```yaml
Type: StorageVol
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PwshVirt.StorageVol

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

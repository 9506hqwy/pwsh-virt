---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Remove-VirtStorageVol

## SYNOPSIS
Delete storage volume.

## SYNTAX

```
Remove-VirtStorageVol -Vol <StorageVol> [-Server <Connection>] [-WithSnapshot] [<CommonParameters>]
```

## DESCRIPTION
Delete storage volume.

## EXAMPLES

### Example 1
```powershell
PS C:\> # delete $vol.
PS C:\> Remove-VirtStorageVol -Vol $vol
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
Specify target storage volume.

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

### -WithSnapshot
Specify whether deleting snapshots.

```yaml
Type: SwitchParameter
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

### PwshVirt.StorageVol

## OUTPUTS

### PwshVirt.StorageVol

## NOTES

## RELATED LINKS

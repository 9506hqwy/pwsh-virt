---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Remove-VirtStoragePool

## SYNOPSIS
Delete storage pool.

## SYNTAX

```
Remove-VirtStoragePool [-Pool <StoragePool>] [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Delete storage pool.

## EXAMPLES

### Example 1
```powershell
PS C:\> # delete $pool.
PS C:\> Remove-VirtStoragePool -Pool $pool
```

## PARAMETERS

### -Pool
Specify target storage pool.

```yaml
Type: StoragePool
Parameter Sets: (All)
Aliases:

Required: False
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

### PwshVirt.StoragePool

## OUTPUTS

### PwshVirt.StoragePool

## NOTES

## RELATED LINKS

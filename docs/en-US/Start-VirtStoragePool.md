---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Start-VirtStoragePool

## SYNOPSIS
Start up storage pool.

## SYNTAX

```
Start-VirtStoragePool -Pool <StoragePool> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Start up storage pool.

## EXAMPLES

### Example 1
```powershell
PS C:\> # start up storage pool by specified name.
PS C:\> Get-VirtStoragePool -Name 'PoolName' | Start-VirtStoragePool
```

## PARAMETERS

### -Pool
Specify storage pool.

```yaml
Type: StoragePool
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

### PwshVirt.StoragePool

## OUTPUTS

### PwshVirt.StoragePool

## NOTES

## RELATED LINKS

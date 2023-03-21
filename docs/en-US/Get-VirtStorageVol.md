---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtStorageVol

## SYNOPSIS
Get storage volume.

## SYNTAX

### Pool (Default)
```
Get-VirtStorageVol -Pool <StoragePool> [-Server <Connection>] [<CommonParameters>]
```

### Key
```
Get-VirtStorageVol -Key <String> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
Get storage volume.

## EXAMPLES

### Example 1
```powershell
PS C:\> # list all storage volume by specified storage pool.
PS C:\> Get-VirtStorageVol -Pool $pool
```

### Example 2
```powershell
PS C:\> # get storage volume by specified key.
PS C:\> Get-VirtStorageVol -Key $key
```

## PARAMETERS

### -Key
Specify key of storage volume.

```yaml
Type: String
Parameter Sets: Key
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Pool
Specify storage pool.

```yaml
Type: StoragePool
Parameter Sets: Pool
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

### PwshVirt.StorageVol
## NOTES

## RELATED LINKS

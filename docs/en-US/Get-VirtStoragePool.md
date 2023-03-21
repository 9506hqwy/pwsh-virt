---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtStoragePool

## SYNOPSIS
Get storage pool.

## SYNTAX

### All (Default)
```
Get-VirtStoragePool [-Server <Connection>] [<CommonParameters>]
```

### Name
```
Get-VirtStoragePool -Name <String> [-Server <Connection>] [<CommonParameters>]
```

### Vol
```
Get-VirtStoragePool [-Server <Connection>] -Vol <StorageVol> [<CommonParameters>]
```

## DESCRIPTION
Get storage pool.

## EXAMPLES

### Example 1
```powershell
PS C:\> # list all storage pool.
PS C:\> Get-VirtStoragePool
```

### Example 2
```powershell
PS C:\> # get storage pool by specified name.
PS C:\> Get-VirtStoragePool -Name 'PoolName'
```

## PARAMETERS

### -Name
Specify name of storage pool.

```yaml
Type: String
Parameter Sets: Name
Aliases:

Required: True
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

### -Vol
Specify storage volume.

```yaml
Type: StorageVol
Parameter Sets: Vol
Aliases:

Required: True
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

### PwshVirt.StoragePool
## NOTES

## RELATED LINKS

---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtStoragePool

## SYNOPSIS
ストレージプールを取得します。

## SYNTAX

### All (Default)
```
Get-VirtStoragePool [-Server <Connection>] [<CommonParameters>]
```

### Name
```
Get-VirtStoragePool [-Name <String>] [-Server <Connection>] [<CommonParameters>]
```

### Vol
```
Get-VirtStoragePool [-Server <Connection>] [-Vol <StorageVol>] [<CommonParameters>]
```

## DESCRIPTION
ストレージプールを取得します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # すべてのストレージプールを取得します。
PS C:\> Get-VirtStoragePool
```

### Example 2
```powershell
PS C:\> # 指定した名前のストレージプールを取得します。
PS C:\> Get-VirtStoragePool -Name 'PoolName'
```

## PARAMETERS

### -Name
ストレージプールの名前を指定します。

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
セッションを指定します。
省略した場合は $DefaultVirtServer を使用します。

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
ストレージボリュームを指定します。

```yaml
Type: StorageVol
Parameter Sets: Vol
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

### PwshVirt.StoragePool
## NOTES

## RELATED LINKS

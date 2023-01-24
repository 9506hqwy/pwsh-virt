---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Watch-VirtStoragePool

## SYNOPSIS
ストレージプールのライフサイクルイベントを監視します。

## SYNTAX

```
Watch-VirtStoragePool [-Pool <StoragePool>] [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
ストレージプールのライフサイクルイベントを監視します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定したプールのライフサイクルイベントを監視します。
PS C:\> Watch-VirtStoragePool -Pool $pool
```

## PARAMETERS

### -Pool
ストレージプールを指定します。

```yaml
Type: StoragePool
Parameter Sets: (All)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Binding.IVirtEvent
## NOTES

## RELATED LINKS

---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtStorageVol

## SYNOPSIS
ストレージボリュームを取得します。

## SYNTAX

### Pool (Default)
```
Get-VirtStorageVol -Pool <StoragePool> [-Server <Connection>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Key
```
Get-VirtStorageVol -Key <String> [-Server <Connection>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
ストレージボリュームを取得します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定したストレージプールにあるストレージボリュームを取得します。
PS C:\> Get-VirtStorageVol -Pool $pool
```

### Example 2
```powershell
PS C:\> # 指定したキーのストレージボリュームを取得します。
PS C:\> Get-VirtStorageVol -Key $key
```

## PARAMETERS

### -Key
ストレージボリュームのキーを指定します。

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
ストレージプールを指定します。

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

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

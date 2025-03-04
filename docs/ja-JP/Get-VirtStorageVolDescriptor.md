---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtStorageVolDescriptor

## SYNOPSIS
ストレージボリュームの XML 記述を取得します。

## SYNTAX

```
Get-VirtStorageVolDescriptor [-Server <Connection>] -Vol <StorageVol> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
ストレージボリュームの XML 記述を取得します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定したキーのストレージボリュームの XML 記述を取得します。
PS C:\> Get-VirtStorageVol -Key 'VolumeKey' | Get-VirtStorageVolDescriptor
```

## PARAMETERS

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### PwshVirt.StorageVol

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

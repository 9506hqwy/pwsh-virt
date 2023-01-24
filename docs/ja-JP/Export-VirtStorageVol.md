---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Export-VirtStorageVol

## SYNOPSIS
ストレージボリュームをエクスポートします。

## SYNTAX

```
Export-VirtStorageVol -Destination <FileInfo> -Vol <StorageVol> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
ストレージボリュームをエクスポートします。

## EXAMPLES

### Example 1
```powershell
PS C:\> # $vol を /root/test.qcow2 にエクスポートします。
PS C:\> Export-VirtStorageVol -Destination /root/test.qcow2 -Vol $vol
```

## PARAMETERS

### -Destination
保存先のファイルパスを指定します。

```yaml
Type: FileInfo
Parameter Sets: (All)
Aliases:

Required: True
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
対象のストレージボリュームを指定します。

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

### System.IO.FileInfo
## NOTES

## RELATED LINKS

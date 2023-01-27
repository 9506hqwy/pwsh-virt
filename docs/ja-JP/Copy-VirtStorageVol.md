---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Copy-VirtStorageVol

## SYNOPSIS
ストレージボリュームを複製します。

## SYNTAX

```
Copy-VirtStorageVol -Name <String> [-PreallocMetadata] [-RefLink] [-Server <Connection>] -Source <StorageVol>
 [<CommonParameters>]
```

## DESCRIPTION
ストレージボリュームを複製します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定したキーのストレージボリュームを複製します。
PS C:\> Get-VirtStorageVol -Key 'VolumeKey' | Copy-VirtStorageVol -Name 'VolumeName'
```

## PARAMETERS

### -Name
作成するストレージボリュームの名前を指定します。

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreallocMetadata
メタデータを事前に割り当てます。

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

### -RefLink
Btrfs COW を使用します。

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

### -Source
複製するストレージボリュームを指定します。

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

### PwshVirt.StorageVol

## NOTES

## RELATED LINKS

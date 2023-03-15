---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# New-VirtHardDisk

## SYNOPSIS
ドメインにハードディスクを追加します。

## SYNTAX

```
New-VirtHardDisk [-Config] -DeviceFile <String> -Domain <Domain> [-Driver <String>]
 [-DriverType <DriverFormat>] -Vol <StorageVol> [-Live] [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
ドメインにハードディスクを追加します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定したドメインにハードディスクを追加します。
PS C:\> New-VirtNetworkAdapter -Domain $dom －Vol $vol -DeviceFile 'vda'
```

## PARAMETERS

### -Config
次回起動時に反映するかどうかを指定します。

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

### -DeviceFile
デバイスファイルを指定します。

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

### -Domain
ドメインを指定します。

```yaml
Type: Domain
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Driver
ドライバを指定します。

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DriverType
ドライバの種別を指定します。

```yaml
Type: DriverFormat
Parameter Sets: (All)
Aliases:
Accepted values: Raw, Dir, Bochs, Cloop, Dmg, Iso, Vpc, Vdi, Fat, Vhd, Ploop, Luks, Cow, Qcow, Qcow2, Qed, Vmdk, Aio

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Live
起動中に反映するかどうかを指定します。

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

### -Vol
ストレージボリュームを指定します。

```yaml
Type: StorageVol
Parameter Sets: (All)
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

### PwshVirt.Domain

## OUTPUTS

### PwshVirt.Domain

## NOTES

## RELATED LINKS

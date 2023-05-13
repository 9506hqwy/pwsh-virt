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
New-VirtHardDisk -DeviceFile <String> -Domain <Domain> [-Driver <String>] [-DriverType <DomainDiskDriverType>]
 -Vol <StorageVol> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
ドメインにハードディスクを追加します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定したドメインにハードディスクを追加します。
PS C:\> New-VirtHardDisk -Domain $dom －Vol $vol -DeviceFile 'vda'
```

## PARAMETERS

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
Type: DomainDiskDriverType
Parameter Sets: (All)
Aliases:
Accepted values: Aio, Bochs, Cloop, Cow, Dir, Dmg, Fat, Iso, Luks, Ploop, Qcow, Qcow2, Qed, Raw, Vdi, Vhd, Vmdk, Vpc

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

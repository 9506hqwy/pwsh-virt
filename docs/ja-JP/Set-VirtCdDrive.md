---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Set-VirtCdDrive

## SYNOPSIS
ドメインの光学ドライブを更新します。

## SYNTAX

### Insert (Default)
```
Set-VirtCdDrive -Drive <CdDrive> [-IsoPath <String>] [-Server <Connection>] [<CommonParameters>]
```

### Eject
```
Set-VirtCdDrive -Drive <CdDrive> [-Eject] [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
ドメインの光学ドライブを更新します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定した名前のドメインの光学ドライブに ISO ファイルをマウントします。
PS C:\> Get-VirtDomain -Name 'DomainName' | Get-VirtCdDrive | Set-VirtCdDrive -IsoPath /root/media.iso
```

### Example 2
```powershell
PS C:\> # 指定した名前のドメインの光学ドライブから ISO ファイルをアンマウントします。
PS C:\> Get-VirtDomain -Name 'DomainName' | Get-VirtCdDrive | Set-VirtCdDrive -Eject
```

## PARAMETERS

### -Drive
光学ドライブを指定します。

```yaml
Type: CdDrive
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Eject
ISO ファイルを取り出します。

```yaml
Type: SwitchParameter
Parameter Sets: Eject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsoPath
ISO ファイルのパスを指定します。

```yaml
Type: String
Parameter Sets: Insert
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

### PwshVirt.CdDrive

## OUTPUTS

### PwshVirt.Domain

## NOTES

## RELATED LINKS

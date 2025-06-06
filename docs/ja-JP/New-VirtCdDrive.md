---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# New-VirtCdDrive

## SYNOPSIS
ドメインに光学ドライブを追加します。

## SYNTAX

```
New-VirtCdDrive -DeviceFile <String> -Domain <Domain> [-Server <Connection>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
ドメインに光学ドライブを追加します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定したドメインに光学ドライブを追加します。
PS C:\> New-VirtCdDrive -Domain $dom -DeviceFile 'vdb'
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

### PwshVirt.Domain

## OUTPUTS

### PwshVirt.CdDrive

## NOTES

## RELATED LINKS

---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Copy-VirtDomainGuestFile

## SYNOPSIS
ゲスト OS へファイルを複製します。またはゲスト OS からファイルを複製します。

## SYNTAX

```
Copy-VirtDomainGuestFile -Destination <String> -Domain <Domain> [-GuestToLocal] [-Server <Connection>]
 -Source <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
ゲスト OS へファイルを複製します。またはゲスト OS からファイルを複製します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定した名前のドメインの /root/test.txt を取得します。
PS C:\> Get-VirtDomain -Name 'DomainName' | Copy-VirtDomainGuestFile -Destination 'test.txt' -Source '/root/test.txt' -GuestToLocal
```

### Example 2
```powershell
PS C:\> # 指定した名前のドメインに test.txt を送信します。
PS C:\> Get-VirtDomain -Name 'DomainName' | Copy-VirtDomainGuestFile -Destination '/root/test.txt' -Source 'test.txt'
```

## PARAMETERS

### -Destination
複製先のファイルパスを指定します。

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

### -GuestToLocal
ゲスト OS からローカルにファイルを複製します。

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
複製元のファイルパスを指定します。

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

### System.IO.FileInfo

## NOTES

## RELATED LINKS

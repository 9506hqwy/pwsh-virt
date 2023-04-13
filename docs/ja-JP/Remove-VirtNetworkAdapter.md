---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Remove-VirtNetworkAdapter

## SYNOPSIS
ドメインからネットワークアダプタを削除します。

## SYNTAX

```
Remove-VirtNetworkAdapter -Domain <Domain> -MacAddress <PhysicalAddress> [-Server <Connection>]
 [<CommonParameters>]
```

## DESCRIPTION
ドメインからネットワークアダプタを削除します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定したドメインからネットワークアダプタを削除します。
PS C:\> Remove-VirtNetworkAdapter -Domain $dom -MacAddress 00:11:22:33:44:55
```

## PARAMETERS

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

### -MacAddress
ネットワークアダプタの MAC アドレスを指定します。

```yaml
Type: PhysicalAddress
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PwshVirt.Domain

## OUTPUTS

### PwshVirt.Domain

## NOTES

## RELATED LINKS

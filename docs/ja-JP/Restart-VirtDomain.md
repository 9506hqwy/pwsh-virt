---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Restart-VirtDomain

## SYNOPSIS
ドメインを再起動します。

## SYNTAX

### Reset (Default)
```
Restart-VirtDomain -Domain <Domain> [-Server <Connection>] [<CommonParameters>]
```

### Reboot
```
Restart-VirtDomain -Domain <Domain> [-Reboot] [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
ドメインを再起動します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定した名前のドメインをリセットします。
PS C:\> Get-VirtDomain -Name 'DomainName' | Restart-VirtDomain
```

### Example 2
```powershell
PS C:\> # 指定した名前のドメインを再起動します。
PS C:\> Get-VirtDomain -Name 'DomainName' | Restart-VirtDomain -Reboot
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

### -Reboot
ゲスト OS を再起動します。

```yaml
Type: SwitchParameter
Parameter Sets: Reboot
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

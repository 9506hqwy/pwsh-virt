---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Stop-VirtDomain

## SYNOPSIS
ドメインを停止します。

## SYNTAX

### PowerOff (Default)
```
Stop-VirtDomain -Domain <Domain> [-Server <Connection>] [<CommonParameters>]
```

### Hibernate
```
Stop-VirtDomain [-BypassCache] -Domain <Domain> [-Hibernate] [-Paused] [-Running] [-Server <Connection>]
 [<CommonParameters>]
```

## DESCRIPTION
ドメインを停止します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定した名前のドメインを停止します。
PS C:\> Get-VirtDomain -Name 'DomainName' | Stop-VirtDomain
```

## PARAMETERS

### -BypassCache
ドメインの状態をファイルに出力するときにファイルシステムキャッシュを回避します。

```yaml
Type: SwitchParameter
Parameter Sets: Hibernate
Aliases:

Required: False
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

### -Hibernate
ドメインの状態をファイルに出力します。

```yaml
Type: SwitchParameter
Parameter Sets: Hibernate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Paused
ドメインの状態を復元するときに一時停止状態にします。

```yaml
Type: SwitchParameter
Parameter Sets: Hibernate
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Running
ドメインの状態を復元するときに起動状態にします。

```yaml
Type: SwitchParameter
Parameter Sets: Hibernate
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

### PwshVirt.Domain
## OUTPUTS

### PwshVirt.Domain
## NOTES

## RELATED LINKS

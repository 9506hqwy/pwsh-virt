---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtNetworkInterfaceDescriptor

## SYNOPSIS
ネットワークインターフェイスの XML 記述を取得します。

## SYNTAX

```
Get-VirtNetworkInterfaceDescriptor -Interface <NetworkInterface> [-Server <Connection>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
ネットワークインターフェイスの XML 記述を取得します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定した名前のネットワークインターフェイスの XML 記述を取得します。
PS C:\> Get-VirtNetworkInterface -Name 'InterfaceName' | Get-VirtNetworkInterfaceDescriptor
```

## PARAMETERS

### -Interface
ネットワークインターフェイスを指定します。

```yaml
Type: NetworkInterface
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

### PwshVirt.NetworkInterface

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

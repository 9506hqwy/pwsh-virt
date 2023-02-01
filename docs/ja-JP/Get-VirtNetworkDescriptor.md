---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtNetworkDescriptor

## SYNOPSIS
ネットワークの XML 記述を取得します。

## SYNTAX

```
Get-VirtNetworkDescriptor -Network <Network> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
ネットワークの XML 記述を取得します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定した名前のネットワークの XML 記述を取得します。
PS C:\> Get-VirtNetwork -Name 'NetworkName' | Get-VirtNetworkDescriptor
```

## PARAMETERS

### -Network
ネットワークを指定します。

```yaml
Type: Network
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PwshVirt.Network

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

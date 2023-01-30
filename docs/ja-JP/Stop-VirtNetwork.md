---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Stop-VirtNetwork

## SYNOPSIS
ネットワークを停止します。

## SYNTAX

```
Stop-VirtNetwork -Network <Network> [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
ネットワークを停止します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定した名前のネットワークを停止します。
PS C:\> Get-VirtNetwork -Name 'NetworkName' | Stop-VirtNetwork
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

### PwshVirt.Network

## NOTES

## RELATED LINKS

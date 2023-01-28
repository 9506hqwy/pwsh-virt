---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Get-VirtNetwork

## SYNOPSIS
ネットワークを取得します。

## SYNTAX

### All (Default)
```
Get-VirtNetwork [-Server <Connection>] [<CommonParameters>]
```

### Name
```
Get-VirtNetwork [-Name <String>] [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
ネットワークを取得します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # すべてのネットワークを取得します。
PS C:\> Get-VirtNetwork
```

### Example 2
```powershell
PS C:\> # 指定した名前のネットワークを取得します。
PS C:\> Get-VirtNetwork -Name 'NetworkName'
```

## PARAMETERS

### -Name
ネットワークの名前を指定します。

```yaml
Type: String
Parameter Sets: Name
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

### None

## OUTPUTS

### PwshVirt.Network

## NOTES

## RELATED LINKS

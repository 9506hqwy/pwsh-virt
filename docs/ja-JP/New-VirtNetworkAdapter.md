---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# New-VirtNetworkAdapter

## SYNOPSIS
ドメインにネットワークアダプタを追加します。

## SYNTAX

### Network (Default)
```
New-VirtNetworkAdapter -Domain <Domain> [-MacAddress <PhysicalAddress>] [-Model <String>] -NetworkName <String>
 [-Server <Connection>] [<CommonParameters>]
```

### Bridge
```
New-VirtNetworkAdapter -BridgeName <String> -Domain <Domain> [-MacAddress <PhysicalAddress>] [-Model <String>]
 [-Server <Connection>] [<CommonParameters>]
```

## DESCRIPTION
ドメインにネットワークアダプタを追加します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定したドメインにネットワークアダプタを追加します。
PS C:\> New-VirtNetworkAdapter -Domain $dom -Type Network -NetworkName 'default'
```

## PARAMETERS

### -BridgeName
接続先ブリッジを指定します。

```yaml
Type: String
Parameter Sets: Bridge
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

### -MacAddress
ネットワークアダプタの MAC アドレスを指定します。

```yaml
Type: PhysicalAddress
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Model
ネットワークアダプタのモデルを指定します。

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkName
接続先ネットワークを指定します。

```yaml
Type: String
Parameter Sets: Network
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

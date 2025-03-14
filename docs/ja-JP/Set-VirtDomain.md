---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Set-VirtDomain

## SYNOPSIS
ドメインの構成を変更します。

## SYNTAX

```
Set-VirtDomain -Domain <Domain> [-Memory <String>] [-NumCpu <UInt32>] [-Server <Connection>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
ドメインの構成を変更します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定した名前のドメインの CPU 数を変更します。
PS C:\> Get-VirtDomain -Name 'DomainName' | Set-VirtDomain -NumCpu 2
```

### Example 2
```powershell
PS C:\> # 指定した名前のドメインのメモリ容量を変更します。
PS C:\> Get-VirtDomain -Name 'DomainName' | Set-VirtDomain -Memory 4G
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

### -Memory
メモリの容量を指定します。

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

### -NumCpu
CPU 数を指定します。

```yaml
Type: UInt32
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

### PwshVirt.Domain

## NOTES

## RELATED LINKS

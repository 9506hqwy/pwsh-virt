---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Connect-VirtServer

## SYNOPSIS
Libvirt サーバに接続します。

## SYNTAX

```
Connect-VirtServer [-Driver <String>] [-Force] [-Name <String>] [-NotDefault] [-PfxPath <FileInfo>]
 [-Port <Int32>] [-Server <String>] [-Transport <String>] [-Uri <Uri>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Libvirt サーバに接続します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # qemu+tls://127.0.0.1/system に接続します。
PS C:\> Connect-VirtServer
```

### Example 2
```powershell
PS C:\> # qemu+tcp://192.168.0.1/system に接続します。
PS C:\> Connect-VirtServer -Server 192.168.0.1 -Transport tcp
```

## PARAMETERS

### -Driver
ドライバを指定します。
省略した場合は qemu です。

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: qemu

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
TLS 接続をする場合にサーバ証明書の検証を無効化します。

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

### -Name
モードを指定します。
省略した場合は /system です。

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

### -NotDefault
$DefaultVirtServer へセッションの保存を無効化します。

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

### -PfxPath
クライアント証明書のファイルパスを指定します。
証明書はパスワードなしの PKCS#12 形式のファイルを指定します。

```yaml
Type: FileInfo
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
ポート番号を指定します。
省略した場合は TLS 16514, TCP 16509 です。

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Server
接続先を指定します。
省略した場合は 127.0.0.1 です。

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

### -Transport
プロトコルを指定します。
省略した場合は tls です。

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: tcp, tls

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Uri
接続先を指定します。

```yaml
Type: Uri
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

### None
## OUTPUTS

### PwshVirt.Connection
## NOTES

## RELATED LINKS

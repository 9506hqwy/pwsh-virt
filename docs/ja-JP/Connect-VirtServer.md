---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Connect-VirtServer

## SYNOPSIS

Libvirt サーバに接続します。

## SYNTAX

### Default (Default)

```
Connect-VirtServer [-Driver <String>] [-Force] [-Name <String>] [-NotDefault] [-PfxPath <FileInfo>]
 [-Port <Int32>] [-Server <String>] [-Transport <String>] [-Uri <Uri>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### __AllParameterSets

```
Connect-VirtServer [-Driver <string>] [-Force] [-Name <string>] [-NotDefault] [-PfxPath <FileInfo>]
 [-Port <int>] [-Server <string>] [-Transport <string>] [-Uri <uri>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

Libvirt サーバに接続します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # qemu+unix:///system?socket=/var/run/libvirt/libvirt-sock に接続します。
PS C:\> # (PS Edition: Core)
PS C:\> Connect-VirtServer
```

### Example 2

```powershell
PS C:\> # qemu+tls://127.0.0.1/system に接続します。
PS C:\> # (PS Edition: Desktop)
PS C:\> Connect-VirtServer
```

### Example 3

```powershell
PS C:\> # qemu+tcp://192.168.0.1/system に接続します。
PS C:\> Connect-VirtServer -Server 192.168.0.1 -Transport tcp
```

## PARAMETERS

### -Driver

ドライバを指定します。
省略した場合は qemu です。

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues:
- qemu
HelpMessage: ''
```

### -Force

TLS 接続をする場合にサーバ証明書の検証を無効化します。

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

モードを指定します。
省略した場合は /system です。

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -NotDefault

$DefaultVirtServer へセッションの保存を無効化します。

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -PfxPath

クライアント証明書のファイルパスを指定します。
証明書はパスワードなしの PKCS#12 形式のファイルを指定します。

```yaml
Type: System.IO.FileInfo
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Port

ポート番号を指定します。
省略した場合は TLS 16514, TCP 16509 です。

```yaml
Type: System.Int32
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ProgressAction

{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
DefaultValue: None
SupportsWildcards: false
Aliases:
- proga
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Server

接続先を指定します。
省略した場合は 127.0.0.1 です。

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Transport

プロトコルを指定します。
省略した場合は tls または unix です。

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues:
- tcp
- tls
- unix
HelpMessage: ''
```

### -Uri

接続先を指定します。

```yaml
Type: System.Uri
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### PwshVirt.Connection

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


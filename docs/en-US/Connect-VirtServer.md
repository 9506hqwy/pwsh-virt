---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Connect-VirtServer

## SYNOPSIS

Connect to the Libvirt server.

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

Connect to the Libvirt server.

## EXAMPLES

### Example 1

```powershell
PS C:\> # connect 'qemu+unix:///system?socket=/var/run/libvirt/libvirt-sock'.
PS C:\> # (PS Edition: Core)
PS C:\> Connect-VirtServer
```

### Example 2

```powershell
PS C:\> # connect 'qemu+tls://127.0.0.1/system'.
PS C:\> # (PS Edition: Desktop)
PS C:\> Connect-VirtServer
```

### Example 3

```powershell
PS C:\> # connect 'qemu+tcp://192.168.0.1/system'.
PS C:\> Connect-VirtServer -Server 192.168.0.1 -Transport tcp
```

## PARAMETERS

### -Driver

Specify driver.
If omitted, use 'qemu'.

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

Disable server certificate verification if transport is 'tls'.

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

Specify mode.
If omitted, use '/system'.

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

Disable session saving to $DefaultVirtServer.

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

Specify client certificate.
Client certificate is PKCS#12 format without password.

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

Specify port number.
If omitted, use TLS 16514, TCP 16509.

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

Specify destination.
If omitted, use '127.0.0.1'.

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

Specify transport protocol.
If omitted, use 'tls' or 'unix'.

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

Specify destination.

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


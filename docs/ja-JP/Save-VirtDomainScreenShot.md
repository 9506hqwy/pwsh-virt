---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Save-VirtDomainScreenShot

## SYNOPSIS

ゲスト OS のコンソールスクリーンショットを取得します。

## SYNTAX

### Default (Default)

```
Save-VirtDomainScreenShot -Destination <FileInfo> -Domain <Domain> [-Screen <UInt32>]
 [-Server <Connection>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### __AllParameterSets

```
Save-VirtDomainScreenShot -Destination <FileInfo> -Domain <Domain> [-Screen <uint>]
 [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ゲスト OS のコンソールスクリーンショットを取得します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # 指定した名前のコンソールスクリーンショットを取得します。
PS C:\> Get-VirtDomain -Name 'DomainName' | Save-VirtDomainScreenShot -Destination 'console.ppm'
```

## PARAMETERS

### -Destination

ファイルパスを指定します。

```yaml
Type: System.IO.FileInfo
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Domain

ドメインを指定します。

```yaml
Type: PwshVirt.Domain
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
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

### -Screen

スクリーン番号を指定します。

```yaml
Type: System.Nullable`1[System.UInt32]
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

### -Server

セッションを指定します。
省略した場合は $DefaultVirtServer を使用します。

```yaml
Type: PwshVirt.Connection
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

### PwshVirt.Domain

## OUTPUTS

### System.IO.FileInfo

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


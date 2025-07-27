---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Copy-VirtDomainGuestFile

## SYNOPSIS

ゲスト OS へファイルを複製します。またはゲスト OS からファイルを複製します。

## SYNTAX

### Default (Default)

```
Copy-VirtDomainGuestFile -Destination <String> -Domain <Domain> -Source <String> [-GuestToLocal]
 [-Server <Connection>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### __AllParameterSets

```
Copy-VirtDomainGuestFile -Destination <string> -Domain <Domain> -Source <string> [-GuestToLocal]
 [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ゲスト OS へファイルを複製します。またはゲスト OS からファイルを複製します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # 指定した名前のドメインの /root/test.txt を取得します。
PS C:\> Get-VirtDomain -Name 'DomainName' | Copy-VirtDomainGuestFile -Destination 'test.txt' -Source '/root/test.txt' -GuestToLocal
```

### Example 2

```powershell
PS C:\> # 指定した名前のドメインに test.txt を送信します。
PS C:\> Get-VirtDomain -Name 'DomainName' | Copy-VirtDomainGuestFile -Destination '/root/test.txt' -Source 'test.txt'
```

## PARAMETERS

### -Destination

複製先のファイルパスを指定します。

```yaml
Type: System.String
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

### -GuestToLocal

ゲスト OS からローカルにファイルを複製します。

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

### -Source

複製元のファイルパスを指定します。

```yaml
Type: System.String
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


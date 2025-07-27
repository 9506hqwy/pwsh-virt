---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Get-VirtStoragePool

## SYNOPSIS

ストレージプールを取得します。

## SYNTAX

### All (Default)

```
Get-VirtStoragePool [-Server <Connection>] [<CommonParameters>]
```

### Name

```
Get-VirtStoragePool -Name <string> [-Server <Connection>] [<CommonParameters>]
```

### Vol

```
Get-VirtStoragePool -Vol <StorageVol> [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ストレージプールを取得します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # すべてのストレージプールを取得します。
PS C:\> Get-VirtStoragePool
```

### Example 2

```powershell
PS C:\> # 指定した名前のストレージプールを取得します。
PS C:\> Get-VirtStoragePool -Name 'PoolName'
```

## PARAMETERS

### -Name

ストレージプールの名前を指定します。

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Name
  Position: Named
  IsRequired: true
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
- Name: All
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Name
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Vol
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Vol

ストレージボリュームを指定します。

```yaml
Type: PwshVirt.StorageVol
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Vol
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

### None

## OUTPUTS

### PwshVirt.StoragePool

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


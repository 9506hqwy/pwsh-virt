---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Get-VirtStorageVol

## SYNOPSIS

ストレージボリュームを取得します。

## SYNTAX

### Pool (Default)

```
Get-VirtStorageVol -Pool <StoragePool> [-Server <Connection>] [<CommonParameters>]
```

### Key

```
Get-VirtStorageVol -Key <string> [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ストレージボリュームを取得します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # 指定したストレージプールにあるストレージボリュームを取得します。
PS C:\> Get-VirtStorageVol -Pool $pool
```

### Example 2

```powershell
PS C:\> # 指定したキーのストレージボリュームを取得します。
PS C:\> Get-VirtStorageVol -Key $key
```

## PARAMETERS

### -Key

ストレージボリュームのキーを指定します。

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Key
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Pool

ストレージプールを指定します。

```yaml
Type: PwshVirt.StoragePool
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Pool
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

### -Server

セッションを指定します。
省略した場合は $DefaultVirtServer を使用します。

```yaml
Type: PwshVirt.Connection
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Key
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Pool
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

### PwshVirt.StoragePool

## OUTPUTS

### PwshVirt.StorageVol

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


---
document type: cmdlet
external help file: PwshVirt.dll-Help.xml
HelpUri: 
ms.date: 07/27/2025
PlatyPS schema version: 2024-05-01
---

# Clear-VirtStorageVol

## SYNOPSIS

ストレージボリュームのデータを消去します。

## SYNTAX

### Default (Default)

```
Clear-VirtStorageVol -Vol <StorageVol> [-Server <Connection>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### __AllParameterSets

```
Clear-VirtStorageVol -Vol <StorageVol> [-Server <Connection>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

ストレージボリュームのデータを消去します。

## EXAMPLES

### Example 1

```powershell
PS C:\> # 指定したキーのストレージボリュームのデータを消去します。
PS C:\> Get-VirtStorageVol -Key 'VaolumeKey' | Clear-VirtStorageVol
```

## PARAMETERS

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

### -Vol

ストレージボリュームを指定します。

```yaml
Type: PwshVirt.StorageVol
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

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

### PwshVirt.StorageVol

{{ Fill in the Description }}

## OUTPUTS

### PwshVirt.StorageVol

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}


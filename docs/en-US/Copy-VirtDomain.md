---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Copy-VirtDomain

## SYNOPSIS
Copy domain.

## SYNTAX

```
Copy-VirtDomain -Name <String> [-Server <Connection>] -Source <Domain> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Copy domain.

## EXAMPLES

### Example 1
```powershell
PS C:\> # copy domain by specified name.
PS C:\> Get-VirtDomain -Name 'DomainName' | Copy-VirtDomain -Name 'NewName'
```

## PARAMETERS

### -Name
Specify name of destination domain.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Server
Specify session.
If omitted, use $DefaultVirtServer.

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

### -Source
Specify source domain.

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

- Only file type disk support.

## RELATED LINKS

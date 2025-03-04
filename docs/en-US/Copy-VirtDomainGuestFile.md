---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Copy-VirtDomainGuestFile

## SYNOPSIS
Copy file to guest OS from local, or copy file to local from guest OS.

## SYNTAX

```
Copy-VirtDomainGuestFile -Destination <String> -Domain <Domain> [-GuestToLocal] [-Server <Connection>]
 -Source <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Copy file to guest OS from local, or copy file to local from guest OS.

## EXAMPLES

### Example 1
```powershell
PS C:\> # acquire file in domain by specified name.
PS C:\> Get-VirtDomain -Name 'DomainName' | Copy-VirtDomainGuestFile -Destination 'test.txt' -Source '/root/test.txt' -GuestToLocal
```

### Example 2
```powershell
PS C:\> # send to file to domain by specified name.
PS C:\> Get-VirtDomain -Name 'DomainName' | Copy-VirtDomainGuestFile -Destination '/root/test.txt' -Source 'test.txt'
```

## PARAMETERS

### -Destination
Specify destination file path.

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

### -Domain
Specify domain.

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

### -GuestToLocal
Whether copy to local from guest OS.

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
Specify source file path.

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

### System.IO.FileInfo

## NOTES

## RELATED LINKS

---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Set-VirtCdDrive

## SYNOPSIS
Set optical drive of domain.

## SYNTAX

### Insert (Default)
```
Set-VirtCdDrive -Drive <CdDrive> [-IsoPath <String>] [-Server <Connection>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Eject
```
Set-VirtCdDrive -Drive <CdDrive> [-Eject] [-Server <Connection>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Set optical drive of domain.

## EXAMPLES

### Example 1
```powershell
PS C:\> # mount iso file to optical drives by specified name.
PS C:\> Get-VirtDomain -Name 'DomainName' | Get-VirtCdDrive | Set-VirtCdDrive -IsoPath /root/media.iso
```

### Example 2
```powershell
PS C:\> # unmount iso file from optical drives by specified name.
PS C:\> Get-VirtDomain -Name 'DomainName' | Get-VirtCdDrive | Set-VirtCdDrive -Eject
```

## PARAMETERS

### -Drive
Specify drive.

```yaml
Type: CdDrive
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Eject
Eject ISO file from optical drive.

```yaml
Type: SwitchParameter
Parameter Sets: Eject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsoPath
Specify path of ISO file.

```yaml
Type: String
Parameter Sets: Insert
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

### PwshVirt.CdDrive

## OUTPUTS

### PwshVirt.Domain

## NOTES

## RELATED LINKS

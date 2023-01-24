---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# Connect-VirtServer

## SYNOPSIS
Connect to the Libvirt server.

## SYNTAX

```
Connect-VirtServer [-Driver <String>] [-Force] [-Name <String>] [-NotDefault] [-PfxPath <FileInfo>]
 [-Port <Int32>] [-Server <String>] [-Transport <String>] [-Uri <Uri>] [<CommonParameters>]
```

## DESCRIPTION
Connect to the Libvirt server.

## EXAMPLES

### Example 1
```powershell
PS C:\> # connect 'qemu+tls://127.0.0.1/system'.
PS C:\> Connect-VirtServer
```

### Example 2
```powershell
PS C:\> # connect 'qemu+tcp://192.168.0.1/system'.
PS C:\> Connect-VirtServer -Server 192.168.0.1 -Transport tcp
```

## PARAMETERS

### -Driver
Specify driver.
If omitted, use 'qemu'.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: qemu

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Disable server certificate verification if transport is 'tls'.

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

### -Name
Specify mode.
If omitted, use '/system'.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotDefault
Disable session saving to $DefaultVirtServer.

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

### -PfxPath
Specify client certificate.
Client certificate is PKCS#12 format without password.

```yaml
Type: FileInfo
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
Specify port number.
If omitted, use TLS 16514, TCP 16509.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Server
Specify destination.
If omitted, use '127.0.0.1'.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Transport
Specify transport protocol.
If omitted, use 'tls'.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: tcp, tls

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Uri
Specify destination.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### PwshVirt.Connection
## NOTES

## RELATED LINKS

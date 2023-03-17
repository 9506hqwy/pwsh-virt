---
external help file: PwshVirt.dll-Help.xml
Module Name: PwshVirt
online version:
schema: 2.0.0
---

# New-VirtStoragePool

## SYNOPSIS
ストレージプールを作成します。

## SYNTAX

### Dir (Default)
```
New-VirtStoragePool -Name <String> -Path <String> [-Server <Connection>] [<CommonParameters>]
```

### Netfs
```
New-VirtStoragePool -Address <String> [-ExportType <PoolSourcefmtnetfsType>] -ExportPath <String>
 -Name <String> -Path <String> [-Server <Connection>] [<CommonParameters>]
```

### Disk
```
New-VirtStoragePool [-DeviceFormat <PoolSourcefmtdiskType>] -DevicePath <String> -Name <String> -Path <String>
 [-Server <Connection>] [<CommonParameters>]
```

### Logical
```
New-VirtStoragePool -Name <String> [-Server <Connection>] -VgName <String> [<CommonParameters>]
```

## DESCRIPTION
ストレージプールを作成します。

## EXAMPLES

### Example 1
```powershell
PS C:\> # 指定した名前のストレージプールを作成します。
PS C:\> New-VirtStoragePool -Name 'PoolName' -Path '/var/lib/libvirt/images'
```

## PARAMETERS

### -Address
リモートホストのアドレスを指定します。

```yaml
Type: String
Parameter Sets: Netfs
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceFormat
デバイスの形式を指定します。

```yaml
Type: PoolSourcefmtdiskType
Parameter Sets: Disk
Aliases:
Accepted values: Unknown, Dos, Dvh, Gpt, Mac, Bsd, Pc98, Sun, Lvm2

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevicePath
デバイスファイルのパスを指定します。

```yaml
Type: String
Parameter Sets: Disk
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportPath
リモートホストの公開パスを指定します。

```yaml
Type: String
Parameter Sets: Netfs
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportType
リモートホストの公開パスの種別を指定します。

```yaml
Type: PoolSourcefmtnetfsType
Parameter Sets: Netfs
Aliases:
Accepted values: Auto, Nfs, Cifs, Glusterfs

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
ストレージプールの名前を指定します。

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

### -Path
ローカルホストのパスを指定します。

```yaml
Type: String
Parameter Sets: Dir, Netfs, Disk
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Server
セッションを指定します。
省略した場合は $DefaultVirtServer を使用します。

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

### -VgName
LVM のボリュームグループを指定します。

```yaml
Type: String
Parameter Sets: Logical
Aliases:

Required: True
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

### PwshVirt.StoragePool

## NOTES

## RELATED LINKS

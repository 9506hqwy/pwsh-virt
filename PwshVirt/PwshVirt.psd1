@{
    RootModule = 'PwshVirt.dll'

    ModuleVersion = '0.4.0.0'

    CompatiblePSEditions = @('Core', 'Desktop')

    GUID = '55aae8d3-5563-4dc4-9b8c-3c6198484f59'

    Author = '9506hqwy'

    Copyright = '(c) 2024 9506hqwy. All rights reserved.'

    Description = 'PowerShell Cmdlet for Libvirt'

    RequiredAssemblies = @('LibvirtModel.dll', 'LibvirtRemote.dll', 'Newtonsoft.Json.dll', 'Xdr.dll')

    CmdletsToExport = @(
        'Clear-VirtStorageVol',
        'Connect-VirtServer',
        'Copy-VirtDomain',
        'Copy-VirtDomainGuestFile',
        'Copy-VirtStorageVol',
        'Disconnect-VirtServer',
        'Export-VirtStorageVol',
        'Get-VirtCdDrive',
        'Get-VirtDomain',
        'Get-VirtDomainDescriptor',
        'Get-VirtNetwork',
        'Get-VirtNetworkDescriptor',
        'Get-VirtNetworkInterface',
        'Get-VirtNetworkInterfaceDescriptor',
        'Get-VirtStoragePool',
        'Get-VirtStoragePoolDescriptor',
        'Get-VirtStorageVol',
        'Get-VirtStorageVolDescriptor',
        'Import-VirtStorageVol',
        'Invoke-VirtDomainScript',
        'New-VirtCdDrive',
        'New-VirtDomain',
        'New-VirtHardDisk',
        'New-VirtNetworkAdapter',
        'New-VirtStoragePool',
        'New-VirtStorageVol',
        'Remove-VirtDomain',
        'Remove-VirtHardDisk',
        'Remove-VirtNetwork',
        'Remove-VirtNetworkAdapter',
        'Remove-VirtNetworkInterface',
        'Remove-VirtStoragePool',
        'Remove-VirtStorageVol',
        'Restart-VirtDomain',
        'Resume-VirtDomain',
        'Save-VirtDomainScreenShot',
        'Start-VirtDomain',
        'Start-VirtNetwork',
        'Start-VirtNetworkInterface',
        'Start-VirtStoragePool',
        'Set-VirtCdDrive',
        'Set-VirtDomain',
        'Stop-VirtDomain',
        'Stop-VirtNetwork',
        'Stop-VirtNetworkInterface',
        'Stop-VirtStoragePool',
        'Suspend-VirtDomain',
        'Watch-VirtStoragePool'
    )

    VariablesToExport = @('DefaultVirtServer')
}

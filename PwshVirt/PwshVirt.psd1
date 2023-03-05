@{
    RootModule = 'PwshVirt.dll'

    ModuleVersion = '0.3.0.0'

    CompatiblePSEditions = @('Core', 'Desktop')

    GUID = '55aae8d3-5563-4dc4-9b8c-3c6198484f59'

    Author = '9506hqwy'

    Copyright = '(c) 2023 9506hqwy. All rights reserved.'

    Description = 'PowerShell Cmdlet for Libvirt'

    RequiredAssemblies = @('LibvirtModel.dll', 'LibvirtRemote.dll', 'Xdr.dll')

    CmdletsToExport = @(
        'Clear-VirtStorageVol',
        'Connect-VirtServer',
        'Copy-VirtStorageVol',
        'Disconnect-VirtServer',
        'Export-VirtStorageVol',
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
        'New-VirtStorageVol',
        'Remove-VirtDomain',
        'Remove-VirtNetwork',
        'Remove-VirtNetworkInterface',
        'Remove-VirtStoragePool',
        'Remove-VirtStorageVol',
        'Start-VirtDomain',
        'Start-VirtNetwork',
        'Start-VirtNetworkInterface',
        'Start-VirtStoragePool',
        'Stop-VirtDomain',
        'Stop-VirtNetwork',
        'Stop-VirtNetworkInterface',
        'Stop-VirtStoragePool',
        'Watch-VirtStoragePool'
    )

    VariablesToExport = @('DefaultVirtServer')
}

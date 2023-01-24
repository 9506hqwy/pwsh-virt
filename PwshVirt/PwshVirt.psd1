@{
    RootModule = 'PwshVirt.dll'

    ModuleVersion = '0.2.0.0'

    CompatiblePSEditions = @('Core', 'Desktop')

    GUID = '55aae8d3-5563-4dc4-9b8c-3c6198484f59'

    Author = '9506hqwy'

    Copyright = '(c) 2023 9506hqwy. All rights reserved.'

    Description = 'PowerShell Cmdlet for Libvirt'

    RequiredAssemblies = @('LibvirtRemote.dll', 'Xdr.dll')

    CmdletsToExport = @(
        'Connect-VirtServer',
        'Disconnect-VirtServer',
        'Export-VirtStorageVol',
        'Get-VirtDomain',
        'Get-VirtStoragePool',
        'Get-VirtStorageVol',
        'Import-VirtStorageVol',
        'Start-VirtDomain',
        'Stop-VirtDomain',
        'Watch-VirtStoragePool'
    )

    VariablesToExport = @('DefaultVirtServer')
}

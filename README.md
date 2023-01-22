# PowerShell Libvirt Module

This module provides to communicate Libvirt server for PowerShell v5.1 or later.

## Installation

1. Download module archive from [release page](https://github.com/9506hqwy/pwsh-virt/releases).

2. If need, remove Zone.Identifier from archive.

3. Extract archive to [PSModulePath](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_psmodulepath).
   The module's folder name is 'PwshVirt'.

## Usage

```powershell
Import-Module PwshVirt

# connect to Libvirt server using tcp protocol.
Connect-VirtServer -Transport tcp

# list all defined domain.
Get-VirtDomain

# disconnect from Libvirt server.
Disconnect-VirtServer
```

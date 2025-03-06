# PowerShell Libvirt Module

This module provides to communicate Libvirt server for PowerShell v5.1 or later.

## Installation

1. Download module archive from [release page](https://github.com/9506hqwy/pwsh-virt/releases).

   | File | PS Edition |
   | :--: | :--------: |
   | PwshVirt_en-US.msi | Core, Desk |
   | PwshVirt_ja-JP.msi | Core, Desk |
   | PwshVirt-Desk.zip  | Core, Desk |
   | PwshVirt-Core.zip  | Core |

2. If need, remove Zone.Identifier from archive.
   ```powershell
   Unblock-File PwshVirt-Desk.zip
   ```

3. Extract archive to [PSModulePath](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_psmodulepath).
   The module's folder name is 'PwshVirt'.

## Server Configuration

This module connects to Libvirt server with TCP or TLS.

Configure Libvirt server in */etc/libvirt/libvirtd.conf*

* TCP
  ```
  listen_tcp = 1
  auth_tcp=none
  ```

* TLS
  ```
  listen_tls = 1
  ```

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

## Help

see [docs](./docs) directory.

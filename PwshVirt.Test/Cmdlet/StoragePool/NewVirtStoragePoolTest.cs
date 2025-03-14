﻿namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class NewVirtStoragePoolTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";

    [TestMethod]
    public void NewDir()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            _ = TestCase.Invoke<object>(psShell).First();
        }

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("New-VirtStoragePool")
                .AddParameter("Name", "dir")
                .AddParameter("Path", "/mnt/images");

            var pool = TestCase.Invoke<StoragePool>(psShell).First();
            Assert.IsNotNull(pool);
        }
    }

    [TestMethod]
    public void NewDisk()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            _ = TestCase.Invoke<object>(psShell).First();
        }

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("New-VirtStoragePool")
                .AddParameter("DeviceFormat", "Gpt")
                .AddParameter("DevicePath", "/dev/nvme0n1")
                .AddParameter("Name", "physical")
                .AddParameter("Path", "/mnt/nvme0n1");

            var pool = TestCase.Invoke<StoragePool>(psShell).First();
            Assert.IsNotNull(pool);
        }
    }

    [TestMethod]
    public void NewLogical()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            _ = TestCase.Invoke<object>(psShell).First();
        }

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("New-VirtStoragePool")
                .AddParameter("Name", "lvm")
                .AddParameter("VgName", "vgpool");

            var pool = TestCase.Invoke<StoragePool>(psShell).First();
            Assert.IsNotNull(pool);
        }
    }

    [TestMethod]
    public void NewNetfs()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            _ = TestCase.Invoke<object>(psShell).First();
        }

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("New-VirtStoragePool")
                .AddParameter("Address", "127.0.0.1")
                .AddParameter("ExportPath", "/mnt/exports")
                .AddParameter("ExportType", "Auto")
                .AddParameter("Name", "nfs")
                .AddParameter("Path", "/mnt/exports");

            var pool = TestCase.Invoke<StoragePool>(psShell).First();
            Assert.IsNotNull(pool);
        }
    }
}

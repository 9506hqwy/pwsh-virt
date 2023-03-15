namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class NewVirtHardDiskTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string Name = "test";
    private const string FilePath = "/var/lib/libvirt/images/test.qcow2";

    [TestMethod]
    public void NewDisk()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        Domain? dom = null;
        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            psShell.AddStatement().AddCommand("Get-VirtDomain").AddParameter("Name", Name);

            dom = this.Invoke<Domain>(psShell).First();
            Assert.IsNotNull(dom);
        }

        StorageVol? vol = null;
        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            psShell.AddStatement().AddCommand("Get-VirtStorageVol").AddParameter("Key", FilePath);

            vol = this.Invoke<StorageVol>(psShell).First();
            Assert.IsNotNull(vol);
        }

        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            psShell.AddCommand("New-VirtHardDisk")
                .AddParameter("Domain", dom)
                .AddParameter("Vol", vol)
                .AddParameter("DeviceFile", "vda")
                .AddParameter("DriverType", "Qcow2");

            this.Invoke<object>(psShell).First();
        }
    }
}

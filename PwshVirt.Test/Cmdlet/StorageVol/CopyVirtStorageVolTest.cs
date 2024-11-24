namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class CopyVirtStorageVolTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string VolKey = "/var/lib/libvirt/images/test.qcow2";
    private const string Name = "test2.qcow2";

    [TestMethod]
    public void Import()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        StorageVol? vol = null;
        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            _ = psShell.AddStatement().AddCommand("Get-VirtStorageVol").AddParameter("Key", VolKey);
            vol = this.Invoke<StorageVol>(psShell).First();
            Assert.IsNotNull(vol);
        }

        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Copy-VirtStorageVol")
                .AddParameter("Name", Name)
                .AddParameter("Source", vol);

            vol = this.Invoke<StorageVol>(psShell).First();
            Assert.IsNotNull(vol);
        }
    }
}

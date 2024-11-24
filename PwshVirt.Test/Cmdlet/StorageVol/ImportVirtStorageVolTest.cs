namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class ImportVirtStorageVolTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string FilePath = "/root/test.qcow2";

    [TestMethod]
    public void Import()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        StoragePool? pool = null;
        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            _ = psShell.AddStatement().AddCommand("Get-VirtStoragePool").AddParameter("Name", "default");

            pool = this.Invoke<StoragePool>(psShell).First();
            Assert.IsNotNull(pool);
        }

        StorageVol? vol = null;
        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Get-VirtStorageVol").AddParameter("Pool", pool);

            vol = this.Invoke<StorageVol>(psShell).First();
            Assert.IsNotNull(vol);
        }

        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Import-VirtStorageVol")
                .AddParameter("Destination", vol)
                .AddParameter("Path", FilePath);

            vol = this.Invoke<StorageVol>(psShell).First();
            Assert.IsNotNull(vol);
        }
    }
}

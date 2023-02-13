namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class NewVirtStorageVolTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string PoolName = "default";
    private const string Name = "test3.qcow2";

    [TestMethod]
    public void Import()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        StoragePool? pool = null;
        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            psShell.AddStatement().AddCommand("Get-VirtStoragePool").AddParameter("Name", PoolName);
            pool = this.Invoke<StoragePool>(psShell).First();
            Assert.IsNotNull(pool);
        }

        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            psShell.AddCommand("New-VirtStorageVol")
                .AddParameter("Name", Name)
                .AddParameter("Capacity", "1GiB")
                .AddParameter("Pool", pool);

            var vol = this.Invoke<StorageVol>(psShell).First();
            Assert.IsNotNull(vol);
        }
    }
}

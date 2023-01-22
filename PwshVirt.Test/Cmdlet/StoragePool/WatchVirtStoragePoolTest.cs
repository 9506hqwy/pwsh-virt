namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class WatchVirtStoragePoolTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";

    [TestMethod]
    public void Watch()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        StoragePool? pool = null;
        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            psShell.AddStatement().AddCommand("Get-VirtStoragePool").AddParameter("Name", "default");

            pool = this.Invoke<StoragePool>(psShell).First();
            Assert.IsNotNull(pool);
        }

        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            psShell.AddCommand("Watch-VirtStoragePool").AddParameter("Pool", pool);

            this.Invoke<object>(psShell).First();
        }
    }
}

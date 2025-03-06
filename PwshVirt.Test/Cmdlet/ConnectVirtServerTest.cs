namespace PwshVirt.Test;

[TestClass]
public class ConnectVirtServerTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string UriTls = "qemu+tls://127.0.0.1:16514/system?no_verify=1&pfxpath=/root/self.pfx";

    [TestMethod]
    [Ignore]
    public void ConnectTcp()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);

            var conn = TestCase.Invoke<Connection>(psShell).First();
            Assert.IsNotNull(conn);

            conn = (Connection)psShell.Runspace.SessionStateProxy.PSVariable.GetValue("DefaultVirtServer");
            Assert.IsNotNull(conn);
        }

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Disconnect-VirtServer");

            _ = TestCase.Invoke<object>(psShell);

            var conn = (Connection)psShell.Runspace.SessionStateProxy.PSVariable.GetValue("DefaultVirtServer");
            Assert.IsNull(conn);
        }
    }

    [TestMethod]
    [Ignore]
    public void ConnectTls()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTls);

            var conn = TestCase.Invoke<Connection>(psShell).First();
            Assert.IsNotNull(conn);

            conn = (Connection)psShell.Runspace.SessionStateProxy.PSVariable.GetValue("DefaultVirtServer");
            Assert.IsNotNull(conn);
        }

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Disconnect-VirtServer");

            _ = TestCase.Invoke<object>(psShell);

            var conn = (Connection)psShell.Runspace.SessionStateProxy.PSVariable.GetValue("DefaultVirtServer");
            Assert.IsNull(conn);
        }
    }
}

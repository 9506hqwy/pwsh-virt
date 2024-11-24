namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class StopVirtDomainTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string Name = "test";

    [TestMethod]
    public void Stop()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        Domain? dom = null;
        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            _ = psShell.AddStatement().AddCommand("Get-VirtDomain").AddParameter("Name", Name);

            dom = this.Invoke<Domain>(psShell).First();
            Assert.IsNotNull(dom);
        }

        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Stop-VirtDomain")
                .AddParameter("Domain", dom)
                .AddParameter("Hibernate", true);

            _ = this.Invoke<object>(psShell).First();
        }
    }
}

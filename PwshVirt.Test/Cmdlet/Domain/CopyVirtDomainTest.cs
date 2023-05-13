namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class CopyVirtDomainTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string Name = "test";
    private const string NewName = "test4";

    [TestMethod]
    public void Invoke()
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

        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            psShell.AddCommand("Copy-VirtDomain")
                .AddParameter("Source", dom)
                .AddParameter("Name", NewName);

            this.Invoke<object>(psShell).First();
        }
    }
}

namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class CopyVirtDomainGuestFileTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string Name = "test";

    [TestMethod]
    public void Invoke()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        Domain? dom = null;
        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);
            _ = psShell.AddStatement().AddCommand("Get-VirtDomain").AddParameter("Name", Name);

            dom = TestCase.Invoke<Domain>(psShell).First();
            Assert.IsNotNull(dom);
        }

        using (var psShell = TestCase.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Copy-VirtDomainGuestFile")
                .AddParameter("Domain", dom)
                .AddParameter("Source", "anaconda-ks.cfg")
                .AddParameter("Destination", "/root/anaconda-ks.cfg2")
                .AddParameter("GuestToLocal", false);

            _ = TestCase.Invoke<object>(psShell).First();
        }
    }
}

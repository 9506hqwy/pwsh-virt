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

            _ = psShell.AddCommand("Copy-VirtDomain")
                .AddParameter("Source", dom)
                .AddParameter("Name", NewName);

            _ = TestCase.Invoke<object>(psShell).First();
        }
    }
}

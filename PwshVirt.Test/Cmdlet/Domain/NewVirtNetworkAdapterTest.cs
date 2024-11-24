namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class NewVirtNetworkAdapterTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string Name = "test";

    [TestMethod]
    public void NewAdapter()
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

            _ = psShell.AddCommand("New-VirtNetworkAdapter")
                .AddParameter("Domain", dom)
                .AddParameter("Type", "Bridge")
                .AddParameter("NetworkName", "virbr0");

            _ = this.Invoke<object>(psShell).First();
        }
    }
}

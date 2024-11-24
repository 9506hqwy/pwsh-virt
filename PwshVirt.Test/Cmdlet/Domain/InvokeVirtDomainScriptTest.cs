namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class InvokeVirtDomainScriptTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string Name = "test";

    [TestMethod]
    public void Invoke()
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

            _ = psShell.AddCommand("Invoke-VirtDomainScript")
                .AddParameter("Domain", dom)
                .AddParameter("Path", "/bin/bash")
                .AddParameter("Arguments", new[] { "-c", "echo ${PATH}" });

            _ = this.Invoke<object>(psShell).First();
        }
    }
}

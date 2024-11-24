namespace PwshVirt.Test;

[TestClass]
[Ignore]
public class NewVirtDomainTest : TestCase
{
    private const string UriTcp = "qemu+tcp://127.0.0.1:16509/system";
    private const string Name = "test5";

    [TestMethod]
    public void Invoke()
    {
        using var rs = RunspaceFactory.CreateRunspace();
        rs.Open();

        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("Connect-VirtServer").AddParameter("Uri", UriTcp);

            _ = this.Invoke<object>(psShell).First();
        }

        using (var psShell = this.CreateShell())
        {
            psShell.Runspace = rs;

            _ = psShell.AddCommand("New-VirtDomain")
                .AddParameter("Name", Name)
                .AddParameter("NumCpu", 2)
                .AddParameter("Memory", "2GiB");

            _ = this.Invoke<object>(psShell).First();
        }
    }
}

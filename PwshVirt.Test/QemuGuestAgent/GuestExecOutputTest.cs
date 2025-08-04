namespace PwshVirt.Test;

[TestClass]
public class GuestExecOutputTest
{
    [TestMethod]
    public void ConvertFrom()
    {
        var m = AgentCommandOutput<GuestExecOutput>.ConvertFrom(/*lang=json,strict*/ "{\"return\":{\"pid\":1}}");
        Assert.IsNotNull(m);
        Assert.IsNotNull(m.Return);
        Assert.AreEqual(1, m.Return.Pid);
    }
}

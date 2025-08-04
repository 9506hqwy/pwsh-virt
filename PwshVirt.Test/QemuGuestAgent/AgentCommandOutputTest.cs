namespace PwshVirt.Test;

[TestClass]
public class AgentCommandOutputTest
{
    [TestMethod]
    public void ConvertFrom()
    {
        var m = AgentCommandOutput<string>.ConvertFrom(/*lang=json,strict*/ "{\"return\":\"value\"}");
        Assert.IsNotNull(m);
        Assert.AreEqual("value", m.Return);
    }
}

namespace PwshVirt.Test;

[TestClass]
public class GuesetFileWriteOutputTest
{
    [TestMethod]
    public void ConvertFrom()
    {
        var m = AgentCommandOutput<GuesetFileWriteOutput>.ConvertFrom(/*lang=json,strict*/ "{\"return\":{\"count\":1,\"eof\":true}}");
        Assert.IsNotNull(m);
        Assert.IsNotNull(m.Return);
        Assert.AreEqual(1, m.Return.Count);
        Assert.IsTrue(m.Return.Eof);
    }
}

namespace PwshVirt.Test;

[TestClass]
public class GuesetFileReadOutputTest
{
    [TestMethod]
    public void ConvertFrom()
    {
        var m = AgentCommandOutput<GuesetFileReadOutput>.ConvertFrom(/*lang=json,strict*/ "{\"return\":{\"count\":1,\"buf-b64\":\"YQ==\",\"eof\":true}}");
        Assert.IsNotNull(m);
        Assert.IsNotNull(m.Return);
        Assert.AreEqual(1, m.Return.Count);
        Assert.AreEqual("YQ==", m.Return.BufB64);
        Assert.IsTrue(m.Return.Eof);
    }
}

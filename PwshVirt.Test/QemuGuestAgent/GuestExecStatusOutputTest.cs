namespace PwshVirt.Test;

[TestClass]
public class GuestExecStatusOutputTest
{
    [TestMethod]
    public void ConvertFrom()
    {
        var m = AgentCommandOutput<GuestExecStatusOutput>.ConvertFrom(/*lang=json,strict*/ "{\"return\":{\"exited\":true,\"exitcode\":1,\"signal\":2,\"out-data\":\"YQ==\",\"err-data\":\"Yg==\",\"out-truncated\":true,\"err-truncated\":true}}");
        Assert.IsNotNull(m);
        Assert.IsNotNull(m.Return);
        Assert.AreEqual(true, m.Return.Exited);
        Assert.AreEqual(1, m.Return.Exitcode);
        Assert.AreEqual(2, m.Return.Signal);
        Assert.AreEqual("YQ==", m.Return.OutData);
        Assert.AreEqual("Yg==", m.Return.ErrData);
        Assert.AreEqual(true, m.Return.OutTruncated);
        Assert.AreEqual(true, m.Return.ErrTruncated);
    }
}

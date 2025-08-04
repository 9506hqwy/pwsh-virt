namespace PwshVirt.Test;

[TestClass]
public class GuestExecInputTest
{
    [TestMethod]
    public void ToJson()
    {
        var m = new AgentCommandInput("action")
        {
            Arguments = new GuestExecInput("a")
            {
                Arg = ["b"],
                InputData = "c",
                CaptureOutput = true,
            }
        };
        var json = m.ToJson();
        Assert.IsNotNull(json);
        Assert.AreEqual(/*lang=json,strict*/ "{\"execute\":\"action\",\"arguments\":{\"path\":\"a\",\"arg\":[\"b\"],\"input-data\":\"c\",\"capture-output\":true}}", json);
    }
}

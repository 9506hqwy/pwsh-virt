namespace PwshVirt.Test;

[TestClass]
public class GuestExecStatusInputTest
{
    [TestMethod]
    public void ToJson()
    {
        var m = new AgentCommandInput("action")
        {
            Arguments = new GuestExecStatusInput(1)
        };
        var json = m.ToJson();
        Assert.IsNotNull(json);
        Assert.AreEqual(/*lang=json,strict*/ "{\"execute\":\"action\",\"arguments\":{\"pid\":1}}", json);
    }
}

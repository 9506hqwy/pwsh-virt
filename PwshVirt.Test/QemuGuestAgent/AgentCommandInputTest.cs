namespace PwshVirt.Test;

[TestClass]
public class AgentCommandInputTest
{
    [TestMethod]
    public void ToJson()
    {
        var m = new AgentCommandInput("action")
        {
            Arguments = new { arg1 = "value1" }
        };
        var json = m.ToJson();
        Assert.IsNotNull(json);
        Assert.AreEqual(/*lang=json,strict*/ "{\"execute\":\"action\",\"arguments\":{\"arg1\":\"value1\"}}", json);
    }
}

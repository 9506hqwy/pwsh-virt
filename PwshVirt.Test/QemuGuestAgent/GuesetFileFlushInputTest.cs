namespace PwshVirt.Test;

[TestClass]
public class GuesetFileFlushInputTest
{
    [TestMethod]
    public void ToJson()
    {
        var m = new AgentCommandInput("action")
        {
            Arguments = new GuesetFileFlushInput(1)
        };
        var json = m.ToJson();
        Assert.IsNotNull(json);
        Assert.AreEqual(/*lang=json,strict*/ "{\"execute\":\"action\",\"arguments\":{\"handle\":1}}", json);
    }
}

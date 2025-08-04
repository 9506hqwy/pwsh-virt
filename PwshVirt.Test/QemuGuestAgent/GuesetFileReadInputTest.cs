namespace PwshVirt.Test;

[TestClass]
public class GuesetFileReadInputTest
{
    [TestMethod]
    public void ToJson()
    {
        var m = new AgentCommandInput("action")
        {
            Arguments = new GuesetFileReadInput(1)
            {
                Count = 2,
            }
        };
        var json = m.ToJson();
        Assert.IsNotNull(json);
        Assert.AreEqual(/*lang=json,strict*/ "{\"execute\":\"action\",\"arguments\":{\"handle\":1,\"count\":2}}", json);
    }
}

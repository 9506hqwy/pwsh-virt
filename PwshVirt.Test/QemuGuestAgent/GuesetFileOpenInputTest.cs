namespace PwshVirt.Test;

[TestClass]
public class GuesetFileOpenInputTest
{
    [TestMethod]
    public void ToJson()
    {
        var m = new AgentCommandInput("action")
        {
            Arguments = new GuesetFileOpenInput("a")
            {
                Mode = "b",
            }
        };
        var json = m.ToJson();
        Assert.IsNotNull(json);
        Assert.AreEqual(/*lang=json,strict*/ "{\"execute\":\"action\",\"arguments\":{\"path\":\"a\",\"mode\":\"b\"}}", json);
    }
}

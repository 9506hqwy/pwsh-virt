namespace PwshVirt.Test;

[TestClass]
public class GuesetFileWriteInputTest
{
    [TestMethod]
    public void ToJson()
    {
        var m = new AgentCommandInput("action")
        {
            Arguments = new GuesetFileWriteInput(1, [0x61])
            {
                Count = 3,
            }
        };
        var json = m.ToJson();
        Assert.IsNotNull(json);
        Assert.AreEqual(/*lang=json,strict*/ "{\"execute\":\"action\",\"arguments\":{\"handle\":1,\"buf-b64\":\"YQ==\",\"count\":3}}", json);
    }
}

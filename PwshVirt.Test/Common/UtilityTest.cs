namespace PwshVirt.Test;

[TestClass]
public class UtilityTest
{
    [TestMethod]
    public void GetScaledSizeToBytes()
    {
        var b = Utility.GetScaledSizeToBytes("1");
        Assert.AreEqual(1ul, b);

        b = Utility.GetScaledSizeToBytes("2b");
        Assert.AreEqual(2ul, b);

        b = Utility.GetScaledSizeToBytes("3k");
        Assert.AreEqual(3072ul, b);

        b = Utility.GetScaledSizeToBytes("4mb");
        Assert.AreEqual(4000000ul, b);

        b = Utility.GetScaledSizeToBytes("5gib");
        Assert.AreEqual(5368709120ul, b);
    }

    [TestMethod]
    [ExpectedException(typeof(PwshVirtException))]
    public void GetScaledSizeToBytesInvalidScale()
    {
        Utility.GetScaledSizeToBytes("1a");
    }

    [TestMethod]
    [ExpectedException(typeof(PwshVirtException))]
    public void GetScaledSizeToBytesInvalidUnit()
    {
        Utility.GetScaledSizeToBytes("1ik");
    }

    [TestMethod]
    [ExpectedException(typeof(PwshVirtException))]
    public void GetScaledSizeToBytesNoNumber()
    {
        Utility.GetScaledSizeToBytes("a");
    }
}

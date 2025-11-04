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
    public void GetScaledSizeToBytesInvalidScale()
    {
        _ = Assert.ThrowsExactly<PwshVirtException>(() => Utility.GetScaledSizeToBytes("1a"));
    }

    [TestMethod]
    public void GetScaledSizeToBytesInvalidUnit()
    {
        _ = Assert.ThrowsExactly<PwshVirtException>(() => Utility.GetScaledSizeToBytes("1ik"));
    }

    [TestMethod]
    public void GetScaledSizeToBytesNoNumber()
    {
        _ = Assert.ThrowsExactly<PwshVirtException>(() => Utility.GetScaledSizeToBytes("a"));
    }
}

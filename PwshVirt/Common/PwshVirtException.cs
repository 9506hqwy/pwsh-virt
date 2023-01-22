namespace PwshVirt;

using System.Runtime.Serialization;

[Serializable]
public class PwshVirtException : Exception
{
    public PwshVirtException(ErrorCategory category)
        : base()
    {
        this.Category = category;
    }

    public PwshVirtException(string message, ErrorCategory category)
        : base(message)
    {
        this.Category = category;
    }

    public PwshVirtException(
        string message,
        Exception innerException,
        ErrorCategory category)
        : base(message, innerException)
    {
        this.Category = category;
    }

    protected PwshVirtException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        this.Category = (ErrorCategory)info.GetValue(
            nameof(this.Category),
            typeof(ErrorCategory))!;
    }

    public ErrorCategory Category { get; }

    public override void GetObjectData(
        SerializationInfo info,
        StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(this.Category), this.Category);
    }
}

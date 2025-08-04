namespace PwshVirt;

#if NETSTANDARD2_0
using System.Runtime.Serialization;
#endif

[Serializable]
public class PwshVirtException : Exception
{
    public PwshVirtException()
    {
    }

    public PwshVirtException(string message) : base(message)
    {
    }

    public PwshVirtException(string message, Exception innerException) : base(message, innerException)
    {
    }

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

#if NETSTANDARD2_0
    protected PwshVirtException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        this.Category = (ErrorCategory)info.GetValue(
            nameof(this.Category),
            typeof(ErrorCategory))!;
    }
#endif

    public ErrorCategory Category { get; } = ErrorCategory.NotSpecified;

#if NETSTANDARD2_0
    public override void GetObjectData(
        SerializationInfo info,
        StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(this.Category), this.Category);
    }
#endif
}

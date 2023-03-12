namespace PwshVirt;

internal class Result : Message
{
    internal Result(object sendToPipeline, bool enumerateCollection)
    {
        this.EnumerateCollection = enumerateCollection;
        this.SendToPipeline = sendToPipeline;
    }

    internal bool EnumerateCollection { get; }

    internal object SendToPipeline { get; }
}

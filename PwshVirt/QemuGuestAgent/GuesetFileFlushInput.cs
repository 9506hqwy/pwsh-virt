namespace PwshVirt;

using System.Text.Json.Serialization;

public class GuesetFileFlushInput
{
    internal GuesetFileFlushInput(int handle)
    {
        this.Handle = handle;
    }

    [JsonPropertyName("handle")]
    public int Handle { get; set; }
}

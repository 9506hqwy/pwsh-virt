namespace PwshVirt;

using Newtonsoft.Json;

public class GuesetFileFlushInput
{
    internal GuesetFileFlushInput(int handle)
    {
        this.Handle = handle;
    }

    [JsonProperty("handle")]
    public int Handle { get; set; }
}

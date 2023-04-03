namespace PwshVirt;

using Newtonsoft.Json;

public class GuesetFileReadInput
{
    internal GuesetFileReadInput(int handle)
    {
        this.Handle = handle;
    }

    [JsonProperty("handle")]
    public int Handle { get; set; }

    [JsonProperty("count")]
    public int? Count { get; set; }
}

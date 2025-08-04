namespace PwshVirt;

using System.Text.Json.Serialization;

public class GuesetFileReadInput
{
    internal GuesetFileReadInput(int handle)
    {
        this.Handle = handle;
    }

    [JsonPropertyName("handle")]
    public int Handle { get; set; }

    [JsonPropertyName("count")]
    public int? Count { get; set; }
}

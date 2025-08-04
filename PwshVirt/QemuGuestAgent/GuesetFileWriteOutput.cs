namespace PwshVirt;

using System.Text.Json.Serialization;

public class GuesetFileWriteOutput
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("eof")]
    public bool Eof { get; set; }
}

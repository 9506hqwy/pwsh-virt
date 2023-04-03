namespace PwshVirt;

using Newtonsoft.Json;

public class GuesetFileWriteOutput
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("eof")]
    public bool Eof { get; set; }
}

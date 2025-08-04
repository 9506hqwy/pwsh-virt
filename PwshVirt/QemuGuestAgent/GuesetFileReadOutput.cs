namespace PwshVirt;

using Newtonsoft.Json;

public class GuesetFileReadOutput
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("buf-b64")]
    public string? BufB64 { get; set; }

    [JsonIgnore]
    public byte[]? BufBytes => GetByte(this.BufB64);

    [JsonProperty("eof")]
    public bool Eof { get; set; }

    private static byte[]? GetByte(string? base64)
    {
        return base64 == null ? null : Convert.FromBase64String(base64);
    }
}

namespace PwshVirt;

using System.Text.Json.Serialization;

public class GuesetFileReadOutput
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("buf-b64")]
    public string? BufB64 { get; set; }

    [JsonIgnore]
    public byte[]? BufBytes => GetByte(this.BufB64);

    [JsonPropertyName("eof")]
    public bool Eof { get; set; }

    private static byte[]? GetByte(string? base64)
    {
        return base64 == null ? null : Convert.FromBase64String(base64);
    }
}

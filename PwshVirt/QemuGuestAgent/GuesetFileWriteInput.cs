namespace PwshVirt;

using System.Text.Json.Serialization;

public class GuesetFileWriteInput
{
    internal GuesetFileWriteInput(int handle, byte[] bufBytes)
    {
        this.Handle = handle;
        this.BufBytes = bufBytes;
    }

    [JsonPropertyName("handle")]
    public int Handle { get; set; }

    [JsonPropertyName("buf-b64")]
    public string BufB64 => Encoding(this.BufBytes);

    [JsonIgnore]
    public byte[] BufBytes { get; set; }

    [JsonPropertyName("count")]
    public int? Count { get; set; }

    private static string Encoding(byte[] bytes)
    {
        return Convert.ToBase64String(bytes);
    }
}

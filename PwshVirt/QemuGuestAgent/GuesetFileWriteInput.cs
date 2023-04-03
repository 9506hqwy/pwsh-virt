namespace PwshVirt;

using Newtonsoft.Json;

public class GuesetFileWriteInput
{
    internal GuesetFileWriteInput(int handle, byte[] bufBytes)
    {
        this.Handle = handle;
        this.BufBytes = bufBytes;
    }

    [JsonProperty("handle")]
    public int Handle { get; set; }

    [JsonProperty("buf-b64")]
    public string BufB64 => this.Encoding(this.BufBytes);

    [JsonIgnore]
    public byte[] BufBytes { get; set; }

    [JsonProperty("count")]
    public int? Count { get; set; }

    private string Encoding(byte[] bytes)
    {
        return Convert.ToBase64String(bytes);
    }
}

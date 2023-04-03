﻿namespace PwshVirt;

using Newtonsoft.Json;

public class GuesetFileReadOutput
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("buf-b64")]
    public string? BufB64 { get; set; }

    [JsonIgnore]
    public byte[]? BufBytes => this.GetByte(this.BufB64);

    [JsonProperty("eof")]
    public bool Eof { get; set; }

    private byte[]? GetByte(string? base64)
    {
        if (base64 == null)
        {
            return null;
        }

        return Convert.FromBase64String(base64);
    }
}

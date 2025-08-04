namespace PwshVirt;

using System.Text.Json.Serialization;
using System.Text;

public class GuestExecStatusOutput
{
    [JsonPropertyName("exited")]
    public bool Exited { get; set; }

    [JsonPropertyName("exitcode")]
    public int? Exitcode { get; set; }

    [JsonPropertyName("signal")]
    public int? Signal { get; set; }

    [JsonPropertyName("out-data")]
    public string? OutData { get; set; }

    [JsonIgnore]
    public string? OutString => GetString(this.OutData);

    [JsonPropertyName("err-data")]
    public string? ErrData { get; set; }

    [JsonIgnore]
    public string? ErrString => GetString(this.ErrData);

    [JsonPropertyName("out-truncated")]
    public bool? OutTruncated { get; set; }

    [JsonPropertyName("err-truncated")]
    public bool? ErrTruncated { get; set; }

    private static string? GetString(string? base64)
    {
        if (base64 == null)
        {
            return null;
        }

        var bytes = Convert.FromBase64String(base64);
        return Encoding.UTF8.GetString(bytes);
    }
}

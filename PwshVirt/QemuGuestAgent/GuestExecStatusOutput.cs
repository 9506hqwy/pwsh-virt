namespace PwshVirt;

using Newtonsoft.Json;
using System.Text;

public class GuestExecStatusOutput
{
    [JsonProperty("exited")]
    public bool Exited { get; set; }

    [JsonProperty("exitcode")]
    public int? Exitcode { get; set; }

    [JsonProperty("signal")]
    public int? Signal { get; set; }

    [JsonProperty("out-data")]
    public string? OutData { get; set; }

    [JsonIgnore]
    public string? OutString => this.GetString(this.OutData);

    [JsonProperty("err-data")]
    public string? ErrData { get; set; }

    [JsonIgnore]
    public string? ErrString => this.GetString(this.ErrData);

    [JsonProperty("out-truncated")]
    public bool? OutTruncated { get; set; }

    [JsonProperty("err-truncated")]
    public bool? ErrTruncated { get; set; }

    private string? GetString(string? base64)
    {
        if (base64 == null)
        {
            return null;
        }

        var bytes = Convert.FromBase64String(base64);
        return Encoding.UTF8.GetString(bytes);
    }
}

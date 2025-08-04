namespace PwshVirt;

using System.Text.Json.Serialization;

public class GuestExecOutput
{
    [JsonPropertyName("pid")]
    public int? Pid { get; set; }
}

namespace PwshVirt;

using Newtonsoft.Json;

public class GuestExecOutput
{
    [JsonProperty("pid")]
    public int? Pid { get; set; }
}

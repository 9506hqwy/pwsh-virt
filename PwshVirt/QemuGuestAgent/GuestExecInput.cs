namespace PwshVirt;

using Newtonsoft.Json;

public class GuestExecInput
{
    internal GuestExecInput(string path)
    {
        this.Path = path;
    }

    [JsonProperty("path")]
    public string Path { get; set; }

    [JsonProperty("arg")]
    public string[]? Arg { get; set; }

    [JsonProperty("input-data")]
    public string? InputData { get; set; }

    [JsonProperty("capture-output")]
    public bool CaptureOutput { get; set; }
}

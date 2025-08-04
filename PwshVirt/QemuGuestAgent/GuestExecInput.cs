namespace PwshVirt;

using System.Text.Json.Serialization;

public class GuestExecInput
{
    internal GuestExecInput(string path)
    {
        this.Path = path;
    }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("arg")]
    public string[]? Arg { get; set; }

    [JsonPropertyName("input-data")]
    public string? InputData { get; set; }

    [JsonPropertyName("capture-output")]
    public bool CaptureOutput { get; set; }
}

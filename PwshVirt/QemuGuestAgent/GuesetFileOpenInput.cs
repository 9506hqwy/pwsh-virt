namespace PwshVirt;

using System.Text.Json.Serialization;

public class GuesetFileOpenInput
{
    internal GuesetFileOpenInput(string path)
    {
        this.Path = path;
    }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("mode")]
    public string? Mode { get; set; }
}

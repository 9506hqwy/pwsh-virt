namespace PwshVirt;

using Newtonsoft.Json;

public class GuesetFileOpenInput
{
    internal GuesetFileOpenInput(string path)
    {
        this.Path = path;
    }

    [JsonProperty("path")]
    public string Path { get; set; }

    [JsonProperty("mode")]
    public string? Mode { get; set; }
}

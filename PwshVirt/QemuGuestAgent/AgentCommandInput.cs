namespace PwshVirt;

using System.Text.Json;
using System.Text.Json.Serialization;

public class AgentCommandInput
{
    private static readonly JsonSerializerOptions options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    internal AgentCommandInput(string execute)
    {
        this.Execute = execute;
    }

    [JsonPropertyName("execute")]
    public string Execute { get; set; }

    [JsonPropertyName("arguments")]
    public object? Arguments { get; set; }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this, options);
    }
}

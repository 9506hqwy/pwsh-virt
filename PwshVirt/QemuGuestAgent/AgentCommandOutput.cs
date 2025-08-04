namespace PwshVirt;

using System.Text.Json;
using System.Text.Json.Serialization;

public class AgentCommandOutput<T>
{
    [JsonPropertyName("return")]
    public T? Return { get; set; }

#pragma warning disable CA1000
    public static AgentCommandOutput<T>? ConvertFrom(string json)
#pragma warning restore CA1000
    {
        return JsonSerializer.Deserialize<AgentCommandOutput<T>>(json);
    }
}

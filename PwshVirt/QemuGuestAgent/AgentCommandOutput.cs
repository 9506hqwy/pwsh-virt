namespace PwshVirt;

using Newtonsoft.Json;

public class AgentCommandOutput<T>
{
    [JsonProperty("return")]
    public T? Return { get; set; }

#pragma warning disable CA1000
    public static AgentCommandOutput<T>? ConvertFrom(string json)
#pragma warning restore CA1000
    {
        return JsonConvert.DeserializeObject<AgentCommandOutput<T>>(json);
    }
}

namespace PwshVirt;

using Newtonsoft.Json;

public class AgentCommandOutput<T>
{
    [JsonProperty("return")]
    public T? Return { get; set; }

    public static AgentCommandOutput<T>? ConvertFrom(string json)
    {
        return JsonConvert.DeserializeObject<AgentCommandOutput<T>>(json);
    }
}

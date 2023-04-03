namespace PwshVirt;

using Newtonsoft.Json;

public class AgentCommandInput
{
    internal AgentCommandInput(string execute)
    {
        this.Execute = execute;
    }

    [JsonProperty("execute")]
    public string Execute { get; set; }

    [JsonProperty("arguments")]
    public object? Arguments { get; set; }

    public string ToJson()
    {
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
        };

        return JsonConvert.SerializeObject(this, settings);
    }
}

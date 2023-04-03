namespace PwshVirt;

using Newtonsoft.Json;

public class GuesetFileCloseInput
{
    internal GuesetFileCloseInput(int handle)
    {
        this.Handle = handle;
    }

    [JsonProperty("handle")]
    public int Handle { get; set; }
}

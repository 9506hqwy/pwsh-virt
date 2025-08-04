namespace PwshVirt;

using System.Text.Json.Serialization;

public class GuesetFileCloseInput
{
    internal GuesetFileCloseInput(int handle)
    {
        this.Handle = handle;
    }

    [JsonPropertyName("handle")]
    public int Handle { get; set; }
}

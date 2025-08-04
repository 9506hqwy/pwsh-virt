namespace PwshVirt;

using System.Text.Json.Serialization;

public class GuestExecStatusInput
{
    internal GuestExecStatusInput(int pid)
    {
        this.Pid = pid;
    }

    [JsonPropertyName("pid")]
    public int Pid { get; set; }
}

namespace PwshVirt;

using Newtonsoft.Json;

public class GuestExecStatusInput
{
    internal GuestExecStatusInput(int pid)
    {
        this.Pid = pid;
    }

    [JsonProperty("pid")]
    public int Pid { get; set; }
}

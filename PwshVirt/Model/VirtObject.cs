namespace PwshVirt;

public class VirtObject
{
    internal VirtObject(Connection conn)
    {
        this.Conn = conn;
    }

    internal Connection Conn { get; }
}

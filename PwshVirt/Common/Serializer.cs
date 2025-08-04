namespace PwshVirt;

using System.Text;
using System.Xml.Serialization;

internal static class Serializer
{
    internal static T Deserialize<T>(string value)
    {
        var ser = new XmlSerializer(typeof(T));

        using var mem = new MemoryStream(Encoding.UTF8.GetBytes(value));
        _ = mem.Seek(0, SeekOrigin.Begin);

#pragma warning disable CA5369
        return (T)ser.Deserialize(mem)!;
#pragma warning restore CA5369
    }

    internal static string Serialize<T>(T obj)
    {
        var ser = new XmlSerializer(typeof(T));

        using var mem = new MemoryStream();
        ser.Serialize(mem, obj);

        return Encoding.UTF8.GetString(mem.ToArray());
    }
}

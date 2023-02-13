namespace PwshVirt;

using System.Text;
using System.Xml.Serialization;

internal static class Serializer
{
    internal static string Serialize<T>(T obj)
    {
        var ser = new XmlSerializer(typeof(T));

        using var mem = new MemoryStream();
        ser.Serialize(mem, obj);

        return Encoding.UTF8.GetString(mem.ToArray());
    }
}

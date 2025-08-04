namespace PwshVirt;

using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

internal static class Utility
{
    internal static string ConvertXmlEnumToString<T>(object obj)
    {
        var field = typeof(T).GetField(obj.ToString()!);
        var attr = field!.GetCustomAttribute<XmlEnumAttribute>();
        return attr!.Name!;
    }

    internal static T ConvertStringToXmlEnum<T>(string value)
    {
        foreach (var field in typeof(T).GetFields())
        {
            var attr = field!.GetCustomAttribute<XmlEnumAttribute>();
            if (attr is not null && attr.Name == value)
            {
                return (T)field.GetValue(null)!;
            }
        }

        throw new InvalidProgramException();
    }

    internal static ulong GetScaledSizeToBytes(string value)
    {
        var m = Regex.Match(value, @"^(\d+)([^\d]*)$");
        if (!m.Success)
        {
            throw new PwshVirtException(
                string.Format(CultureInfo.CurrentCulture, Resource.ERR_InvalidFormat, value),
                ErrorCategory.InvalidArgument);
        }

        var num = ulong.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
        var scale = m.Groups[2].Value.ToLower(CultureInfo.InvariantCulture);

        if (string.IsNullOrEmpty(scale) || scale == "b" || scale == "byte" || scale == "bytes")
        {
            return num;
        }

        uint b = scale switch
        {
            _ when scale.EndsWith("ib", StringComparison.InvariantCultureIgnoreCase) && scale.Length == 3 => 1024,
#pragma warning disable CA1867 // for .Net Standard 2.0 compatibility
            _ when scale.EndsWith("b", StringComparison.InvariantCultureIgnoreCase) && scale.Length == 2 => 1000,
#pragma warning restore CA1867
            _ when scale.Length == 1 => 1024,
            _ => throw new PwshVirtException(
                string.Format(CultureInfo.CurrentCulture, Resource.ERR_InvalidFormat, value),
                ErrorCategory.InvalidArgument),
        };

        switch (scale[0])
        {
            case 'e':
                num *= b;
                goto case 'p';
            case 'p':
                num *= b;
                goto case 't';
            case 't':
                num *= b;
                goto case 'g';
            case 'g':
                num *= b;
                goto case 'm';
            case 'm':
                num *= b;
                goto case 'k';
            case 'k':
                num *= b;
                break;
            default:
                throw new PwshVirtException(
                    string.Format(CultureInfo.CurrentCulture, Resource.ERR_InvalidFormat, value),
                    ErrorCategory.InvalidArgument);
        }

        return num;
    }
}

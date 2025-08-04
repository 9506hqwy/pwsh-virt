namespace PwshVirt;

using System.Globalization;
using System.Resources;

internal static class Resource
{
#if NETSTANDARD2_0
    private static readonly ResourceManager Rm = new("PwshVirt.Locale.Resource", typeof(Resource).Assembly);
#else
    private static readonly ResourceManager Rm = new("PwshVirt.Resource", typeof(Resource).Assembly);
#endif

    internal static string ERR_AlreadyExistStoragePool => Rm.GetString("ERR_AlreadyExistStoragePool", CultureInfo.CurrentCulture)!;

    internal static string ERR_AlreadyExistStorageVol => Rm.GetString("ERR_AlreadyExistStorageVol", CultureInfo.CurrentCulture)!;

    internal static string ERR_CopyVirtDomain_ShouldContainDomainNameInDisk => Rm.GetString("ERR_CopyVirtDomain_ShouldContainDomainNameInDisk", CultureInfo.CurrentCulture)!;

    internal static string ERR_InvalidFormat => Rm.GetString("ERR_InvalidFormat", CultureInfo.CurrentCulture)!;

    internal static string ERR_NotFoundDomainDevice => Rm.GetString("ERR_NotFoundDomainDevice", CultureInfo.CurrentCulture)!;

    internal static string ERR_ShouldConnectVirtServer => Rm.GetString("ERR_ShouldConnectVirtServer", CultureInfo.CurrentCulture)!;

    internal static string ERR_ShouldPowerOffDomain => Rm.GetString("ERR_ShouldPowerOffDomain", CultureInfo.CurrentCulture)!;
}

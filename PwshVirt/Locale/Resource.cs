namespace PwshVirt;

using System.Resources;

internal static class Resource
{
    private static readonly ResourceManager Rm;

    static Resource()
    {
        Rm = new ResourceManager("PwshVirt.Locale.Resource", typeof(Resource).Assembly);
    }

    internal static string ERR_AlreadyExistStoragePool => Rm.GetString("ERR_AlreadyExistStoragePool");

    internal static string ERR_AlreadyExistStorageVol => Rm.GetString("ERR_AlreadyExistStorageVol");

    internal static string ERR_CopyVirtDomain_ShouldContainDomainNameInDisk => Rm.GetString("ERR_CopyVirtDomain_ShouldContainDomainNameInDisk");

    internal static string ERR_InvalidFormat => Rm.GetString("ERR_InvalidFormat");

    internal static string ERR_NotFoundDomainDevice => Rm.GetString("ERR_NotFoundDomainDevice");

    internal static string ERR_ShouldConnectVirtServer => Rm.GetString("ERR_ShouldConnectVirtServer");

    internal static string ERR_ShouldPowerOffDomain => Rm.GetString("ERR_ShouldPowerOffDomain");
}

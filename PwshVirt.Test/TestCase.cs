#pragma warning disable CA1052
namespace PwshVirt.Test;

public class TestCase
{
    internal static PowerShell CreateShell()
    {
        using var psShell = PowerShell.Create();
        _ = psShell.AddCommand("Import-Module").AddParameter("Assembly", typeof(VirtObject).Assembly);
        return psShell.AddStatement();
    }

    internal static IEnumerable<T> Invoke<T>(PowerShell shell)
    {
        var ret = shell.Invoke()
            .Where(o => o.BaseObject is not null)
            .Where(o => typeof(T).IsAssignableFrom(o.BaseObject.GetType()))
            .Select(o => (T)o.BaseObject);
        return shell.HadErrors ? throw new Exception(shell.Streams.Error.First().Exception.Message) : ret;
    }
}
#pragma warning restore CA1052

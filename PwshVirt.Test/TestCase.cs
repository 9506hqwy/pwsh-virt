namespace PwshVirt.Test;

public class TestCase
{
    internal PowerShell CreateShell()
    {
        var psShell = PowerShell.Create();
        psShell.AddCommand("Import-Module").AddParameter("Assembly", typeof(VirtObject).Assembly);
        return psShell.AddStatement();
    }

    internal IEnumerable<T> Invoke<T>(PowerShell shell)
    {
        var ret = shell.Invoke()
            .Where(o => o.BaseObject is not null)
            .Where(o => typeof(T).IsAssignableFrom(o.BaseObject.GetType()))
            .Select(o => (T)o.BaseObject);
        if (shell.HadErrors)
        {
            throw new Exception(shell.Streams.Error.First().Exception.Message);
        }

        return ret;
    }
}

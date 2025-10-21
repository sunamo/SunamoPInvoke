// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoPInvoke.PInvoke.ByDll;

public class User32
{
    /// <summary>
    /// Provides access to function required to delete handle. This method is used publicly
    /// and is not required to be called separately.
    /// </summary>
    /// <param name="hIcon">Pointer to icon handle.</param>
    /// <returns>N/A</returns>
    [DllImport("User32.dll")]
    public static extern int DestroyIcon(nint hIcon);
}

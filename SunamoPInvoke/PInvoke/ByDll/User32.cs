namespace SunamoPInvoke.PInvoke.ByDll;

/// <summary>
/// Represents the user 32 type.
/// </summary>
public class User32
{
    /// <summary>
    /// Destroy icon.
    /// </summary>
    /// <param name="hIcon">The h icon.</param>
    /// <returns>The destroy icon result.</returns>
    [DllImport("User32.dll")]
    public static extern int DestroyIcon(nint hIcon);
}

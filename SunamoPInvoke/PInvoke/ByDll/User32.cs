namespace SunamoPInvoke.PInvoke.ByDll;

/// <summary>
/// Provides P/Invoke declarations for User32.dll functions.
/// </summary>
public class User32
{
    /// <summary>
    /// Destroys an icon and frees any memory the icon occupied.
    /// </summary>
    /// <param name="hIcon">Pointer to icon handle.</param>
    /// <returns>Non-zero if the function succeeds.</returns>
    [DllImport("User32.dll")]
    public static extern int DestroyIcon(nint hIcon);
}

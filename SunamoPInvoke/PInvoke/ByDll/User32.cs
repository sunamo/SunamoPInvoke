namespace SunamoPInvoke.PInvoke.ByDll;

public class User32
{
    [DllImport("User32.dll")]
    public static extern int DestroyIcon(nint hIcon);
}

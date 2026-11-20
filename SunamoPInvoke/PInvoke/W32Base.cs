namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Represents the w 32 base type.
/// </summary>
public class W32Base
{
    /// <summary>
    /// Represents the low level keyboard proc type.
    /// </summary>
    public delegate nint LowLevelKeyboardProc(
        int nCode, nint wParam, nint lParam);

    /// <summary>
    /// Represents the hook proc type.
    /// </summary>
    public delegate nint HookProc(int nCode, nint wParam, nint lParam);
}

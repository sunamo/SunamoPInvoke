namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Provides base delegate definitions for Windows hook procedures used in P/Invoke operations.
/// </summary>
public class W32Base
{
    /// <summary>
    /// Delegate for a low-level keyboard hook procedure.
    /// </summary>
    /// <param name="nCode">The hook code passed to the hook procedure.</param>
    /// <param name="wParam">The identifier of the keyboard message.</param>
    /// <param name="lParam">A pointer to a low-level keyboard input event structure.</param>
    /// <returns>The result of the hook processing.</returns>
    public delegate nint LowLevelKeyboardProc(
        int nCode, nint wParam, nint lParam);

    /// <summary>
    /// Delegate for a general hook procedure.
    /// </summary>
    /// <param name="nCode">The hook code passed to the hook procedure.</param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns>The result of the hook processing.</returns>
    public delegate nint HookProc(int nCode, nint wParam, nint lParam);
}

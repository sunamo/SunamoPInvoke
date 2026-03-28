namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Provides a global keyboard hook for capturing keyboard events system-wide. Based on https://gist.github.com/Stasonix
/// </summary>
public class GlobalKeyboardHook : W32Base, IDisposable
{
    /// <summary>
    /// Occurs when a keyboard key is pressed or released.
    /// </summary>
    public event EventHandler<GlobalKeyboardHookEventArgs>? KeyboardPressed;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalKeyboardHook"/> class.
    /// Does not distinguish between uppercase and lowercase letters, even when caps lock is on.
    /// </summary>
    /// <exception cref="Win32Exception">Thrown when the hook installation fails.</exception>
    public GlobalKeyboardHook()
    {
        windowsHookHandle = nint.Zero;
        user32LibraryHandle = nint.Zero;
        hookProc = new HookProc(LowLevelKeyboardProc2);

        user32LibraryHandle = W32.LoadLibrary("User32");
        if (user32LibraryHandle == nint.Zero)
        {
            int errorCode = Marshal.GetLastWin32Error();
            throw new Win32Exception(errorCode, $"Failed to load library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
        }

        windowsHookHandle = W32.SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, user32LibraryHandle, 0);
        if (windowsHookHandle == nint.Zero)
        {
            int errorCode = Marshal.GetLastWin32Error();
            throw new Win32Exception(errorCode, $"Failed to adjust keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
        }
    }

    /// <summary>
    /// Releases the keyboard hook and frees the User32 library.
    /// </summary>
    /// <param name="isDisposing">True if called from Dispose, false if called from finalizer.</param>
    protected virtual void Dispose(bool isDisposing)
    {
        if (isDisposing)
        {
            if (windowsHookHandle != nint.Zero)
            {
                if (!W32.UnhookWindowsHookEx(windowsHookHandle))
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                windowsHookHandle = nint.Zero;

                hookProc = null!;
            }
        }

        if (user32LibraryHandle != nint.Zero)
        {
            if (!W32.FreeLibrary(user32LibraryHandle))
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Failed to unload library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }
            user32LibraryHandle = nint.Zero;
        }
    }

    /// <summary>
    /// Finalizer that releases unmanaged resources.
    /// </summary>
    ~GlobalKeyboardHook()
    {
        Dispose(false);
    }

    /// <summary>
    /// Releases all resources used by the <see cref="GlobalKeyboardHook"/>.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private nint windowsHookHandle;
    private nint user32LibraryHandle;
    private HookProc hookProc;

    /// <summary>
    /// The identifier for low-level keyboard hook.
    /// </summary>
    public const int WH_KEYBOARD_LL = 13;

    /// <summary>
    /// Specifies the state of a keyboard key event.
    /// </summary>
    public enum KeyboardState
    {
        /// <summary>
        /// A key was pressed.
        /// </summary>
        KeyDown = 0x0100,
        /// <summary>
        /// A key was released.
        /// </summary>
        KeyUp = 0x0101,
        /// <summary>
        /// A system key was pressed.
        /// </summary>
        SysKeyDown = 0x0104,
        /// <summary>
        /// A system key was released.
        /// </summary>
        SysKeyUp = 0x0105
    }

    /// <summary>
    /// Virtual key code for the Print Screen key.
    /// </summary>
    public const int VkSnapshot = 0x2c;

    private const int KfAltdown = 0x2000;

    /// <summary>
    /// Low-level keyboard hook flag indicating Alt key is down.
    /// </summary>
    public const int LlkhfAltdown = KfAltdown >> 8;

    /// <summary>
    /// Callback for the low-level keyboard hook procedure.
    /// </summary>
    /// <param name="nCode">The hook code passed to the hook procedure.</param>
    /// <param name="wParam">The identifier of the keyboard message.</param>
    /// <param name="lParam">A pointer to a LowLevelKeyboardInputEvent structure.</param>
    /// <returns>A non-zero value to prevent the message from being passed to the target window.</returns>
    public nint LowLevelKeyboardProc2(int nCode, nint wParam, nint lParam)
    {
        var messageType = wParam.ToInt32();
        if (Enum.IsDefined(typeof(KeyboardState), messageType))
        {
            LowLevelKeyboardInputEvent keyboardInputEvent = (LowLevelKeyboardInputEvent)Marshal.PtrToStructure(lParam, typeof(LowLevelKeyboardInputEvent))!;

            var eventArguments = new GlobalKeyboardHookEventArgs(keyboardInputEvent, (KeyboardState)messageType);

            EventHandler<GlobalKeyboardHookEventArgs>? handler = KeyboardPressed;
            handler?.Invoke(this, eventArguments);
        }

        return 1;
    }
}

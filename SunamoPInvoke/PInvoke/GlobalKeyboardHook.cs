namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Represents the global keyboard hook type.
/// </summary>
public class GlobalKeyboardHook : W32Base, IDisposable
{
    /// <summary>
    /// The keyboard pressed.
    /// </summary>
    public event EventHandler<GlobalKeyboardHookEventArgs>? KeyboardPressed;

    /// <summary>
    /// Global keyboard hook.
    /// </summary>
    /// <returns>The global keyboard hook result.</returns>
    public GlobalKeyboardHook()
    {
        windowsHookHandle = 0;
        user32LibraryHandle = 0;
        hookProc = new HookProc(LowLevelKeyboardProc2);

        user32LibraryHandle = W32.LoadLibrary("User32");
        if (user32LibraryHandle == 0)
        {
            int errorCode = Marshal.GetLastWin32Error();
            throw new Win32Exception(errorCode, $"Failed to load library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
        }

        windowsHookHandle = W32.SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, user32LibraryHandle, 0);
        if (windowsHookHandle == 0)
        {
            int errorCode = Marshal.GetLastWin32Error();
            throw new Win32Exception(errorCode, $"Failed to adjust keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
        }
    }

    /// <summary>
    /// Dispose.
    /// </summary>
    /// <param name="isDisposing">The is disposing.</param>
    /// <returns>The dispose result.</returns>
    protected virtual void Dispose(bool isDisposing)
    {
        if (isDisposing)
        {
            if (windowsHookHandle != 0)
            {
                if (!W32.UnhookWindowsHookEx(windowsHookHandle))
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                windowsHookHandle = 0;

                hookProc = null!;
            }
        }

        if (user32LibraryHandle != 0)
        {
            if (!W32.FreeLibrary(user32LibraryHandle))
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Failed to unload library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }
            user32LibraryHandle = 0;
        }
    }

    /// <summary>
    /// Global keyboard hook.
    /// </summary>
    /// <returns>The global keyboard hook result.</returns>
    ~GlobalKeyboardHook()
    {
        Dispose(false);
    }

    /// <summary>
    /// Initializes a new instance of the dispose class.
    /// </summary>
    /// <param name="false">The false.</param>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private nint windowsHookHandle;
    private nint user32LibraryHandle;
    private HookProc hookProc;

    /// <summary>
    /// The WH KEYBOARD LL constant.
    /// </summary>
    public const int WH_KEYBOARD_LL = 13;

    /// <summary>
    /// Represents the keyboard state type.
    /// </summary>
    public enum KeyboardState
    {
        /// <summary>
        /// The key down value.
        /// </summary>
        KeyDown = 0x0100,
        /// <summary>
        /// The key up value.
        /// </summary>
        KeyUp = 0x0101,
        /// <summary>
        /// The sys key down value.
        /// </summary>
        SysKeyDown = 0x0104,
        /// <summary>
        /// The sys key up value.
        /// </summary>
        SysKeyUp = 0x0105
    }

    /// <summary>
    /// The vk snapshot constant.
    /// </summary>
    public const int VkSnapshot = 0x2c;

    private const int KfAltdown = 0x2000;

    /// <summary>
    /// The llkhf altdown constant.
    /// </summary>
    public const int LlkhfAltdown = KfAltdown >> 8;

    /// <summary>
    /// Low level keyboard proc 2.
    /// </summary>
    /// <param name="nCode">The n code.</param>
    /// <param name="wParam">The w param.</param>
    /// <param name="lParam">The l param.</param>
    /// <returns>The low level keyboard proc 2 result.</returns>
    public nint LowLevelKeyboardProc2(int nCode, nint wParam, nint lParam)
    {
        var messageType = (int)wParam;
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

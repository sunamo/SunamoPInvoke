namespace SunamoPInvoke.PInvoke;

public class GlobalKeyboardHook : W32Base, IDisposable
{
    public event EventHandler<GlobalKeyboardHookEventArgs>? KeyboardPressed;

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

    ~GlobalKeyboardHook()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private nint windowsHookHandle;
    private nint user32LibraryHandle;
    private HookProc hookProc;

    public const int WH_KEYBOARD_LL = 13;

    public enum KeyboardState
    {
        KeyDown = 0x0100,
        KeyUp = 0x0101,
        SysKeyDown = 0x0104,
        SysKeyUp = 0x0105
    }

    public const int VkSnapshot = 0x2c;

    private const int KfAltdown = 0x2000;

    public const int LlkhfAltdown = KfAltdown >> 8;

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

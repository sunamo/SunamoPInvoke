namespace SunamoPInvoke.PInvoke;

//Based on https://gist.github.com/Stasonix
public class GlobalKeyboardHook : W32Base, IDisposable
{
    public event EventHandler<GlobalKeyboardHookEventArgs> KeyboardPressed;

    /// <summary>
    /// Nerozlišuje mezi velkými a malými písmeny
    /// dokonce i když je zapnutý caps lock
    /// </summary>
    /// <exception cref="Win32Exception"></exception>
    public GlobalKeyboardHook()
    {
        _windowsHookHandle = nint.Zero;
        _user32LibraryHandle = nint.Zero;
        _hookProc = new HookProc(LowLevelKeyboardProc2); // we must keep alive _hookProc, because GC is not aware about SetWindowsHookEx behaviour.


        _user32LibraryHandle = W32.LoadLibrary("User32");
        if (_user32LibraryHandle == nint.Zero)
        {
            int errorCode = Marshal.GetLastWin32Error();
            throw new Win32Exception(errorCode, $"Failed to load library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
        }

        _windowsHookHandle = W32.SetWindowsHookEx(WH_KEYBOARD_LL, _hookProc, _user32LibraryHandle, 0);
        if (_windowsHookHandle == nint.Zero)
        {
            int errorCode = Marshal.GetLastWin32Error();
            throw new Win32Exception(errorCode, $"Failed to adjust keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // because we can unhook only in the same thread, not in garbage collector thread
            if (_windowsHookHandle != nint.Zero)
            {
                if (!W32.UnhookWindowsHookEx(_windowsHookHandle))
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                _windowsHookHandle = nint.Zero;

                // ReSharper disable once DelegateSubtraction
                _hookProc -= LowLevelKeyboardProc2;
            }
        }

        if (_user32LibraryHandle != nint.Zero)
        {
            if (!W32.FreeLibrary(_user32LibraryHandle)) // reduces reference to library by 1.
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Failed to unload library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }
            _user32LibraryHandle = nint.Zero;
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

    private nint _windowsHookHandle;
    private nint _user32LibraryHandle;
    private HookProc _hookProc;

    public const int WH_KEYBOARD_LL = 13;
    //const int HC_ACTION = 0;

    public enum KeyboardState
    {
        KeyDown = 0x0100,
        KeyUp = 0x0101,
        SysKeyDown = 0x0104,
        SysKeyUp = 0x0105
    }

    public const int VkSnapshot = 0x2c;
    //const int VkLwin = 0x5b;
    //const int VkRwin = 0x5c;
    //const int VkTab = 0x09;
    //const int VkEscape = 0x18;
    //const int VkControl = 0x11;
    const int KfAltdown = 0x2000;
    public const int LlkhfAltdown = KfAltdown >> 8;

    public nint LowLevelKeyboardProc2(int nCode, nint wParam, nint lParam)
    {
        bool fEatKeyStroke = false;

        var wparamTyped = wParam.ToInt32();
        if (Enum.IsDefined(typeof(KeyboardState), wparamTyped))
        {
            object o = Marshal.PtrToStructure(lParam, typeof(LowLevelKeyboardInputEvent));
            LowLevelKeyboardInputEvent p = (LowLevelKeyboardInputEvent)o;

            var eventArguments = new GlobalKeyboardHookEventArgs(p, (KeyboardState)wparamTyped);

            EventHandler<GlobalKeyboardHookEventArgs> handler = KeyboardPressed;
            handler?.Invoke(this, eventArguments);

            fEatKeyStroke = eventArguments.Handled;
        }

        return 1;
        //return fEatKeyStroke ? (IntPtr)1 : W32.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
    }
}
namespace SunamoPInvoke.PInvoke;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class W32 : W32Base
{
    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
    [DllImport(@"urlmon.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public extern static System.UInt32 FindMimeFromData(System.UInt32 pBC, [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl, [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer, System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed, System.UInt32 dwMimeFlags, out System.UInt32 ppwzMimeOut, System.UInt32 dwReserverd);
    [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DestroyIcon(IntPtr hIcon);
    [DllImport("kernel32.dll", ExactSpelling = true)]
    public static extern IntPtr GetCurrentProcess();
    [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);
    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool LookupPrivilegeValue(string host, string name, ref LUID pluid);
    [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TOKEN_PRIVILEGES newst, int len, IntPtr prev, IntPtr relen);
    [DllImport("user32.dll")]
    public static extern IntPtr GetShellWindow();
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, uint processId);
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool DuplicateTokenEx(IntPtr hExistingToken, uint dwDesiredAccess, IntPtr lpTokenAttributes, SECURITY_IMPERSONATION_LEVEL impersonationLevel, TOKEN_TYPE tokenType, out IntPtr phNewToken);
    [DllImport("advapi32", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool CreateProcessWithTokenW(IntPtr hToken, int dwLogonFlags, string lpApplicationName, string lpCommandLine, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, [In] ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);
    /// <summary>
    /// Places the given window in the system-maintained clipboard format listener list.
    /// </summary>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool AddClipboardFormatListener(IntPtr hwnd);
    /// <summary>
    /// Removes the given window from the system-maintained clipboard format listener list.
    /// </summary>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
    /// <summary>
    /// Sent when the contents of the clipboard have changed.
    /// </summary>
    public const int WM_CLIPBOARDUPDATE = 0x031D;
    /// <summary>
    /// To find message-only windows, specify HWND_MESSAGE in the hwndParent parameter of the FindWindowEx function.
    /// </summary>
    public static IntPtr HWND_MESSAGE = new IntPtr(-3);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
    public static extern short GetKeyState(int keyCode);
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GlobalLock(IntPtr hMem);
    [DllImport("Kernel32.Dll", EntryPoint = "Wow64EnableWow64FsRedirection")]
    public static extern bool EnableWow64FSRedirection(bool enable);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool CloseClipboard();
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetClipboardData(uint uFormat, IntPtr data);
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern IntPtr GetOpenClipboardWindow();
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GlobalUnlock(IntPtr hMem);
    /// <summary>
    /// Retrieves the current size of the specified global memory object, in bytes.
    /// </summary>
    /// <param name = "hMem"></param>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern UIntPtr GlobalSize(IntPtr hMem);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetClipboardData(uint uFormat);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool IsClipboardFormatAvailable(uint format);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool OpenClipboard(IntPtr hWndNewOwner);
}
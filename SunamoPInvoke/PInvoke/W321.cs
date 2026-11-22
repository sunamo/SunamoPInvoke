namespace SunamoPInvoke.PInvoke;

public partial class W32 : W32Base
{
    /// <summary>
    /// Get device caps.
    /// </summary>
    /// <param name="hdc">The hdc.</param>
    /// <param name="nIndex">The n index.</param>
    /// <returns>The get device caps result.</returns>
    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

    /// <summary>
    /// Find mime from data.
    /// </summary>
    /// <param name="pBC">The p BC.</param>
    /// <param name="pwzUrl">The pwz url.</param>
    /// <param name="pBuffer">The p buffer.</param>
    /// <param name="cbSize">The cb size.</param>
    /// <param name="pwzMimeProposed">The pwz mime proposed.</param>
    /// <param name="dwMimeFlags">The dw mime flags.</param>
    /// <param name="ppwzMimeOut">The ppwz mime out.</param>
    /// <param name="dwReserverd">The dw reserverd.</param>
    /// <returns>The find mime from data result.</returns>
    [DllImport(@"urlmon.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern System.UInt32 FindMimeFromData(System.UInt32 pBC, [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl, [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer, System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed, System.UInt32 dwMimeFlags, out System.UInt32 ppwzMimeOut, System.UInt32 dwReserverd);

    /// <summary>
    /// SH get file info.
    /// </summary>
    /// <param name="pszPath">The psz path.</param>
    /// <param name="dwFileAttributes">The dw file attributes.</param>
    /// <param name="psfi">The psfi.</param>
    /// <param name="cbFileInfo">The cb file info.</param>
    /// <param name="uFlags">The u flags.</param>
    /// <returns>The SH get file info result.</returns>
    [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

    /// <summary>
    /// Destroy icon.
    /// </summary>
    /// <param name="hIcon">The h icon.</param>
    /// <returns>The destroy icon result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DestroyIcon(IntPtr hIcon);

    /// <summary>
    /// Get current process.
    /// </summary>
    /// <returns>The get current process result.</returns>
    [DllImport("kernel32.dll", ExactSpelling = true)]
    public static extern IntPtr GetCurrentProcess();

    /// <summary>
    /// Open process token.
    /// </summary>
    /// <param name="h">The h.</param>
    /// <param name="acc">The acc.</param>
    /// <param name="phtok">The phtok.</param>
    /// <returns>The open process token result.</returns>
    [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

    /// <summary>
    /// Lookup privilege value.
    /// </summary>
    /// <param name="host">The host.</param>
    /// <param name="name">The name.</param>
    /// <param name="pluid">The pluid.</param>
    /// <returns>The lookup privilege value result.</returns>
    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool LookupPrivilegeValue(string host, string name, ref LUID pluid);

    /// <summary>
    /// Adjust token privileges.
    /// </summary>
    /// <param name="htok">The htok.</param>
    /// <param name="disall">The disall.</param>
    /// <param name="newst">The newst.</param>
    /// <param name="len">The len.</param>
    /// <param name="prev">The prev.</param>
    /// <param name="relen">The relen.</param>
    /// <returns>The adjust token privileges result.</returns>
    [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TOKEN_PRIVILEGES newst, int len, IntPtr prev, IntPtr relen);

    /// <summary>
    /// Get shell window.
    /// </summary>
    /// <returns>The get shell window result.</returns>
    [DllImport("user32.dll")]
    public static extern IntPtr GetShellWindow();

    /// <summary>
    /// Open process.
    /// </summary>
    /// <param name="processAccess">The process access.</param>
    /// <param name="bInheritHandle">The b inherit handle.</param>
    /// <param name="processId">The process id.</param>
    /// <returns>The open process result.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, uint processId);

    /// <summary>
    /// Duplicate token ex.
    /// </summary>
    /// <param name="hExistingToken">The h existing token.</param>
    /// <param name="dwDesiredAccess">The dw desired access.</param>
    /// <param name="lpTokenAttributes">The lp token attributes.</param>
    /// <param name="impersonationLevel">The impersonation level.</param>
    /// <param name="tokenType">The token type.</param>
    /// <param name="phNewToken">The ph new token.</param>
    /// <returns>The duplicate token ex result.</returns>
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool DuplicateTokenEx(IntPtr hExistingToken, uint dwDesiredAccess, IntPtr lpTokenAttributes, SECURITY_IMPERSONATION_LEVEL impersonationLevel, TOKEN_TYPE tokenType, out IntPtr phNewToken);

    /// <summary>
    /// Create process with token w.
    /// </summary>
    /// <param name="hToken">The h token.</param>
    /// <param name="dwLogonFlags">The dw logon flags.</param>
    /// <param name="lpApplicationName">The lp application name.</param>
    /// <param name="lpCommandLine">The lp command line.</param>
    /// <param name="dwCreationFlags">The dw creation flags.</param>
    /// <param name="lpEnvironment">The lp environment.</param>
    /// <param name="lpCurrentDirectory">The lp current directory.</param>
    /// <param name="lpStartupInfo">The lp startup info.</param>
    /// <param name="lpProcessInformation">The lp process information.</param>
    /// <returns>The create process with token w result.</returns>
    [DllImport("advapi32", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool CreateProcessWithTokenW(IntPtr hToken, int dwLogonFlags, string lpApplicationName, string lpCommandLine, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, [In] ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

    /// <summary>
    /// Add clipboard format listener.
    /// </summary>
    /// <param name="hwnd">The hwnd.</param>
    /// <returns>The add clipboard format listener result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool AddClipboardFormatListener(IntPtr hwnd);

    /// <summary>
    /// Remove clipboard format listener.
    /// </summary>
    /// <param name="hwnd">The hwnd.</param>
    /// <returns>The remove clipboard format listener result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

    /// <summary>
    /// The WM CLIPBOARDUPDATE constant.
    /// </summary>
    public const int WM_CLIPBOARDUPDATE = 0x031D;

    /// <summary>
    /// The HWND MESSAGE.
    /// </summary>
    public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

    /// <summary>
    /// Set foreground window.
    /// </summary>
    /// <param name="-3">The 3.</param>
    /// <returns>The set foreground window result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    /// <summary>
    /// Get key state.
    /// </summary>
    /// <param name="-3">The 3.</param>
    /// <returns>The get key state result.</returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
    public static extern short GetKeyState(int keyCode);

    /// <summary>
    /// Global lock.
    /// </summary>
    /// <param name="hWnd">The h wnd.</param>
    /// <returns>The global lock result.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GlobalLock(IntPtr hMem);

    /// <summary>
    /// Enable wow 64 FS redirection.
    /// </summary>
    /// <param name="keyCode">The key code.</param>
    /// <returns>The enable wow 64 FS redirection result.</returns>
    [DllImport("Kernel32.Dll", EntryPoint = "Wow64EnableWow64FsRedirection")]
    public static extern bool EnableWow64FSRedirection(bool enable);

    /// <summary>
    /// Close clipboard.
    /// </summary>
    /// <param name="hMem">The h mem.</param>
    /// <returns>The close clipboard result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool CloseClipboard();

    /// <summary>
    /// Set clipboard data.
    /// </summary>
    /// <param name="enable">The enable.</param>
    /// <returns>The set clipboard data result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetClipboardData(uint uFormat, IntPtr data);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetOpenClipboardWindow();

    /// <summary>
    /// Global unlock.
    /// </summary>
    /// <param name="uFormat">The u format.</param>
    /// <param name="data">The data.</param>
    /// <returns>The global unlock result.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GlobalUnlock(IntPtr hMem);

    /// <summary>
    /// Global size.
    /// </summary>
    /// <returns>The global size result.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern UIntPtr GlobalSize(IntPtr hMem);

    /// <summary>
    /// Get clipboard data.
    /// </summary>
    /// <param name="hMem">The h mem.</param>
    /// <returns>The get clipboard data result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetClipboardData(uint uFormat);

    /// <summary>
    /// Is clipboard format available.
    /// </summary>
    /// <param name="hMem">The h mem.</param>
    /// <returns>The is clipboard format available result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool IsClipboardFormatAvailable(uint format);

    /// <summary>
    /// Open clipboard.
    /// </summary>
    /// <param name="uFormat">The u format.</param>
    /// <returns>The open clipboard result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool OpenClipboard(IntPtr hWndNewOwner);
}

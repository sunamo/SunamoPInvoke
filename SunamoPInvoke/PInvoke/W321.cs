namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Provides additional P/Invoke declarations for Windows API functions.
/// </summary>
public partial class W32 : W32Base
{
    /// <summary>
    /// Retrieves device-specific information for the specified device.
    /// </summary>
    /// <param name="hdc">A handle to the device context.</param>
    /// <param name="nIndex">The item to be returned.</param>
    /// <returns>The value of the desired item.</returns>
    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

    /// <summary>
    /// Determines the MIME type from the data provided.
    /// </summary>
    /// <param name="pBC">A pointer to the bind context. Can be set to zero.</param>
    /// <param name="pwzUrl">A string value that contains the URL of the data.</param>
    /// <param name="pBuffer">A pointer to the buffer that contains the data to be sniffed.</param>
    /// <param name="cbSize">The number of bytes in the buffer.</param>
    /// <param name="pwzMimeProposed">A string value that contains the proposed MIME type.</param>
    /// <param name="dwMimeFlags">Flags that control the operation.</param>
    /// <param name="ppwzMimeOut">The address of the determined MIME type.</param>
    /// <param name="dwReserverd">Reserved. Must be set to zero.</param>
    /// <returns>Returns S_OK if successful.</returns>
    [DllImport(@"urlmon.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern System.UInt32 FindMimeFromData(System.UInt32 pBC, [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl, [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer, System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed, System.UInt32 dwMimeFlags, out System.UInt32 ppwzMimeOut, System.UInt32 dwReserverd);

    /// <summary>
    /// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.
    /// </summary>
    /// <param name="pszPath">A pointer to a string that specifies the path of the file or folder.</param>
    /// <param name="dwFileAttributes">A combination of file attribute flags.</param>
    /// <param name="psfi">A pointer to a SHFILEINFO structure to receive the file information.</param>
    /// <param name="cbFileInfo">The size, in bytes, of the SHFILEINFO structure.</param>
    /// <param name="uFlags">The flags that specify the file information to retrieve.</param>
    /// <returns>Depends on the flags parameter.</returns>
    [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

    /// <summary>
    /// Destroys an icon and frees any memory the icon occupied.
    /// </summary>
    /// <param name="hIcon">A handle to the icon to be destroyed.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DestroyIcon(IntPtr hIcon);

    /// <summary>
    /// Retrieves a pseudo handle for the current process.
    /// </summary>
    /// <returns>A pseudo handle to the current process.</returns>
    [DllImport("kernel32.dll", ExactSpelling = true)]
    public static extern IntPtr GetCurrentProcess();

    /// <summary>
    /// Opens the access token associated with a process.
    /// </summary>
    /// <param name="h">A handle to the process whose access token is opened.</param>
    /// <param name="acc">Specifies an access mask that specifies the requested types of access to the access token.</param>
    /// <param name="phtok">A pointer to a handle that identifies the newly opened access token when the function returns.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

    /// <summary>
    /// Retrieves the locally unique identifier (LUID) used on a specified system to locally represent the specified privilege name.
    /// </summary>
    /// <param name="host">A string that specifies the name of the system.</param>
    /// <param name="name">A string that specifies the name of the privilege.</param>
    /// <param name="pluid">A pointer to an LUID variable that receives the LUID.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool LookupPrivilegeValue(string host, string name, ref LUID pluid);

    /// <summary>
    /// Enables or disables privileges in the specified access token.
    /// </summary>
    /// <param name="htok">A handle to the access token that contains the privileges to be modified.</param>
    /// <param name="disall">Specifies whether the function disables all privileges.</param>
    /// <param name="newst">A pointer to a TOKEN_PRIVILEGES structure.</param>
    /// <param name="len">Specifies the size, in bytes, of the buffer pointed to by the previous state parameter.</param>
    /// <param name="prev">A pointer to a buffer for the previous state.</param>
    /// <param name="relen">A pointer to a variable that receives the required size.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TOKEN_PRIVILEGES newst, int len, IntPtr prev, IntPtr relen);

    /// <summary>
    /// Retrieves a handle to the Shell's desktop window.
    /// </summary>
    /// <returns>A handle to the Shell's desktop window.</returns>
    [DllImport("user32.dll")]
    public static extern IntPtr GetShellWindow();

    /// <summary>
    /// Opens an existing local process object with specified access flags.
    /// </summary>
    /// <param name="processAccess">The access rights for the process object.</param>
    /// <param name="bInheritHandle">If true, processes created by this process will inherit the handle.</param>
    /// <param name="processId">The identifier of the local process to be opened.</param>
    /// <returns>An open handle to the specified process.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, uint processId);

    /// <summary>
    /// Creates a new access token that duplicates an existing token.
    /// </summary>
    /// <param name="hExistingToken">A handle to an access token.</param>
    /// <param name="dwDesiredAccess">Specifies the requested access rights for the new token.</param>
    /// <param name="lpTokenAttributes">A pointer to a SECURITY_ATTRIBUTES structure.</param>
    /// <param name="impersonationLevel">Specifies the impersonation level of the new token.</param>
    /// <param name="tokenType">Specifies the type of the new token.</param>
    /// <param name="phNewToken">A pointer to a variable that receives the handle to the new token.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool DuplicateTokenEx(IntPtr hExistingToken, uint dwDesiredAccess, IntPtr lpTokenAttributes, SECURITY_IMPERSONATION_LEVEL impersonationLevel, TOKEN_TYPE tokenType, out IntPtr phNewToken);

    /// <summary>
    /// Creates a new process and its primary thread. The new process runs in the security context of the specified token.
    /// </summary>
    /// <param name="hToken">A handle to the primary token that represents a user.</param>
    /// <param name="dwLogonFlags">The logon option.</param>
    /// <param name="lpApplicationName">The name of the module to be executed.</param>
    /// <param name="lpCommandLine">The command line to be executed.</param>
    /// <param name="dwCreationFlags">The flags that control the priority class and the creation of the process.</param>
    /// <param name="lpEnvironment">A pointer to the environment block for the new process.</param>
    /// <param name="lpCurrentDirectory">The full path to the current directory for the process.</param>
    /// <param name="lpStartupInfo">A pointer to a STARTUPINFO structure.</param>
    /// <param name="lpProcessInformation">A pointer to a PROCESS_INFORMATION structure that receives identification information about the new process.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("advapi32", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool CreateProcessWithTokenW(IntPtr hToken, int dwLogonFlags, string lpApplicationName, string lpCommandLine, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, [In] ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

    /// <summary>
    /// Places the given window in the system-maintained clipboard format listener list.
    /// </summary>
    /// <param name="hwnd">A handle to the window to be placed in the clipboard format listener list.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool AddClipboardFormatListener(IntPtr hwnd);

    /// <summary>
    /// Removes the given window from the system-maintained clipboard format listener list.
    /// </summary>
    /// <param name="hwnd">A handle to the window to remove from the clipboard format listener list.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

    /// <summary>
    /// Message sent when the contents of the clipboard have changed.
    /// </summary>
    public const int WM_CLIPBOARDUPDATE = 0x031D;

    /// <summary>
    /// Handle value used to find message-only windows via FindWindowEx.
    /// </summary>
    public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

    /// <summary>
    /// Brings the thread that created the specified window into the foreground and activates the window.
    /// </summary>
    /// <param name="hWnd">A handle to the window that should be activated.</param>
    /// <returns>True if the window was brought to the foreground.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    /// <summary>
    /// Retrieves the status of the specified virtual key.
    /// </summary>
    /// <param name="keyCode">A virtual key code.</param>
    /// <returns>The status of the specified virtual key.</returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
    public static extern short GetKeyState(int keyCode);

    /// <summary>
    /// Locks a global memory object and returns a pointer to the first byte of the object's memory block.
    /// </summary>
    /// <param name="hMem">A handle to the global memory object.</param>
    /// <returns>A pointer to the first byte of the memory block.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GlobalLock(IntPtr hMem);

    /// <summary>
    /// Enables or disables file system redirection for the calling thread.
    /// </summary>
    /// <param name="enable">True to enable redirection, false to disable it.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("Kernel32.Dll", EntryPoint = "Wow64EnableWow64FsRedirection")]
    public static extern bool EnableWow64FSRedirection(bool enable);

    /// <summary>
    /// Closes the clipboard.
    /// </summary>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool CloseClipboard();

    /// <summary>
    /// Places data on the clipboard in a specified clipboard format.
    /// </summary>
    /// <param name="uFormat">The clipboard format.</param>
    /// <param name="data">A handle to the data in the specified format.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetClipboardData(uint uFormat, IntPtr data);

    /// <summary>
    /// Retrieves the handle to the window that currently has the clipboard open.
    /// </summary>
    /// <returns>A handle to the window that has the clipboard open, or IntPtr.Zero if no window has the clipboard open.</returns>
    [DllImport("user32.dll")]
    internal static extern IntPtr GetOpenClipboardWindow();

    /// <summary>
    /// Decrements the lock count associated with a memory object.
    /// </summary>
    /// <param name="hMem">A handle to the global memory object.</param>
    /// <returns>True if the memory object is still locked after decrementing the lock count.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GlobalUnlock(IntPtr hMem);

    /// <summary>
    /// Retrieves the current size of the specified global memory object, in bytes.
    /// </summary>
    /// <param name="hMem">A handle to the global memory object.</param>
    /// <returns>The size of the specified global memory object, in bytes.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern UIntPtr GlobalSize(IntPtr hMem);

    /// <summary>
    /// Retrieves data from the clipboard in a specified format.
    /// </summary>
    /// <param name="uFormat">The clipboard format.</param>
    /// <returns>A handle to the clipboard data in the specified format.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetClipboardData(uint uFormat);

    /// <summary>
    /// Determines whether the clipboard contains data in the specified format.
    /// </summary>
    /// <param name="format">The clipboard format to check.</param>
    /// <returns>True if the clipboard format is available.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool IsClipboardFormatAvailable(uint format);

    /// <summary>
    /// Opens the clipboard for examination and prevents other applications from modifying the clipboard content.
    /// </summary>
    /// <param name="hWndNewOwner">A handle to the window to be associated with the open clipboard.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool OpenClipboard(IntPtr hWndNewOwner);
}

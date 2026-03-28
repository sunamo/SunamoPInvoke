namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Provides P/Invoke declarations for Windows API functions from kernel32, user32, shell32, psapi, gdi32 and advapi32.
/// </summary>
public partial class W32 : W32Base
{
    /// <summary>
    /// Loads the specified module into the address space of the calling process.
    /// </summary>
    /// <param name="lpFileName">The name of the module to load.</param>
    /// <returns>A handle to the loaded module, or IntPtr.Zero on failure.</returns>
    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string lpFileName);

    /// <summary>
    /// Frees the loaded dynamic-link library module.
    /// </summary>
    /// <param name="hModule">A handle to the loaded library module.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern bool FreeLibrary(IntPtr hModule);

    /// <summary>
    /// Installs an application-defined hook procedure into a hook chain.
    /// You would install a hook procedure to monitor the system for certain types of events.
    /// </summary>
    /// <param name="idHook">The type of hook procedure to be installed.</param>
    /// <param name="lpfn">A pointer to the hook procedure.</param>
    /// <param name="hMod">A handle to the DLL containing the hook procedure.</param>
    /// <param name="dwThreadId">The identifier of the thread with which the hook procedure is to be associated.</param>
    /// <returns>If the function succeeds, the return value is the handle to the hook procedure.</returns>
    [DllImport("USER32", SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

    /// <summary>
    /// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
    /// </summary>
    /// <param name="hHook">A handle to the hook to be removed.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("USER32", SetLastError = true)]
    public static extern bool UnhookWindowsHookEx(IntPtr hHook);

    /// <summary>
    /// Passes the hook information to the next hook procedure in the current hook chain.
    /// </summary>
    /// <param name="hHook">This parameter is ignored.</param>
    /// <param name="code">The hook code passed to the current hook procedure.</param>
    /// <param name="wParam">The wParam value passed to the current hook procedure.</param>
    /// <param name="lParam">The lParam value passed to the current hook procedure.</param>
    /// <returns>The value returned by the next hook procedure in the chain.</returns>
    [DllImport("USER32", SetLastError = true)]
    public static extern IntPtr CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Opens an existing local process object.
    /// </summary>
    /// <param name="processAccess">The access to the process object.</param>
    /// <param name="bInheritHandle">If true, processes created by this process will inherit the handle.</param>
    /// <param name="processId">The identifier of the local process to be opened.</param>
    /// <returns>An open handle to the specified process, or IntPtr.Zero on failure.</returns>
    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

    /// <summary>
    /// Retrieves the fully qualified path for the file containing the specified module.
    /// </summary>
    /// <param name="hProcess">A handle to the process.</param>
    /// <param name="hModule">A handle to the module. If NULL, returns the path of the executable.</param>
    /// <param name="lpBaseName">A buffer that receives the fully qualified path to the module.</param>
    /// <param name="nSize">The size of the buffer, in characters.</param>
    /// <returns>The length of the string copied to the buffer.</returns>
    [DllImport("psapi.dll")]
    public static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In][MarshalAs(UnmanagedType.U4)] int nSize);

    /// <summary>
    /// Closes an open object handle.
    /// </summary>
    /// <param name="hObject">A valid handle to an open object.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(IntPtr hObject);

    /// <summary>
    /// Installs an application-defined hook procedure into a hook chain (low-level keyboard version).
    /// </summary>
    /// <param name="idHook">The type of hook procedure to be installed.</param>
    /// <param name="lpfn">A pointer to the hook procedure.</param>
    /// <param name="hMod">A handle to the DLL containing the hook procedure.</param>
    /// <param name="dwThreadId">The identifier of the thread with which the hook procedure is to be associated.</param>
    /// <returns>If the function succeeds, the return value is the handle to the hook procedure.</returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    /// <summary>
    /// Retrieves the handle to the specified module.
    /// </summary>
    /// <param name="lpModuleName">The name of the loaded module. If NULL, returns a handle to the calling process.</param>
    /// <returns>A handle to the specified module, or IntPtr.Zero on failure.</returns>
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    /// <summary>
    /// Retrieves the identifier of the thread that created the specified window and the identifier of the process.
    /// </summary>
    /// <param name="hWnd">A handle to the window.</param>
    /// <param name="lpdwProcessId">A pointer that receives the process identifier.</param>
    /// <returns>The identifier of the thread that created the window.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    /// <summary>
    /// Flag to retrieve the icon handle.
    /// </summary>
    public const uint SHGFI_ICON = 0x000000100;

    /// <summary>
    /// Flag to retrieve the display name.
    /// </summary>
    public const uint SHGFI_DISPLAYNAME = 0x000000200;

    /// <summary>
    /// Flag to retrieve the type name.
    /// </summary>
    public const uint SHGFI_TYPENAME = 0x000000400;

    /// <summary>
    /// Flag to retrieve the attributes.
    /// </summary>
    public const uint SHGFI_ATTRIBUTES = 0x000000800;

    /// <summary>
    /// Flag to retrieve the icon location.
    /// </summary>
    public const uint SHGFI_ICONLOCATION = 0x000001000;

    /// <summary>
    /// Flag to return the exe type.
    /// </summary>
    public const uint SHGFI_EXETYPE = 0x000002000;

    /// <summary>
    /// Flag to get the system icon index.
    /// </summary>
    public const uint SHGFI_SYSICONINDEX = 0x000004000;

    /// <summary>
    /// Flag to put a link overlay on the icon.
    /// </summary>
    public const uint SHGFI_LINKOVERLAY = 0x000008000;

    /// <summary>
    /// Flag to show icon in selected state.
    /// </summary>
    public const uint SHGFI_SELECTED = 0x000010000;

    /// <summary>
    /// Flag to get only specified attributes.
    /// </summary>
    public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;

    /// <summary>
    /// Flag to retrieve the large icon.
    /// </summary>
    public const uint SHGFI_LARGEICON = 0x000000000;

    /// <summary>
    /// Flag to retrieve the small icon.
    /// </summary>
    public const uint SHGFI_SMALLICON = 0x000000001;

    /// <summary>
    /// Flag to retrieve the open icon.
    /// </summary>
    public const uint SHGFI_OPENICON = 0x000000002;

    /// <summary>
    /// Flag to retrieve the shell size icon.
    /// </summary>
    public const uint SHGFI_SHELLICONSIZE = 0x000000004;

    /// <summary>
    /// Indicates that pszPath is a PIDL.
    /// </summary>
    public const uint SHGFI_PIDL = 0x000000008;

    /// <summary>
    /// Flag to use the passed dwFileAttribute.
    /// </summary>
    public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;

    /// <summary>
    /// Flag to apply the appropriate overlays.
    /// </summary>
    public const uint SHGFI_ADDOVERLAYS = 0x000000020;

    /// <summary>
    /// Flag to get the index of the overlay.
    /// </summary>
    public const uint SHGFI_OVERLAYINDEX = 0x000000040;

    /// <summary>
    /// File attribute flag indicating a directory.
    /// </summary>
    public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;

    /// <summary>
    /// File attribute flag indicating a normal file.
    /// </summary>
    public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

    /// <summary>
    /// Creates or opens a file or I/O device.
    /// </summary>
    /// <param name="lpFileName">The name of the file or device to be created or opened.</param>
    /// <param name="dwDesiredAccess">The requested access to the file or device.</param>
    /// <param name="dwShareMode">The requested sharing mode of the file or device.</param>
    /// <param name="lpSECURITY_ATTRIBUTES">A pointer to a SECURITY_ATTRIBUTES structure.</param>
    /// <param name="dwCreationDisposition">An action to take on a file or device that exists or does not exist.</param>
    /// <param name="dwFlagsAndAttributes">The file or device attributes and flags.</param>
    /// <param name="hTemplateFile">A valid handle to a template file with GENERIC_READ access right.</param>
    /// <returns>An open handle to the specified file or device.</returns>
    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, IntPtr lpSECURITY_ATTRIBUTES, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);

    /// <summary>
    /// Retrieves the number of hard links for a file by its path.
    /// </summary>
    /// <param name="filePath">The full path to the file.</param>
    /// <param name="lastError">When this method returns, contains the last Win32 error code if the operation failed.</param>
    /// <returns>The number of hard links, or uint.MaxValue if the operation failed.</returns>
    public static uint GetFileInformationByHandleWorker(string filePath, out int lastError)
    {
        uint numberOfLinks = uint.MaxValue;
        lastError = 0;
        BY_HANDLE_FILE_INFORMATION fileInformation = new BY_HANDLE_FILE_INFORMATION
        {
        };
        IntPtr fileHandle = CreateFile(filePath, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
        if (fileHandle.ToInt32() != INVALID_HANDLE_VALUE)
        {
            if (GetFileInformationByHandle(fileHandle, ref fileInformation))
                numberOfLinks = fileInformation.nNumberOfLinks;
            else
                lastError = Marshal.GetLastWin32Error();
            CloseHandle(fileHandle);
        }
        else
            lastError = Marshal.GetLastWin32Error();
        return numberOfLinks;
    }

    /// <summary>
    /// Retrieves file information for the specified file.
    /// </summary>
    /// <param name="handle">A handle to the file.</param>
    /// <param name="hfi">A pointer to a BY_HANDLE_FILE_INFORMATION structure that receives the file information.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool GetFileInformationByHandle(IntPtr handle, ref BY_HANDLE_FILE_INFORMATION hfi);

    /// <summary>
    /// Constant representing an invalid handle value.
    /// </summary>
    public const int INVALID_HANDLE_VALUE = -1;

    /// <summary>
    /// Generic read access flag.
    /// </summary>
    public const uint GENERIC_READ = 0x80000000;

    /// <summary>
    /// Error code indicating the buffer is too small.
    /// </summary>
    public const int ERROR_INSUFFICIENT_BUFFER = 122;

    /// <summary>
    /// Enables subsequent read operations on a file.
    /// </summary>
    public const int FILE_SHARE_READ = 1;

    /// <summary>
    /// Enables subsequent write operations on a file.
    /// </summary>
    public const int FILE_SHARE_WRITE = 2;

    /// <summary>
    /// Enables subsequent delete operations on a file.
    /// </summary>
    public const int FILE_SHARE_DELETE = 4;

    /// <summary>
    /// Creates a new file only if it does not already exist.
    /// </summary>
    public const int CREATE_NEW = 1;

    /// <summary>
    /// Creates a new file, always. Overwrites if the file exists.
    /// </summary>
    public const int CREATE_ALWAYS = 2;

    /// <summary>
    /// Opens a file only if it exists.
    /// </summary>
    public const int OPEN_EXISTING = 3;

    /// <summary>
    /// Opens a file, always. Creates the file if it does not exist.
    /// </summary>
    public const int OPEN_ALWAYS = 4;

    /// <summary>
    /// Opens a file and truncates it so that its size is zero bytes.
    /// </summary>
    public const int TRUNCATE_EXISTING = 5;

    /// <summary>
    /// Contains information about a file retrieved by handle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BY_HANDLE_FILE_INFORMATION
    {
        /// <summary>
        /// The file attributes.
        /// </summary>
        public uint dwFileAttributes;
        /// <summary>
        /// The time the file was created.
        /// </summary>
        public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
        /// <summary>
        /// The time the file was last accessed.
        /// </summary>
        public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
        /// <summary>
        /// The time the file was last written to.
        /// </summary>
        public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
        /// <summary>
        /// The serial number of the volume that contains the file.
        /// </summary>
        public uint dwVolumeSerialNumber;
        /// <summary>
        /// The high-order part of the file size.
        /// </summary>
        public uint nFileSizeHigh;
        /// <summary>
        /// The low-order part of the file size.
        /// </summary>
        public uint nFileSizeLow;
        /// <summary>
        /// The number of links to this file.
        /// </summary>
        public uint nNumberOfLinks;
        /// <summary>
        /// The high-order part of a unique identifier associated with the file.
        /// </summary>
        public uint nFileIndexHigh;
        /// <summary>
        /// The low-order part of a unique identifier associated with the file.
        /// </summary>
        public uint nFileIndexLow;
    }

    /// <summary>
    /// Frees the specified global memory object and invalidates its handle.
    /// </summary>
    /// <param name="hMem">A handle to the global memory object.</param>
    /// <returns>If the function succeeds, the return value is NULL.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GlobalFree(IntPtr hMem);

    /// <summary>
    /// Enumerates the data formats currently available on the clipboard.
    /// </summary>
    /// <param name="format">A clipboard format. Set to zero to begin enumeration.</param>
    /// <returns>The next available clipboard format, or zero if there are no more formats.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint EnumClipboardFormats(uint format);

    /// <summary>
    /// Retrieves the calling thread's last-error code value. Use Marshal.GetLastWin32Error instead.
    /// </summary>
    /// <returns>The calling thread's last-error code.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern uint GetLastError();

    /// <summary>
    /// Adds the specified window to the chain of clipboard viewers.
    /// </summary>
    /// <param name="hWndNewViewer">A handle to the window to be added to the clipboard chain.</param>
    /// <returns>A handle to the next window in the clipboard viewer chain.</returns>
    [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

    /// <summary>
    /// Removes a specified window from the chain of clipboard viewers.
    /// </summary>
    /// <param name="hWndRemove">A handle to the window to be removed from the chain.</param>
    /// <param name="hWndNewNext">A handle to the window that follows the window being removed.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

    /// <summary>
    /// Sends the specified message to a window or windows.
    /// </summary>
    /// <param name="hwnd">A handle to the window whose window procedure will receive the message.</param>
    /// <param name="wMsg">The message to be sent.</param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns>The result of the message processing.</returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Retrieves the full path of a known folder identified by the folder's KNOWNFOLDERID.
    /// </summary>
    /// <param name="rfid">A reference to the KNOWNFOLDERID that identifies the folder.</param>
    /// <param name="dwFlags">Flags that specify special retrieval options.</param>
    /// <param name="hToken">An access token that represents a particular user.</param>
    /// <param name="pszPath">When this method returns, contains the address of a string that specifies the path of the known folder.</param>
    /// <returns>Returns S_OK if successful, or an error value otherwise.</returns>
    [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);

    /// <summary>
    /// Sets the icon for the console window.
    /// </summary>
    /// <param name="hIcon">A handle to the icon to be displayed.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleIcon(IntPtr hIcon);

    /// <summary>
    /// Deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object.
    /// </summary>
    /// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
    /// <returns>True if the function succeeds.</returns>
    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern bool DeleteObject(IntPtr hObject);
}

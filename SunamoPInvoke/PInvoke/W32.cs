namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Represents the w 32 type.
/// </summary>
public partial class W32 : W32Base
{
    /// <summary>
    /// Load library.
    /// </summary>
    /// <param name="lpFileName">The lp file name.</param>
    /// <returns>The load library result.</returns>
    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string lpFileName);

    /// <summary>
    /// Free library.
    /// </summary>
    /// <param name="hModule">The h module.</param>
    /// <returns>The free library result.</returns>
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern bool FreeLibrary(IntPtr hModule);

    /// <summary>
    /// Set windows hook ex.
    /// </summary>
    /// <param name="idHook">The id hook.</param>
    /// <param name="lpfn">The lpfn.</param>
    /// <param name="hMod">The h mod.</param>
    /// <param name="dwThreadId">The dw thread id.</param>
    /// <returns>The set windows hook ex result.</returns>
    [DllImport("USER32", SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

    /// <summary>
    /// Unhook windows hook ex.
    /// </summary>
    /// <param name="hHook">The h hook.</param>
    /// <returns>The unhook windows hook ex result.</returns>
    [DllImport("USER32", SetLastError = true)]
    public static extern bool UnhookWindowsHookEx(IntPtr hHook);

    /// <summary>
    /// Call next hook ex.
    /// </summary>
    /// <param name="hHook">The h hook.</param>
    /// <param name="code">The code.</param>
    /// <param name="wParam">The w param.</param>
    /// <param name="lParam">The l param.</param>
    /// <returns>The call next hook ex result.</returns>
    [DllImport("USER32", SetLastError = true)]
    public static extern IntPtr CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Open process.
    /// </summary>
    /// <param name="processAccess">The process access.</param>
    /// <param name="bInheritHandle">The b inherit handle.</param>
    /// <param name="processId">The process id.</param>
    /// <returns>The open process result.</returns>
    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

    /// <summary>
    /// Get module file name ex.
    /// </summary>
    /// <param name="hProcess">The h process.</param>
    /// <param name="hModule">The h module.</param>
    /// <param name="lpBaseName">The lp base name.</param>
    /// <param name="nSize">The n size.</param>
    /// <returns>The get module file name ex result.</returns>
    [DllImport("psapi.dll")]
    public static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In][MarshalAs(UnmanagedType.U4)] int nSize);

    /// <summary>
    /// Close handle.
    /// </summary>
    /// <param name="hObject">The h object.</param>
    /// <returns>The close handle result.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(IntPtr hObject);

    /// <summary>
    /// Set windows hook ex.
    /// </summary>
    /// <param name="idHook">The id hook.</param>
    /// <param name="lpfn">The lpfn.</param>
    /// <param name="hMod">The h mod.</param>
    /// <param name="dwThreadId">The dw thread id.</param>
    /// <returns>The set windows hook ex result.</returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    /// <summary>
    /// Get module handle.
    /// </summary>
    /// <param name="lpModuleName">The lp module name.</param>
    /// <returns>The get module handle result.</returns>
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    /// <summary>
    /// Get window thread process id.
    /// </summary>
    /// <param name="hWnd">The h wnd.</param>
    /// <param name="lpdwProcessId">The lpdw process id.</param>
    /// <returns>The get window thread process id result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    /// <summary>
    /// The SHGFI ICON constant.
    /// </summary>
    public const uint SHGFI_ICON = 0x000000100;
    /// <summary>
    /// The SHGFI DISPLAYNAME constant.
    /// </summary>
    public const uint SHGFI_DISPLAYNAME = 0x000000200;
    /// <summary>
    /// The SHGFI TYPENAME constant.
    /// </summary>
    public const uint SHGFI_TYPENAME = 0x000000400;
    /// <summary>
    /// The SHGFI ATTRIBUTES constant.
    /// </summary>
    public const uint SHGFI_ATTRIBUTES = 0x000000800;
    /// <summary>
    /// The SHGFI ICONLOCATION constant.
    /// </summary>
    public const uint SHGFI_ICONLOCATION = 0x000001000;
    /// <summary>
    /// The SHGFI EXETYPE constant.
    /// </summary>
    public const uint SHGFI_EXETYPE = 0x000002000;
    /// <summary>
    /// The SHGFI SYSICONINDEX constant.
    /// </summary>
    public const uint SHGFI_SYSICONINDEX = 0x000004000;
    /// <summary>
    /// The SHGFI LINKOVERLAY constant.
    /// </summary>
    public const uint SHGFI_LINKOVERLAY = 0x000008000;
    /// <summary>
    /// The SHGFI SELECTED constant.
    /// </summary>
    public const uint SHGFI_SELECTED = 0x000010000;
    /// <summary>
    /// The SHGFI ATTR SPECIFIED constant.
    /// </summary>
    public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;
    /// <summary>
    /// The SHGFI LARGEICON constant.
    /// </summary>
    public const uint SHGFI_LARGEICON = 0x000000000;
    /// <summary>
    /// The SHGFI SMALLICON constant.
    /// </summary>
    public const uint SHGFI_SMALLICON = 0x000000001;
    /// <summary>
    /// The SHGFI OPENICON constant.
    /// </summary>
    public const uint SHGFI_OPENICON = 0x000000002;
    /// <summary>
    /// The SHGFI SHELLICONSIZE constant.
    /// </summary>
    public const uint SHGFI_SHELLICONSIZE = 0x000000004;
    /// <summary>
    /// The SHGFI PIDL constant.
    /// </summary>
    public const uint SHGFI_PIDL = 0x000000008;
    /// <summary>
    /// The SHGFI USEFILEATTRIBUTES constant.
    /// </summary>
    public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
    /// <summary>
    /// The SHGFI ADDOVERLAYS constant.
    /// </summary>
    public const uint SHGFI_ADDOVERLAYS = 0x000000020;
    /// <summary>
    /// The SHGFI OVERLAYINDEX constant.
    /// </summary>
    public const uint SHGFI_OVERLAYINDEX = 0x000000040;
    /// <summary>
    /// The FILE ATTRIBUTE DIRECTORY constant.
    /// </summary>
    public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
    /// <summary>
    /// The FILE ATTRIBUTE NORMAL constant.
    /// </summary>
    public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

    /// <summary>
    /// Create file.
    /// </summary>
    /// <param name="lpFileName">The lp file name.</param>
    /// <param name="dwDesiredAccess">The dw desired access.</param>
    /// <param name="dwShareMode">The dw share mode.</param>
    /// <param name="lpSECURITY_ATTRIBUTES">The lp SECURITY ATTRIBUTES.</param>
    /// <param name="dwCreationDisposition">The dw creation disposition.</param>
    /// <param name="dwFlagsAndAttributes">The dw flags and attributes.</param>
    /// <param name="hTemplateFile">The h template file.</param>
    /// <returns>The create file result.</returns>
    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, IntPtr lpSECURITY_ATTRIBUTES, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);

    /// <summary>
    /// Get file information by handle worker.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="lastError">The last error.</param>
    /// <returns>The get file information by handle worker result.</returns>
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
    /// Get file information by handle.
    /// </summary>
    /// <param name="handle">The handle.</param>
    /// <param name="hfi">The hfi.</param>
    /// <returns>The get file information by handle result.</returns>
    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool GetFileInformationByHandle(IntPtr handle, ref BY_HANDLE_FILE_INFORMATION hfi);

    /// <summary>
    /// The INVALID HANDLE VALUE constant.
    /// </summary>
    public const int INVALID_HANDLE_VALUE = -1;
    /// <summary>
    /// The GENERIC READ constant.
    /// </summary>
    public const uint GENERIC_READ = 0x80000000;
    /// <summary>
    /// The ERROR INSUFFICIENT BUFFER constant.
    /// </summary>
    public const int ERROR_INSUFFICIENT_BUFFER = 122;
    /// <summary>
    /// The FILE SHARE READ constant.
    /// </summary>
    public const int FILE_SHARE_READ = 1;
    /// <summary>
    /// The FILE SHARE WRITE constant.
    /// </summary>
    public const int FILE_SHARE_WRITE = 2;
    /// <summary>
    /// The FILE SHARE DELETE constant.
    /// </summary>
    public const int FILE_SHARE_DELETE = 4;
    /// <summary>
    /// The CREATE NEW constant.
    /// </summary>
    public const int CREATE_NEW = 1;
    /// <summary>
    /// The CREATE ALWAYS constant.
    /// </summary>
    public const int CREATE_ALWAYS = 2;
    /// <summary>
    /// The OPEN EXISTING constant.
    /// </summary>
    public const int OPEN_EXISTING = 3;
    /// <summary>
    /// The OPEN ALWAYS constant.
    /// </summary>
    public const int OPEN_ALWAYS = 4;
    /// <summary>
    /// The TRUNCATE EXISTING constant.
    /// </summary>
    public const int TRUNCATE_EXISTING = 5;

    /// <summary>
    /// Represents the BY HANDLE FILE INFORMATION type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BY_HANDLE_FILE_INFORMATION
    {
        /// <summary>
        /// The dw file attributes.
        /// </summary>
        public uint dwFileAttributes;
        /// <summary>
        /// The ft creation time.
        /// </summary>
        public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
        /// <summary>
        /// The ft last access time.
        /// </summary>
        public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
        /// <summary>
        /// The ft last write time.
        /// </summary>
        public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
        /// <summary>
        /// The dw volume serial number.
        /// </summary>
        public uint dwVolumeSerialNumber;
        /// <summary>
        /// The n file size high.
        /// </summary>
        public uint nFileSizeHigh;
        /// <summary>
        /// The n file size low.
        /// </summary>
        public uint nFileSizeLow;
        /// <summary>
        /// The n number of links.
        /// </summary>
        public uint nNumberOfLinks;
        /// <summary>
        /// The n file index high.
        /// </summary>
        public uint nFileIndexHigh;
        /// <summary>
        /// The n file index low.
        /// </summary>
        public uint nFileIndexLow;
    }

    /// <summary>
    /// Global free.
    /// </summary>
    /// <param name=""Kernel32.dll"">The kernel 32 dll.</param>
    /// <param name="SetLastError">The set last error.</param>
    /// <param name="CharSet">The char set.</param>
    /// <returns>The global free result.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GlobalFree(IntPtr hMem);

    /// <summary>
    /// Enum clipboard formats.
    /// </summary>
    /// <param name=""Kernel32.dll"">The kernel 32 dll.</param>
    /// <param name="SetLastError">The set last error.</param>
    /// <param name="CharSet">The char set.</param>
    /// <returns>The enum clipboard formats result.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint EnumClipboardFormats(uint format);

    /// <summary>
    /// Get last error.
    /// </summary>
    /// <param name="lpFileName">The lp file name.</param>
    /// <param name="dwDesiredAccess">The dw desired access.</param>
    /// <param name="dwShareMode">The dw share mode.</param>
    /// <param name="lpSECURITY_ATTRIBUTES">The lp SECURITY ATTRIBUTES.</param>
    /// <param name="dwCreationDisposition">The dw creation disposition.</param>
    /// <param name="dwFlagsAndAttributes">The dw flags and attributes.</param>
    /// <param name="hTemplateFile">The h template file.</param>
    /// <returns>The get last error result.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern uint GetLastError();

    /// <summary>
    /// Set clipboard viewer.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="GENERIC_READ">The GENERIC READ.</param>
    /// <param name="FILE_SHARE_WRITE">The FILE SHARE WRITE.</param>
    /// <param name="IntPtr.Zero">The int ptr zero.</param>
    /// <param name="OPEN_EXISTING">The OPEN EXISTING.</param>
    /// <param name="0">The 0.</param>
    /// <returns>The set clipboard viewer result.</returns>
    [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

    /// <summary>
    /// Change clipboard chain.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="GENERIC_READ">The GENERIC READ.</param>
    /// <param name="FILE_SHARE_WRITE">The FILE SHARE WRITE.</param>
    /// <param name="IntPtr.Zero">The int ptr zero.</param>
    /// <param name="OPEN_EXISTING">The OPEN EXISTING.</param>
    /// <param name="0">The 0.</param>
    /// <returns>The change clipboard chain result.</returns>
    [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

    /// <summary>
    /// Send message.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="GENERIC_READ">The GENERIC READ.</param>
    /// <param name="FILE_SHARE_WRITE">The FILE SHARE WRITE.</param>
    /// <param name="IntPtr.Zero">The int ptr zero.</param>
    /// <param name="OPEN_EXISTING">The OPEN EXISTING.</param>
    /// <param name="0">The 0.</param>
    /// <returns>The send message result.</returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Initializes a new instance of the SH get known folder path class.
    /// </summary>
    /// <param name="fileInformation)">The file information.</param>
    [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);

    /// <summary>
    /// Set console icon.
    /// </summary>
    /// <returns>The set console icon result.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleIcon(IntPtr hIcon);

    /// <summary>
    /// Delete object.
    /// </summary>
    /// <returns>The delete object result.</returns>
    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern bool DeleteObject(IntPtr hObject);
}

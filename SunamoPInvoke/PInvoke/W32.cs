namespace SunamoPInvoke.PInvoke;

public partial class W32 : W32Base
{
    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string lpFileName);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern bool FreeLibrary(IntPtr hModule);

    [DllImport("USER32", SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

    [DllImport("USER32", SetLastError = true)]
    public static extern bool UnhookWindowsHookEx(IntPtr hHook);

    [DllImport("USER32", SetLastError = true)]
    public static extern IntPtr CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

    [DllImport("psapi.dll")]
    public static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In][MarshalAs(UnmanagedType.U4)] int nSize);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(IntPtr hObject);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    public const uint SHGFI_ICON = 0x000000100;
    public const uint SHGFI_DISPLAYNAME = 0x000000200;
    public const uint SHGFI_TYPENAME = 0x000000400;
    public const uint SHGFI_ATTRIBUTES = 0x000000800;
    public const uint SHGFI_ICONLOCATION = 0x000001000;
    public const uint SHGFI_EXETYPE = 0x000002000;
    public const uint SHGFI_SYSICONINDEX = 0x000004000;
    public const uint SHGFI_LINKOVERLAY = 0x000008000;
    public const uint SHGFI_SELECTED = 0x000010000;
    public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;
    public const uint SHGFI_LARGEICON = 0x000000000;
    public const uint SHGFI_SMALLICON = 0x000000001;
    public const uint SHGFI_OPENICON = 0x000000002;
    public const uint SHGFI_SHELLICONSIZE = 0x000000004;
    public const uint SHGFI_PIDL = 0x000000008;
    public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
    public const uint SHGFI_ADDOVERLAYS = 0x000000020;
    public const uint SHGFI_OVERLAYINDEX = 0x000000040;
    public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
    public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, IntPtr lpSECURITY_ATTRIBUTES, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);

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

    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool GetFileInformationByHandle(IntPtr handle, ref BY_HANDLE_FILE_INFORMATION hfi);

    public const int INVALID_HANDLE_VALUE = -1;
    public const uint GENERIC_READ = 0x80000000;
    public const int ERROR_INSUFFICIENT_BUFFER = 122;
    public const int FILE_SHARE_READ = 1;
    public const int FILE_SHARE_WRITE = 2;
    public const int FILE_SHARE_DELETE = 4;
    public const int CREATE_NEW = 1;
    public const int CREATE_ALWAYS = 2;
    public const int OPEN_EXISTING = 3;
    public const int OPEN_ALWAYS = 4;
    public const int TRUNCATE_EXISTING = 5;

    [StructLayout(LayoutKind.Sequential)]
    public struct BY_HANDLE_FILE_INFORMATION
    {
        public uint dwFileAttributes;
        public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
        public uint dwVolumeSerialNumber;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public uint nNumberOfLinks;
        public uint nFileIndexHigh;
        public uint nFileIndexLow;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GlobalFree(IntPtr hMem);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint EnumClipboardFormats(uint format);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern uint GetLastError();

    [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

    [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

    [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleIcon(IntPtr hIcon);

    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern bool DeleteObject(IntPtr hObject);
}

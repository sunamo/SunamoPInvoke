namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Represents the file operation API wrapper type.
/// </summary>
public class FileOperationAPIWrapper
{
    /// <summary>
    /// Represents the file operation flags type.
    /// </summary>
    [Flags]
    public enum FileOperationFlags : ushort
    {
        /// <summary>
        /// The FOF SILENT value.
        /// </summary>
        FOF_SILENT = 0x0004,
        /// <summary>
        /// The FOF NOCONFIRMATION value.
        /// </summary>
        FOF_NOCONFIRMATION = 0x0010,
        /// <summary>
        /// The FOF ALLOWUNDO value.
        /// </summary>
        FOF_ALLOWUNDO = 0x0040,
        /// <summary>
        /// The FOF SIMPLEPROGRESS value.
        /// </summary>
        FOF_SIMPLEPROGRESS = 0x0100,
        /// <summary>
        /// The FOF NOERRORUI value.
        /// </summary>
        FOF_NOERRORUI = 0x0400,
        /// <summary>
        /// The FOF WANTNUKEWARNING value.
        /// </summary>
        FOF_WANTNUKEWARNING = 0x4000,
    }

    /// <summary>
    /// Represents the file operation type type.
    /// </summary>
    public enum FileOperationType : uint
    {
        /// <summary>
        /// The FO MOVE value.
        /// </summary>
        FO_MOVE = 0x0001,
        /// <summary>
        /// The FO COPY value.
        /// </summary>
        FO_COPY = 0x0002,
        /// <summary>
        /// The FO DELETE value.
        /// </summary>
        FO_DELETE = 0x0003,
        /// <summary>
        /// The FO RENAME value.
        /// </summary>
        FO_RENAME = 0x0004,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct SHFILEOPSTRUCT
    {
        public nint hwnd;
        [MarshalAs(UnmanagedType.U4)]
        public FileOperationType wFunc;
        public string pFrom;
        public string pTo;
        public FileOperationFlags fFlags;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fAnyOperationsAborted;
        public nint hNameMappings;
        public string lpszProgressTitle;
    }

    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    private static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);

    /// <summary>
    /// Send.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="flags">The flags.</param>
    /// <returns>The send result.</returns>
    public static bool Send(string path, FileOperationFlags flags)
    {
        try
        {
            var fileOperation = new SHFILEOPSTRUCT
            {
                wFunc = FileOperationType.FO_DELETE,
                pFrom = path + '\0' + '\0',
                fFlags = FileOperationFlags.FOF_ALLOWUNDO | flags
            };
            SHFileOperation(ref fileOperation);
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return false;
        }
    }

    /// <summary>
    /// Send.
    /// </summary>
    /// <param name="UnmanagedType.Bool">The unmanaged type bool.</param>
    /// <returns>The send result.</returns>
    public static bool Send(string path)
    {
        return Send(path, FileOperationFlags.FOF_NOCONFIRMATION | FileOperationFlags.FOF_WANTNUKEWARNING);
    }

    /// <summary>
    /// Move to recycle bin.
    /// </summary>
    /// <param name=""shell32.dll"">The shell 32 dll.</param>
    /// <param name="CharSet">The char set.</param>
    /// <returns>The move to recycle bin result.</returns>
    public static bool MoveToRecycleBin(string path)
    {
        return Send(path, FileOperationFlags.FOF_NOCONFIRMATION | FileOperationFlags.FOF_NOERRORUI | FileOperationFlags.FOF_SILENT);
    }

    private static bool deleteFile(string path, FileOperationFlags flags)
    {
        try
        {
            var fileOperation = new SHFILEOPSTRUCT
            {
                wFunc = FileOperationType.FO_DELETE,
                pFrom = path + '\0' + '\0',
                fFlags = flags
            };
            SHFileOperation(ref fileOperation);
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return false;
        }
    }

    /// <summary>
    /// Delete completely silent.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The delete completely silent result.</returns>
    public static bool DeleteCompletelySilent(string path)
    {
        return deleteFile(path,
                          FileOperationFlags.FOF_NOCONFIRMATION | FileOperationFlags.FOF_NOERRORUI |
                          FileOperationFlags.FOF_SILENT);
    }
}

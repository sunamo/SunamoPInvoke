namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Contains information about a file object retrieved by the SHGetFileInfo function.
/// </summary>
public struct SHFILEINFO
{
    /// <summary>
    /// A handle to the icon that represents the file.
    /// </summary>
    public nint hIcon;

    /// <summary>
    /// The index of the icon image within the system image list.
    /// </summary>
    public int iIcon;

    /// <summary>
    /// An array of values that indicates the attributes of the file object.
    /// </summary>
    public uint dwAttributes;

    /// <summary>
    /// A string that contains the name of the file as it appears in the Windows Shell.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string szDisplayName;

    /// <summary>
    /// A string that describes the type of file.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
    public string szTypeName;
}

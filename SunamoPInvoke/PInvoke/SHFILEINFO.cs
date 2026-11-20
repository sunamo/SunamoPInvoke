namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Represents the SHFILEINFO type.
/// </summary>
public struct SHFILEINFO
{
    /// <summary>
    /// The h icon.
    /// </summary>
    public nint hIcon;
    /// <summary>
    /// The i icon.
    /// </summary>
    public int iIcon;
    /// <summary>
    /// The dw attributes.
    /// </summary>
    public uint dwAttributes;

    /// <summary>
    /// The sz display name.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string szDisplayName;

    /// <summary>
    /// The sz type name.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
    public string szTypeName;
}

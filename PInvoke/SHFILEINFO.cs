namespace SunamoPInvoke.PInvoke;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public struct SHFILEINFO
{
    public nint hIcon;
    public int iIcon;
    public uint dwAttributes;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string szDisplayName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
    public string szTypeName;
};





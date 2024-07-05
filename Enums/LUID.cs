namespace SunamoPInvoke.Enums;

[StructLayout(LayoutKind.Sequential)]
public struct LUID
{
    public uint LowPart;
    public int HighPart;
}

namespace SunamoPInvoke.Enums;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct LUID_AND_ATTRIBUTES
{
    public LUID Luid;
    public uint Attributes;
}

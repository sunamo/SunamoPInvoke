// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoPInvoke.Enums;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct LUID_AND_ATTRIBUTES
{
    public LUID Luid;
    public uint Attributes;
}

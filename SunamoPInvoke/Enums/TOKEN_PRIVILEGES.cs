// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoPInvoke.Enums;

public struct TOKEN_PRIVILEGES
{
    public uint PrivilegeCount;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public LUID_AND_ATTRIBUTES[] Privileges;
}

namespace SunamoPInvoke.Enums;

/// <summary>
/// Represents the TOKEN PRIVILEGES type.
/// </summary>
public struct TOKEN_PRIVILEGES
{
    /// <summary>
    /// The privilege count.
    /// </summary>
    public uint PrivilegeCount;

    /// <summary>
    /// The privileges.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public LUID_AND_ATTRIBUTES[] Privileges;
}

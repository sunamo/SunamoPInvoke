namespace SunamoPInvoke.Enums;

/// <summary>
/// Contains information about a set of privileges for an access token.
/// </summary>
public struct TOKEN_PRIVILEGES
{
    /// <summary>
    /// The number of entries in the Privileges array.
    /// </summary>
    public uint PrivilegeCount;

    /// <summary>
    /// An array of LUID_AND_ATTRIBUTES structures, each specifying a privilege and its attributes.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public LUID_AND_ATTRIBUTES[] Privileges;
}

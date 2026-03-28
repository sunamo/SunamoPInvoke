namespace SunamoPInvoke.Enums;

/// <summary>
/// Specifies the security impersonation levels for token operations.
/// </summary>
public enum SECURITY_IMPERSONATION_LEVEL
{
    /// <summary>
    /// The server process cannot obtain identification information about the client.
    /// </summary>
    SecurityAnonymous,

    /// <summary>
    /// The server process can obtain information about the client but cannot impersonate.
    /// </summary>
    SecurityIdentification,

    /// <summary>
    /// The server process can impersonate the client's security context on its local system.
    /// </summary>
    SecurityImpersonation,

    /// <summary>
    /// The server process can impersonate the client's security context on remote systems.
    /// </summary>
    SecurityDelegation
}
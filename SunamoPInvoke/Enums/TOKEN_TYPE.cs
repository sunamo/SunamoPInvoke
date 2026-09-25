namespace SunamoPInvoke.Enums;

/// <summary>
/// Specifies the type of a security token.
/// </summary>
public enum TOKEN_TYPE
{
    /// <summary>
    /// Indicates a primary token.
    /// </summary>
    TokenPrimary = 1,

    /// <summary>
    /// Indicates an impersonation token.
    /// </summary>
    TokenImpersonation
}
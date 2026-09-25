namespace SunamoPInvoke.Enums;

/// <summary>
/// Represents a locally unique identifier (LUID) used in Windows security operations.
/// </summary>
public struct LUID
{
    /// <summary>
    /// The low-order part of the LUID.
    /// </summary>
    public uint LowPart;

    /// <summary>
    /// The high-order part of the LUID.
    /// </summary>
    public int HighPart;
}

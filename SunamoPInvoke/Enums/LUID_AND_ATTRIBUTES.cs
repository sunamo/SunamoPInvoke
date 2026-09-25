namespace SunamoPInvoke.Enums;

/// <summary>
/// Represents a locally unique identifier (LUID) and its attributes, used for privilege operations.
/// </summary>
public struct LUID_AND_ATTRIBUTES
{
    /// <summary>
    /// The locally unique identifier.
    /// </summary>
    public LUID Luid;

    /// <summary>
    /// The attributes of the LUID, specifying privilege state flags.
    /// </summary>
    public uint Attributes;
}

namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Provides constants and utilities for extracting file and folder icons via the Windows Shell API.
/// Icon extraction methods are not available in .NET Core (require System.Drawing).
/// </summary>
public class IconExtractor
{
    /// <summary>
    /// Flag to retrieve the icon handle.
    /// </summary>
    public const uint SHGFI_ICON = 0x000000100;

    /// <summary>
    /// Flag to use the passed file attributes.
    /// </summary>
    public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;

    /// <summary>
    /// Flag to retrieve the open icon.
    /// </summary>
    public const uint SHGFI_OPENICON = 0x000000002;

    /// <summary>
    /// Flag to retrieve the small icon.
    /// </summary>
    public const uint SHGFI_SMALLICON = 0x000000001;

    /// <summary>
    /// Flag to retrieve the large icon.
    /// </summary>
    public const uint SHGFI_LARGEICON = 0x000000000;

    /// <summary>
    /// File attribute flag indicating a directory.
    /// </summary>
    public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
}

namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Represents the icon extractor type.
/// </summary>
public class IconExtractor
{
    /// <summary>
    /// The SHGFI ICON constant.
    /// </summary>
    public const uint SHGFI_ICON = 0x000000100;
    /// <summary>
    /// The SHGFI USEFILEATTRIBUTES constant.
    /// </summary>
    public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
    /// <summary>
    /// The SHGFI OPENICON constant.
    /// </summary>
    public const uint SHGFI_OPENICON = 0x000000002;
    /// <summary>
    /// The SHGFI SMALLICON constant.
    /// </summary>
    public const uint SHGFI_SMALLICON = 0x000000001;
    /// <summary>
    /// The SHGFI LARGEICON constant.
    /// </summary>
    public const uint SHGFI_LARGEICON = 0x000000000;
    /// <summary>
    /// The FILE ATTRIBUTE DIRECTORY constant.
    /// </summary>
    public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
}

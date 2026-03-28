namespace SunamoPInvoke.Structs;

/// <summary>
/// Specifies the window station, desktop, standard handles, and appearance of the main window for a process at creation time.
/// </summary>
public struct STARTUPINFO
{
    /// <summary>
    /// The size of the structure, in bytes.
    /// </summary>
    public int cb;

    /// <summary>
    /// Reserved; must be NULL.
    /// </summary>
    public string lpReserved;

    /// <summary>
    /// The name of the desktop, or the name of both the desktop and window station.
    /// </summary>
    public string lpDesktop;

    /// <summary>
    /// The title displayed in the title bar if a new console window is created.
    /// </summary>
    public string lpTitle;

    /// <summary>
    /// The x offset of the upper left corner of a window, in pixels.
    /// </summary>
    public int dwX;

    /// <summary>
    /// The y offset of the upper left corner of a window, in pixels.
    /// </summary>
    public int dwY;

    /// <summary>
    /// The width of the window, in pixels.
    /// </summary>
    public int dwXSize;

    /// <summary>
    /// The height of the window, in pixels.
    /// </summary>
    public int dwYSize;

    /// <summary>
    /// The screen buffer width, in character columns, if a new console window is created.
    /// </summary>
    public int dwXCountChars;

    /// <summary>
    /// The screen buffer height, in character rows, if a new console window is created.
    /// </summary>
    public int dwYCountChars;

    /// <summary>
    /// The initial text and background colors for a console window.
    /// </summary>
    public int dwFillAttribute;

    /// <summary>
    /// A bitfield that determines whether certain STARTUPINFO members are used when the process creates a window.
    /// </summary>
    public int dwFlags;

    /// <summary>
    /// Specifies the window show state. Can be any of the values that can be specified in the nCmdShow parameter.
    /// </summary>
    public short wShowWindow;

    /// <summary>
    /// Reserved for use by the C Runtime; must be zero.
    /// </summary>
    public short cbReserved2;

    /// <summary>
    /// Reserved for use by the C Runtime; must be NULL.
    /// </summary>
    public nint lpReserved2;

    /// <summary>
    /// A handle to the standard input device for the process.
    /// </summary>
    public nint hStdInput;

    /// <summary>
    /// A handle to the standard output device for the process.
    /// </summary>
    public nint hStdOutput;

    /// <summary>
    /// A handle to the standard error device for the process.
    /// </summary>
    public nint hStdError;
}

namespace SunamoPInvoke.Structs;

/// <summary>
/// Represents the STARTUPINFO type.
/// </summary>
public struct STARTUPINFO
{
    /// <summary>
    /// The cb.
    /// </summary>
    public int cb;
    /// <summary>
    /// The lp reserved.
    /// </summary>
    public string lpReserved;
    /// <summary>
    /// The lp desktop.
    /// </summary>
    public string lpDesktop;
    /// <summary>
    /// The lp title.
    /// </summary>
    public string lpTitle;
    /// <summary>
    /// The dw x.
    /// </summary>
    public int dwX;
    /// <summary>
    /// The dw y.
    /// </summary>
    public int dwY;
    /// <summary>
    /// The dw x size.
    /// </summary>
    public int dwXSize;
    /// <summary>
    /// The dw y size.
    /// </summary>
    public int dwYSize;
    /// <summary>
    /// The dw x count chars.
    /// </summary>
    public int dwXCountChars;
    /// <summary>
    /// The dw y count chars.
    /// </summary>
    public int dwYCountChars;
    /// <summary>
    /// The dw fill attribute.
    /// </summary>
    public int dwFillAttribute;
    /// <summary>
    /// The dw flags.
    /// </summary>
    public int dwFlags;
    /// <summary>
    /// The w show window.
    /// </summary>
    public short wShowWindow;
    /// <summary>
    /// The cb reserved 2.
    /// </summary>
    public short cbReserved2;
    /// <summary>
    /// The lp reserved 2.
    /// </summary>
    public nint lpReserved2;
    /// <summary>
    /// The h std input.
    /// </summary>
    public nint hStdInput;
    /// <summary>
    /// The h std output.
    /// </summary>
    public nint hStdOutput;
    /// <summary>
    /// The h std error.
    /// </summary>
    public nint hStdError;
}

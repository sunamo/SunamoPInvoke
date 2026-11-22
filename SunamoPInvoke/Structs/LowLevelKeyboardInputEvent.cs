namespace SunamoPInvoke.Structs;

/// <summary>
/// Represents the low level keyboard input event type.
/// </summary>
public struct LowLevelKeyboardInputEvent
{
    /// <summary>
    /// The virtual code.
    /// </summary>
    public int VirtualCode;
    /// <summary>
    /// The hardware scan code.
    /// </summary>
    public int HardwareScanCode;
    /// <summary>
    /// The flags.
    /// </summary>
    public int Flags;
    /// <summary>
    /// The time stamp.
    /// </summary>
    public int TimeStamp;
    /// <summary>
    /// The additional information.
    /// </summary>
    public nint AdditionalInformation;
}

namespace SunamoPInvoke.Structs;

/// <summary>
/// Represents the PROCESS INFORMATION type.
/// </summary>
public struct PROCESS_INFORMATION
{
    /// <summary>
    /// The h process.
    /// </summary>
    public nint hProcess;
    /// <summary>
    /// The h thread.
    /// </summary>
    public nint hThread;
    /// <summary>
    /// The dw process id.
    /// </summary>
    public int dwProcessId;
    /// <summary>
    /// The dw thread id.
    /// </summary>
    public int dwThreadId;
}

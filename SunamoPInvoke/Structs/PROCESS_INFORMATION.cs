namespace SunamoPInvoke.Structs;

/// <summary>
/// Contains information about a newly created process and its primary thread.
/// </summary>
public struct PROCESS_INFORMATION
{
    /// <summary>
    /// A handle to the newly created process.
    /// </summary>
    public nint hProcess;

    /// <summary>
    /// A handle to the primary thread of the newly created process.
    /// </summary>
    public nint hThread;

    /// <summary>
    /// A value that can be used to identify the process.
    /// </summary>
    public int dwProcessId;

    /// <summary>
    /// A value that can be used to identify the primary thread.
    /// </summary>
    public int dwThreadId;
}

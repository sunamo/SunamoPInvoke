namespace SunamoPInvoke.Enums;

/// <summary>
/// Specifies the access rights for opening a process.
/// </summary>
public enum ProcessAccessFlags : uint
{
    /// <summary>
    /// All possible access rights for a process object.
    /// </summary>
    All = 0x001F0FFF,

    /// <summary>
    /// Required to terminate a process.
    /// </summary>
    Terminate = 0x00000001,

    /// <summary>
    /// Required to create a thread in the process.
    /// </summary>
    CreateThread = 0x00000002,

    /// <summary>
    /// Required to perform virtual memory operations on the process.
    /// </summary>
    VirtualMemoryOperation = 0x00000008,

    /// <summary>
    /// Required to read memory in the process.
    /// </summary>
    VirtualMemoryRead = 0x00000010,

    /// <summary>
    /// Required to write to memory in the process.
    /// </summary>
    VirtualMemoryWrite = 0x00000020,

    /// <summary>
    /// Required to duplicate a handle.
    /// </summary>
    DuplicateHandle = 0x00000040,

    /// <summary>
    /// Required to create a process.
    /// </summary>
    CreateProcess = 0x000000080,

    /// <summary>
    /// Required to set memory limits.
    /// </summary>
    SetQuota = 0x00000100,

    /// <summary>
    /// Required to set certain information about a process.
    /// </summary>
    SetInformation = 0x00000200,

    /// <summary>
    /// Required to query certain information about a process.
    /// </summary>
    QueryInformation = 0x00000400,

    /// <summary>
    /// Required to retrieve limited information about a process.
    /// </summary>
    QueryLimitedInformation = 0x00001000,

    /// <summary>
    /// Required to wait for the process to terminate using wait functions.
    /// </summary>
    Synchronize = 0x00100000
}
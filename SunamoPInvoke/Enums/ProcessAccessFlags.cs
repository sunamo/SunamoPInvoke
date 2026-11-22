namespace SunamoPInvoke.Enums;

/// <summary>
/// Represents the process access flags type.
/// </summary>
public enum ProcessAccessFlags : uint
{
    /// <summary>
    /// The all value.
    /// </summary>
    All = 0x001F0FFF,
    /// <summary>
    /// The terminate value.
    /// </summary>
    Terminate = 0x00000001,
    /// <summary>
    /// The create thread value.
    /// </summary>
    CreateThread = 0x00000002,
    /// <summary>
    /// The virtual memory operation value.
    /// </summary>
    VirtualMemoryOperation = 0x00000008,
    /// <summary>
    /// The virtual memory read value.
    /// </summary>
    VirtualMemoryRead = 0x00000010,
    /// <summary>
    /// The virtual memory write value.
    /// </summary>
    VirtualMemoryWrite = 0x00000020,
    /// <summary>
    /// The duplicate handle value.
    /// </summary>
    DuplicateHandle = 0x00000040,
    /// <summary>
    /// The create process value.
    /// </summary>
    CreateProcess = 0x000000080,
    /// <summary>
    /// The set quota value.
    /// </summary>
    SetQuota = 0x00000100,
    /// <summary>
    /// The set information value.
    /// </summary>
    SetInformation = 0x00000200,
    /// <summary>
    /// The query information value.
    /// </summary>
    QueryInformation = 0x00000400,
    /// <summary>
    /// The query limited information value.
    /// </summary>
    QueryLimitedInformation = 0x00001000,
    /// <summary>
    /// The synchronize value.
    /// </summary>
    Synchronize = 0x00100000
}

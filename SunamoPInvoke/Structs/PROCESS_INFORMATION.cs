namespace SunamoPInvoke.Structs;

public struct PROCESS_INFORMATION
{
    public nint hProcess;
    public nint hThread;
    public int dwProcessId;
    public int dwThreadId;
}
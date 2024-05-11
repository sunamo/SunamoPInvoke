namespace SunamoPInvoke;

[StructLayout(LayoutKind.Sequential)]
public struct PROCESS_INFORMATION
{
    public nint hProcess;
    public nint hThread;
    public int dwProcessId;
    public int dwThreadId;
}

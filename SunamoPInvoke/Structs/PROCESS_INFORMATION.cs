// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoPInvoke.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct PROCESS_INFORMATION
{
    public nint hProcess;
    public nint hThread;
    public int dwProcessId;
    public int dwThreadId;
}

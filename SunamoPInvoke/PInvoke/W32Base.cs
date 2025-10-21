// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoPInvoke.PInvoke;

public class W32Base
{
    public delegate nint LowLevelKeyboardProc(
        int nCode, nint wParam, nint lParam);
    public delegate nint HookProc(int nCode, nint wParam, nint lParam);
}

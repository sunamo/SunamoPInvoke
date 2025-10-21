// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoPInvoke.Args;



public class GlobalKeyboardHookEventArgs : HandledEventArgs
{
    public GlobalKeyboardHook.KeyboardState KeyboardState { get; private set; }
    public LowLevelKeyboardInputEvent KeyboardData { get; private set; }

    public GlobalKeyboardHookEventArgs(
        LowLevelKeyboardInputEvent keyboardData,
        GlobalKeyboardHook.KeyboardState keyboardState)
    {
        KeyboardData = keyboardData;
        KeyboardState = keyboardState;
    }
}

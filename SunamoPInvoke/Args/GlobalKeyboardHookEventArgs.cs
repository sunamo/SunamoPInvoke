namespace SunamoPInvoke.Args;

/// <summary>
/// Provides event data for global keyboard hook events, including the keyboard state and low-level input data.
/// </summary>
public class GlobalKeyboardHookEventArgs : HandledEventArgs
{
    /// <summary>
    /// Gets the state of the keyboard key (pressed, released, etc.).
    /// </summary>
    public GlobalKeyboardHook.KeyboardState KeyboardState { get; private set; }

    /// <summary>
    /// Gets the low-level keyboard input event data including virtual key code and scan code.
    /// </summary>
    public LowLevelKeyboardInputEvent KeyboardData { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalKeyboardHookEventArgs"/> class.
    /// </summary>
    /// <param name="keyboardData">The low-level keyboard input event data.</param>
    /// <param name="keyboardState">The state of the keyboard key.</param>
    public GlobalKeyboardHookEventArgs(
        LowLevelKeyboardInputEvent keyboardData,
        GlobalKeyboardHook.KeyboardState keyboardState)
    {
        KeyboardData = keyboardData;
        KeyboardState = keyboardState;
    }
}

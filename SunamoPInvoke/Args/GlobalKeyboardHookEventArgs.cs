namespace SunamoPInvoke.Args;

/// <summary>
/// Represents the global keyboard hook event args type.
/// </summary>
public class GlobalKeyboardHookEventArgs : HandledEventArgs
{
    /// <summary>
    /// Gets or sets the keyboard state.
    /// </summary>
    public GlobalKeyboardHook.KeyboardState KeyboardState { get; private set; }

    /// <summary>
    /// Gets or sets the keyboard data.
    /// </summary>
    public LowLevelKeyboardInputEvent KeyboardData { get; private set; }

    /// <summary>
    /// Global keyboard hook event args.
    /// </summary>
    /// <param name="keyboardData">The keyboard data.</param>
    /// <param name="keyboardState">The keyboard state.</param>
    /// <returns>The global keyboard hook event args result.</returns>
    public GlobalKeyboardHookEventArgs(
        LowLevelKeyboardInputEvent keyboardData,
        GlobalKeyboardHook.KeyboardState keyboardState)
    {
        KeyboardData = keyboardData;
        KeyboardState = keyboardState;
    }
}

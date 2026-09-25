namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Provides key state detection utilities. Key state methods require System.Windows.Forms.Keys which is not available in .NET Core.
/// </summary>
public class KeysCatcher
{
    /// <summary>
    /// Specifies the possible states of a keyboard key.
    /// </summary>
    [Flags]
    public enum KeyStates
    {
        /// <summary>
        /// The key is not pressed and not toggled.
        /// </summary>
        None = 0,
        /// <summary>
        /// The key is currently pressed down.
        /// </summary>
        Down = 1,
        /// <summary>
        /// The key is toggled (e.g. Caps Lock is on).
        /// </summary>
        Toggled = 2
    }
}

namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Represents the keys catcher type.
/// </summary>
public class KeysCatcher
{
    /// <summary>
    /// Represents the key states type.
    /// </summary>
    [Flags]
    public enum KeyStates
    {
        /// <summary>
        /// The none value.
        /// </summary>
        None = 0,
        /// <summary>
        /// The down value.
        /// </summary>
        Down = 1,
        /// <summary>
        /// The toggled value.
        /// </summary>
        Toggled = 2
    }
}

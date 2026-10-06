namespace SunamoPInvoke.PInvoke;

public class KeysCatcher
{
    [Flags]
    public enum KeyStates
    {
        None = 0,
        Down = 1,
        Toggled = 2
    }
}

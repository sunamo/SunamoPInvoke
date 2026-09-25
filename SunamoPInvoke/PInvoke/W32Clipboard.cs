namespace SunamoPInvoke.PInvoke;

/// <summary>
/// Provides clipboard-related utility methods using Windows API.
/// </summary>
public partial class W32
{
    /// <summary>
    /// Retrieves the process that currently has the clipboard open.
    /// </summary>
    /// <returns>The process holding the clipboard, or null if no process has it open.</returns>
    public static Process? ProcessHoldingClipboard()
    {
        Process? holdingProcess = null;

        IntPtr windowHandle = GetOpenClipboardWindow();

        if (windowHandle != IntPtr.Zero)
        {
            GetWindowThreadProcessId(windowHandle, out uint processId);

            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                IntPtr mainWindowHandle = process.MainWindowHandle;

                if (mainWindowHandle == windowHandle)
                {
                    holdingProcess = process;
                }
                else if (processId == process.Id)
                {
                    holdingProcess = process;
                }
            }
        }

        return holdingProcess;
    }
}

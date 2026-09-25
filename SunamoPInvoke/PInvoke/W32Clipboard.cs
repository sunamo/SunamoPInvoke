namespace SunamoPInvoke.PInvoke;

public partial class W32
{
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

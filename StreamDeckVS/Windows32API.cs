using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
#if NET5_0_OR_GREATER
using System.Runtime.Versioning;
#endif

namespace StreamDeckVS
{
#if NET5_0_OR_GREATER
    [SupportedOSPlatform("windows")]
#endif
    public static class Windows32API
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("ole32.dll")]
        public static extern int CreateBindCtx(uint reserved, out IBindCtx ppbc);

        public static (IntPtr handle, int processId) GetForeground()
        {
            var foreground = Windows32API.GetForegroundWindow();

            Windows32API.GetWindowThreadProcessId(foreground, out var pid);

            return (handle: foreground, processId: (int)pid);
        }
    }
}

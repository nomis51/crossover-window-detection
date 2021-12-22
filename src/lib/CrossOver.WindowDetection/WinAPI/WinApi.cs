using System;
using System.Diagnostics;
using System.Text;

namespace CrossOver.WindowDetection.WinAPI
{
    public static class WinApi
    {
        #region Public methods

        public static string GetForegroundWindowText(IntPtr hwnd)
        {
            try
            {
                var windowHandle = hwnd == IntPtr.Zero ? GetForegroundWindow() : hwnd;
                if (windowHandle == IntPtr.Zero) return string.Empty;

                var textLength = User32.GetWindowTextLength(windowHandle);
                if (textLength <= 0) return string.Empty;
                // The reading of GetWindowText is < textLength instead of <= textLength like usually. So to get the full string, need to add +1
                ++textLength;

                var text = new StringBuilder(textLength);
                var result = User32.GetWindowText(windowHandle, text, textLength);

                return result + 1 != textLength ? string.Empty : text.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string GetForegroundWindowModuleFileName(IntPtr hwnd)
        {
            try
            {
                var windowHandle = hwnd == IntPtr.Zero ? GetForegroundWindow() : hwnd;
                if (windowHandle == IntPtr.Zero) return string.Empty;

                var result = User32.GetWindowThreadProcessId(hwnd, out var processId);
                if (result <= 0) return string.Empty;

                var processModule = Process.GetProcessById((int) processId).MainModule;
                return processModule is null ? string.Empty : processModule.FileName;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static IntPtr GetForegroundWindow()
        {
            return User32.GetForegroundWindow();
        }

        #endregion
    }
}
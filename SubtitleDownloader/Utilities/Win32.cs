using System;
using System.Runtime.InteropServices;

namespace SubtitleDownloader
{
    class Win32
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
    }
}

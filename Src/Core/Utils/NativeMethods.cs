using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Core.Utils
{
    public static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint len, IntPtr order);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Minecraft_AFK_GUI
{
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int nMaxCount);

        private void GetWindowHandle()
        {
            Hotkey.UnRegist(SelfWindowHandle, GetWindowHandle);

            TargetWindowHandle = GetForegroundWindow();

            if (TargetWindowHandle == IntPtr.Zero)
            {
                this.set.WindowTitleName = "捕获失败！请重试！";
                return;
            }

            StringBuilder text = new StringBuilder();
            GetWindowText(TargetWindowHandle, text, 45);
            this.set.WindowTitleName = text.ToString();

            this.set.WindowHandleButtonState = "False";
        }
    }
}

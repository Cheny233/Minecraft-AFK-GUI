using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows;

namespace Minecraft_AFK_GUI
{
    static class Hotkey
    {
        const int WM_HOTKEY = 0x312;
        static int keyid = 0;
        static Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();

        public delegate void HotKeyCallBackHanlder();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, HotkeyModifiers fsModifiers, uint vk);

        [DllImport("user32.dll")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //注册快捷键
        public static void Regist(IntPtr hWnd, HotkeyModifiers fsModifiers, Key key, HotKeyCallBackHanlder callBack)
        {
            var _hwndSource = HwndSource.FromHwnd(hWnd);
            _hwndSource.AddHook(WndProc);

            var vk = (uint)KeyInterop.VirtualKeyFromKey(key);
            int id = keyid++;
            if (!RegisterHotKey(hWnd, id, fsModifiers, vk))
            {
                //报错
                Console.WriteLine("Error!");
            }
            keymap[id] = callBack;
        }

        //注销快捷键消息
        public static void UnRegist(IntPtr hWnd, HotKeyCallBackHanlder callBack)
        {
            foreach (KeyValuePair<int, HotKeyCallBackHanlder> var in keymap)
            {
                if (var.Value == callBack)
                {
                    UnregisterHotKey(hWnd, var.Key);
                    return;
                }
            }
        }

        //快捷键消息处理
        static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_HOTKEY)
            {
                int id = wParam.ToInt32();
                if (keymap.TryGetValue(id, out var callback))
                {
                    callback();
                }
            }
            return IntPtr.Zero;
        }
    }

    enum HotkeyModifiers
    {
        MOD_ALT = 0x0001,
        MOD_CONTROL = 0x0002,
        MOD_SHIFT = 0x0004,
        MOD_WIN = 0x0008,
        MOD_NOREPEAT = 0x4000
    }
}
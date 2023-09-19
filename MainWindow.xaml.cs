using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Windows.Interop;
using System.Globalization;
using System.Windows.Media.Animation;

namespace Minecraft_AFK_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings set = new Settings();

        IntPtr SelfWindowHandle, TargetWindowHandle;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = set;

            OperationPage.ItemsSource = set.Source;
        }

        //鼠标拖动窗口
        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            }
            catch { }
        }

        //最小化窗口
        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //关闭窗口
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //切换至深色模式
        private void ToDarkMode(object sender, RoutedEventArgs e)
        {
            var paletteHelper = new PaletteHelper();

            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(Theme.Dark);

            paletteHelper.SetTheme(theme);
        }

        //切换至浅色模式
        private void ToLightMode(object sender, RoutedEventArgs e)
        {
            var paletteHelper = new PaletteHelper();
            
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(Theme.Light);

            paletteHelper.SetTheme(theme);
        }

        //获取窗口句柄
        private void WindowHandleButton(object sender, RoutedEventArgs e)
        {
            this.set.WindowHandleButtonState = true;
            this.set.WindowTitleName = "";
            TargetWindowHandle = IntPtr.Zero;

            Hotkey.Regist(SelfWindowHandle, HotkeyModifiers.MOD_CONTROL | HotkeyModifiers.MOD_NOREPEAT, Key.M, GetWindowHandle);
        }

        //打开配置添加窗口
        private void OpenAddOperation(object sender, RoutedEventArgs e)
        {
            this.set.AddOperationDialogOpening = true;
        }

        //测试快捷键注册
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            WindowInteropHelper wndHelp = new WindowInteropHelper(this);
            SelfWindowHandle = wndHelp.Handle;
            //Hotkey.Regist(wndHelp.Handle, HotkeyModifiers.MOD_ALT, Key.T,GetWindowHandle);
            //Hotkey.Regist(wndHelp.Handle, HotkeyModifiers.MOD_ALT, Key.T, HotKeyRegist);
            //Hotkey.UnRegist(wndHelp.Handle,close);
        }
    }
}

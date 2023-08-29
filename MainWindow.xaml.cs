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
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace Minecraft_AFK_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
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
        private void MinClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //关闭窗口
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //切换至深色模式
        private void To_Dark_Mode(object sender, RoutedEventArgs e)
        {
            var paletteHelper = new PaletteHelper();

            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(Theme.Dark);

            paletteHelper.SetTheme(theme);
        }

        //切换至浅色模式
        private void To_Light_Mode(object sender, RoutedEventArgs e)
        {
            var paletteHelper = new PaletteHelper();
            
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(Theme.Light);

            paletteHelper.SetTheme(theme);
        }

        private void Get_Window(object sender, RoutedEventArgs e)
        {

        }

        //快捷键设置
        protected override void OnSourceInitialized(EventArgs e)
        {
            Hotkey.Regist(this, HotkeyModifiers.MOD_ALT, Key.T, () =>
            {
                this.Close();
            });
        }
    }
}

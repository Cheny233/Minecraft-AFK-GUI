using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Minecraft_AFK_GUI
{
    /// <summary>
    /// AddOperationDialog.xaml 的交互逻辑
    /// </summary>
    public partial class AddOperationDialog : UserControl
    {
        public AddOperationDialog()
        {
            InitializeComponent();
        }

        //检查字符串是否符合数字格式
        private static bool IsNumber(string value)
        {
            return Regex.IsMatch(value, @"^([0-9]{1,}[.][0-9]*)$") || Regex.IsMatch(value, @"^([0-9]{1,})$");
        }

        private void AddOperation(object sender, RoutedEventArgs e)
        {
            MainWindow mw = Application.Current.MainWindow as MainWindow;

            //检查选项是否符合要求
            if (OperationModeSelection.SelectedItem == null || KeyModeSelection.SelectedItem == null ||
                StartTimeSelection.Text == string.Empty || DurationSelection.Text == string.Empty || RestartTimeSeletion.Text == string.Empty)
            {
                mw.set.ErrorDialogOpening = true;
                return;
            }

            if ((KeyModeSelection.SelectedItem as ComboBoxItem).Content.ToString() == "键盘按键" && KeySelection.Text == string.Empty)
            {
                mw.set.ErrorDialogOpening = true;
                return;
            }

            if ((OperationModeSelection.SelectedItem as ComboBoxItem).Content.ToString() == "点击" && (!IsNumber(SpeedSelection.Text))) 
            {
                mw.set.ErrorDialogOpening = true;
                return;
            }

            if ((!IsNumber(StartTimeSelection.Text)) || (!IsNumber(DurationSelection.Text)) || (!IsNumber(RestartTimeSeletion.Text)))
            {
                mw.set.ErrorDialogOpening = true;
                return;
            }

            //存入配置
            if (!SpeedSelection.IsEnabled)
                SpeedSelection.Text = string.Empty;

            string _KeySelection = KeyModeSelection.SelectedItem == null ? string.Empty : (KeyModeSelection.SelectedItem as ComboBoxItem).Content.ToString();
            if (KeySelection.IsEnabled)
                _KeySelection = KeySelection.Text;

            string _Speed = OperationModeSelection.SelectedItem == null ? string.Empty : SpeedSelection.Text;

            mw.set.Source.Add(new OperationPageSource((OperationModeSelection.SelectedItem as ComboBoxItem).Content.ToString(), _KeySelection, _Speed, StartTimeSelection.Text, DurationSelection.Text, RestartTimeSeletion.Text));

            //string _OperationMod, string _KeySelection, string _Speed, string _StartTime, string _Duratrion, string _RestartTime
        }
    }
}

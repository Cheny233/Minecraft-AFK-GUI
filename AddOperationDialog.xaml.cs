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

        private void AddOperation(object sender, RoutedEventArgs e)
        {
            if (!SpeedSelection.IsEnabled)
                SpeedSelection.Text = string.Empty;

            string _KeySelection = KeyModeSelection.SelectedItem == null ? "" : KeyModeSelection.SelectedItem.ToString();
            if (KeySelection.IsEnabled)
                _KeySelection = KeySelection.Text;

            //string _OperationMod, string _KeySelection, string _Speed, string _StartTime, string _Duratrion, string _RestartTime
        }
    }
}

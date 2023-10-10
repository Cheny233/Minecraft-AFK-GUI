using Microsoft.Win32;
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
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;

namespace Minecraft_AFK_GUI
{
    /// <summary>
    /// ExportJsonDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ExportJsonDialog : UserControl
    {
        public ExportJsonDialog()
        {
            InitializeComponent();
        }

        private static bool IsPath(string value)
        {
            return Regex.IsMatch(value, @"^([a-zA-Z]:\\)([-\u4e00-\u9fa5\w\s.()~!@#$%^&()\[\]{}+=]+\\?)*.json$");
        }

        private void SelectFolder(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "配置文件(*.json)|*.json";

            if (saveFileDialog.ShowDialog() == true)
            {
                MainWindow mw = Application.Current.MainWindow as MainWindow;
                mw.set.ExportJsonPath = saveFileDialog.FileName;
            }
        }

        private void ExportJson(object sender, RoutedEventArgs e)
        {
            MainWindow mw = Application.Current.MainWindow as MainWindow;

            if (IsPath(mw.set.ExportJsonPath))
            {
                string json = JsonConvert.SerializeObject(mw.set.Source);
                File.WriteAllText(mw.set.ExportJsonPath, json);
            }

            else mw.set.ErrorDialogOpening = true;
        }
    }
}

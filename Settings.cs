using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Minecraft_AFK_GUI
{
    public class Settings : INotifyPropertyChanged
    {
        private string _WindowTitleName, _ExportJsonPath;
        private bool _WindowHandleButtonState, _AddOperationDialogOpening, _ErrorDialogOpening, _ExportJsonDialogOpening;

        //public List<OperationPageSource> Source;
        public ObservableCollection<OperationPageSource> Source;
        public Settings()
        {
            _WindowTitleName = "";
            _ExportJsonPath = "";
            _WindowHandleButtonState = false;
            _AddOperationDialogOpening = false;
            _ErrorDialogOpening = false;
            _ExportJsonDialogOpening = false;
            //Source = new List<OperationPageSource>();
            Source = new ObservableCollection<OperationPageSource>();
        }

        public string WindowTitleName
        {
            get { return _WindowTitleName; }
            set
            {
                if (PropertyChanged != null)
                {
                    _WindowTitleName = value;
                    OnPropertyChanged(nameof(WindowTitleName));
                }
            }
        }

        public string ExportJsonPath
        {
            get { return _ExportJsonPath; }
            set
            {
                if (PropertyChanged != null)
                {
                    _ExportJsonPath = value;
                    OnPropertyChanged(nameof(ExportJsonPath));
                }
            }
        }

        public bool WindowHandleButtonState
        {
            get { return _WindowHandleButtonState; }
            set
            {
                if (PropertyChanged != null)
                {
                    _WindowHandleButtonState = value;
                    OnPropertyChanged(nameof(WindowHandleButtonState));
                }
            }
        }

        public bool AddOperationDialogOpening
        {
            get { return _AddOperationDialogOpening; }
            set
            {
                if (PropertyChanged != null)
                {
                    _AddOperationDialogOpening = value;
                    OnPropertyChanged(nameof(AddOperationDialogOpening));
                }
            }
        }

        public bool ErrorDialogOpening
        {
            get { return _ErrorDialogOpening; }
            set
            {
                if (PropertyChanged != null)
                {
                    _ErrorDialogOpening = value;
                    OnPropertyChanged(nameof(ErrorDialogOpening));
                }
            }
        }

        public bool ExportJsonDialogOpening
        {
            get { return _ExportJsonDialogOpening; }
            set
            {
                if (PropertyChanged != null)
                {
                    _ExportJsonDialogOpening = value;
                    OnPropertyChanged(nameof(ExportJsonDialogOpening));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class OperationPageSource
    {
        public OperationPageSource(string _OperationMode = "", string _KeySelection = "", string _Speed = "", string _StartTime = "", string _Duratrion = "", string _RestartTime = "")
        {
            OperationMode = _OperationMode;
            KeySelection = _KeySelection;
            Speed = _Speed;
            StartTime = _StartTime;
            Duration = _Duratrion;
            RestartTime = _RestartTime;
        }

        public string OperationMode { set; get; }
        public string KeySelection { set; get; }
        public string Speed { set; get; }
        public string StartTime { set; get; }
        public string Duration { set; get; }
        public string RestartTime { set; get; }
    }

    public class IsKeySelectionEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString() == "键盘按键";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class IsSpeedInputEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString() == "点击";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

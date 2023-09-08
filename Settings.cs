using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Minecraft_AFK_GUI
{
    public class Settings : INotifyPropertyChanged
    {
        private string _WindowTitleName, _WindowHandleButtonState;
        //public List<OperationPageSource> Source;
        public ObservableCollection<OperationPageSource> Source;
        public Settings()
        {
            _WindowTitleName = "";
            _WindowHandleButtonState = "False";
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
        public string WindowHandleButtonState
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class OperationPageSource
    {
        public OperationPageSource()
        {
            //test
            Number = 1;
            OperationMode = "阿巴阿巴";
            KeySelection = Speed = StartTime = Duration = RestartTime = "23333333333";
            IsAllSelected = "True";
        }

        public int Number { set; get; }
        public string IsAllSelected { set; get; }
        public string OperationMode { set; get; }
        public string KeySelection { set; get; }
        public string Speed { set; get; }
        public string StartTime { set; get; }
        public string Duration { set; get; }
        public string RestartTime { set; get; }
    }
}
    /*
    public class OperationPageSource
    {
        private string _IsAllSelected, _OperationMode, _KeySelection, _Speed, _StartTime, _Duration, _RestartTime;

        public OperationPageSource()
        {
            _OperationMode = _KeySelection = _Speed = _StartTime = _Duration = _RestartTime = "1";
            _IsAllSelected = "True";
        }
        public string IsAllSelected
        {
            get { return _IsAllSelected; }
            set
            {
                if (PropertyChanged != null)
                {
                    _IsAllSelected = value;
                    OnPropertyChanged(nameof(IsAllSelected));
                }
            }
        }

        public string OperationMode
        {
            get { return _OperationMode; }
            set
            {
                if (PropertyChanged != null)
                {
                    _OperationMode = value;
                    OnPropertyChanged(nameof(OperationMode));
                }
            }
        }

        public string KeySelection
        {
            get { return _KeySelection; }
            set
            {
                if (PropertyChanged != null)
                {
                    _KeySelection = value;
                    OnPropertyChanged(nameof(KeySelection));
                }
            }
        }

        public string Speed
        {
            get { return _Speed; }
            set
            {
                if (PropertyChanged != null)
                {
                    _Speed = value;
                    OnPropertyChanged(nameof(Speed));
                }
            }
        }

        public string StartTime
        {
            get { return _StartTime; }
            set
            {
                if (PropertyChanged != null)
                {
                    _StartTime = value;
                    OnPropertyChanged(nameof(StartTime));
                }
            }
        }

        public string Duration
        {
            get { return _Duration; }
            set
            {
                if (PropertyChanged != null)
                {
                    _Duration = value;
                    OnPropertyChanged(nameof(Duration));
                }
            }
        }

        public string RestartTime
        {
            get { return _RestartTime; }
            set
            {
                if (PropertyChanged != null)
                {
                    _RestartTime = value;
                    OnPropertyChanged(nameof(RestartTime));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}*/

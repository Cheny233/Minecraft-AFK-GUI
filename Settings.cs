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
        private string _WindowTitleName, _WindowHandleButtonState, _AddOperationDialogOpening;
        //public List<OperationPageSource> Source;
        public ObservableCollection<OperationPageSource> Source;
        public Settings()
        {
            _WindowTitleName = "";
            _WindowHandleButtonState = "False";
            _AddOperationDialogOpening = "False";
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

        public string AddOperationDialogOpening
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

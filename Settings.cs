using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_AFK_GUI
{
    public class Settings : INotifyPropertyChanged
    {
        private string _WindowTitleName;
        private string _WindowHandleButtonState;

        public Settings()
        {
            _WindowTitleName = "";
            _WindowHandleButtonState = "False";
        }

        public string WindowTitleName
        {
            get { return _WindowTitleName; }
            set
            {
                if(PropertyChanged != null)
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
                if(PropertyChanged!= null)
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
}

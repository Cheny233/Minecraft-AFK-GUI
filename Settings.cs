using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_AFK_GUI
{
    public class Settings
    {
        public Settings()
        {
            WindowHandleName = "";
            WindowHandleButtonState = "False";
        }

        public string WindowHandleName { set; get; }
        public string WindowHandleButtonState { set; get; }
        
    }
}

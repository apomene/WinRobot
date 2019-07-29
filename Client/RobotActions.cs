using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client.RobotActions;
using RobotService;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Client
{
    internal class Actions:IDisposable
    {
        #region Imports For Set Window by Ttile
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);
        [DllImportAttribute("User32.dll")]
        private static extern IntPtr SetForegroundWindow(int hWnd);
        #endregion
        RobotActions.RobotClient proxy;

        public Actions()
        {
            //InstanceContext context = new InstanceContext(this);
            //proxy = new RobotClient(context);
        }
        public void CallBackFunction(string str)
        {
            Console.WriteLine(str);
        }

        public void GetWindow()
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new RobotClient(context);
            proxy.GetWindow("test.txt - Notepad");
        }

        public void MouseClick()
        {         
            proxy.MouseCLick();
        }

        public void SetText(string keys)
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new RobotClient(context);
            proxy.SetText(keys);
        }

        public void Dispose()
        {
            proxy.Close();
        }

        public void CallBackGetWindow(string windowTitle)
        {
            //Find the window, using the CORRECT Window Title, for example, Notepad
            int hWnd = FindWindow(null, windowTitle);
            if (hWnd > 0) //If found
            {
                SetForegroundWindow(hWnd);
                //return true;
            }
            else //Not Found
            {
               // return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Runtime.InteropServices; 

namespace RobotService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Robot : IRobot
    {
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);
        [DllImportAttribute("User32.dll")]
        private static extern IntPtr SetForegroundWindow(int hWnd);

        public bool GetWindow(string windowTitle)
        {
            //    IMyContractCallBack callback = OperationContext.Current.GetCallbackChannel<IMyContractCallBack>();
            //    callback.CallBackFunction("Calling from Call Back");
            //Find the window, using the CORRECT Window Title, for example, Notepad
            int hWnd = FindWindow(null, windowTitle);
            if (hWnd > 0) //If found
            {
                SetForegroundWindow(hWnd);
                return true;
            }
            else //Not Found
            {
                return false;
            }
        }

        public void MoveMouse(int x, int y)
        {
            //to do
        }
       
        public void MouseCLick()
        {
           //TO DO
        }

        public void SetText(string text)
        {
            //TO DO
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

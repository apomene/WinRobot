using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace RobotService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Robot : IRobot
    {
        #region Imports For Set Window by Ttile
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);
        [DllImportAttribute("User32.dll")]
        private static extern IntPtr SetForegroundWindow(int hWnd);
        #endregion
        #region Imports for MOuse CLick
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        #endregion

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
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        public void SetText(string text)
        {
            SendKeys.SendWait(text);
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

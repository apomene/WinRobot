using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace RobotService
{
    internal static class Actions
    {
        const string Select = "select-window";
        const string Move = "mouse-move";
        const string Click = "mouse-click";
        const string SendText = "send-keys";

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

        private static void GetWindow(string windowTitle)
        {
            //IActionCallBack callback = OperationContext.Current.GetCallbackChannel<IActionCallBack>();
            //callback.CallBackFunction("Calling from Call Back");           

            //Find the window, using the CORRECT Window Title, for example, Notepad
            int hWnd = FindWindow(null, windowTitle);
            if (hWnd > 0) //If found
            {
                SetForegroundWindow(hWnd);
               // callback.CallBackResult(true);
                //return true;
            }
            else //Not Found
            {
               // callback.CallBackResult(false);
            }
        }
        private static void MoveMouse(int x, int y)
        {
            //to do
        }
        private static void MouseCLick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        private static void SetText(string text)
        {
            SendKeys.SendWait(text);
        }

        #region Parse action Script And produce Actions
        /// <summary>
        /// Each Separate Action in 1 line and can be one of the 4 const strings, : separated by the action args
        /// </summary>
        /// <param name="actionScript"></param>
        public static void ParseActionScript(string actionScript)
        {
            try
            {
                foreach (var action in actionScript.Split(new[] { Environment.NewLine },StringSplitOptions.None))
                {
                    ParseAction(action);
                }
            }
            catch (Exception ex)
            {
                //TO DO log
            }
        }

        private static void  ParseAction(string action)
        {
            try
            {
                string actionName = action.Split(':')[0];
                string actionArgs = action.Split(':')[1];
                switch (actionName)
                {
                    case (Actions.Select):
                        ///Get Active Window By title
                        GetWindow(actionArgs);
                        break;
                    case (Actions.Move):
                        break;
                    case (Actions.Click):
                        MouseCLick();
                        break;
                    case (Actions.SendText):
                        SetText(actionArgs);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //TO DO log
            }
        }
        #endregion
    }
}

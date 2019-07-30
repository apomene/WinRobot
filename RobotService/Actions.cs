using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;
using System.Drawing;

namespace RobotService
{
    internal static class Actions
    {
        const string Select = "select-window";
        const string Move = "mouse-move";
        const string Click = "mouse-click";
        const string SendText = "send-keys";

        #region Imports For Invoking Various Actions
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImportAttribute("User32.dll")]
        private static extern IntPtr SetForegroundWindow(int hWnd);
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);   
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void  mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rectangle rect);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        #endregion
        private static void GetWindow(string windowTitle)
        {
            try
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
            catch (Exception ex)
            {
                Logging.Logging.LogErrorToFile(ex.ToString());
            }
          
        }
        private static string GetActiveWindowTitle()
        {
            try
            {
                const int nChars = 256;
                StringBuilder Buff = new StringBuilder(nChars);
                IntPtr handle = GetForegroundWindow();

                if (GetWindowText(handle, Buff, nChars) > 0)
                {
                    return Buff.ToString();
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.LogErrorToFile(ex.ToString());
            }
            return null;
        }
        private static void MoveMouse(int x, int y)
        {
            try
            {
                Rectangle rect;
                IntPtr hwnd = (IntPtr)FindWindow(null, GetActiveWindowTitle());
                GetWindowRect(hwnd, out rect); //get cuurent active window Position
                Cursor.Position = new System.Drawing.Point(rect.X - x, rect.Y - y); 
            }
            catch (Exception ex)
            {
                Logging.Logging.LogErrorToFile(ex.ToString());
            }
        
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
            foreach (var action in actionScript.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                ParseAction(action);
            }
        }

        private static void ParseAction(string action)
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
                        //x,y coordinates are comma separated:
                        var coords = actionArgs.Split(',');
                        MoveMouse(int.Parse(coords[0]), int.Parse(coords[1]));
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
                Logging.Logging.LogErrorToFile(ex.ToString());
            }
        
        }
        #endregion
    }
}

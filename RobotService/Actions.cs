using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;
using System.Drawing;
using ActionsModel;


namespace RobotService
{
    internal  class Actions:IActions
    {
       
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

        private string GetActiveWindowTitle()
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
                Logging.LogErrorToFile(ex.ToString());
            }
            return null;
        }

        #region External Assembly Model Implementation
        public  void GetWindow(string windowTitle)
        {
            try
            {
              
                //Find the window, using the CORRECT Window Title
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
                Logging.LogErrorToFile(ex.ToString());
            }         
        }      
        public  void MoveMouse(int x, int y)
        {
            try
            {
                Rectangle rect;
                IntPtr hwnd = (IntPtr)FindWindow(null, GetActiveWindowTitle());
                GetWindowRect(hwnd, out rect); //get cuurent active window Position
                Cursor.Position = new System.Drawing.Point(rect.X + x, rect.Y + y); 
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
            }
        
        }
        public  void MouseCLick(string clickType)
        {
            try
            {
                uint X = (uint)Cursor.Position.X;
                uint Y = (uint)Cursor.Position.Y;
                switch (clickType)
                {
                    case (ScriptModel.clickTypeL):
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                        break;
                    case (ScriptModel.clickTypeR):
                        mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
                        break;
                    case (ScriptModel.clickTypeD):
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                        //Thread.Sleep(50);
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
            }
      
          
        }
        public  void SetText(string text)
        {
            SendKeys.SendWait(text);
        }
        #endregion

        #region Parse action Script And produce Actions       
        public void ParseActionScript(string actionScript)
        {
            foreach (var action in actionScript.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                ParseAction(action);
            }
        }

        private  void ParseAction(string action)
        {
            try
            {
                
                string actionName = action.Split(ScriptModel.delimeter)[0];
                string actionArgs = action.Split(ScriptModel.delimeter)[1];
                /// TO DO: Avoid Switch statemnet - USE STRATEGY Pattern
                switch (actionName)
                {
                    case (ScriptModel.Select):
                        ///Get Active Window By title
                        GetWindow(actionArgs);
                        break;
                    case (ScriptModel.Move):                      
                        var coords = actionArgs.Split(ScriptModel.coordsDelim);
                        MoveMouse(int.Parse(coords[0]), int.Parse(coords[1]));
                        break;
                    case (ScriptModel.Click):
                        MouseCLick(actionArgs);
                        break;
                    case (ScriptModel.SendText):
                        SetText(actionArgs);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
            }
        
        }
        #endregion
       
    }
}

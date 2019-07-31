using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WpfRobotServer.RobotActions;
using System.ServiceModel;
using WpfRobotServer.Model;
using System.Threading.Tasks;
using ActionsModel;

namespace WpfRobotServer.ViewModel
{
    class ViewModelMain:ViewModelBase
    {
        #region UI proprties and fields
        string _textTitle;
        public string TextTitle
        {
            get
            {
                return _textTitle;
            }
            set
            {
                if (_textTitle != value)
                {
                    _textTitle = value;
                    RaisePropertyChanged("TextTitle");
                }
            }
        }

        string _textKeys;
        public string TextKeys
        {
            get
            {
                return _textKeys;
            }
            set
            {
                if (_textKeys != value)
                {
                    _textKeys = value;
                    RaisePropertyChanged("TextKeys");
                }
            }
        }

        string _textMouseMove;
        public string TextMouseMove
        {
            get
            {
                return _textMouseMove;
            }
            set
            {
                if (_textMouseMove != value)
                {
                    _textMouseMove = value;
                    RaisePropertyChanged("TextMouseMove");
                }
            }
        }
        string _textActions;
        public string TextActions
        {
            get
            {
                return _textActions;
            }
            set
            {
                if (_textActions != value)
                {
                    _textActions = value;
                    RaisePropertyChanged("TextActions");
                }
            }
        }

        string _textLog;
        public string TextLog
        {
            get
            {
                return _textLog;
            }
            set
            {
                if (_textLog != value)
                {
                    _textLog = value;
                    RaisePropertyChanged("TextLog");
                }
            }
        }

        public ObservableCollection<string> MouseActions { get; set; }
        string _clcik;
        public string MouseClicks
        {
            get
            {
                return _clcik;
            }
            set
            {
                if (_clcik != value)
                {
                    _clcik = value;
                    RaisePropertyChanged("MouseClicks");
                }
            }
        }

        #endregion

        #region Commands - Button Clicks
        public RelayCommand SetWindowByTitle { get; set; }
        public RelayCommand SetText { get; set; }
        public RelayCommand MouseClick { get; set; }
        public RelayCommand MouseMove { get; set; }
        public RelayCommand ClearActions { get; set; }
        public RelayCommand SendActions { get; set; }
        #endregion
        public ViewModelMain()
        {
            SetWindowByTitle = new RelayCommand(ActionWindow);
            SetText = new RelayCommand(ActionText);
            MouseClick = new RelayCommand(ActionClick);
            MouseMove = new RelayCommand(ActionMove);
            ClearActions = new RelayCommand(Clear);
            SendActions = new RelayCommand(Send);
            MouseActions = new ObservableCollection<string>();
            MouseActions.Add(ScriptModel.clickTypeL);
            MouseActions.Add(ScriptModel.clickTypeR);
            MouseActions.Add(ScriptModel.clickTypeD);
        }

        //RobotClient proxy;
        private void ActionWindow(object parameter)
        {
            try
            {
                //The server sends the action or action script to the connected client. 
                // InstanceContext context = new InstanceContext(this);
                //proxy = new RobotClient(context);
                // RobotMethods robotActions = new RobotMethods();
                string actionScript = $"{ScriptModel.Select}:{TextTitle}";
                // robotActions.SendActionScript(actionScript);
                this.TextActions += actionScript + Environment.NewLine;
                Logging.LogMsgToFile($"Action {ScriptModel.Select}, Added to Action Script");
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
            }
         
        }
        private void ActionText(object parameter)
        {
            try
            {
                string actionScript = $"{ScriptModel.SendText}:{TextKeys}";
                this.TextActions += actionScript + Environment.NewLine;
                Logging.LogMsgToFile($"Action {actionScript}, Added to Action Script");
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
            }

        }
        private void ActionClick(object parameter)
        {
            try
            {
                string actionScript = $"{ScriptModel.Click}:{MouseClicks}";
                this.TextActions += actionScript + Environment.NewLine;
                Logging.LogMsgToFile($"Action {actionScript}, Added to Action Script");
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
            }
          
        }
        private void ActionMove(object parameter)
        {
            try
            {
                string actionScript = $"{ScriptModel.Move}:{TextMouseMove}";
                this.TextActions += actionScript + Environment.NewLine;
                Logging.LogMsgToFile($"Action {actionScript}, Added to Action Script");
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
            }
        }
        private void Clear(object parameters)
        {
            try
            {
                this.TextActions = "";
                var msg = $"Action Script Cleared";
                Logging.LogMsgToFile(msg);
                TextLog += msg + Environment.NewLine;
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
            }        
        }
        private async void Send(object parameters)
        {         
            try
            {
                //The server sends the action or action script to the connected client.     
                RobotMethods robotActions = new RobotMethods();
                var msg = $"Sending Action Script  to Client";
                Logging.LogMsgToFile(msg);
                TextLog += msg + Environment.NewLine;
                await Task.Delay(5000); //For Test Reasons.  REMOVE on FINAL RELEASE!!
                var result = await robotActions.SendActionScriptAsync(TextActions);
                if (result)
                {
                    var msgSuccess = $"Action Script  succesfully executed";
                    Logging.LogMsgToFile(msgSuccess);
                    TextLog += msgSuccess + Environment.NewLine;
                }
                else
                {
                    var msgFail= $"Client  failure on executing script";
                    Logging.LogMsgToFile(msgFail);
                    TextLog += msgFail + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WpfRobotServer.RobotActions;
using System.ServiceModel;
using WpfRobotServer.Model;

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
        }

        RobotClient proxy;
        private void ActionWindow(object parameter)
        {
            //The server sends the action or action script to the connected client. 
            // InstanceContext context = new InstanceContext(this);
            //proxy = new RobotClient(context);
           // RobotMethods robotActions = new RobotMethods();
            string actionScript = $"{Actions.Select}:{TextTitle}";
           // robotActions.SendActionScript(actionScript);
            this.TextActions += actionScript + Environment.NewLine;
        }
        private void ActionText(object parameter)
        {
            string actionScript = $"{Actions.SendKeys}:{TextKeys}";
            this.TextActions += actionScript + Environment.NewLine;
        }
        private void ActionClick(object parameter)
        {
            string actionScript = $"{Actions.Click}:{TextKeys}";
            this.TextActions += actionScript + Environment.NewLine;
        }
        private void ActionMove(object parameter)
        {
            string actionScript = $"{Actions.Move}:{TextMouseMove}";
            this.TextActions += actionScript + Environment.NewLine;
        }
        private void Clear(object parameters)
        {
            this.TextActions = "";
        }
        private void Send(object parameters)
        {
            //The server sends the action or action script to the connected client.     
             RobotMethods robotActions = new RobotMethods();
             robotActions.SendActionScript(TextActions);        
        }
    }
}

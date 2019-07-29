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

        public RelayCommand SetWindowByTitle { get; set; }

        public ViewModelMain()
        {
            SetWindowByTitle = new RelayCommand(SetWindow);
        }

        RobotClient proxy;
        private void SetWindow(object parameter)
        {
            //The server sends the action or action script to the connected client. 
            // InstanceContext context = new InstanceContext(this);
            //proxy = new RobotClient(context);
            RobotMethods robotActions = new RobotMethods();
            string actionScript = $"{Actions.Select}:{TextTitle}";
            robotActions.SendActionScript(actionScript);

        }
    }
}

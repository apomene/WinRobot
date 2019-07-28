using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;


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

        private void SetWindow(object parameter)
        {
            //The server sends the action or action script to the connected client. 
            string test = "1";
        }
    }
}

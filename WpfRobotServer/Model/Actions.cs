using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRobotServer.Model
{
    internal static class Actions
    {
        public const string Select = "select-window";
        internal const string Move = "mouse-move";
        internal const string Click = "mouse-click";
        internal const string SendKeys = "send-keys";
    }
}

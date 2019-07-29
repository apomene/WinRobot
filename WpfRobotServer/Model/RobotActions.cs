using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WpfRobotServer.RobotActions;

namespace WpfRobotServer.Model
{
    internal class Actions:IRobotCallback
    {
        RobotClient proxy;
        public void CallBackGetWindow(string str)
        {
            Console.WriteLine(str);
        }

        public void GetWindow(string Title)
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new RobotClient(context);
            proxy.GetWindow(Title);
        }
    }
}

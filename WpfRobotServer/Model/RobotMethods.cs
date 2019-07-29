using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WpfRobotServer.RobotActions;

namespace WpfRobotServer.Model
{
    internal class RobotMethods : IRobotCallback
    {
        RobotClient proxy;
        public void CallBackResult(bool result)
        {
            Console.WriteLine(result);
        }

        public void SendActionScript(string script)
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new RobotClient(context);
            proxy.SendActionScript(script);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client.RobotActions;

namespace Client
{
    internal class Actions:IDisposable,IRobotCallback
    {
        RobotActions.RobotClient proxy;
        public void CallBackFunction(string str)
        {
            Console.WriteLine(str);
        }

        public void callService()
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new RobotClient(context);
            proxy.NormalFunction();
        }

        public void Dispose()
        {
            proxy.Close();
        }
    }
}

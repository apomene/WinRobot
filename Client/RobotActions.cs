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

        public Actions()
        {
            //InstanceContext context = new InstanceContext(this);
            //proxy = new RobotClient(context);
        }
        public void CallBackFunction(string str)
        {
            Console.WriteLine(str);
        }

        public void GetWindow()
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new RobotClient(context);
            proxy.GetWindow("test.txt - Notepad");
        }

        public void MouseClick()
        {         
            proxy.MouseCLick();
        }

        public void SetText(string keys)
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new RobotClient(context);
            proxy.SetText(keys);
        }

        public void Dispose()
        {
            proxy.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WpfRobotServer.RobotActions;
using System.Configuration;

namespace WpfRobotServer.Model
{
    internal class RobotMethods : IRobotCallback
    {
        RobotClient proxy;
        readonly string  timeOut = ConfigurationManager.AppSettings["ScriptExecTimeout"];
        readonly int _timeOut = 10 * 1000; //set default value in case parse fails
        public RobotMethods()
        {
            int.TryParse(timeOut,out _timeOut);
        }

        public void CallBackResult(bool result)
        {
            Console.WriteLine(result);
        }
        
        public bool SendActionScript(string script)
        {
            try
            {
                InstanceContext context = new InstanceContext(this);
                proxy = new RobotClient(context);
                bool result = proxy.SendActionScriptAsync(script).Wait(_timeOut);
                return result;
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
                return false;
            }
          
        }

        public async Task<bool> SendActionScriptAsync(string script)
        {
            try
            {
                InstanceContext context = new InstanceContext(this);
                proxy = new RobotClient(context);
                await proxy.SendActionScriptAsync(script);
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
                return false;
            }

        }
    }
}

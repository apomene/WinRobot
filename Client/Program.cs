using RobotService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            InitService();
            Console.Read();
            Logging.Logging.LogMsgToFile("Host Service Exited");
        }

        static ServiceHost  host = null;
        private static void InitService()
        {
            try
            {
                host = new ServiceHost(typeof(Robot));
                host.AddServiceEndpoint(typeof(IRobot),
                    new WSDualHttpBinding(), "");
                host.Open();
                Logging.Logging.LogMsgToFile("Host Service Started");
            }
            catch (Exception ex)
            {
                Logging.Logging.LogErrorToFile(ex.ToString());
                host.Abort();             
            }
        }
    }
}

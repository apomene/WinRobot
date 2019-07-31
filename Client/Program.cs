using RobotService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        readonly static string sendTimeOut = ConfigurationManager.AppSettings["SendTimeout"];
        readonly static string receiveTimeOut = ConfigurationManager.AppSettings["ReceiveTimeout"];
        static int _sendTimeOut = 3; //set default value in case parse fails
        static int _receivedTimeOut = 3; //set default value in case parse fails
        static void Main(string[] args)
        {
            int.TryParse(sendTimeOut, out _sendTimeOut);
            int.TryParse(receiveTimeOut, out _receivedTimeOut);
            InitService();
            Console.Read();
            Logging.LogMsgToFile("Host Service Exited");
        }

        static ServiceHost  host = null;
        private static void InitService()
        {
            try
            {
                host = new ServiceHost(typeof(Robot));
                WSDualHttpBinding binding = new WSDualHttpBinding();
                binding.OpenTimeout = new TimeSpan(0, 1, 0);
                binding.CloseTimeout = new TimeSpan(0, 1, 0);
                binding.SendTimeout = new TimeSpan(0, 0, _sendTimeOut);
                binding.ReceiveTimeout = new TimeSpan(0,0, _receivedTimeOut);
                host.AddServiceEndpoint(typeof(IRobot), binding , "");
                host.Open();
                Logging.LogMsgToFile("Host Service Started");
            }
            catch (Exception ex)
            {
                Logging.LogErrorToFile(ex.ToString());
                host.Abort();             
            }
        }
    }
}

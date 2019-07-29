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
           // Actions robot = new Actions();
            InitService();
            //robot.GetWindow();
            //robot.SetText("Hi");
            //robot.SetText("{ENTER}");
            //robot.SetText("All!!");
            Console.Read();
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
                //TO DO: Log
            }
            catch (Exception ex)
            {
                host.Abort();
                //TO DO LOG
            }
        }
    }
}

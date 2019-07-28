using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotActions.RobotClient robot = new RobotActions.RobotClient();
            var test = robot.GetData(3);
            Console.WriteLine(test);
            Console.Read();
        }
    }
}

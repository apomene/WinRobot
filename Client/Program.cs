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
            Actions robot = new Actions();
            
            robot.GetWindow();
            robot.SetText("Hi");
            robot.SetText("{ENTER}");
            robot.SetText("All!!");
            Console.Read();
        }
    }
}

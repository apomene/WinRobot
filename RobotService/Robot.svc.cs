using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace RobotService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Robot : IRobot
    {       
        public bool SendActionScript(string actionScript)
        {
            Actions.ParseActionScript(actionScript);
            return true;
        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

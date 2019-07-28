using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RobotService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Robot : IRobot
    {
        public void NormalFunction()
        {
            IMyContractCallBack callback = OperationContext.Current.GetCallbackChannel<IMyContractCallBack>();
            callback.CallBackFunction("Calling from Call Back");
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

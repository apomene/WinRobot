using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace winRobotService
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        public void SimpleAction()
        {
            IContractActions callback = OperationContext.Current.GetCallbackChannel<IContractActions>();
            callback.CallBackAction("Calling from Call Back");
        }
    }

}

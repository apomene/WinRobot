using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace winRobotService
{
    interface IContractActions
    {
        [OperationContract(IsOneWay = true)]
        void CallBackAction(string str);
    }

    [ServiceContract(CallbackContract = typeof(IContractActions))]
    public interface IService1
    {
        [OperationContract(IsOneWay = true)]
        void SimpleAction();
    }


}

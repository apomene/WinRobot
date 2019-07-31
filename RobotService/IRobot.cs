using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RobotService
{
    
    [ServiceContract(CallbackContract = typeof(IActionCallBack))]
    public interface IRobot
    {
        //[OperationContract(IsOneWay = true)]
        //void GetWindow(string windowTitle);

        //[OperationContract(IsOneWay = true)]
        //void MoveMouse(int x, int y);

        //[OperationContract(IsOneWay = true)]
        //void MouseCLick();

        [OperationContract]
        bool SendActionScript( string actionScript);
    }

    public interface IActionCallBack
    {
        [OperationContract(IsOneWay = true)]
        void CallBackResult(bool actionResult);
    }
  
}

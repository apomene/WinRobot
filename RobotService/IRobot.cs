﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RobotService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IMyContractCallBack))]
    public interface IRobot
    {
        [OperationContract]
        bool GetWindow(string windowTitle);

        [OperationContract(IsOneWay = true)]
        void MoveMouse(int x, int y);

        [OperationContract(IsOneWay = true)]
        void MouseCLick();

        [OperationContract(IsOneWay = true)]
        void SetText(string text);
    }

    public interface IMyContractCallBack
    {
        [OperationContract(IsOneWay = true)]
        void CallBackFunction(string str);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}

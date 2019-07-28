﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.RobotActions {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RobotActions.IRobot", CallbackContract=typeof(Client.RobotActions.IRobotCallback))]
    public interface IRobot {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IRobot/NormalFunction")]
        void NormalFunction();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IRobot/NormalFunction")]
        System.Threading.Tasks.Task NormalFunctionAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRobotCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IRobot/CallBackFunction")]
        void CallBackFunction(string str);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRobotChannel : Client.RobotActions.IRobot, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RobotClient : System.ServiceModel.DuplexClientBase<Client.RobotActions.IRobot>, Client.RobotActions.IRobot {
        
        public RobotClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public RobotClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public RobotClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public RobotClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public RobotClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void NormalFunction() {
            base.Channel.NormalFunction();
        }
        
        public System.Threading.Tasks.Task NormalFunctionAsync() {
            return base.Channel.NormalFunctionAsync();
        }
    }
}

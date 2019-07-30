﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfRobotServer.RobotActions {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RobotActions.IRobot", CallbackContract=typeof(WpfRobotServer.RobotActions.IRobotCallback))]
    public interface IRobot {
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IRobot/SendActionScript", ReplyAction="http://tempuri.org/IRobot/SendActionScriptResponse")]
        bool SendActionScript(string actionScript);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IRobot/SendActionScript", ReplyAction="http://tempuri.org/IRobot/SendActionScriptResponse")]
        System.Threading.Tasks.Task<bool> SendActionScriptAsync(string actionScript);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRobotCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IRobot/CallBackResult")]
        void CallBackResult(bool actionResult);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRobotChannel : WpfRobotServer.RobotActions.IRobot, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RobotClient : System.ServiceModel.DuplexClientBase<WpfRobotServer.RobotActions.IRobot>, WpfRobotServer.RobotActions.IRobot {
        
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
        
        public bool SendActionScript(string actionScript) {
            return base.Channel.SendActionScript(actionScript);
        }
        
        public System.Threading.Tasks.Task<bool> SendActionScriptAsync(string actionScript) {
            return base.Channel.SendActionScriptAsync(actionScript);
        }
    }
}

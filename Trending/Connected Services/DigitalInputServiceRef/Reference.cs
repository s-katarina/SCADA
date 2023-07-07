﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DigitalInputServiceRef
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DigitalInput", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    public partial class DigitalInput : object
    {
        
        private string DescriptionField;
        
        private DigitalInputServiceRef.DriverType DriverField;
        
        private string IOAddressField;
        
        private bool IsScanningField;
        
        private int ScanTimeField;
        
        private string TagNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DigitalInputServiceRef.DriverType Driver
        {
            get
            {
                return this.DriverField;
            }
            set
            {
                this.DriverField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IOAddress
        {
            get
            {
                return this.IOAddressField;
            }
            set
            {
                this.IOAddressField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsScanning
        {
            get
            {
                return this.IsScanningField;
            }
            set
            {
                this.IsScanningField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ScanTime
        {
            get
            {
                return this.ScanTimeField;
            }
            set
            {
                this.ScanTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TagName
        {
            get
            {
                return this.TagNameField;
            }
            set
            {
                this.TagNameField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DriverType", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    public enum DriverType : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SIM = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REAL = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DigitalInputServiceRef.IDigitalInputService")]
    public interface IDigitalInputService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalInputService/GetAll", ReplyAction="http://tempuri.org/IDigitalInputService/GetAllResponse")]
        DigitalInputServiceRef.DigitalInput[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalInputService/GetAll", ReplyAction="http://tempuri.org/IDigitalInputService/GetAllResponse")]
        System.Threading.Tasks.Task<DigitalInputServiceRef.DigitalInput[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalInputService/SendFromRTU", ReplyAction="http://tempuri.org/IDigitalInputService/SendFromRTUResponse")]
        void SendFromRTU(string IOAdress, bool value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalInputService/SendFromRTU", ReplyAction="http://tempuri.org/IDigitalInputService/SendFromRTUResponse")]
        System.Threading.Tasks.Task SendFromRTUAsync(string IOAdress, bool value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface IDigitalInputServiceChannel : DigitalInputServiceRef.IDigitalInputService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class DigitalInputServiceClient : System.ServiceModel.ClientBase<DigitalInputServiceRef.IDigitalInputService>, DigitalInputServiceRef.IDigitalInputService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DigitalInputServiceClient() : 
                base(DigitalInputServiceClient.GetDefaultBinding(), DigitalInputServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IDigitalInputService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DigitalInputServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(DigitalInputServiceClient.GetBindingForEndpoint(endpointConfiguration), DigitalInputServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DigitalInputServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DigitalInputServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DigitalInputServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DigitalInputServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DigitalInputServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public DigitalInputServiceRef.DigitalInput[] GetAll()
        {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<DigitalInputServiceRef.DigitalInput[]> GetAllAsync()
        {
            return base.Channel.GetAllAsync();
        }
        
        public void SendFromRTU(string IOAdress, bool value)
        {
            base.Channel.SendFromRTU(IOAdress, value);
        }
        
        public System.Threading.Tasks.Task SendFromRTUAsync(string IOAdress, bool value)
        {
            return base.Channel.SendFromRTUAsync(IOAdress, value);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDigitalInputService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDigitalInputService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:4062/Impl/DigitalInputService.svc/DigitalInput");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return DigitalInputServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IDigitalInputService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return DigitalInputServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IDigitalInputService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IDigitalInputService,
        }
    }
}

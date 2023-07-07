﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RTU.DigitalInputServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DigitalInput", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    [System.SerializableAttribute()]
    public partial class DigitalInput : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RTU.DigitalInputServiceRef.DriverType DriverField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IOAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsScaningField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ScanTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RTU.DigitalInputServiceRef.DriverType Driver {
            get {
                return this.DriverField;
            }
            set {
                if ((this.DriverField.Equals(value) != true)) {
                    this.DriverField = value;
                    this.RaisePropertyChanged("Driver");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IOAddress {
            get {
                return this.IOAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.IOAddressField, value) != true)) {
                    this.IOAddressField = value;
                    this.RaisePropertyChanged("IOAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsScaning {
            get {
                return this.IsScaningField;
            }
            set {
                if ((this.IsScaningField.Equals(value) != true)) {
                    this.IsScaningField = value;
                    this.RaisePropertyChanged("IsScaning");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ScanTime {
            get {
                return this.ScanTimeField;
            }
            set {
                if ((this.ScanTimeField.Equals(value) != true)) {
                    this.ScanTimeField = value;
                    this.RaisePropertyChanged("ScanTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TagName {
            get {
                return this.TagNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TagNameField, value) != true)) {
                    this.TagNameField = value;
                    this.RaisePropertyChanged("TagName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DriverType", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    public enum DriverType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SIM = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REAL = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DigitalInputServiceRef.IDigitalInputService")]
    public interface IDigitalInputService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalInputService/GetAll", ReplyAction="http://tempuri.org/IDigitalInputService/GetAllResponse")]
        RTU.DigitalInputServiceRef.DigitalInput[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalInputService/GetAll", ReplyAction="http://tempuri.org/IDigitalInputService/GetAllResponse")]
        System.Threading.Tasks.Task<RTU.DigitalInputServiceRef.DigitalInput[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalInputService/SendFromRTU", ReplyAction="http://tempuri.org/IDigitalInputService/SendFromRTUResponse")]
        void SendFromRTU(string IOAdress, bool value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalInputService/SendFromRTU", ReplyAction="http://tempuri.org/IDigitalInputService/SendFromRTUResponse")]
        System.Threading.Tasks.Task SendFromRTUAsync(string IOAdress, bool value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDigitalInputServiceChannel : RTU.DigitalInputServiceRef.IDigitalInputService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DigitalInputServiceClient : System.ServiceModel.ClientBase<RTU.DigitalInputServiceRef.IDigitalInputService>, RTU.DigitalInputServiceRef.IDigitalInputService {
        
        public DigitalInputServiceClient() {
        }
        
        public DigitalInputServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DigitalInputServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DigitalInputServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DigitalInputServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RTU.DigitalInputServiceRef.DigitalInput[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<RTU.DigitalInputServiceRef.DigitalInput[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void SendFromRTU(string IOAdress, bool value) {
            base.Channel.SendFromRTU(IOAdress, value);
        }
        
        public System.Threading.Tasks.Task SendFromRTUAsync(string IOAdress, bool value) {
            return base.Channel.SendFromRTUAsync(IOAdress, value);
        }
    }
}

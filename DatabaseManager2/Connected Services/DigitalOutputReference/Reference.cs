﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseManager2.DigitalOutputReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DigitalOutput", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    [System.SerializableAttribute()]
    public partial class DigitalOutput : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IOAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int InitialValueField;
        
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
        public int InitialValue {
            get {
                return this.InitialValueField;
            }
            set {
                if ((this.InitialValueField.Equals(value) != true)) {
                    this.InitialValueField = value;
                    this.RaisePropertyChanged("InitialValue");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DigitalOutputReference.IDigitalOutputService")]
    public interface IDigitalOutputService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalOutputService/GetAll", ReplyAction="http://tempuri.org/IDigitalOutputService/GetAllResponse")]
        DatabaseManager2.DigitalOutputReference.DigitalOutput[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalOutputService/GetAll", ReplyAction="http://tempuri.org/IDigitalOutputService/GetAllResponse")]
        System.Threading.Tasks.Task<DatabaseManager2.DigitalOutputReference.DigitalOutput[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalOutputService/Add", ReplyAction="http://tempuri.org/IDigitalOutputService/AddResponse")]
        void Add(DatabaseManager2.DigitalOutputReference.DigitalOutput digitalOutput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalOutputService/Add", ReplyAction="http://tempuri.org/IDigitalOutputService/AddResponse")]
        System.Threading.Tasks.Task AddAsync(DatabaseManager2.DigitalOutputReference.DigitalOutput digitalOutput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalOutputService/Delete", ReplyAction="http://tempuri.org/IDigitalOutputService/DeleteResponse")]
        void Delete(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalOutputService/Delete", ReplyAction="http://tempuri.org/IDigitalOutputService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalOutputService/Edit", ReplyAction="http://tempuri.org/IDigitalOutputService/EditResponse")]
        void Edit(string tagName, int initialValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDigitalOutputService/Edit", ReplyAction="http://tempuri.org/IDigitalOutputService/EditResponse")]
        System.Threading.Tasks.Task EditAsync(string tagName, int initialValue);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDigitalOutputServiceChannel : DatabaseManager2.DigitalOutputReference.IDigitalOutputService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DigitalOutputServiceClient : System.ServiceModel.ClientBase<DatabaseManager2.DigitalOutputReference.IDigitalOutputService>, DatabaseManager2.DigitalOutputReference.IDigitalOutputService {
        
        public DigitalOutputServiceClient() {
        }
        
        public DigitalOutputServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DigitalOutputServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DigitalOutputServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DigitalOutputServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DatabaseManager2.DigitalOutputReference.DigitalOutput[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<DatabaseManager2.DigitalOutputReference.DigitalOutput[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void Add(DatabaseManager2.DigitalOutputReference.DigitalOutput digitalOutput) {
            base.Channel.Add(digitalOutput);
        }
        
        public System.Threading.Tasks.Task AddAsync(DatabaseManager2.DigitalOutputReference.DigitalOutput digitalOutput) {
            return base.Channel.AddAsync(digitalOutput);
        }
        
        public void Delete(string tagName) {
            base.Channel.Delete(tagName);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(string tagName) {
            return base.Channel.DeleteAsync(tagName);
        }
        
        public void Edit(string tagName, int initialValue) {
            base.Channel.Edit(tagName, initialValue);
        }
        
        public System.Threading.Tasks.Task EditAsync(string tagName, int initialValue) {
            return base.Channel.EditAsync(tagName, initialValue);
        }
    }
}

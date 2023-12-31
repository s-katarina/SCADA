﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trending.RecordServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Record", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    [System.SerializableAttribute()]
    public partial class Record : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IOAdressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimestampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ValueField;
        
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
        public string IOAdress {
            get {
                return this.IOAdressField;
            }
            set {
                if ((object.ReferenceEquals(this.IOAdressField, value) != true)) {
                    this.IOAdressField = value;
                    this.RaisePropertyChanged("IOAdress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Timestamp {
            get {
                return this.TimestampField;
            }
            set {
                if ((this.TimestampField.Equals(value) != true)) {
                    this.TimestampField = value;
                    this.RaisePropertyChanged("Timestamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RecordServiceRef.IRecordService")]
    public interface IRecordService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/GetCurrent", ReplyAction="http://tempuri.org/IRecordService/GetCurrentResponse")]
        System.Collections.Generic.Dictionary<string, double> GetCurrent();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/GetCurrent", ReplyAction="http://tempuri.org/IRecordService/GetCurrentResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetCurrentAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/GetAll", ReplyAction="http://tempuri.org/IRecordService/GetAllResponse")]
        Trending.RecordServiceRef.Record[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/GetAll", ReplyAction="http://tempuri.org/IRecordService/GetAllResponse")]
        System.Threading.Tasks.Task<Trending.RecordServiceRef.Record[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/GetAllInPeriod", ReplyAction="http://tempuri.org/IRecordService/GetAllInPeriodResponse")]
        Trending.RecordServiceRef.Record[] GetAllInPeriod(System.DateTime low, System.DateTime high);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/GetAllInPeriod", ReplyAction="http://tempuri.org/IRecordService/GetAllInPeriodResponse")]
        System.Threading.Tasks.Task<Trending.RecordServiceRef.Record[]> GetAllInPeriodAsync(System.DateTime low, System.DateTime high);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/MostRecentAI", ReplyAction="http://tempuri.org/IRecordService/MostRecentAIResponse")]
        Trending.RecordServiceRef.Record[] MostRecentAI();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/MostRecentAI", ReplyAction="http://tempuri.org/IRecordService/MostRecentAIResponse")]
        System.Threading.Tasks.Task<Trending.RecordServiceRef.Record[]> MostRecentAIAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/MostRecentDI", ReplyAction="http://tempuri.org/IRecordService/MostRecentDIResponse")]
        Trending.RecordServiceRef.Record[] MostRecentDI();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/MostRecentDI", ReplyAction="http://tempuri.org/IRecordService/MostRecentDIResponse")]
        System.Threading.Tasks.Task<Trending.RecordServiceRef.Record[]> MostRecentDIAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/GetAllForTag", ReplyAction="http://tempuri.org/IRecordService/GetAllForTagResponse")]
        Trending.RecordServiceRef.Record[] GetAllForTag(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecordService/GetAllForTag", ReplyAction="http://tempuri.org/IRecordService/GetAllForTagResponse")]
        System.Threading.Tasks.Task<Trending.RecordServiceRef.Record[]> GetAllForTagAsync(string tagName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRecordServiceChannel : Trending.RecordServiceRef.IRecordService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RecordServiceClient : System.ServiceModel.ClientBase<Trending.RecordServiceRef.IRecordService>, Trending.RecordServiceRef.IRecordService {
        
        public RecordServiceClient() {
        }
        
        public RecordServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RecordServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RecordServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RecordServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.Dictionary<string, double> GetCurrent() {
            return base.Channel.GetCurrent();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetCurrentAsync() {
            return base.Channel.GetCurrentAsync();
        }
        
        public Trending.RecordServiceRef.Record[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<Trending.RecordServiceRef.Record[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public Trending.RecordServiceRef.Record[] GetAllInPeriod(System.DateTime low, System.DateTime high) {
            return base.Channel.GetAllInPeriod(low, high);
        }
        
        public System.Threading.Tasks.Task<Trending.RecordServiceRef.Record[]> GetAllInPeriodAsync(System.DateTime low, System.DateTime high) {
            return base.Channel.GetAllInPeriodAsync(low, high);
        }
        
        public Trending.RecordServiceRef.Record[] MostRecentAI() {
            return base.Channel.MostRecentAI();
        }
        
        public System.Threading.Tasks.Task<Trending.RecordServiceRef.Record[]> MostRecentAIAsync() {
            return base.Channel.MostRecentAIAsync();
        }
        
        public Trending.RecordServiceRef.Record[] MostRecentDI() {
            return base.Channel.MostRecentDI();
        }
        
        public System.Threading.Tasks.Task<Trending.RecordServiceRef.Record[]> MostRecentDIAsync() {
            return base.Channel.MostRecentDIAsync();
        }
        
        public Trending.RecordServiceRef.Record[] GetAllForTag(string tagName) {
            return base.Channel.GetAllForTag(tagName);
        }
        
        public System.Threading.Tasks.Task<Trending.RecordServiceRef.Record[]> GetAllForTagAsync(string tagName) {
            return base.Channel.GetAllForTagAsync(tagName);
        }
    }
}

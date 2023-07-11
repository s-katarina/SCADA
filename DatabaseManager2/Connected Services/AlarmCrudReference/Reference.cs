﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseManager2.AlarmCRUDReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Alarm", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    [System.SerializableAttribute()]
    public partial class Alarm : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DatabaseManager2.AlarmCRUDReference.AnalogInput AnalogInputField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InputTagNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DatabaseManager2.AlarmCRUDReference.Priority PriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DatabaseManager2.AlarmCRUDReference.AlarmType TypeField;
        
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
        public DatabaseManager2.AlarmCRUDReference.AnalogInput AnalogInput {
            get {
                return this.AnalogInputField;
            }
            set {
                if ((object.ReferenceEquals(this.AnalogInputField, value) != true)) {
                    this.AnalogInputField = value;
                    this.RaisePropertyChanged("AnalogInput");
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
        public string InputTagName {
            get {
                return this.InputTagNameField;
            }
            set {
                if ((object.ReferenceEquals(this.InputTagNameField, value) != true)) {
                    this.InputTagNameField = value;
                    this.RaisePropertyChanged("InputTagName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Limit {
            get {
                return this.LimitField;
            }
            set {
                if ((this.LimitField.Equals(value) != true)) {
                    this.LimitField = value;
                    this.RaisePropertyChanged("Limit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DatabaseManager2.AlarmCRUDReference.Priority Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((this.PriorityField.Equals(value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DatabaseManager2.AlarmCRUDReference.AlarmType Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AnalogInput", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    [System.SerializableAttribute()]
    public partial class AnalogInput : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DatabaseManager2.AlarmCRUDReference.Alarm[] AlarmsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DatabaseManager2.AlarmCRUDReference.DriverType DriverField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HighLimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IOAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsScanningField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LowLimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ScanTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnitsField;
        
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
        public DatabaseManager2.AlarmCRUDReference.Alarm[] Alarms {
            get {
                return this.AlarmsField;
            }
            set {
                if ((object.ReferenceEquals(this.AlarmsField, value) != true)) {
                    this.AlarmsField = value;
                    this.RaisePropertyChanged("Alarms");
                }
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
        public DatabaseManager2.AlarmCRUDReference.DriverType Driver {
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
        public int HighLimit {
            get {
                return this.HighLimitField;
            }
            set {
                if ((this.HighLimitField.Equals(value) != true)) {
                    this.HighLimitField = value;
                    this.RaisePropertyChanged("HighLimit");
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
        public bool IsScanning {
            get {
                return this.IsScanningField;
            }
            set {
                if ((this.IsScanningField.Equals(value) != true)) {
                    this.IsScanningField = value;
                    this.RaisePropertyChanged("IsScanning");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LowLimit {
            get {
                return this.LowLimitField;
            }
            set {
                if ((this.LowLimitField.Equals(value) != true)) {
                    this.LowLimitField = value;
                    this.RaisePropertyChanged("LowLimit");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Units {
            get {
                return this.UnitsField;
            }
            set {
                if ((object.ReferenceEquals(this.UnitsField, value) != true)) {
                    this.UnitsField = value;
                    this.RaisePropertyChanged("Units");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Priority", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    public enum Priority : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FIRST = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SECOND = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        THIRD = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AlarmType", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    public enum AlarmType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        HIGH = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LOW = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DriverType", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    public enum DriverType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SIM = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REAL = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AlarmDTO", Namespace="http://schemas.datacontract.org/2004/07/CORE.Models")]
    [System.SerializableAttribute()]
    public partial class AlarmDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InputTagNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
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
        public string InputTagName {
            get {
                return this.InputTagNameField;
            }
            set {
                if ((object.ReferenceEquals(this.InputTagNameField, value) != true)) {
                    this.InputTagNameField = value;
                    this.RaisePropertyChanged("InputTagName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Limit {
            get {
                return this.LimitField;
            }
            set {
                if ((this.LimitField.Equals(value) != true)) {
                    this.LimitField = value;
                    this.RaisePropertyChanged("Limit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((object.ReferenceEquals(this.PriorityField, value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AlarmCRUDReference.IAlarmCRUDService")]
    public interface IAlarmCRUDService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlarmCRUDService/Add", ReplyAction="http://tempuri.org/IAlarmCRUDService/AddResponse")]
        void Add(DatabaseManager2.AlarmCRUDReference.Alarm alarm, string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlarmCRUDService/Add", ReplyAction="http://tempuri.org/IAlarmCRUDService/AddResponse")]
        System.Threading.Tasks.Task AddAsync(DatabaseManager2.AlarmCRUDReference.Alarm alarm, string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlarmCRUDService/Delete", ReplyAction="http://tempuri.org/IAlarmCRUDService/DeleteResponse")]
        void Delete(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlarmCRUDService/Delete", ReplyAction="http://tempuri.org/IAlarmCRUDService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlarmCRUDService/GetAll", ReplyAction="http://tempuri.org/IAlarmCRUDService/GetAllResponse")]
        DatabaseManager2.AlarmCRUDReference.AlarmDTO[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlarmCRUDService/GetAll", ReplyAction="http://tempuri.org/IAlarmCRUDService/GetAllResponse")]
        System.Threading.Tasks.Task<DatabaseManager2.AlarmCRUDReference.AlarmDTO[]> GetAllAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlarmCRUDServiceChannel : DatabaseManager2.AlarmCRUDReference.IAlarmCRUDService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlarmCRUDServiceClient : System.ServiceModel.ClientBase<DatabaseManager2.AlarmCRUDReference.IAlarmCRUDService>, DatabaseManager2.AlarmCRUDReference.IAlarmCRUDService {
        
        public AlarmCRUDServiceClient() {
        }
        
        public AlarmCRUDServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlarmCRUDServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlarmCRUDServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlarmCRUDServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Add(DatabaseManager2.AlarmCRUDReference.Alarm alarm, string tagName) {
            base.Channel.Add(alarm, tagName);
        }
        
        public System.Threading.Tasks.Task AddAsync(DatabaseManager2.AlarmCRUDReference.Alarm alarm, string tagName) {
            return base.Channel.AddAsync(alarm, tagName);
        }
        
        public void Delete(int id) {
            base.Channel.Delete(id);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(int id) {
            return base.Channel.DeleteAsync(id);
        }
        
        public DatabaseManager2.AlarmCRUDReference.AlarmDTO[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<DatabaseManager2.AlarmCRUDReference.AlarmDTO[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
    }
}

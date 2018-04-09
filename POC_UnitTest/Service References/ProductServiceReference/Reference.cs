﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POC_UnitTest.ProductServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductDTO", Namespace="http://schemas.datacontract.org/2004/07/POC_Common")]
    [System.SerializableAttribute()]
    public partial class ProductDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> CreationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> QuantityField;
        
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
        public System.Nullable<System.DateTime> CreationDate {
            get {
                return this.CreationDateField;
            }
            set {
                if ((this.CreationDateField.Equals(value) != true)) {
                    this.CreationDateField = value;
                    this.RaisePropertyChanged("CreationDate");
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ContainerDTOOfProductDTO3Ww7OU9a", Namespace="http://schemas.datacontract.org/2004/07/POC_Common")]
    [System.SerializableAttribute()]
    public partial class ContainerDTOOfProductDTO3Ww7OU9a : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private POC_UnitTest.ProductServiceReference.ProductDTO[] listField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int totalField;
        
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
        public POC_UnitTest.ProductServiceReference.ProductDTO[] list {
            get {
                return this.listField;
            }
            set {
                if ((object.ReferenceEquals(this.listField, value) != true)) {
                    this.listField = value;
                    this.RaisePropertyChanged("list");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int total {
            get {
                return this.totalField;
            }
            set {
                if ((this.totalField.Equals(value) != true)) {
                    this.totalField = value;
                    this.RaisePropertyChanged("total");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductServiceReference.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/findAll", ReplyAction="http://tempuri.org/IProductService/findAllResponse")]
        POC_UnitTest.ProductServiceReference.ProductDTO[] findAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/findAll", ReplyAction="http://tempuri.org/IProductService/findAllResponse")]
        System.Threading.Tasks.Task<POC_UnitTest.ProductServiceReference.ProductDTO[]> findAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/findAllPaged", ReplyAction="http://tempuri.org/IProductService/findAllPagedResponse")]
        POC_UnitTest.ProductServiceReference.ContainerDTOOfProductDTO3Ww7OU9a findAllPaged(int start, int length);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/findAllPaged", ReplyAction="http://tempuri.org/IProductService/findAllPagedResponse")]
        System.Threading.Tasks.Task<POC_UnitTest.ProductServiceReference.ContainerDTOOfProductDTO3Ww7OU9a> findAllPagedAsync(int start, int length);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/findById", ReplyAction="http://tempuri.org/IProductService/findByIdResponse")]
        POC_UnitTest.ProductServiceReference.ProductDTO findById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/findById", ReplyAction="http://tempuri.org/IProductService/findByIdResponse")]
        System.Threading.Tasks.Task<POC_UnitTest.ProductServiceReference.ProductDTO> findByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/findByCreationDate", ReplyAction="http://tempuri.org/IProductService/findByCreationDateResponse")]
        POC_UnitTest.ProductServiceReference.ProductDTO[] findByCreationDate(System.DateTime creationDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/findByCreationDate", ReplyAction="http://tempuri.org/IProductService/findByCreationDateResponse")]
        System.Threading.Tasks.Task<POC_UnitTest.ProductServiceReference.ProductDTO[]> findByCreationDateAsync(System.DateTime creationDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/create", ReplyAction="http://tempuri.org/IProductService/createResponse")]
        bool create(POC_UnitTest.ProductServiceReference.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/create", ReplyAction="http://tempuri.org/IProductService/createResponse")]
        System.Threading.Tasks.Task<bool> createAsync(POC_UnitTest.ProductServiceReference.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/update", ReplyAction="http://tempuri.org/IProductService/updateResponse")]
        bool update(POC_UnitTest.ProductServiceReference.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/update", ReplyAction="http://tempuri.org/IProductService/updateResponse")]
        System.Threading.Tasks.Task<bool> updateAsync(POC_UnitTest.ProductServiceReference.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/delete", ReplyAction="http://tempuri.org/IProductService/deleteResponse")]
        bool delete(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/delete", ReplyAction="http://tempuri.org/IProductService/deleteResponse")]
        System.Threading.Tasks.Task<bool> deleteAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : POC_UnitTest.ProductServiceReference.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<POC_UnitTest.ProductServiceReference.IProductService>, POC_UnitTest.ProductServiceReference.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public POC_UnitTest.ProductServiceReference.ProductDTO[] findAll() {
            return base.Channel.findAll();
        }
        
        public System.Threading.Tasks.Task<POC_UnitTest.ProductServiceReference.ProductDTO[]> findAllAsync() {
            return base.Channel.findAllAsync();
        }
        
        public POC_UnitTest.ProductServiceReference.ContainerDTOOfProductDTO3Ww7OU9a findAllPaged(int start, int length) {
            return base.Channel.findAllPaged(start, length);
        }
        
        public System.Threading.Tasks.Task<POC_UnitTest.ProductServiceReference.ContainerDTOOfProductDTO3Ww7OU9a> findAllPagedAsync(int start, int length) {
            return base.Channel.findAllPagedAsync(start, length);
        }
        
        public POC_UnitTest.ProductServiceReference.ProductDTO findById(int id) {
            return base.Channel.findById(id);
        }
        
        public System.Threading.Tasks.Task<POC_UnitTest.ProductServiceReference.ProductDTO> findByIdAsync(int id) {
            return base.Channel.findByIdAsync(id);
        }
        
        public POC_UnitTest.ProductServiceReference.ProductDTO[] findByCreationDate(System.DateTime creationDate) {
            return base.Channel.findByCreationDate(creationDate);
        }
        
        public System.Threading.Tasks.Task<POC_UnitTest.ProductServiceReference.ProductDTO[]> findByCreationDateAsync(System.DateTime creationDate) {
            return base.Channel.findByCreationDateAsync(creationDate);
        }
        
        public bool create(POC_UnitTest.ProductServiceReference.ProductDTO product) {
            return base.Channel.create(product);
        }
        
        public System.Threading.Tasks.Task<bool> createAsync(POC_UnitTest.ProductServiceReference.ProductDTO product) {
            return base.Channel.createAsync(product);
        }
        
        public bool update(POC_UnitTest.ProductServiceReference.ProductDTO product) {
            return base.Channel.update(product);
        }
        
        public System.Threading.Tasks.Task<bool> updateAsync(POC_UnitTest.ProductServiceReference.ProductDTO product) {
            return base.Channel.updateAsync(product);
        }
        
        public bool delete(int id) {
            return base.Channel.delete(id);
        }
        
        public System.Threading.Tasks.Task<bool> deleteAsync(int id) {
            return base.Channel.deleteAsync(id);
        }
    }
}

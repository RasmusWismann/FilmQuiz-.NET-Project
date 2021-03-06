﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestClient.FilmQuizServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CategoryDTO", Namespace="http://schemas.datacontract.org/2004/07/Storage.DTO_s")]
    [System.SerializableAttribute()]
    public partial class CategoryDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FilmQuizServiceReference.IFilmQuiz")]
    public interface IFilmQuiz {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmQuiz/CreateCategory", ReplyAction="http://tempuri.org/IFilmQuiz/CreateCategoryResponse")]
        TestClient.FilmQuizServiceReference.CategoryDTO CreateCategory(TestClient.FilmQuizServiceReference.CategoryDTO category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmQuiz/CreateCategory", ReplyAction="http://tempuri.org/IFilmQuiz/CreateCategoryResponse")]
        System.Threading.Tasks.Task<TestClient.FilmQuizServiceReference.CategoryDTO> CreateCategoryAsync(TestClient.FilmQuizServiceReference.CategoryDTO category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmQuiz/EditCategory", ReplyAction="http://tempuri.org/IFilmQuiz/EditCategoryResponse")]
        TestClient.FilmQuizServiceReference.CategoryDTO EditCategory(TestClient.FilmQuizServiceReference.CategoryDTO category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmQuiz/EditCategory", ReplyAction="http://tempuri.org/IFilmQuiz/EditCategoryResponse")]
        System.Threading.Tasks.Task<TestClient.FilmQuizServiceReference.CategoryDTO> EditCategoryAsync(TestClient.FilmQuizServiceReference.CategoryDTO category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmQuiz/GetCategory", ReplyAction="http://tempuri.org/IFilmQuiz/GetCategoryResponse")]
        TestClient.FilmQuizServiceReference.CategoryDTO GetCategory(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmQuiz/GetCategory", ReplyAction="http://tempuri.org/IFilmQuiz/GetCategoryResponse")]
        System.Threading.Tasks.Task<TestClient.FilmQuizServiceReference.CategoryDTO> GetCategoryAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmQuiz/DeleteCategory", ReplyAction="http://tempuri.org/IFilmQuiz/DeleteCategoryResponse")]
        void DeleteCategory(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmQuiz/DeleteCategory", ReplyAction="http://tempuri.org/IFilmQuiz/DeleteCategoryResponse")]
        System.Threading.Tasks.Task DeleteCategoryAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmQuiz/GetAllCategories", ReplyAction="http://tempuri.org/IFilmQuiz/GetAllCategoriesResponse")]
        TestClient.FilmQuizServiceReference.CategoryDTO[] GetAllCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmQuiz/GetAllCategories", ReplyAction="http://tempuri.org/IFilmQuiz/GetAllCategoriesResponse")]
        System.Threading.Tasks.Task<TestClient.FilmQuizServiceReference.CategoryDTO[]> GetAllCategoriesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFilmQuizChannel : TestClient.FilmQuizServiceReference.IFilmQuiz, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FilmQuizClient : System.ServiceModel.ClientBase<TestClient.FilmQuizServiceReference.IFilmQuiz>, TestClient.FilmQuizServiceReference.IFilmQuiz {
        
        public FilmQuizClient() {
        }
        
        public FilmQuizClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FilmQuizClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilmQuizClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilmQuizClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TestClient.FilmQuizServiceReference.CategoryDTO CreateCategory(TestClient.FilmQuizServiceReference.CategoryDTO category) {
            return base.Channel.CreateCategory(category);
        }
        
        public System.Threading.Tasks.Task<TestClient.FilmQuizServiceReference.CategoryDTO> CreateCategoryAsync(TestClient.FilmQuizServiceReference.CategoryDTO category) {
            return base.Channel.CreateCategoryAsync(category);
        }
        
        public TestClient.FilmQuizServiceReference.CategoryDTO EditCategory(TestClient.FilmQuizServiceReference.CategoryDTO category) {
            return base.Channel.EditCategory(category);
        }
        
        public System.Threading.Tasks.Task<TestClient.FilmQuizServiceReference.CategoryDTO> EditCategoryAsync(TestClient.FilmQuizServiceReference.CategoryDTO category) {
            return base.Channel.EditCategoryAsync(category);
        }
        
        public TestClient.FilmQuizServiceReference.CategoryDTO GetCategory(int id) {
            return base.Channel.GetCategory(id);
        }
        
        public System.Threading.Tasks.Task<TestClient.FilmQuizServiceReference.CategoryDTO> GetCategoryAsync(int id) {
            return base.Channel.GetCategoryAsync(id);
        }
        
        public void DeleteCategory(int id) {
            base.Channel.DeleteCategory(id);
        }
        
        public System.Threading.Tasks.Task DeleteCategoryAsync(int id) {
            return base.Channel.DeleteCategoryAsync(id);
        }
        
        public TestClient.FilmQuizServiceReference.CategoryDTO[] GetAllCategories() {
            return base.Channel.GetAllCategories();
        }
        
        public System.Threading.Tasks.Task<TestClient.FilmQuizServiceReference.CategoryDTO[]> GetAllCategoriesAsync() {
            return base.Channel.GetAllCategoriesAsync();
        }
    }
}

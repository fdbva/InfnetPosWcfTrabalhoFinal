﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RespondentUiWcfService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseViewModel", Namespace="http://schemas.datacontract.org/2004/07/Evaluation.Application.ViewModels")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(RespondentUiWcfService.QuestionViewModel))]
    public partial class BaseViewModel : object
    {
        
        private System.Guid IdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="QuestionViewModel", Namespace="http://schemas.datacontract.org/2004/07/Evaluation.Application.ViewModels")]
    public partial class QuestionViewModel : RespondentUiWcfService.BaseViewModel
    {
        
        private string TextField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text
        {
            get
            {
                return this.TextField;
            }
            set
            {
                this.TextField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RespondentUiWcfService.IRespondentUiService")]
    public interface IRespondentUiService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRespondentUiService/Add", ReplyAction="http://tempuri.org/IRespondentUiService/AddResponse")]
        System.Threading.Tasks.Task<RespondentUiWcfService.QuestionViewModel> AddAsync(RespondentUiWcfService.QuestionViewModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRespondentUiService/AddWithoutCommit", ReplyAction="http://tempuri.org/IRespondentUiService/AddWithoutCommitResponse")]
        System.Threading.Tasks.Task<RespondentUiWcfService.QuestionViewModel> AddWithoutCommitAsync(RespondentUiWcfService.QuestionViewModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRespondentUiService/Commit", ReplyAction="http://tempuri.org/IRespondentUiService/CommitResponse")]
        System.Threading.Tasks.Task CommitAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public interface IRespondentUiServiceChannel : RespondentUiWcfService.IRespondentUiService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public partial class RespondentUiServiceClient : System.ServiceModel.ClientBase<RespondentUiWcfService.IRespondentUiService>, RespondentUiWcfService.IRespondentUiService
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public RespondentUiServiceClient() : 
                base(RespondentUiServiceClient.GetDefaultBinding(), RespondentUiServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IRespondentUiService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RespondentUiServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(RespondentUiServiceClient.GetBindingForEndpoint(endpointConfiguration), RespondentUiServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RespondentUiServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(RespondentUiServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RespondentUiServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(RespondentUiServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RespondentUiServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<RespondentUiWcfService.QuestionViewModel> AddAsync(RespondentUiWcfService.QuestionViewModel obj)
        {
            return base.Channel.AddAsync(obj);
        }
        
        public System.Threading.Tasks.Task<RespondentUiWcfService.QuestionViewModel> AddWithoutCommitAsync(RespondentUiWcfService.QuestionViewModel obj)
        {
            return base.Channel.AddWithoutCommitAsync(obj);
        }
        
        public System.Threading.Tasks.Task CommitAsync()
        {
            return base.Channel.CommitAsync();
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IRespondentUiService))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IRespondentUiService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:23324/RespondentUiService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return RespondentUiServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IRespondentUiService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return RespondentUiServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IRespondentUiService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IRespondentUiService,
        }
    }
}

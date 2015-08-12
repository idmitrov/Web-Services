﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceDistanceCalculatorConsoleClient.DistanceService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Point", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceDistanceCalculator")]
    [System.SerializableAttribute()]
    public partial class Point : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int XField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int YField;

        public Point()
        {
        }

        public Point(int posX, int posY)
        {
            this.X = posX;
            this.Y = posY;
        }

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
        public int X {
            get {
                return this.XField;
            }
            set {
                if ((this.XField.Equals(value) != true)) {
                    this.XField = value;
                    this.RaisePropertyChanged("X");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Y {
            get {
                return this.YField;
            }
            set {
                if ((this.YField.Equals(value) != true)) {
                    this.YField = value;
                    this.RaisePropertyChanged("Y");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DistanceService.ICalculator")]
    public interface ICalculator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/CalcDistance", ReplyAction="http://tempuri.org/ICalculator/CalcDistanceResponse")]
        double CalcDistance(WcfServiceDistanceCalculatorConsoleClient.DistanceService.Point startPoint, WcfServiceDistanceCalculatorConsoleClient.DistanceService.Point endPoint);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/CalcDistance", ReplyAction="http://tempuri.org/ICalculator/CalcDistanceResponse")]
        System.Threading.Tasks.Task<double> CalcDistanceAsync(WcfServiceDistanceCalculatorConsoleClient.DistanceService.Point startPoint, WcfServiceDistanceCalculatorConsoleClient.DistanceService.Point endPoint);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculatorChannel : WcfServiceDistanceCalculatorConsoleClient.DistanceService.ICalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<WcfServiceDistanceCalculatorConsoleClient.DistanceService.ICalculator>, WcfServiceDistanceCalculatorConsoleClient.DistanceService.ICalculator {
        
        public CalculatorClient() {
        }
        
        public CalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double CalcDistance(WcfServiceDistanceCalculatorConsoleClient.DistanceService.Point startPoint, WcfServiceDistanceCalculatorConsoleClient.DistanceService.Point endPoint) {
            return base.Channel.CalcDistance(startPoint, endPoint);
        }
        
        public System.Threading.Tasks.Task<double> CalcDistanceAsync(WcfServiceDistanceCalculatorConsoleClient.DistanceService.Point startPoint, WcfServiceDistanceCalculatorConsoleClient.DistanceService.Point endPoint) {
            return base.Channel.CalcDistanceAsync(startPoint, endPoint);
        }
    }
}

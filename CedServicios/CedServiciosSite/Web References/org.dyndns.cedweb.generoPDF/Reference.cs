﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace CedServicios.Site.org.dyndns.cedweb.generoPDF {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="GeneroPDFSoap", Namespace="http://www.cedeira.com.ar/webservices")]
    public partial class GeneroPDF : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GenerarPDFOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GeneroPDF() {
            this.Url = global::CedServicios.Site.Properties.Settings.Default.CedServiciosSite_org_dyndns_cedweb_generoPDF_GeneroPDF;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GenerarPDFCompletedEventHandler GenerarPDFCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.cedeira.com.ar/webservices/GenerarPDF", RequestNamespace="http://www.cedeira.com.ar/webservices", ResponseNamespace="http://www.cedeira.com.ar/webservices", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GenerarPDF(string CuitVendedor, int NroPuntoVta, int TipoComprobante, long NroComprobante, string IdDestinoComprobante, string ArchivoXML) {
            object[] results = this.Invoke("GenerarPDF", new object[] {
                        CuitVendedor,
                        NroPuntoVta,
                        TipoComprobante,
                        NroComprobante,
                        IdDestinoComprobante,
                        ArchivoXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GenerarPDFAsync(string CuitVendedor, int NroPuntoVta, int TipoComprobante, long NroComprobante, string IdDestinoComprobante, string ArchivoXML) {
            this.GenerarPDFAsync(CuitVendedor, NroPuntoVta, TipoComprobante, NroComprobante, IdDestinoComprobante, ArchivoXML, null);
        }
        
        /// <remarks/>
        public void GenerarPDFAsync(string CuitVendedor, int NroPuntoVta, int TipoComprobante, long NroComprobante, string IdDestinoComprobante, string ArchivoXML, object userState) {
            if ((this.GenerarPDFOperationCompleted == null)) {
                this.GenerarPDFOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGenerarPDFOperationCompleted);
            }
            this.InvokeAsync("GenerarPDF", new object[] {
                        CuitVendedor,
                        NroPuntoVta,
                        TipoComprobante,
                        NroComprobante,
                        IdDestinoComprobante,
                        ArchivoXML}, this.GenerarPDFOperationCompleted, userState);
        }
        
        private void OnGenerarPDFOperationCompleted(object arg) {
            if ((this.GenerarPDFCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GenerarPDFCompleted(this, new GenerarPDFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void GenerarPDFCompletedEventHandler(object sender, GenerarPDFCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GenerarPDFCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GenerarPDFCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
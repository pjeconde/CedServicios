﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1008
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.1008.
// 
#pragma warning disable 1591

namespace CedServicios.Site.org.dyndns.cedweb.listado {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ListadoIBKSoap", Namespace="http://www.cedeira.com.ar/webservices")]
    public partial class ListadoIBK : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ListarIBKOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ListadoIBK() {
            this.Url = global::CedServicios.Site.Properties.Settings.Default.CedServiciosSite_org_dyndns_cedweb_listado_ListadoIBK;
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
        public event ListarIBKCompletedEventHandler ListarIBKCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.cedeira.com.ar/webservices/ListarIBK", RequestNamespace="http://www.cedeira.com.ar/webservices", ResponseNamespace="http://www.cedeira.com.ar/webservices", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ListarIBK([System.Xml.Serialization.XmlElementAttribute(Namespace="http://lote.schemas.cfe.ib.com.ar/")] cecl cecl, string pathCertificado) {
            object[] results = this.Invoke("ListarIBK", new object[] {
                        cecl,
                        pathCertificado});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ListarIBKAsync(cecl cecl, string pathCertificado) {
            this.ListarIBKAsync(cecl, pathCertificado, null);
        }
        
        /// <remarks/>
        public void ListarIBKAsync(cecl cecl, string pathCertificado, object userState) {
            if ((this.ListarIBKOperationCompleted == null)) {
                this.ListarIBKOperationCompleted = new System.Threading.SendOrPostCallback(this.OnListarIBKOperationCompleted);
            }
            this.InvokeAsync("ListarIBK", new object[] {
                        cecl,
                        pathCertificado}, this.ListarIBKOperationCompleted, userState);
        }
        
        private void OnListarIBKOperationCompleted(object arg) {
            if ((this.ListarIBKCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ListarIBKCompleted(this, new ListarIBKCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://lote.schemas.cfe.ib.com.ar/")]
    public partial class cecl {
        
        private long cuit_canalField;
        
        private string cod_interno_canalField;
        
        private long cuit_vendedorField;
        
        private int tipo_doc_compradorField;
        
        private bool tipo_doc_compradorFieldSpecified;
        
        private long doc_compradorField;
        
        private bool doc_compradorFieldSpecified;
        
        private string denominacio_compradorField;
        
        private string fecha_emision_desdeField;
        
        private string fecha_emision_hastaField;
        
        private int punto_de_ventaField;
        
        private bool punto_de_ventaFieldSpecified;
        
        private int tipo_de_comprobanteField;
        
        private bool tipo_de_comprobanteFieldSpecified;
        
        private long numero_comprobante_desdeField;
        
        private bool numero_comprobante_desdeFieldSpecified;
        
        private long numero_comprobante_hastaField;
        
        private bool numero_comprobante_hastaFieldSpecified;
        
        private string estadoField;
        
        private string limiteField;
        
        /// <comentarios/>
        public long cuit_canal {
            get {
                return this.cuit_canalField;
            }
            set {
                this.cuit_canalField = value;
            }
        }
        
        /// <comentarios/>
        public string cod_interno_canal {
            get {
                return this.cod_interno_canalField;
            }
            set {
                this.cod_interno_canalField = value;
            }
        }
        
        /// <comentarios/>
        public long cuit_vendedor {
            get {
                return this.cuit_vendedorField;
            }
            set {
                this.cuit_vendedorField = value;
            }
        }
        
        /// <comentarios/>
        public int tipo_doc_comprador {
            get {
                return this.tipo_doc_compradorField;
            }
            set {
                this.tipo_doc_compradorField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool tipo_doc_compradorSpecified {
            get {
                return this.tipo_doc_compradorFieldSpecified;
            }
            set {
                this.tipo_doc_compradorFieldSpecified = value;
            }
        }
        
        /// <comentarios/>
        public long doc_comprador {
            get {
                return this.doc_compradorField;
            }
            set {
                this.doc_compradorField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool doc_compradorSpecified {
            get {
                return this.doc_compradorFieldSpecified;
            }
            set {
                this.doc_compradorFieldSpecified = value;
            }
        }
        
        /// <comentarios/>
        public string denominacio_comprador {
            get {
                return this.denominacio_compradorField;
            }
            set {
                this.denominacio_compradorField = value;
            }
        }
        
        /// <comentarios/>
        public string fecha_emision_desde {
            get {
                return this.fecha_emision_desdeField;
            }
            set {
                this.fecha_emision_desdeField = value;
            }
        }
        
        /// <comentarios/>
        public string fecha_emision_hasta {
            get {
                return this.fecha_emision_hastaField;
            }
            set {
                this.fecha_emision_hastaField = value;
            }
        }
        
        /// <comentarios/>
        public int punto_de_venta {
            get {
                return this.punto_de_ventaField;
            }
            set {
                this.punto_de_ventaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool punto_de_ventaSpecified {
            get {
                return this.punto_de_ventaFieldSpecified;
            }
            set {
                this.punto_de_ventaFieldSpecified = value;
            }
        }
        
        /// <comentarios/>
        public int tipo_de_comprobante {
            get {
                return this.tipo_de_comprobanteField;
            }
            set {
                this.tipo_de_comprobanteField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool tipo_de_comprobanteSpecified {
            get {
                return this.tipo_de_comprobanteFieldSpecified;
            }
            set {
                this.tipo_de_comprobanteFieldSpecified = value;
            }
        }
        
        /// <comentarios/>
        public long numero_comprobante_desde {
            get {
                return this.numero_comprobante_desdeField;
            }
            set {
                this.numero_comprobante_desdeField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numero_comprobante_desdeSpecified {
            get {
                return this.numero_comprobante_desdeFieldSpecified;
            }
            set {
                this.numero_comprobante_desdeFieldSpecified = value;
            }
        }
        
        /// <comentarios/>
        public long numero_comprobante_hasta {
            get {
                return this.numero_comprobante_hastaField;
            }
            set {
                this.numero_comprobante_hastaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numero_comprobante_hastaSpecified {
            get {
                return this.numero_comprobante_hastaFieldSpecified;
            }
            set {
                this.numero_comprobante_hastaFieldSpecified = value;
            }
        }
        
        /// <comentarios/>
        public string estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
            }
        }
        
        /// <comentarios/>
        public string limite {
            get {
                return this.limiteField;
            }
            set {
                this.limiteField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ListarIBKCompletedEventHandler(object sender, ListarIBKCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ListarIBKCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ListarIBKCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
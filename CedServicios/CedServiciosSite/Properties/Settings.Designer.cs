﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CedServicios.Site.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:20587/ValidoIBK.asmx")]
        public string CedServiciosSite_org_dyndns_cedweb_valido_ValidoIBK {
            get {
                return ((string)(this["CedServiciosSite_org_dyndns_cedweb_valido_ValidoIBK"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:20587/EnvioIBK.asmx")]
        public string CedServiciosSite_org_dyndns_cedweb_envio_EnvioIBK {
            get {
                return ((string)(this["CedServiciosSite_org_dyndns_cedweb_envio_EnvioIBK"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:4167/ConsultaIBK.asmx")]
        public string CedServiciosSite_org_dyndns_cedweb_consulta_ConsultaIBK {
            get {
                return ((string)(this["CedServiciosSite_org_dyndns_cedweb_consulta_ConsultaIBK"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:20587/ListadoIBK.asmx")]
        public string CedServiciosSite_org_dyndns_cedweb_listado_ListadoIBK {
            get {
                return ((string)(this["CedServiciosSite_org_dyndns_cedweb_listado_ListadoIBK"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:20587/DetalleIBK.asmx")]
        public string CedServiciosSite_org_dyndns_cedweb_detalle_DetalleIBK {
            get {
                return ((string)(this["CedServiciosSite_org_dyndns_cedweb_detalle_DetalleIBK"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:20587/GeneroPDF.asmx")]
        public string CedServiciosSite_org_dyndns_cedweb_generoPDF_GeneroPDF {
            get {
                return ((string)(this["CedServiciosSite_org_dyndns_cedweb_generoPDF_GeneroPDF"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://wswhomo.afip.gov.ar/wsfe/service.asmx")]
        public string CedServiciosSite_ar_gov_afip_wsw_Service {
            get {
                return ((string)(this["CedServiciosSite_ar_gov_afip_wsw_Service"]));
            }
        }
    }
}

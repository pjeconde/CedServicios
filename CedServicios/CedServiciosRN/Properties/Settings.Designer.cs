﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1022
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CedServicios.RN.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("https://bcfealsb02-qa:10001/ws/FacturaWebServiceConSchema")]
        public string CedServiciosRN_IBK_FacturaWebServiceConSchema {
            get {
                return ((string)(this["CedServiciosRN_IBK_FacturaWebServiceConSchema"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://ibsibqa01:10001/ws/ValidaFacturaWebService")]
        public string CedServiciosRN_IBKValidate_ValidaFacturaWebService {
            get {
                return ((string)(this["CedServiciosRN_IBKValidate_ValidaFacturaWebService"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://ibsibqa01:10001/ws/ReporteFacturaWebService")]
        public string CedServiciosRN_IBKComprobantesListado_ReporteFacturaWebService {
            get {
                return ((string)(this["CedServiciosRN_IBKComprobantesListado_ReporteFacturaWebService"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://wsaahomo.afip.gov.ar/ws/services/LoginCms")]
        public string CedServiciosRN_ar_gov_afip_wsaa_LoginCMSService {
            get {
                return ((string)(this["CedServiciosRN_ar_gov_afip_wsaa_LoginCMSService"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://wswhomo.afip.gov.ar/wsfev1/service.asmx")]
        public string CedServiciosRN_ar_gov_afip_wsfev1_Service {
            get {
                return ((string)(this["CedServiciosRN_ar_gov_afip_wsfev1_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://wswhomo.afip.gov.ar/wsfe/service.asmx")]
        public string CedServiciosRN_ar_gov_afip_wsw_Service {
            get {
                return ((string)(this["CedServiciosRN_ar_gov_afip_wsw_Service"]));
            }
        }
    }
}

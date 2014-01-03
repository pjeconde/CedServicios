using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas.Listado
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class consulta_emisor_comprobante_listado_response
    {
        private consulta_emisor_listado_response consulta_emisor_listado_responseField = new consulta_emisor_listado_response();
        private error[] errores_responseField = new error[100];

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("consulta_emisor_listado_response")]
        public consulta_emisor_listado_response consulta_emisor_listado_response
        {
            get
            {
                return this.consulta_emisor_listado_responseField;
            }
            set
            {
                this.consulta_emisor_listado_responseField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("errores_response", IsNullable = false)]
        public error[] errores_response
        {
            get
            {
                return this.errores_responseField;
            }
            set
            {
                this.errores_responseField = value;
            }
        }
    }
}

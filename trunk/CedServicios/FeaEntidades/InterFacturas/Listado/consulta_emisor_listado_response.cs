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
    public class consulta_emisor_listado_response
    {
        private long cuit_canalField;
        private long cuit_vendedorField;
        private long cant_total_busquedaField;
        private emisor_comprobante_response emisor_comprobante_responseField = new emisor_comprobante_response();
        private error[] errores_consultaField = new error[20];

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("emisor_comprobante_response")]
        public emisor_comprobante_response emisor_comprobante_response
        {
            get
            {
                return this.emisor_comprobante_responseField;
            }
            set
            {
                this.emisor_comprobante_responseField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("errores_consulta", IsNullable = false)]
        public error[] errores_consulta
        {
            get
            {
                return this.errores_consultaField;
            }
            set
            {
                this.errores_consultaField = value;
            }
        }

        /// <comentarios/>
        public long cuit_canal
        {
            get
            {
                return this.cuit_canalField;
            }
            set
            {
                this.cuit_canalField = value;
            }
        }

        /// <comentarios/>
        public long cuit_vendedor
        {
            get
            {
                return this.cuit_vendedorField;
            }
            set
            {
                this.cuit_vendedorField = value;
            }
        }

        /// <comentarios/>
        public long cant_total_busqueda
        {
            get
            {
                return this.cant_total_busquedaField;
            }
            set
            {
                this.cant_total_busquedaField = value;
            }
        }

    }
}

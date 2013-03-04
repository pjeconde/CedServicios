using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Reporte
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
    [FileHelpers.DelimitedRecord("|")]
    public partial class comprobante_response
    {
        private string nombre_claseField = "<comprobante_response>";

        private int tipo_de_comprobanteField;

        private long numero_comprobanteField;

        private int punto_de_ventaField;

        private string estadoField;

        [FileHelpers.FieldIgnored()]
        private error[] errores_comprobanteField = new error[60];

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string nombre_clase
        {
            get
            {
                return nombre_claseField;
            }
        }

        /// <comentarios/>
        public int tipo_de_comprobante
        {
            get
            {
                return this.tipo_de_comprobanteField;
            }
            set
            {
                this.tipo_de_comprobanteField = value;
            }
        }

        /// <comentarios/>
        public long numero_comprobante
        {
            get
            {
                return this.numero_comprobanteField;
            }
            set
            {
                this.numero_comprobanteField = value;
            }
        }

        /// <comentarios/>
        public int punto_de_venta
        {
            get
            {
                return this.punto_de_ventaField;
            }
            set
            {
                this.punto_de_ventaField = value;
            }
        }

        /// <comentarios/>
        public string estado
        {
            get
            {
                return this.estadoField;
            }
            set
            {
                this.estadoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("error", IsNullable = false)]
        public error[] errores_comprobante
        {
            get
            {
                return this.errores_comprobanteField;
            }
            set
            {
                this.errores_comprobanteField = value;
            }
        }
    }

}

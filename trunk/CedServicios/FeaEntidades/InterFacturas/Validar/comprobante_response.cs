using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas.Validar
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class comprobante_response
    {
        private int tipo_de_comprobanteField;

        private long numero_comprobanteField;

        private int punto_de_ventaField;

        private string estadoField;

        [FileHelpers.FieldIgnored()]
        private error[] errores_comprobanteField = new error[60];

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

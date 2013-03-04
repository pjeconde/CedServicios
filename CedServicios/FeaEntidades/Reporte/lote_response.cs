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
    public partial class lote_response
    {
        private string nombre_claseField = "<lote_response>";

        private long id_loteField;

        private long cuit_canalField;

        private long cuit_vendedorField;

        private int cantidad_regField;

        private int presta_servField;

        private bool presta_servFieldSpecified;

        private string fecha_envio_loteField;

        private int punto_de_ventaField;

        private string estadoField;

        [FileHelpers.FieldIgnored()]
        private error[] errores_loteField = new error[20];

        [FileHelpers.FieldIgnored()]
        private comprobante_response[] comprobante_responseField = new comprobante_response[5000];

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
        public long id_lote
        {
            get
            {
                return this.id_loteField;
            }
            set
            {
                this.id_loteField = value;
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
        public int cantidad_reg
        {
            get
            {
                return this.cantidad_regField;
            }
            set
            {
                this.cantidad_regField = value;
            }
        }

        /// <comentarios/>
        public int presta_serv
        {
            get
            {
                return this.presta_servField;
            }
            set
            {
                this.presta_servField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool presta_servSpecified
        {
            get
            {
                return this.presta_servFieldSpecified;
            }
            set
            {
                this.presta_servFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string fecha_envio_lote
        {
            get
            {
                return this.fecha_envio_loteField;
            }
            set
            {
                this.fecha_envio_loteField = value;
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
        public error[] errores_lote
        {
            get
            {
                return this.errores_loteField;
            }
            set
            {
                this.errores_loteField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("comprobante_response")]
        public comprobante_response[] comprobante_response
        {
            get
            {
                return this.comprobante_responseField;
            }
            set
            {
                this.comprobante_responseField = value;
            }
        }
    }
}

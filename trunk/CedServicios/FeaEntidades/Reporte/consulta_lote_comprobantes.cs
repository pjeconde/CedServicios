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
    public partial class consulta_lote_comprobantes
    {
        private string nombre_claseField = "<consulta_lote_comprobantes>";

        private long id_loteField;

        private long cuit_canalField;

        private string cod_interno_canalField;

        private long cuit_vendedorField;

        private int punto_de_ventaField;

        private bool punto_de_ventaFieldSpecified;

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
        public string cod_interno_canal
        {
            get
            {
                return this.cod_interno_canalField;
            }
            set
            {
                this.cod_interno_canalField = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool punto_de_ventaSpecified
        {
            get
            {
                return this.punto_de_ventaFieldSpecified;
            }
            set
            {
                this.punto_de_ventaFieldSpecified = value;
            }
        }
    }
}

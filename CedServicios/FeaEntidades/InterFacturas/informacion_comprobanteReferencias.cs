using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
    [FileHelpers.DelimitedRecord("|")]
    public partial class informacion_comprobanteReferencias
    {
        private string nombre_claseField = "<informacion_comprobanteReferencias>";

        private string tipo_comprobante_afipField; 

        private int codigo_de_referenciaField;

        private string descripcioncodigo_de_referenciaField;

        private string dato_de_referenciaField;

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
        public string tipo_comprobante_afip
        {
            get
            {
                return this.tipo_comprobante_afipField;
            }
            set
            {
                this.tipo_comprobante_afipField = value;
            }
        }

        /// <comentarios/>
        public int codigo_de_referencia
        {
            get
            {
                return this.codigo_de_referenciaField;
            }
            set
            {
                this.codigo_de_referenciaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string descripcioncodigo_de_referencia
        {
            get
            {
                return this.descripcioncodigo_de_referenciaField;
            }
            set
            {
                this.descripcioncodigo_de_referenciaField = value;
            }
        }

        /// <comentarios/>
        public string dato_de_referencia
        {
            get
            {
                return this.dato_de_referenciaField;
            }
            set
            {
                this.dato_de_referenciaField = value;
            }
        }
    }

}

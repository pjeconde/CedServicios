using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://lote.schemas.cfe.ib.com.ar/", IsNullable = false)]
    [FileHelpers.DelimitedRecord("|")]
    public partial class comprobante 
    {
        private cabecera cabeceraField;
        private detalle detalleField;
        private resumen resumenField;
        private forma_pago[] forma_pagoField;

        private extensiones extensionesField;
        private bool extensionesFieldSpecified;

        public comprobante() : base()
        {
            cabeceraField = new cabecera();
            detalleField = new detalle();
            resumenField = new resumen();
            forma_pagoField = new forma_pago[100];
        }

        [System.Xml.Serialization.XmlElementAttribute("cabecera")]
        public cabecera cabecera
        {
            get
            {
                return this.cabeceraField;
            }
            set
            {
                this.cabeceraField = value;
            }
        }
        public detalle detalle
        {
            get
            {
                return this.detalleField;
            }
            set
            {
                this.detalleField = value;
            }
        }
        public resumen resumen
        {
            get
            {
                return this.resumenField;
            }
            set
            {
                this.resumenField = value;
            }
        }
        [System.Xml.Serialization.XmlElementAttribute("forma_pago")]
        public new forma_pago[] forma_pago
        {
            get
            {
                return this.forma_pagoField;
            }
            set
            {
                this.forma_pagoField = value;
            }
        }

        /// <comentarios/>
        public extensiones extensiones
        {
            get
            {
                return this.extensionesField;
            }
            set
            {
                this.extensionesField = value;
            }
        }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool extensionesSpecified
        {
            get
            {
                return this.extensionesFieldSpecified;
            }
            set
            {
                this.extensionesFieldSpecified = value;
            }
        }
    }
}

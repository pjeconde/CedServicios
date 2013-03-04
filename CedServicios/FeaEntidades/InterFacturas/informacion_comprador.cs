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
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://lote.schemas.cfe.ib.com.ar/", IsNullable = false)]
    [FileHelpers.DelimitedRecord("|")]
    public partial class informacion_comprador
    {
        private string nombre_claseField = "<informacion_comprador>";

        [FileHelpers.FieldNullValue(typeof(System.Int64), "0")]
        private long gLNField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
        private bool gLNFieldSpecified;

        private string codigo_internoField;

        [FileHelpers.FieldNullValue(typeof(System.Int32), "0")]
        private int codigo_doc_identificatorioField;

        [FileHelpers.FieldNullValue(typeof(System.Int64), "0")]
        private long nro_doc_identificatorioField;

        private string denominacionField;

        [FileHelpers.FieldNullValue(typeof(System.Int32), "0")]
        private int condicion_IVAField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
        private bool condicion_IVAFieldSpecified;

        [FileHelpers.FieldNullValue(typeof(System.Int32), "0")]
        private int condicion_ingresos_brutosField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
        private bool condicion_ingresos_brutosFieldSpecified;

        [FileHelpers.FieldNullValue(typeof(System.String), "")]
        private string nro_ingresos_brutosField;

        private string inicio_de_actividadesField;

        private string contactoField;

        private string domicilio_calleField;

        private string domicilio_numeroField;

        private string domicilio_pisoField;

        private string domicilio_deptoField;

        private string domicilio_sectorField;

        private string domicilio_torreField;

        private string domicilio_manzanaField;

        private string localidadField;

        private string provinciaField;

        private string cpField;

        private string emailField;

        private string telefonoField;

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
        public long GLN
        {
            get
            {
                return this.gLNField;
            }
            set
            {
                this.gLNField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GLNSpecified
        {
            get
            {
                return this.gLNFieldSpecified;
            }
            set
            {
                this.gLNFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string codigo_interno
        {
            get
            {
                return this.codigo_internoField;
            }
            set
            {
                this.codigo_internoField = value;
            }
        }

        /// <comentarios/>
        public int codigo_doc_identificatorio
        {
            get
            {
                return this.codigo_doc_identificatorioField;
            }
            set
            {
                this.codigo_doc_identificatorioField = value;
            }
        }

        /// <comentarios/>
        public long nro_doc_identificatorio
        {
            get
            {
                return this.nro_doc_identificatorioField;
            }
            set
            {
                this.nro_doc_identificatorioField = value;
            }
        }

        /// <comentarios/>
        public string denominacion
        {
            get
            {
                return this.denominacionField;
            }
            set
            {
                this.denominacionField = value;
            }
        }

        /// <comentarios/>
        public int condicion_IVA
        {
            get
            {
                return this.condicion_IVAField;
            }
            set
            {
                this.condicion_IVAField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool condicion_IVASpecified
        {
            get
            {
                return this.condicion_IVAFieldSpecified;
            }
            set
            {
                this.condicion_IVAFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public int condicion_ingresos_brutos
        {
            get
            {
                return this.condicion_ingresos_brutosField;
            }
            set
            {
                this.condicion_ingresos_brutosField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool condicion_ingresos_brutosSpecified
        {
            get
            {
                return this.condicion_ingresos_brutosFieldSpecified;
            }
            set
            {
                this.condicion_ingresos_brutosFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string nro_ingresos_brutos
        {
            get
            {
                return this.nro_ingresos_brutosField;
            }
            set
            {
                this.nro_ingresos_brutosField = value;
            }
        }

        /// <comentarios/>
        public string inicio_de_actividades
        {
            get
            {
                return this.inicio_de_actividadesField;
            }
            set
            {
                this.inicio_de_actividadesField = value;
            }
        }

        /// <comentarios/>
        public string contacto
        {
            get
            {
                return this.contactoField;
            }
            set
            {
                this.contactoField = value;
            }
        }

        /// <comentarios/>
        public string domicilio_calle
        {
            get
            {
                return this.domicilio_calleField;
            }
            set
            {
                this.domicilio_calleField = value;
            }
        }

        /// <comentarios/>
        public string domicilio_numero
        {
            get
            {
                return this.domicilio_numeroField;
            }
            set
            {
                this.domicilio_numeroField = value;
            }
        }

        /// <comentarios/>
        public string domicilio_piso
        {
            get
            {
                return this.domicilio_pisoField;
            }
            set
            {
                this.domicilio_pisoField = value;
            }
        }

        /// <comentarios/>
        public string domicilio_depto
        {
            get
            {
                return this.domicilio_deptoField;
            }
            set
            {
                this.domicilio_deptoField = value;
            }
        }

        /// <comentarios/>
        public string domicilio_sector
        {
            get
            {
                return this.domicilio_sectorField;
            }
            set
            {
                this.domicilio_sectorField = value;
            }
        }

        /// <comentarios/>
        public string domicilio_torre
        {
            get
            {
                return this.domicilio_torreField;
            }
            set
            {
                this.domicilio_torreField = value;
            }
        }

        /// <comentarios/>
        public string domicilio_manzana
        {
            get
            {
                return this.domicilio_manzanaField;
            }
            set
            {
                this.domicilio_manzanaField = value;
            }
        }

        /// <comentarios/>
        public string localidad
        {
            get
            {
                return this.localidadField;
            }
            set
            {
                this.localidadField = value;
            }
        }

        /// <comentarios/>
        public string provincia
        {
            get
            {
                return this.provinciaField;
            }
            set
            {
                this.provinciaField = value;
            }
        }

        /// <comentarios/>
        public string cp
        {
            get
            {
                return this.cpField;
            }
            set
            {
                this.cpField = value;
            }
        }

        /// <comentarios/>
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <comentarios/>
        public string telefono
        {
            get
            {
                return this.telefonoField;
            }
            set
            {
                this.telefonoField = value;
            }
        }
    }

}

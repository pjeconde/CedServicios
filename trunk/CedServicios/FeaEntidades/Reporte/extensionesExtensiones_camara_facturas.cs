using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Reporte
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
    [FileHelpers.DelimitedRecord("|")]
    public partial class extensionesExtensiones_camara_facturas
    {
        private string nombre_claseField = "<extensionesExtensiones_camara_facturas>";

        [FileHelpers.FieldNullValue(typeof(System.String), "")]
        private string clave_de_vinculacionField;

        private string id_templateField;

        private string id_idiomaField;

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
        public string clave_de_vinculacion
        {
            get
            {
                return this.clave_de_vinculacionField;
            }
            set
            {
                this.clave_de_vinculacionField = value;
            }
        }

        /// <comentarios/>
        public string id_template
        {
            get
            {
                return this.id_templateField;
            }
            set
            {
                this.id_templateField = value;
            }
        }

        /// <comentarios/>
        public string id_idioma
        {
            get
            {
                return this.id_idiomaField;
            }
            set
            {
                this.id_idiomaField = value;
            }
        }

    }
}

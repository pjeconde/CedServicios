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
    public partial class error
    {
        private string nombre_claseField = "<error>";

        private int codigo_errorField;

        private string descripcion_errorField;

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
        public int codigo_error
        {
            get
            {
                return this.codigo_errorField;
            }
            set
            {
                this.codigo_errorField = value;
            }
        }

        /// <comentarios/>
        public string descripcion_error
        {
            get
            {
                return this.descripcion_errorField;
            }
            set
            {
                this.descripcion_errorField = value;
            }
        }
    }
}

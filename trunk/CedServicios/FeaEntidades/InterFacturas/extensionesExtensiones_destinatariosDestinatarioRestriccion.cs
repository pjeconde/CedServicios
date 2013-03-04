using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
    [FileHelpers.DelimitedRecord("|")]
    public partial class extensionesExtensiones_destinatariosDestinatarioRestriccion
    {
        private string nombre_claseField = "<extensionesExtensiones_destinatariosDestinatarioRestriccion>";

        private string tipoField;

        private string idField;

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
        public string tipo
        {
            get
            {
                return this.tipoField;
            }
            set
            {
                this.tipoField = value;
            }
        }

        /// <comentarios/>
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
}

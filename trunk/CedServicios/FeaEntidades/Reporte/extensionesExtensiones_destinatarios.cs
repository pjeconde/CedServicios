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
    public partial class extensionesExtensiones_destinatarios
    {
        private string nombre_claseField = "<extensionesExtensiones_destinatarios>";
        
        [FileHelpers.FieldIgnored()]
        private extensionesExtensiones_destinatariosDestinatario[] destinatarioField = new extensionesExtensiones_destinatariosDestinatario[5];

        private string emailField;

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
        [System.Xml.Serialization.XmlElementAttribute("destinatario")]
        public extensionesExtensiones_destinatariosDestinatario[] destinatario
        {
            get
            {
                return this.destinatarioField;
            }
            set
            {
                this.destinatarioField = value;
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
    }
}

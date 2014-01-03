using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas.Listado
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class emisor_comprobante_response
    {
        private emisor_comprobante_listado[] emisor_comprobante_listadoField = new emisor_comprobante_listado[10000];

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("emisor_comprobante_listado")]
        public emisor_comprobante_listado[] emisor_comprobante_listado
        {
            get
            {
                return this.emisor_comprobante_listadoField;
            }
            set
            {
                this.emisor_comprobante_listadoField = value;
            }
        }
    }
}

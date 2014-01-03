using System;
using System.Collections.Generic;
using System.Text;
using FeaEntidades.InterFacturas;

namespace FeaEntidades.InterFacturas.Listado
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class errores_response
    {
        private error[] errorField = new error[100];

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("error", IsNullable = false)]
        public error[] error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }
    }
}

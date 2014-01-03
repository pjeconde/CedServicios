using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas.Validar
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class error
    {
        private int codigo_errorField;

        private string descripcion_errorField;

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

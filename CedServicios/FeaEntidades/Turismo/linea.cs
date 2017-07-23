using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    public partial class linea : FeaEntidades.InterFacturas.linea
    {
        private short codigo_TurismoField;

        public linea() : base()
        {
        }

        public short codigo_Turismo
        {
            get
            {
                return this.codigo_TurismoField;
            }
            set
            {
                this.codigo_TurismoField = value;
            }
        }
    }
}

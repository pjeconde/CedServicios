using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    public partial class resumen : FeaEntidades.InterFacturas.resumen
    {
        private decimal importe_ReintegroField;

        public resumen() : base()
        {
        }

        public decimal importe_Reintegro
        {
            get
            {
                return this.importe_ReintegroField;
            }
            set
            {
                this.importe_ReintegroField = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    public partial class detalle : FeaEntidades.InterFacturas.detalle
    {
        private linea[] lineaField;

        public detalle() : base()
        {
            lineaField = new linea[1000];
        }

        public new linea[] linea
        {
            get
            {
                return this.lineaField;
            }
            set
            {
                this.lineaField = value;
            }
        }
    }
}

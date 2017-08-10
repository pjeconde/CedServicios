using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    [System.SerializableAttribute()]
    public partial class informacion_comprobante : FeaEntidades.InterFacturas.informacion_comprobante
    {
        private string tipo_AutorizacionField;
        private long codigo_AutotizacionField;

        public informacion_comprobante() : base()
        {
        }

        public string tipo_Autorizacion
        {
            get
            {
                return this.tipo_AutorizacionField;
            }
            set
            {
                this.tipo_AutorizacionField = value;
            }
        }
        public long codigo_Autotizacion
        {
            get
            {
                return this.codigo_AutotizacionField;
            }
            set
            {
                this.codigo_AutotizacionField = value;
            }
        }
    }
}

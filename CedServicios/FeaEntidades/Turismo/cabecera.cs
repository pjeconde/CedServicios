using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    public partial class cabecera : FeaEntidades.InterFacturas.cabecera
    {
        private informacion_comprador informacion_compradorField;
        private informacion_comprobante informacion_comprobanteField;

        public cabecera() : base()
        {
            informacion_compradorField = new informacion_comprador();
            informacion_comprobanteField = new informacion_comprobante();
        }

        public new informacion_comprador informacion_comprador
        {
            get
            {
                return this.informacion_compradorField;
            }
            set
            {
                this.informacion_compradorField = value;
            }
        }
        public new informacion_comprobante informacion_comprobante
        {
            get
            {
                return this.informacion_comprobanteField;
            }
            set
            {
                this.informacion_comprobanteField = value;
            }
        }
    }
}

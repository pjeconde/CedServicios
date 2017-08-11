using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    [System.SerializableAttribute()]
    public partial class cabecera 
    {
        private informacion_vendedor informacion_vendedorField;
        private informacion_comprador informacion_compradorField;
        private informacion_comprobante informacion_comprobanteField;

        public cabecera() : base()
        {
            informacion_vendedorField = new informacion_vendedor();
            informacion_compradorField = new informacion_comprador();
            informacion_comprobanteField = new informacion_comprobante();
        }

        public informacion_vendedor informacion_vendedor
        {
            get
            {
                return this.informacion_vendedorField;
            }
            set
            {
                this.informacion_vendedorField = value;
            }
        }

        public informacion_comprador informacion_comprador
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

        public informacion_comprobante informacion_comprobante
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

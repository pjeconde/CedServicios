using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    public partial class comprobante : FeaEntidades.InterFacturas.comprobante
    {
        private cabecera cabeceraField;
        private detalle detalleField;
        private resumen resumenField;
        private forma_pago[] forma_pagoField;


        public comprobante() : base()
        {
            cabeceraField = new cabecera();
            detalleField = new detalle();
            resumenField = new resumen();
            forma_pagoField = new forma_pago[1000];
        }

        public new cabecera cabecera
        {
            get
            {
                return this.cabeceraField;
            }
            set
            {
                this.cabeceraField = value;
            }
        }
        public new detalle detalle
        {
            get
            {
                return this.detalleField;
            }
            set
            {
                this.detalleField = value;
            }
        }
        public new resumen resumen
        {
            get
            {
                return this.resumenField;
            }
            set
            {
                this.resumenField = value;
            }
        }
        public new forma_pago[] forma_pago
        {
            get
            {
                return this.forma_pagoField;
            }
            set
            {
                this.forma_pagoField = value;
            }
        }
    }
}

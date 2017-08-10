using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    [System.SerializableAttribute()]
    public partial class forma_pago
    {
        private short codigoField;
        private string swift_codeField;
        private short tipo_cuentaField;
        private decimal numero_cuentaField;
        private long numero_tarjetaField;
        private decimal importeField;

        public forma_pago()
        {
        }

        public short codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }
        public string swift_code
        {
            get
            {
                return this.swift_codeField;
            }
            set
            {
                this.swift_codeField = value;
            }
        }
        public short tipo_cuenta
        {
            get
            {
                return this.tipo_cuentaField;
            }
            set
            {
                this.tipo_cuentaField = value;
            }
        }
        public decimal numero_cuenta
        {
            get
            {
                return this.numero_cuentaField;
            }
            set
            {
                this.numero_cuentaField = value;
            }
        }
        public long numero_tarjeta
        {
            get
            {
                return this.numero_tarjetaField;
            }
            set
            {
                this.numero_tarjetaField = value;
            }
        }
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }
}

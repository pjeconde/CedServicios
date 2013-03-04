using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.FormasPago
{
    public class CuentaCorriente : FormaPago
    {
        public CuentaCorriente()
        {
            Codigo = 96;
            Descr = "Cuenta Corriente";
        }
    }
}


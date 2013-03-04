using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.FormasPago
{
    public class TarjetaDeCredito : FormaPago
    {
        public TarjetaDeCredito()
        {
            Codigo = 68;
            Descr = "Tarjeta de Crédito";
        }
    }
}


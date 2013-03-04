using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.FormasPago
{
    public class TarjetaDeDebito : FormaPago
    {
        public TarjetaDeDebito()
        {
            Codigo = 69;
            Descr = "Tarjeta de Débito";
        }
    }
}


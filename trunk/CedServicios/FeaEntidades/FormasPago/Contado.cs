using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.FormasPago
{
    public class Contado : FormaPago
    {
        public Contado()
        {
            Codigo = 1;
            Descr = "Contado";
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.FormasPago
{
    public class Cheque : FormaPago
    {
        public Cheque()
        {
            Codigo = 97;
            Descr = "Cheque";
        }
    }
}


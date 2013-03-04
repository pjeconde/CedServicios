using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes
{
    public class SinInformar : TipoComprobante
    {
        public SinInformar()
        {
            Codigo = 0;
            Descr = String.Empty;
        }
    }
}

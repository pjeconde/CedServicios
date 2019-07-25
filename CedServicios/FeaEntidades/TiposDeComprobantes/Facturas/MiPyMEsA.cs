using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Facturas
{
    [Serializable]
    public class MiPyMEsA : Factura
    {
        public MiPyMEsA()
        {
            codigo = 201;
            descr = "Factura de Crédito MiPyMEs A";
        }
    }
}

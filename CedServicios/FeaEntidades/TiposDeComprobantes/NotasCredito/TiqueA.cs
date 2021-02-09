using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasCredito
{
    [Serializable]
    public class TiqueA : NotaCredito
    {
        public TiqueA()
        {
            codigo = 112;
            descr = "Tique Notas de Crédito A";
        }
    }
}

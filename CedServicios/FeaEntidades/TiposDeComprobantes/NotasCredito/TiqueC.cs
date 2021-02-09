using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasCredito
{
    [Serializable]
    public class TiqueC : NotaCredito
    {
        public TiqueC()
        {
            codigo = 114;
            descr = "Tique Notas de Crédito C";
        }
    }
}

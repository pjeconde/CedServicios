using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasDebito
{
    [Serializable]
    public class TiqueA : NotaDebito
    {
        public TiqueA()
        {
            codigo = 115;
            descr = "Tique Notas de Débito A";
        }
    }
}

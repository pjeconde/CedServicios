using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasDebito
{
    [Serializable]
    public class TiqueC : NotaDebito
    {
        public TiqueC()
        {
            codigo = 117;
            descr = "Tique Notas de Débito A";
        }
    }
}

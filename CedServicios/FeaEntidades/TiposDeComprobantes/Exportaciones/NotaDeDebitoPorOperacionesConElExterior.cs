using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Exportaciones
{
    [Serializable]
    public class NotaDeDebitoPorOperacionesConElExterior : Exportacion
    {
        public NotaDeDebitoPorOperacionesConElExterior()
        {
            Codigo = 20;
            Descr = "Nota de D�bito por Operaciones con el Exterior";
        }
    }
}


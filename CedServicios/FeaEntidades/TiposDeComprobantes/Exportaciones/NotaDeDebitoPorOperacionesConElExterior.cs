using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Exportaciones
{
    public class NotaDeDebitoPorOperacionesConElExterior : Exportacion
    {
        public NotaDeDebitoPorOperacionesConElExterior()
        {
            Codigo = 20;
            Descr = "Nota de Débito por Operaciones con el Exterior";
        }
    }
}


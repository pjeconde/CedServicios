using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Exportaciones
{
    public class NotaDeCreditoPorOperacionesConElExterior : Exportacion
    {
        public NotaDeCreditoPorOperacionesConElExterior()
        {
            Codigo = 21;
            Descr = "Nota de Crédito por Operaciones con el Exterior";
        }
    }
}


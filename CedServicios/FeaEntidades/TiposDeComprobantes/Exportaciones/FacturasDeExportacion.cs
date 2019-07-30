using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Exportaciones
{
    [Serializable]
    public class FacturasDeExportacion : Exportacion
    {
        public FacturasDeExportacion()
        {
            Codigo = 19;
            Descr = "Facturas de Exportaci�n";
        }
    }
}


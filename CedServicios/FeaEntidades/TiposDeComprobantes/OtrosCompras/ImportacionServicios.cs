using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.OtrosCompras
{
    [Serializable]
    public class ImportacionServicios : OtrosCompra
	{
        public ImportacionServicios()
		{
			codigo = 67;
            descr = "Importacion de Servicios";
		}
	}
}

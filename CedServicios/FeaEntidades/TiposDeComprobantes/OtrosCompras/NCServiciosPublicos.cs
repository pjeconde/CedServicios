using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.OtrosCompras
{
    [Serializable]
    public class NCServiciosPublicos : OtrosCompra
	{
        public NCServiciosPublicos()
		{
			codigo = 85;
            descr = "Nota de Cr�dito Servicios P�blicos";
		}
	}
}

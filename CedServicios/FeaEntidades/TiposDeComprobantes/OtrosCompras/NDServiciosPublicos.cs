using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.OtrosCompras
{
    [Serializable]
    public class NDServiciosPublicos : OtrosCompra
	{
        public NDServiciosPublicos()
		{
			codigo = 86;
            descr = "Nota de Débito Servicios Públicos";
		}
	}
}

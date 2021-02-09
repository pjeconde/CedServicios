using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.OtrosCompras
{
    [Serializable]

    public class BienesUsados : OtrosCompra
	{
        public BienesUsados()
		{
			codigo = 30;
            descr = "Comprob. Compra Bienes Usados";
		}
	}
}

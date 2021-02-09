using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.OtrosCompras
{
    [Serializable]
    public class RecibosFactCredito : OtrosCompra
	{
        public RecibosFactCredito()
		{
			codigo = 70;
            descr = "Recibos Factura de Crédito";
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.OtrosCompras
{
    [Serializable]
    public class TiqueFactB : OtrosCompra
	{
        public TiqueFactB()
		{
			codigo = 82;
            descr = "Tique Factura B";
		}
	}
}

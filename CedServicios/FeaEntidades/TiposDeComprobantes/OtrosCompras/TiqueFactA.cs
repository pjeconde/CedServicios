using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.OtrosCompras
{
    [Serializable]
    public class TiqueFactA : OtrosCompra
	{
        public TiqueFactA()
		{
			codigo = 81;
            descr = "Tique Factura A - Controladores Fiscal";
		}
	}
}

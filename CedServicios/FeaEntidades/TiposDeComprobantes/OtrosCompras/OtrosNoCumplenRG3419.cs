using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.OtrosCompras
{
    [Serializable]
    public class OtrosNoCumplenRG3419 : OtrosCompra
	{
        public OtrosNoCumplenRG3419()
		{
			codigo = 99;
            descr = "Otros Comprobantes que no cumplen con R.G. N° 3419";
		}
	}
}

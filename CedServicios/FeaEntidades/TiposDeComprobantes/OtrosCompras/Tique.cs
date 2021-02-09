using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.OtrosCompras
{
    [Serializable]
    public class Tique : OtrosCompra
	{
        public Tique()
		{
			codigo = 83;
            descr = "Tique";
		}
	}
}

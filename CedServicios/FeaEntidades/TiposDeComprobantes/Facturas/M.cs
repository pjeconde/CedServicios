using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Facturas
{
    [Serializable]
    public class M : Factura
	{
		public M()
		{
			codigo = 51;
			descr = "Facturas M";
		}
	}
}

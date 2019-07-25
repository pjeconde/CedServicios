using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Facturas
{
    [Serializable]
    public class C : Factura
	{
		public C()
		{
			codigo = 11;
			descr = "Facturas C";
		}
	}
}

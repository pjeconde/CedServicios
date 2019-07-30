using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Facturas
{
    [Serializable]
    public class T : Factura
	{
		public T()
		{
			codigo = 195;
			descr = "Facturas T";
		}
	}
}

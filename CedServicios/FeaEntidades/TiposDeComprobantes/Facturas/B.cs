using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Facturas
{
    [Serializable]
    public class B : Factura
	{
		public B()
		{
			codigo = 6;
			descr = "Facturas B";
		}
	}
}

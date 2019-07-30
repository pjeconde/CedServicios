using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Facturas
{
    [Serializable]
    public class A : Factura
	{
		public A()
		{
			codigo = 1;
			descr = "Facturas A";
		}
	}
}

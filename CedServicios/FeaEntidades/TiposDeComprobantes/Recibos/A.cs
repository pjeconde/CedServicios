using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Recibos
{
    [Serializable]
    public class A : Recibo
	{
		public A()
		{
			codigo = 4;
			descr = "Recibos A";
		}
	}
}

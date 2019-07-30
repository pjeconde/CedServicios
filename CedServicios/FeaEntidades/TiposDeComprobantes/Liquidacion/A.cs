using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Liquidacion
{
    [Serializable]
    public class A : Liquidacion
	{
        public A()
		{
			codigo = 63;
			descr = "Liquidación A";
		}
	}
}

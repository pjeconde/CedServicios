using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Liquidacion
{
    [Serializable]
    public class B : Liquidacion
	{
        public B()
		{
			codigo = 64;
			descr = "Liquidación B";
		}
	}
}

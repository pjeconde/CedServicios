using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Recibos
{
    [Serializable]
    public class B : Recibo
	{
		public B()
		{
			codigo = 9;
			descr = "Recibos B";
		}
	}
}

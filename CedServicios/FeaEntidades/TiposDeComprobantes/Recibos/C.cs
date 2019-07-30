using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Recibos
{
    [Serializable]
    public class C : Recibo
	{
		public C()
		{
			codigo = 15;
			descr = "Recibos C";
		}
	}
}

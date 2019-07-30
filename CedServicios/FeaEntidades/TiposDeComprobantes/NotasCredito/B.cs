using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasCredito
{
    [Serializable]
    public class B : NotaCredito
	{
		public B()
		{
			codigo = 8;
			descr = "Notas de Crédito B";
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasCredito
{
    [Serializable]
    public class M : NotaCredito
	{
		public M()
		{
			codigo = 53;
			descr = "Notas de Crédito M";
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasCredito
{
    [Serializable]
    public class T : NotaCredito
	{
		public T()
		{
			codigo = 197;
			descr = "Notas de Crédito T";
		}
	}
}

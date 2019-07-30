using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasCredito
{
    [Serializable]
    public class MiPyMEsA : NotaCredito
	{
		public MiPyMEsA()
		{
			codigo = 203;
			descr = "Nota de Crédito MiPyMEs A";
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasCredito
{
    [Serializable]
    public class C : NotaCredito
	{
		public C()
		{
			codigo = 13;
			descr = "Notas de Crédito C";
		}
	}
}

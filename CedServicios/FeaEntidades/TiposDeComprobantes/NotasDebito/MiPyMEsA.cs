using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasDebito
{
    [Serializable]
    public class MiPyMEsA : NotaDebito
	{
		public MiPyMEsA()
		{
			codigo = 202;
			descr = "Nota de Débito MiPyMEs A";
		}
	}
}

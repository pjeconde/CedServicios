using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasDebito
{
    [Serializable]
    public class T : NotaDebito
	{
		public T()
		{
			codigo = 196;
			descr = "Notas de Débito T";
		}
	}
}

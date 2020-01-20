using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasDebito
{
    [Serializable]
    public class M : NotaDebito
	{
		public M()
		{
			codigo = 52;
			descr = "Notas de Débito M";
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasDebito
{
    [Serializable]
    public class B : NotaDebito
	{
		public B()
		{
			codigo = 7;
			descr = "Notas de Débito B";
		}
	}
}

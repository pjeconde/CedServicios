using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasDebito
{
    [Serializable]
    public class C : NotaDebito
	{
		public C()
		{
			codigo = 12;
			descr = "Notas de Débito C";
		}
	}
}

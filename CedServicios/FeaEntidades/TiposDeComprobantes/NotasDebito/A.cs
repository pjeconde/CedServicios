using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasDebito
{
    [Serializable]
    public class A : NotaDebito
	{
		public A()
		{
			codigo = 2;
			descr = "Notas de Débito A";
		}
	}
}

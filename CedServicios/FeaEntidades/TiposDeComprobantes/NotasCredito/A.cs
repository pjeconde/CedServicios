using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasCredito
{
    [Serializable]
    public class A : NotaCredito
	{
		public A()
		{
			codigo = 3;
			descr = "Notas de Cr�dito A";
		}
	}
}

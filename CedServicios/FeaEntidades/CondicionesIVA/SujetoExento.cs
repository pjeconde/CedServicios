using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CondicionesIVA
{
	public class SujetoExento : CondicionIVA
	{
		public SujetoExento()
		{
			Codigo = 4;
			Descr = "IVA Sujeto Exento";
		}
	}
}

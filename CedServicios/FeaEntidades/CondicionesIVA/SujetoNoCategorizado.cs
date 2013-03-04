using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CondicionesIVA
{
	public class SujetoNoCategorizado : CondicionIVA
	{
		public SujetoNoCategorizado()
		{
			Codigo = 7;
			Descr = "Sujeto no categorizado";
		}
	}
}

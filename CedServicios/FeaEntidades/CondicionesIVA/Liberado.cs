using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CondicionesIVA
{
	public class Liberado : CondicionIVA
	{
		public Liberado()
		{
			Codigo = 10;
			Descr = "IVA Liberado - Ley N° 19640";
		}
	}
}

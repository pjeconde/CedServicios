using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CondicionesIVA
{
	public class NoResponsable : CondicionIVA
	{
		public NoResponsable()
		{
			Codigo = 3;
			Descr = "IVA no responsable";
		}
	}
}

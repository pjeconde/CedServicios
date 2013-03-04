using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CondicionesIVA
{
	public class ResponsableNoInscripto : CondicionIVA
	{
		public ResponsableNoInscripto()
		{
			Codigo = 2;
			Descr = "IVA Responsable no inscripto";
		}
	}
}

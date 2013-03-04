using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CondicionesIVA
{
	public class ClienteDelExterior : CondicionIVA
	{
		public ClienteDelExterior()
		{
			Codigo = 9;
			Descr = "Cliente del Exterior";
		}
	}
}

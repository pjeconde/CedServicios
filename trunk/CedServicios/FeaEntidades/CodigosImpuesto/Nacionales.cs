using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosImpuesto
{
	public class Nacionales : CodigoImpuesto
	{
		public Nacionales()
		{
			Codigo = 4;
			Descr = "Percepciones o pagos a cuenta de impuestos nacionales";
		}
	}
}

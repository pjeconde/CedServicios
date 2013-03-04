using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Documentos.CI
{
	public class Extranjera : CedulaIdentidad
	{
		public Extranjera()
		{
			Codigo = 91;
			Descr = "CI extranjera";
		}
	}
}

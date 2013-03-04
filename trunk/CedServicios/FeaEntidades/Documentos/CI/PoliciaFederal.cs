using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Documentos.CI
{
	public class PoliciaFederal : CedulaIdentidad
	{
		public PoliciaFederal()
		{
			Codigo = 00;
			Descr = "CI Policía Federal";
		}
	}
}

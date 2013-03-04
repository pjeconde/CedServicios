using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.IVA
{
	public class Cero : IVA
	{
		public Cero()
		{
			Codigo = 0;
			Descr = "0%";
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Otros
{
    [Serializable]
    public class A : Otro
	{
		public A()
		{
			codigo = 39;
            descr = "Otros comprobantes A que cumplan con la R.G. N° 1415";
		}
	}
}

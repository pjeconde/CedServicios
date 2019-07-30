using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Otros
{
    [Serializable]
    public class B : Otro
	{
		public B()
		{
			codigo = 40;
            descr = "Otros comprobantes B que cumplan con la R.G. N° 1415";
		}
	}
}

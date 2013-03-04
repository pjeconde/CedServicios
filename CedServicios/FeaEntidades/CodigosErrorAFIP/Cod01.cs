using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosErrorAFIP
{
    public class Cod01 : CodigoErrorAFIP
	{
        public Cod01()
		{
			Codigo = "01";
			Descr = "LA CUIT INFORMADA NO CORRESPONDE A UN RESPONSABLE INSCRIPTO EN EL IVA ACTIVO";
		}
	}
}

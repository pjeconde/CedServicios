using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosErrorAFIP
{
    public class Cod11 : CodigoErrorAFIP
	{
		public Cod11()
		{
			Codigo = "11";
			Descr = "EL NRO DE COMPROBANTE DESDE INFORMADO NO ES CORRELATIVO AL ULTIMO NRO DE COMPROBANTE REGISTRADO/HASTA SOLICITADO PARA ESE TIPO DE COMPROBANTE Y PUNTO DE VENTA";
		}
	}
}

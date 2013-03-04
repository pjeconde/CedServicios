using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosErrorAFIP
{
	public class Cod02 : CodigoErrorAFIP
	{
        public Cod02()
		{
			Codigo = "02";
			Descr = "LA CUIT INFORMADA NO SE ENCUENTRA AUTORIZADA A EMITIR COMPROBANTES ELECTRONICOS ORIGINALES O EL PERIODO DE INICIO AUTORIZADO ES POSTERIOR AL DE LA GENERACION DE LA SOLICITUD";
		}
	}
}

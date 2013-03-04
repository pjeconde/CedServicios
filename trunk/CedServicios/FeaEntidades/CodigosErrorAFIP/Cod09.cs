using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosErrorAFIP
{
    public class Cod09 : CodigoErrorAFIP
	{
        public Cod09()
		{
			Codigo = "09";
			Descr = "LA CUIT INDICADA EN EL CAMPO NRO DE IDENTIFICACION DEL COMPRADOR NO EXISTE EN EL PADRON UNICO DE CONTRIBUYENTES";
		}
	}
}

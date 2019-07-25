using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.CuentaDeVentaYLiquido
{
    [Serializable]
    public class B : CuentaDeVentaYLiquido
	{
		public B()
		{
			codigo = 61;
			descr = "Cuenta de Venta y Líquido producto B";
		}
	}
}

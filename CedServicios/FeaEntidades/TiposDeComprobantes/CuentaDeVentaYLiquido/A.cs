using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.CuentaDeVentaYLiquido
{
    [Serializable]
    public class A : CuentaDeVentaYLiquido
	{
		public A()
		{
			codigo = 60;
			descr = "Cuenta de Venta y L�quido producto A";
		}
	}
}

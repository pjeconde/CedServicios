using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.OtrosCompras
{
    [Serializable]
    public class OtrosExceptuadosNDyResumen : OtrosCompra
	{
        public OtrosExceptuadosNDyResumen()
		{
			codigo = 89;
            descr = "Otros Comprobantes exceptuados ND y Resumen";
		}
	}
}

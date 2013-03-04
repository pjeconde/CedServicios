using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosReferencia
{
    public class CodigoReferencia
	{
		private string codigo;
		private string descr;

		public string Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		public string Descr
		{
			get { return descr; }
			set { descr = value; }
		}

		public static List<CodigoReferencia> Lista()
		{
            List<CodigoReferencia> lista = new List<CodigoReferencia>();
			lista.Add(new SinInformar());
			lista.Add(new OrdenDeCompra());
			lista.Add(new Remito());
			lista.Add(new FacturaDeReferencia());
			lista.Add(new NotaDeCredito());
			return lista;
		}

	}
}

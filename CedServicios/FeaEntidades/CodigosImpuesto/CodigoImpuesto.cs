using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosImpuesto
{
	public class CodigoImpuesto
	{
		private int codigo;
		private string descr;

		public int Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		public string Descr
		{
			get { return descr; }
			set { descr = value; }
		}

		public static List<CodigoImpuesto> Lista()
		{
			List<CodigoImpuesto> lista = new List<CodigoImpuesto>();
			lista.Add(new IB());
			lista.Add(new Internos());
			lista.Add(new IVA());
			lista.Add(new Municipales());
			lista.Add(new Nacionales());
			lista.Add(new Otros());
			return lista;
		}
	}
}

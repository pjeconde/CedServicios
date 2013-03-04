using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.IVA
{
	public class IVA
	{
		private double codigo;
		private string descr;

		public double Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		public string Descr
		{
			get { return descr; }
			set { descr = value; }
		}

		public static List<IVA> Lista()
		{
			List<IVA> lista = new List<IVA>();
			lista.Add(new SinInformar());
			lista.Add(new Cero());
			lista.Add(new DiezYMedio());
			lista.Add(new Veintiuno());
			lista.Add(new Veintisiete());
			return lista;
		}

		public static List<IVA> ListaMinima()
		{
			List<IVA> lista = new List<IVA>();
			lista.Add(new Cero());
			lista.Add(new DiezYMedio());
			lista.Add(new Veintiuno());
			lista.Add(new Veintisiete());
			return lista;
		}
	}
}

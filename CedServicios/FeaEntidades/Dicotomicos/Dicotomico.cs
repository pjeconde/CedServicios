using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Dicotomicos
{
	public class Dicotomico
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

		public static List<Dicotomico> Lista()
		{
			List<Dicotomico> lista = new List<Dicotomico>();
			lista.Add(new SinInformar());
			lista.Add(new Si());
			lista.Add(new No());
			return lista;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Indicacion
{
	public class Indicacion
	{
		private string codigo;
		private string descr;

		public string Codigo
		{
			get
			{
				return codigo;
			}
			set
			{
				codigo = value;
			}
		}

		public string Descr
		{
			get
			{
				return descr;
			}
			set
			{
				descr = value;
			}
		}

		public static List<Indicacion> Lista()
		{
			List<Indicacion> lista = new List<Indicacion>();
			lista.Add(new SinInformar());
			lista.Add(new Exento());
			lista.Add(new Gravado());
			lista.Add(new NoGravado());
			return lista;
		}

	}
}

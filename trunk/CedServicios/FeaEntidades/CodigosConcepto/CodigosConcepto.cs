using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosConcepto
{
	public class CodigosConcepto
	{
		protected int codigo;
		protected string descr;

		public int Codigo
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

		public static List<CodigosConcepto> Lista()
		{
			List<CodigosConcepto> lista = new List<CodigosConcepto>();
			lista.Add(new Productos());
			lista.Add(new Servicios());
			lista.Add(new ProductosYServicios());
			return lista;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosReferencia.Exportaciones
{
	public abstract class Exportacion
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

		public static List<Exportacion> Lista()
		{
			List<Exportacion> lista = new List<Exportacion>();
			lista.Add(new SinInformar());
			lista.Add(new FacturasDeExportacion());
			lista.Add(new NotaDeCreditoPorOperacionesConElExterior());
			lista.Add(new NotaDeDebitoPorOperacionesConElExterior());
			return lista;
		}
	}
}

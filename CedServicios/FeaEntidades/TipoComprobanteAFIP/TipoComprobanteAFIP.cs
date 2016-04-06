using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TipoComprobanteAFIP
{
    public class TipoComprobanteAFIP
	{
		protected string codigo;
		protected string descr;

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

        public static List<TipoComprobanteAFIP> Lista()
		{
            List<TipoComprobanteAFIP> lista = new List<TipoComprobanteAFIP>();
            lista.Add(new SinInformar());
            lista.Add(new SI());
			lista.Add(new NO());
			return lista;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosRelacionReceptorEmisor
{
    public class CodigoRelacionReceptorEmisor
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

        public static List<CodigoRelacionReceptorEmisor> Lista()
		{
            List<CodigoRelacionReceptorEmisor> lista = new List<CodigoRelacionReceptorEmisor>();
			lista.Add(new AlojTuristaNoResidente());
            lista.Add(new AlojAgenciaViajeResidente());
            lista.Add(new AlojAgenciaViajeNoResidente());
			return lista;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosTurismo
{
    public class CodigoTurismo
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

        public static List<CodigoTurismo> Lista()
		{
            List<CodigoTurismo> lista = new List<CodigoTurismo>();
			lista.Add(new AlojaminetoSinDesayuno());
            lista.Add(new AlojamientoConDesayuno());
			lista.Add(new Excedentes());
			return lista;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosErrorAFIP
{
	public class CodigoErrorAFIP
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

        public static List<CodigoErrorAFIP> Lista()
        {
            List<CodigoErrorAFIP> lista = new List<CodigoErrorAFIP>();
            lista.Add(new Cod01());
            lista.Add(new Cod02());
            lista.Add(new Cod03());
            lista.Add(new Cod04());
            lista.Add(new Cod06());
            lista.Add(new Cod08());
            lista.Add(new Cod09());
            lista.Add(new Cod10());
            lista.Add(new Cod11());
            lista.Add(new Cod13());
            return lista;
        }

        public static List<CodigoErrorAFIP> ListaANivelLote()
		{
            List<CodigoErrorAFIP> lista = new List<CodigoErrorAFIP>();
			lista.Add(new Cod01());
            lista.Add(new Cod02());
            lista.Add(new Cod03());
            lista.Add(new Cod04());
            lista.Add(new Cod06());
			return lista;
		}

        public static List<CodigoErrorAFIP> ListaANivelComprobante()
        {
            List<CodigoErrorAFIP> lista = new List<CodigoErrorAFIP>();
            lista.Add(new Cod08());
            lista.Add(new Cod09());
            lista.Add(new Cod10());
            lista.Add(new Cod11());
            lista.Add(new Cod13());
            return lista;
        }

	}
}

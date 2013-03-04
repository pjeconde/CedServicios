using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CondicionesIB
{
	public class CondicionIB
	{
		private short codigo;
		private string descr;

		public short Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		public string Descr
		{
			get { return descr; }
			set { descr = value; }
		}

		public static List<CondicionIB> Lista()
		{
			List<CondicionIB> lista = new List<CondicionIB>();
			lista.Add(new SinInformar());
			lista.Add(new ContribuyenteLocal());
			lista.Add(new ContribuyenteMultilateral());
			lista.Add(new Exento());
			return lista;
		}

        public static List<CondicionIB> ListaInf()
        {
            List<CondicionIB> lista = new List<CondicionIB>();
            lista.Add(new ContribuyenteLocal());
            lista.Add(new ContribuyenteMultilateral());
            lista.Add(new Exento());
            return lista;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosOperacion
{
	public class CodigoOperacion
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

		public static List<CodigoOperacion> Lista()
		{
			List<CodigoOperacion> lista = new List<CodigoOperacion>();
			lista.Add(new SinInformar());
			lista.Add(new ExportacionesALaZonaFranca());
			lista.Add(new ExportacionesAlExterior());
			lista.Add(new NoGravado());
			lista.Add(new OperacionesExentas());
			return lista;
		}

        public static List<CodigoOperacion> ListaDetalle()
        {
            List<CodigoOperacion> lista = new List<CodigoOperacion>();
            lista.Add(new SinInformar());
            lista.Add(new Gravado());
            lista.Add(new NoGravado());
            lista.Add(new OperacionesExentas());
            return lista;
        }
	}
}

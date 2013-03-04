using System;
using System.Collections.Generic;
using System.Text;
namespace FeaEntidades.TiposExportacion
{
    public class TipoExportacion
    {
        private int codigo;
        private string descr;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descr
        {
            get { return descr; }
            set { descr = value; }
        }

        public static List<TipoExportacion> Lista()
        {
            List<TipoExportacion> lista = new List<TipoExportacion>();
            lista.Add(new ExportacionDefinitivaDeBienes());
            lista.Add(new Servicios());
            lista.Add(new Otros());
            return lista;
        }

		public static List<TipoExportacion> ListaSinInformar()
		{
			List<TipoExportacion> lista = new List<TipoExportacion>();
			lista.Add(new SinInformar());
			lista.Add(new ExportacionDefinitivaDeBienes());
			lista.Add(new Servicios());
			lista.Add(new Otros());
			return lista;
		}
	}
}

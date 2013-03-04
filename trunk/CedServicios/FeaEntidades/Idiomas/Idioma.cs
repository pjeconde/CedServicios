using System;
using System.Collections.Generic;
using System.Text;
namespace FeaEntidades.Idiomas
{
    public class Idioma
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

        public static List<Idioma> Lista()
        {
            List<Idioma> lista = new List<Idioma>();
            lista.Add(new Espanol());
            lista.Add(new Ingles());
            lista.Add(new Portugues());
            return lista;
        }
		public static List<Idioma> ListaSinInformar()
		{
			List<Idioma> lista = new List<Idioma>();
			lista.Add(new SinInformar());
			lista.Add(new Espanol());
			lista.Add(new Ingles());
			lista.Add(new Portugues());
			return lista;
		}
    }
}

using System;
using System.Collections.Generic;
using System.Text;
namespace FeaEntidades.Incoterms
{
    public class Incoterm : IComparable
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

        public static List<Incoterm> Lista()
        {
            List<Incoterm> lista = new List<Incoterm>();
            lista.Add(new EXW());
            lista.Add(new FCA());
            lista.Add(new FAS());
            lista.Add(new FOB());
            lista.Add(new CFR());
            lista.Add(new CIF());
            lista.Add(new CPT());
            lista.Add(new CIP());
            lista.Add(new DAF());
            lista.Add(new DES());
            lista.Add(new DEQ());
            lista.Add(new DDU());
            lista.Add(new DDP());
            return lista;
        }

		public static List<Incoterm> ListaSinInformar()
		{
			List<Incoterm> lista = new List<Incoterm>();
			lista.Add(new SinInformar());
			lista.AddRange(Lista());
			lista.Sort();
			return lista;
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			if (obj is Incoterm)
			{
				Incoterm dp2 = (Incoterm)obj;
				return descr.CompareTo(dp2.descr);
			}
			else
				throw new ArgumentException("Object no es un Incoterm.");
		}

		#endregion
	}
}

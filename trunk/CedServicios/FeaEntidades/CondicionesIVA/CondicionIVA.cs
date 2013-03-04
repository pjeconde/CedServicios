using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CondicionesIVA
{
	public class CondicionIVA
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

		public static List<CondicionIVA> Lista()
		{
			List<CondicionIVA> lista = new List<CondicionIVA>();
			lista.Add(new SinInformar());
			lista.Add(new ResponsableInscripto());
			lista.Add(new ResponsableNoInscripto());
			lista.Add(new NoResponsable());
			lista.Add(new SujetoExento());
			lista.Add(new ConsumidorFinal());
			lista.Add(new ResponsableMonotributo());
			lista.Add(new SujetoNoCategorizado());
			lista.Add(new ImportadorDelExterior());
			lista.Add(new ClienteDelExterior());
			lista.Add(new Liberado());
			lista.Add(new ResponsableInscriptoAgentePercepcion());
			return lista;
		}

        public static List<CondicionIVA> ListaInf()
        {
            List<CondicionIVA> lista = new List<CondicionIVA>();
            lista.Add(new ResponsableInscripto());
            lista.Add(new ResponsableNoInscripto());
            lista.Add(new NoResponsable());
            lista.Add(new SujetoExento());
            lista.Add(new ConsumidorFinal());
            lista.Add(new ResponsableMonotributo());
            lista.Add(new SujetoNoCategorizado());
            lista.Add(new ImportadorDelExterior());
            lista.Add(new ClienteDelExterior());
            lista.Add(new Liberado());
            lista.Add(new ResponsableInscriptoAgentePercepcion());
            return lista;
        }
    }
}

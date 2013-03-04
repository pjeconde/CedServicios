using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosProvincia
{
	public class CodigoProvincia
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

		public static List<CodigoProvincia> Lista()
		{
			List<CodigoProvincia> lista = new List<CodigoProvincia>();
			lista.Add(new SinInformar());
			lista.Add(new CapitalFederal());
			lista.Add(new BuenosAires());
			lista.Add(new Catamarca());
			lista.Add(new Cordoba());
			lista.Add(new Corrientes());
			lista.Add(new Chaco());
			lista.Add(new Chubut());
			lista.Add(new EntreRios());
			lista.Add(new Formosa());
			lista.Add(new Jujuy());
			lista.Add(new LaPampa());
			lista.Add(new LaRioja());
			lista.Add(new Mendoza());
			lista.Add(new Misiones());
			lista.Add(new Neuquen());
			lista.Add(new RioNegro());
			lista.Add(new Salta());
			lista.Add(new SanJuan());
			lista.Add(new SanLuis());
			lista.Add(new SantaCruz());
			lista.Add(new SantaFe());
			lista.Add(new SantiagoDelEstero());
			lista.Add(new TierraDelFuego());
			lista.Add(new Tucuman());
			return lista;
		}
        public static List<CodigoProvincia> ListaInf()
        {
            List<CodigoProvincia> lista = new List<CodigoProvincia>();
            lista.Add(new CapitalFederal());
            lista.Add(new BuenosAires());
            lista.Add(new Catamarca());
            lista.Add(new Cordoba());
            lista.Add(new Corrientes());
            lista.Add(new Chaco());
            lista.Add(new Chubut());
            lista.Add(new EntreRios());
            lista.Add(new Formosa());
            lista.Add(new Jujuy());
            lista.Add(new LaPampa());
            lista.Add(new LaRioja());
            lista.Add(new Mendoza());
            lista.Add(new Misiones());
            lista.Add(new Neuquen());
            lista.Add(new RioNegro());
            lista.Add(new Salta());
            lista.Add(new SanJuan());
            lista.Add(new SanLuis());
            lista.Add(new SantaCruz());
            lista.Add(new SantaFe());
            lista.Add(new SantiagoDelEstero());
            lista.Add(new TierraDelFuego());
            lista.Add(new Tucuman());
            return lista;
        }
    }
}

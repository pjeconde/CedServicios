using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosMoneda
{
	public class CodigoMoneda
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

		public static string Local
		{
			get { return "PES"; }
		}

		public static List<CodigoMoneda> ListaNoExportacion()
		{
			List<CodigoMoneda> lista = new List<CodigoMoneda>();
			lista.Add(new PesosArgentinos());
			lista.Add(new DolarEstadounidense());
			return lista;
		}

        public static List<CodigoMoneda> Lista()
        {
            List<CodigoMoneda> lista = new List<CodigoMoneda>();
            lista.Add(new PesosArgentinos());
            lista.Add(new DolarEstadounidense());
            lista.Add(new DolarLibreEeuu());
            lista.Add(new FlorinesHolandeses());
            lista.Add(new PesosMejicanos());
            lista.Add(new PesosUruguayos());
            lista.Add(new CoronasDanesas());
            lista.Add(new CoronasNoruegas());
            lista.Add(new CoronasSuecas());
            lista.Add(new DolarCanadiense());
            lista.Add(new Yens());
            lista.Add(new LibraEsterlina());
            lista.Add(new BolivarVenezolano());
            lista.Add(new CoronaCheca());
            lista.Add(new DinarYugoslavo());
            lista.Add(new DolarAustraliano());
            lista.Add(new DracmaGriego());
            lista.Add(new FlorinAntillasHolandesas());
            lista.Add(new Güarani());
            lista.Add(new PesoBoliviano());
            lista.Add(new PesoColombiano());
            lista.Add(new PesoChileno());
            lista.Add(new RandSudafricano());
            lista.Add(new SucreEcuatoriano());
            lista.Add(new DolarDeHongKong());
            lista.Add(new DolarDeSingapur());
            lista.Add(new DolarDeJamaica());
            lista.Add(new DolarDeTaiwan());
            lista.Add(new QuetzalGuatemalteco());
            lista.Add(new ForintHungria());
            lista.Add(new BahtTailandia());
            lista.Add(new DinarKuwaiti());
            lista.Add(new Real());
            lista.Add(new ShekelIsrael());
            lista.Add(new NuevoSolPeruano());
            lista.Add(new Euro());
            lista.Add(new LeiRumano());
            lista.Add(new PesoDominicano());
            lista.Add(new BalboasPanameñas());
            lista.Add(new CordobaNicaragüense());
            lista.Add(new DirhamMarroqui());
            lista.Add(new LibraEgipcia());
            lista.Add(new RiyalSaudita());
            lista.Add(new ZlotyPolaco());
            lista.Add(new RupiaHindu());
            lista.Add(new LempiraHondureña());
            lista.Add(new YuanRepPopChina());
            lista.Add(new FrancoSuizo());
            lista.Add(new DerechosEspecialesDeGiro());
            lista.Add(new GramosDeOroFino());
            return lista;
		}
	}
}

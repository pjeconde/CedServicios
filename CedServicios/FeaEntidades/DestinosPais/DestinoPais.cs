using System;
using System.Collections.Generic;
using System.Text;
namespace FeaEntidades.DestinosPais
{
    public class DestinoPais : IComparable
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

		public static List<DestinoPais> ListaSinInformar()
		{
			List<DestinoPais> lista = new List<DestinoPais>();
			lista.Add(new SinInformar());
			lista.AddRange(Lista());
			lista.Sort();
			return lista;
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			if (obj is DestinoPais)
			{
				DestinoPais dp2 = (DestinoPais)obj;
				return descr.CompareTo(dp2.descr);
			}
			else
				throw new ArgumentException("Object no es un DestinoPais.");
		}

		#endregion

        public static List<DestinoPais> Lista()
        {
            List<DestinoPais> lista = new List<DestinoPais>();
            lista.Add(new BurkinaFaso());
            lista.Add(new Argelia());
            lista.Add(new Botswana());
            lista.Add(new Burundi());
            lista.Add(new Camerun());
            lista.Add(new RepCentroafricana());
            lista.Add(new Congo());
            lista.Add(new RepDemocratDelCongoExZaire());
            lista.Add(new CostaDeMarfil());
            lista.Add(new Chad());
            lista.Add(new Benin());
            lista.Add(new Egipto());
            lista.Add(new Gabon());
            lista.Add(new Gambia());
            lista.Add(new Ghana());
            lista.Add(new Guinea());
            lista.Add(new GuineaEcuatorial());
            lista.Add(new Kenya());
            lista.Add(new Lesotho());
            lista.Add(new Liberia());
            lista.Add(new Libia());
            lista.Add(new Madagascar());
            lista.Add(new Malawi());
            lista.Add(new Mali());
            lista.Add(new Marruecos());
            lista.Add(new MauricioIslas());
            lista.Add(new Mauritania());
            lista.Add(new Niger());
            lista.Add(new Nigeria());
            lista.Add(new Zimbabwe());
            lista.Add(new Rwanda());
            lista.Add(new Senegal());
            lista.Add(new SierraLeona());
            lista.Add(new Somalia());
            lista.Add(new Swazilandia());
            lista.Add(new Sudan());
            lista.Add(new Tanzania());
            lista.Add(new Togo());
            lista.Add(new Tunez());
            lista.Add(new Uganda());
            lista.Add(new Zambia());
            lista.Add(new TerritVinculadosAlRUnido());
            lista.Add(new TerritVinculadosAEspaña());
            lista.Add(new TerritVinculadosAFrancia());
            lista.Add(new Angola());
            lista.Add(new CaboVerde());
            lista.Add(new Mozambique());
            lista.Add(new Seychelles());
            lista.Add(new Djibouti());
            lista.Add(new Comoras());
            lista.Add(new GuineaBissau());
            lista.Add(new StoTomeYPrincipe());
            lista.Add(new Namibia());
            lista.Add(new Sudafrica());
            lista.Add(new Eritrea());
            lista.Add(new Etiopia());
            lista.Add(new RestoAfrica());
            lista.Add(new IndeterminadoAfrica());
            lista.Add(new Argentina());
            lista.Add(new Barbados());
            lista.Add(new Bolivia());
            lista.Add(new Brasil());
            lista.Add(new Canada());
            lista.Add(new Colombia());
            lista.Add(new CostaRica());
            lista.Add(new Cuba());
            lista.Add(new Chile());
            lista.Add(new RepublicaDominicana());
            lista.Add(new Ecuador());
            lista.Add(new ElSalvador());
            lista.Add(new EstadosUnidos());
            lista.Add(new Guatemala());
            lista.Add(new Guyana());
            lista.Add(new Haiti());
            lista.Add(new Honduras());
            lista.Add(new Jamaica());
            lista.Add(new Mexico());
            lista.Add(new Nicaragua());
            lista.Add(new Panama());
            lista.Add(new Paraguay());
            lista.Add(new Peru());
            lista.Add(new PuertoRico());
            lista.Add(new TrinidadYTobago());
            lista.Add(new Uruguay());
            lista.Add(new Venezuela());
            lista.Add(new TerritVinculadoAlRUnido());
            lista.Add(new TerVinculadosADinamarca());
            lista.Add(new TerritVinculadosAFranciaAmeric());
            lista.Add(new TerritHolandeses());
            lista.Add(new TerVinculadosAEstadosUnidos());
            lista.Add(new Suriname());
            lista.Add(new Dominica());
            lista.Add(new SantaLucia());
            lista.Add(new SanVicenteYLasGranadinas());
            lista.Add(new Belice());
            lista.Add(new AntiguaYBarbuda());
            lista.Add(new SCristobalYNevis());
            lista.Add(new Bahamas());
            lista.Add(new Grenada());
            lista.Add(new AntillasHolandesas());
            lista.Add(new AaeTierraDelFuegoArgentina());
            lista.Add(new ZfLaPlataArgentina());
            lista.Add(new ZfJustoDaractArgentina());
            lista.Add(new ZfRioGallegosArgentina());
            lista.Add(new IslasMalvinasArgentina());
            lista.Add(new ZfTucumanArgentina());
            lista.Add(new ZfCordobaArgentina());
            lista.Add(new ZfMendozaArgentina());
            lista.Add(new ZfGeneralPicoArgentina());
            lista.Add(new ZfComodoroRivadaviaArgentina());
            lista.Add(new ZfIquique());
            lista.Add(new ZfPuntaArenas());
            lista.Add(new ZfSaltaArgentina());
            lista.Add(new ZfPasoDeLosLibresArgentina());
            lista.Add(new ZfPuertoIguazuArgentina());
            lista.Add(new SectorAntarticoArg());
            lista.Add(new ZfColonRepublicaDePanama());
            lista.Add(new ZfWinnerStaCDeLaSierraBolivia());
            lista.Add(new ZfColoniaUruguay());
            lista.Add(new ZfFloridaUruguay());
            lista.Add(new ZfLibertadUruguay());
            lista.Add(new ZfZonamericaUruguay());
            lista.Add(new ZfNuevaHelveciaUruguay());
            lista.Add(new ZfNuevaPalmiraUruguay());
            lista.Add(new ZfRioNegroUruguay());
            lista.Add(new ZfRiveraUruguay());
            lista.Add(new ZfSanJoseUruguay());
            lista.Add(new ZfManaosBrasil());
            lista.Add(new MarArgZonaEcoEx());
            lista.Add(new RiosArgNavegInter());
            lista.Add(new RestoAmerica());
            lista.Add(new IndeterminadoAmerica());
            lista.Add(new Afganistan());
            lista.Add(new ArabiaSaudita());
            lista.Add(new Bahrein());
            lista.Add(new MyanmarExBirmania());
            lista.Add(new Butan());
            lista.Add(new CambodyaExKampuche());
            lista.Add(new SriLanka());
            lista.Add(new CoreaDemocratica());
            lista.Add(new CoreaRepublicana());
            lista.Add(new China());
            lista.Add(new Filipinas());
            lista.Add(new Taiwan());
            lista.Add(new India());
            lista.Add(new Indonesia());
            lista.Add(new Irak());
            lista.Add(new Iran());
            lista.Add(new Israel());
            lista.Add(new Japon());
            lista.Add(new Jordania());
            lista.Add(new Qatar());
            lista.Add(new Kuwait());
            lista.Add(new Laos());
            lista.Add(new Libano());
            lista.Add(new Malasia());
            lista.Add(new MaldivasIslas());
            lista.Add(new Oman());
            lista.Add(new Mongolia());
            lista.Add(new Nepal());
            lista.Add(new EmiratosArabesUnidos());
            lista.Add(new Pakistan());
            lista.Add(new Singapur());
            lista.Add(new Siria());
            lista.Add(new Thailandia());
            lista.Add(new Vietnam());
            lista.Add(new HongKong());
            lista.Add(new Macao());
            lista.Add(new Bangladesh());
            lista.Add(new Brunei());
            lista.Add(new RepublicaDeYemen());
            lista.Add(new Armenia());
            lista.Add(new Azerbaijan());
            lista.Add(new Georgia());
            lista.Add(new Kazajstan());
            lista.Add(new Kirguizistan());
            lista.Add(new Tayikistan());
            lista.Add(new Turkmenistan());
            lista.Add(new Uzbekistan());
            lista.Add(new TerrAuPalestinos());
            lista.Add(new RestoDeAsia());
            lista.Add(new IndetAsia());
            lista.Add(new Albania());
            lista.Add(new Andorra());
            lista.Add(new Austria());
            lista.Add(new Belgica());
            lista.Add(new Bulgaria());
            lista.Add(new Dinamarca());
            lista.Add(new España());
            lista.Add(new Finlandia());
            lista.Add(new Francia());
            lista.Add(new Grecia());
            lista.Add(new Hungria());
            lista.Add(new Irlanda());
            lista.Add(new Islandia());
            lista.Add(new Italia());
            lista.Add(new Liechtenstein());
            lista.Add(new Luxemburgo());
            lista.Add(new Malta());
            lista.Add(new Monaco());
            lista.Add(new Noruega());
            lista.Add(new PaisesBajos());
            lista.Add(new Polonia());
            lista.Add(new Portugal());
            lista.Add(new ReinoUnido());
            lista.Add(new Rumania());
            lista.Add(new SanMarino());
            lista.Add(new Suecia());
            lista.Add(new Suiza());
            lista.Add(new VaticanoSantaSede());
            lista.Add(new PosBritEuropa());
            lista.Add(new Chipre());
            lista.Add(new Turquia());
            lista.Add(new AlemaniaRepFed());
            lista.Add(new Bielorrusia());
            lista.Add(new Estonia());
            lista.Add(new Letonia());
            lista.Add(new Lituania());
            lista.Add(new Moldavia());
            lista.Add(new Rusia());
            lista.Add(new Ucrania());
            lista.Add(new BosniaHerzegovina());
            lista.Add(new Croacia());
            lista.Add(new Eslovaquia());
            lista.Add(new Eslovenia());
            lista.Add(new Macedonia());
            lista.Add(new RepCheca());
            lista.Add(new Montenegro());
            lista.Add(new Serbia());
            lista.Add(new RestoEuropa());
            lista.Add(new IndetEuropa());
            lista.Add(new Australia());
            lista.Add(new Nauru());
            lista.Add(new NuevaZelandia());
            lista.Add(new Vanatu());
            lista.Add(new SamoaOccidental());
            lista.Add(new TerritorioVinculadosAAustralia());
            lista.Add(new TerritoriosVinculadosAlRUnido());
            lista.Add(new TerritoriosVinculadosAFrancia());
            lista.Add(new TerVinculadosANuevaZelanda());
            lista.Add(new TerVinculadosAEstadosUnidos());
            lista.Add(new FijiIslas());
            lista.Add(new PapuaNuevaGuinea());
            lista.Add(new KiribatiIslas());
            lista.Add(new MicronesiaEstFeder());
            lista.Add(new Palau());
            lista.Add(new Tuvalu());
            lista.Add(new SalomonIslas());
            lista.Add(new Tonga());
            lista.Add(new MarshallIslas());
            lista.Add(new MarianasIslas());
            lista.Add(new RestoOceania());
            lista.Add(new IndetOceania());
            lista.Add(new RestoContinente());
            lista.Add(new IndetContinente());
            return lista;
        }
    }
}

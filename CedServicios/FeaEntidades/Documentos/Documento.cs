using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Documentos
{
	public class Documento : IComparable
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

		#region IComparable Members

		public int CompareTo(object obj)
		{
			if (obj is Documento)
			{
				Documento dp2 = (Documento)obj;
				return descr.CompareTo(dp2.descr);
			}
			else
				throw new ArgumentException("Object no es un Documento.");
		}

		#endregion		
		
		public static List<Documento> Lista()
		{
			List<Documento> lista = new List<Documento>();
			lista.Add(new Documentos.CUIT());
			lista.Add(new Documentos.CI.BsAsRNP());
			lista.Add(new Documentos.CI.Extranjera());
			lista.Add(new Documentos.CI.PoliciaFederal());
			lista.Add(new Documentos.CI.BuenosAires());
			lista.Add(new Documentos.CI.Mendoza());
			lista.Add(new Documentos.CI.LaRioja());
			lista.Add(new Documentos.CI.Salta());
			lista.Add(new Documentos.CI.SanJuan());
			lista.Add(new Documentos.CI.SanLuis());
			lista.Add(new Documentos.CI.SantaFe());
			lista.Add(new Documentos.CI.SantiagoDelEstero());
			lista.Add(new Documentos.CI.Tucuman());
			lista.Add(new Documentos.CI.Chaco());
			lista.Add(new Documentos.CI.Chubut());
			lista.Add(new Documentos.CI.Formosa());
			lista.Add(new Documentos.CI.Misiones());
			lista.Add(new Documentos.CI.Neuquen());
			lista.Add(new Documentos.ActaNacimiento());
			lista.Add(new Documentos.CDI());
			lista.Add(new Documentos.CUIL());
			lista.Add(new Documentos.DNI());
			lista.Add(new Documentos.EnTramite());
			lista.Add(new Documentos.LC());
			lista.Add(new Documentos.LE());
			lista.Add(new Documentos.Pasaporte());
			lista.Add(new Documentos.CUITPais());
			lista.Sort();
			return lista;
		}
        public static List<Documento> ListaNoExportacion()
        {
            List<Documento> lista = new List<Documento>();
            lista.Add(new Documentos.CUIT());
            lista.Add(new Documentos.CI.BsAsRNP());
            lista.Add(new Documentos.CI.Extranjera());
            lista.Add(new Documentos.CI.PoliciaFederal());
            lista.Add(new Documentos.CI.BuenosAires());
            lista.Add(new Documentos.CI.Mendoza());
            lista.Add(new Documentos.CI.LaRioja());
            lista.Add(new Documentos.CI.Salta());
            lista.Add(new Documentos.CI.SanJuan());
            lista.Add(new Documentos.CI.SanLuis());
            lista.Add(new Documentos.CI.SantaFe());
            lista.Add(new Documentos.CI.SantiagoDelEstero());
            lista.Add(new Documentos.CI.Tucuman());
            lista.Add(new Documentos.CI.Chaco());
            lista.Add(new Documentos.CI.Chubut());
            lista.Add(new Documentos.CI.Formosa());
            lista.Add(new Documentos.CI.Misiones());
            lista.Add(new Documentos.CI.Neuquen());
            lista.Add(new Documentos.ActaNacimiento());
            lista.Add(new Documentos.CDI());
            lista.Add(new Documentos.CUIL());
            lista.Add(new Documentos.DNI());
            lista.Add(new Documentos.EnTramite());
            lista.Add(new Documentos.LC());
            lista.Add(new Documentos.LE());
            lista.Add(new Documentos.Pasaporte());
            lista.Sort();
            return lista;
        }
        public static List<Documento> ListaExportacion()
		{
			List<Documento> lista = new List<Documento>();
			lista.Add(new Documentos.CUITPais());
			return lista;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Excel
{
	[FileHelpers.DelimitedRecord("|")]
	public class Ubicador
	{
		string tipo;
		int x = 2;
		int y=1;

		public string Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}

		public int X
		{
			get { return x; }
			set { x = value; }
		}

		public int Y
		{
			get { return y; }
			set { y = value; }
		}

		
		public static List<Ubicador> Lista()
		{
			List<Ubicador> lista = new List<Ubicador>();
			//lista.Add(new cabecera_lote());
			//lista.Add(new comprobante());
			//lista.Add(new descuentos());
			//lista.Add(new detalle());
			//lista.Add(new importes_moneda_origen());
			//lista.Add(new impuestos());
			//lista.Add(new informacion_comprador());
			//lista.Add(new informacion_comprobante());
			//lista.Add(new informacion_comprobanteReferencias());
			//lista.Add(new informacion_vendedor());
			//lista.Add(new linea());
			//lista.Add(new resumen());
			//lista.Add(new resumenDescuentos());
			//lista.Add(new resumenImportes_moneda_origen());
			//lista.Add(new resumenImpuestos());
			lista.Add(new Ubicador());
			return lista;
		}

	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes
{
	public class TipoComprobante
	{
		private long idComprobante;
		protected short codigo;
		protected string descr;

		public long IdComprobante
		{
			get { return idComprobante; }
			set { idComprobante = value; }
		}

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

		public static List<TipoComprobante> Lista()
		{
			List<TipoComprobante> lista = new List<TipoComprobante>();
			lista.Add(new Facturas.A());
			lista.Add(new NotasDebito.A());
			lista.Add(new NotasCredito.A());
			lista.Add(new Recibos.A());
			lista.Add(new NotasDeVentaAlContado.A());
			lista.Add(new Facturas.B());
			lista.Add(new NotasDebito.B());
			lista.Add(new NotasCredito.B());
			lista.Add(new Recibos.B());
			lista.Add(new NotasDeVentaAlContado.B());
			lista.Add(new Otros.A());
			lista.Add(new Otros.B());
			lista.Add(new CuentaDeVentaYLiquido.A());
			lista.Add(new CuentaDeVentaYLiquido.B());
			lista.Add(new Liquidacion.A());
			lista.Add(new Liquidacion.B());
			return lista;
		}
        public static List<TipoComprobante> ListaSinInf()
        {
            List<TipoComprobante> lista = new List<TipoComprobante>();
            lista.Add(new SinInformar());
            lista.Add(new Facturas.A());
            lista.Add(new NotasDebito.A());
            lista.Add(new NotasCredito.A());
            lista.Add(new Recibos.A());
            lista.Add(new NotasDeVentaAlContado.A());
            lista.Add(new Facturas.B());
            lista.Add(new NotasDebito.B());
            lista.Add(new NotasCredito.B());
            lista.Add(new Recibos.B());
            lista.Add(new NotasDeVentaAlContado.B());
            lista.Add(new Otros.A());
            lista.Add(new Otros.B());
            lista.Add(new CuentaDeVentaYLiquido.A());
            lista.Add(new CuentaDeVentaYLiquido.B());
            lista.Add(new Liquidacion.A());
            lista.Add(new Liquidacion.B());
            return lista;
        }
        public static List<TipoComprobante> ListaParaBienesDeCapital()
        {
            List<TipoComprobante> lista = new List<TipoComprobante>();
            lista.Add(new Facturas.A());
            lista.Add(new NotasDebito.A());
            lista.Add(new NotasCredito.A());
            lista.Add(new Facturas.B());
            lista.Add(new NotasDebito.B());
            lista.Add(new NotasCredito.B());
            return lista;
        }

        public static List<TipoComprobante> ListaParaExportaciones()
        {
            List<TipoComprobante> lista = new List<TipoComprobante>();
            lista.Add(new Exportaciones.FacturasDeExportacion());
            lista.Add(new Exportaciones.NotaDeDebitoPorOperacionesConElExterior());
            lista.Add(new Exportaciones.NotaDeCreditoPorOperacionesConElExterior());
            return lista;
        }

        public static List<TipoComprobante> ListaCompleta()
        {
            List<TipoComprobante> lista = new List<TipoComprobante>();
            lista.Add(new Facturas.A());
            lista.Add(new NotasDebito.A());
            lista.Add(new NotasCredito.A());
            lista.Add(new Recibos.A());
            lista.Add(new NotasDeVentaAlContado.A());
            lista.Add(new Facturas.B());
            lista.Add(new NotasDebito.B());
            lista.Add(new NotasCredito.B());
            lista.Add(new Recibos.B());
            lista.Add(new NotasDeVentaAlContado.B());
            lista.Add(new Otros.A());
            lista.Add(new Otros.B());
            lista.Add(new CuentaDeVentaYLiquido.A());
            lista.Add(new CuentaDeVentaYLiquido.B());
            lista.Add(new Liquidacion.A());
            lista.Add(new Liquidacion.B());
            lista.Add(new Exportaciones.FacturasDeExportacion());
            lista.Add(new Exportaciones.NotaDeDebitoPorOperacionesConElExterior());
            lista.Add(new Exportaciones.NotaDeCreditoPorOperacionesConElExterior());
            return lista;
        }


	}
}

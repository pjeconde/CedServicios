using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes
{
    [Serializable]
    public class TipoComprobante
	{
		private long idComprobante;
		protected short codigo;
		protected string descr;
        protected bool incluir;

        public TipoComprobante()
        {
            incluir = true;
        }

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

        public bool Incluir
        {
            get { return incluir; }
            set { incluir = value; }
        }

        public string DescrCompleta
        {
            get { return Codigo.ToString("00") + "-" + descr; }
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
            lista.Add(new Facturas.MiPyMEsA());
            lista.Add(new NotasDebito.MiPyMEsA());
            lista.Add(new NotasCredito.MiPyMEsA());
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
            lista.Add(new Facturas.MiPyMEsA());
            lista.Add(new NotasDebito.MiPyMEsA());
            lista.Add(new NotasCredito.MiPyMEsA());
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
            lista.Add(new Facturas.MiPyMEsA());
            lista.Add(new NotasDebito.MiPyMEsA());
            lista.Add(new NotasCredito.MiPyMEsA());
            return lista;
        }

        public static List<TipoComprobante> ListaMonotributo()
        {
            List<TipoComprobante> lista = new List<TipoComprobante>();
            lista.Add(new Facturas.C());
            lista.Add(new NotasDebito.C());
            lista.Add(new NotasCredito.C());
            lista.Add(new Recibos.C());
            return lista;
        }

        public static List<TipoComprobante> ListaCompletaAFIP()
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
            lista.Add(new Facturas.C());
            lista.Add(new NotasDebito.C());
            lista.Add(new NotasCredito.C());
            lista.Add(new Recibos.C());
            lista.Add(new Facturas.MiPyMEsA());
            lista.Add(new NotasDebito.MiPyMEsA());
            lista.Add(new NotasCredito.MiPyMEsA());
            return lista;
        }

        public static List<TipoComprobante> ListaCompletaAFIPSinInf()
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
            lista.Add(new Exportaciones.FacturasDeExportacion());
            lista.Add(new Exportaciones.NotaDeDebitoPorOperacionesConElExterior());
            lista.Add(new Exportaciones.NotaDeCreditoPorOperacionesConElExterior());
            lista.Add(new Facturas.C());
            lista.Add(new NotasDebito.C());
            lista.Add(new NotasCredito.C());
            lista.Add(new Recibos.C());
            lista.Add(new Facturas.MiPyMEsA());
            lista.Add(new NotasDebito.MiPyMEsA());
            lista.Add(new NotasCredito.MiPyMEsA());
            return lista;
        }

        public static List<TipoComprobante> ListaCompletaAFIPCompras()
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
            lista.Add(new Facturas.C());
            lista.Add(new NotasDebito.C());
            lista.Add(new NotasCredito.C());
            lista.Add(new Recibos.C());
            lista.Add(new Exportaciones.FacturasDeExportacion());
            lista.Add(new Exportaciones.NotaDeDebitoPorOperacionesConElExterior());
            lista.Add(new Exportaciones.NotaDeCreditoPorOperacionesConElExterior());
            lista.Add(new OtrosCompras.BienesUsados());
            lista.Add(new Otros.A());
            lista.Add(new Otros.B());
            lista.Add(new CuentaDeVentaYLiquido.A());
            lista.Add(new CuentaDeVentaYLiquido.B());
            lista.Add(new Liquidacion.A());
            lista.Add(new Liquidacion.B());
            lista.Add(new OtrosCompras.ImportacionServicios());
            lista.Add(new OtrosCompras.RecibosFactCredito());
            lista.Add(new OtrosCompras.TiqueFactA());
            lista.Add(new OtrosCompras.TiqueFactB());
            lista.Add(new OtrosCompras.Tique());
            lista.Add(new OtrosCompras.NCServiciosPublicos());
            lista.Add(new OtrosCompras.NDServiciosPublicos());
            lista.Add(new OtrosCompras.OtrosExceptuadosNDyResumen());
            lista.Add(new OtrosCompras.OtrosNoCumplenRG3419());
            lista.Add(new Facturas.MiPyMEsA());
            lista.Add(new NotasDebito.MiPyMEsA());
            lista.Add(new NotasCredito.MiPyMEsA());
            return lista;
        }

        public static List<TipoComprobante> ListaTurismoAFIP()
        {
            List<TipoComprobante> lista = new List<TipoComprobante>();
            lista.Add(new Facturas.T());
            lista.Add(new NotasDebito.T());
            lista.Add(new NotasCredito.T());
            return lista;
        }

        public static List<TipoComprobante> ListaCompletaAFIPTurismo()
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
            lista.Add(new Facturas.C());
            lista.Add(new NotasDebito.C());
            lista.Add(new NotasCredito.C());
            lista.Add(new Recibos.C());
            lista.Add(new Facturas.T());
            lista.Add(new NotasDebito.T());
            lista.Add(new NotasCredito.T());
            lista.Add(new Facturas.MiPyMEsA());
            lista.Add(new NotasDebito.MiPyMEsA());
            lista.Add(new NotasCredito.MiPyMEsA());
            return lista;
        }

        public static List<TipoComprobante> ListaBasicaFiltrosCombo()
        {
            List<TipoComprobante> lista = new List<TipoComprobante>();
            lista.Add(new Facturas.A());
            lista.Add(new NotasDebito.A());
            lista.Add(new NotasCredito.A());
            lista.Add(new Recibos.A());
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
            lista.Add(new Facturas.C());
            lista.Add(new NotasDebito.C());
            lista.Add(new NotasCredito.C());
            lista.Add(new Recibos.C());
            lista.Add(new OtrosCompras.OtrosExceptuadosNDyResumen());
            lista.Add(new OtrosCompras.OtrosNoCumplenRG3419());
            lista.Add(new Facturas.T());
            lista.Add(new NotasDebito.T());
            lista.Add(new NotasCredito.T());
            lista.Add(new Facturas.MiPyMEsA());
            lista.Add(new NotasDebito.MiPyMEsA());
            lista.Add(new NotasCredito.MiPyMEsA());
            return lista;
        }
    }
}

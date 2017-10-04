using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class DetalleCTConsulta : System.Web.UI.UserControl
    {
        System.Collections.Generic.List<FeaEntidades.Turismo.linea> lineas;
        private System.Globalization.CultureInfo cedeiraCultura;
        string puntoDeVenta;
        string idListaPrecio;

        protected void Page_Load(object sender, EventArgs e)
        {
            puntoDeVenta = Convert.ToString(ViewState["puntoDeVenta"]);
            idListaPrecio = Convert.ToString(ViewState["idListaPrecio"]);
            if (!this.IsPostBack)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    ViewState["articulolista"] = RN.Articulo.ListaPorCuit(true, true, ((Entidades.Sesion)Session["Sesion"]));
                    Object o = Session["ComprobanteATratar"];
                    if (o == null || ((Entidades.ComprobanteATratar)o).Tratamiento == Entidades.Enum.TratamientoComprobante.Alta)
                    {
                        ResetearGrillas();
                    }
                    else
                    {
                        BindearDropDownLists();
                    }
                }
            }
        }
        public void ResetearGrillas()
        {
            lineas = new System.Collections.Generic.List<FeaEntidades.Turismo.linea>();
            FeaEntidades.Turismo.linea linea = new FeaEntidades.Turismo.linea();
            lineas.Add(linea);
            detalleGridView.DataSource = lineas;
            ViewState["lineas"] = lineas;
            detalleGridView.DataBind();
            BindearDropDownLists();
        }
        public System.Collections.Generic.List<FeaEntidades.Turismo.linea> Lineas
        {
            get
            {
                System.Collections.Generic.List<FeaEntidades.Turismo.linea> refs = ((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"]);
                return refs;
            }
        }
        public string PuntoDeVenta
        {
            set
            {
                ViewState["puntoDeVenta"] = value;
                puntoDeVenta = value;
            }
        }
        public string IdListaPrecio
        {
            set
            {
                ViewState["idListaPrecio"] = value;
                idListaPrecio = value;
            }
        }
        public string IdNaturalezaComprobante
        {
            set
            {
                ViewState["idNaturalezaComprobante"] = value;
            }
        }
        public void CompletarDetalles(FeaEntidades.Turismo.comprobante comprobante)
        {
            lineas = new System.Collections.Generic.List<FeaEntidades.Turismo.linea>();
            foreach (FeaEntidades.Turismo.linea l in comprobante.detalle.linea)
            {
                FeaEntidades.Turismo.linea linea = new FeaEntidades.Turismo.linea();
                if (l.GTINSpecified)
                {
                    linea.GTIN = l.GTIN;
                    linea.GTINSpecified = true;
                }
                linea.descripcion = l.descripcion.Replace("<br>", System.Environment.NewLine);
                if (l.alicuota_ivaSpecified)
                {
                    linea.alicuota_iva = l.alicuota_iva;
                }
                else
                {
                    linea.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                }
                linea.alicuota_ivaSpecified = l.alicuota_ivaSpecified;
                linea.importe_ivaSpecified = l.importe_ivaSpecified;
                if (l.unidad != null)
                {
                    linea.unidad = l.unidad;
                }
                else
                {
                    linea.unidad = Convert.ToString(new FeaEntidades.CodigosUnidad.SinInformar().Codigo);
                }
                linea.codigo_Turismo = l.codigo_Turismo;
                linea.cantidad = l.cantidad;
                linea.cantidadSpecified = l.cantidadSpecified;
                linea.codigo_producto_comprador = l.codigo_producto_comprador;
                linea.codigo_producto_vendedor = l.codigo_producto_vendedor;
                linea.indicacion_exento_gravado = l.indicacion_exento_gravado;

                if (l.importes_moneda_origen == null || l.importes_moneda_origen.importe_total_articulo.Equals(0))
                {
                    linea.importe_total_articulo = l.importe_total_articulo;
                    linea.importe_iva = l.importe_iva;
                    linea.precio_unitario = l.precio_unitario;
                    linea.precio_unitarioSpecified = l.precio_unitarioSpecified;
                }
                else
                {
                    linea.importe_total_articulo = l.importes_moneda_origen.importe_total_articulo;
                    linea.importe_iva = l.importes_moneda_origen.importe_iva;
                    linea.precio_unitario = l.importes_moneda_origen.precio_unitario;
                    linea.precio_unitarioSpecified = l.importes_moneda_origen.precio_unitarioSpecified;
                }
                lineas.Add(linea);
            }
            detalleGridView.DataSource = lineas;
            detalleGridView.DataBind();
            ViewState["lineas"] = lineas;

        }

 
        public void BindearDropDownLists()
        {

        }

        public FeaEntidades.Turismo.detalle GenerarDetalles(string MonedaComprobante, string TipoDeCambio, string TipoPtoVta, string TipoCbte, bool EsParaImprimirPDF)
        {
            FeaEntidades.Turismo.detalle det = new FeaEntidades.Turismo.detalle();
            System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"];
            for (int i = 0; i < listadelineas.Count; i++)
            {
                det.linea[i] = new FeaEntidades.Turismo.linea();
                det.linea[i].numeroLinea = i + 1;
                if (listadelineas[i].descripcion == null)
                {
                    throw new Exception("Debe informar al menos un artículo");
                }
                string textoSinSaltoDeLinea = listadelineas[i].descripcion.Replace("\n", "<br>").Replace("\r", string.Empty);
                det.linea[i].descripcion = textoSinSaltoDeLinea;

                GenerarDetallesAlicuotaIVA(TipoPtoVta, TipoCbte, det, listadelineas, i);

                if (!listadelineas[i].unidad.Equals(Convert.ToString(new FeaEntidades.CodigosUnidad.SinInformar().Codigo)))
                {
                    det.linea[i].unidad = listadelineas[i].unidad;
                }
                det.linea[i].codigo_Turismo = listadelineas[i].codigo_Turismo;
                det.linea[i].cantidad = listadelineas[i].cantidad;
                det.linea[i].cantidadSpecified = listadelineas[i].cantidadSpecified;
                det.linea[i].GTIN = listadelineas[i].GTIN;
                det.linea[i].GTINSpecified = listadelineas[i].GTINSpecified;
                det.linea[i].codigo_producto_comprador = listadelineas[i].codigo_producto_comprador;
                det.linea[i].codigo_producto_vendedor = listadelineas[i].codigo_producto_vendedor;

                GenerarDetallesIndExGravado(TipoPtoVta, TipoCbte, det, listadelineas, i);

                if (MonedaComprobante.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
                {

                    GenerarDetalleMonedaLocal(TipoCbte, det, listadelineas, i, TipoPtoVta);
                }
                else
                {
                    GenerarDetalleMonedaExtranjera(TipoDeCambio, TipoCbte, det, listadelineas, i, TipoPtoVta);
                }
            }
            return det;
        }

        protected string GetAlicuotaIVA(double alic)
        {
            if (alic != 99)
            {
                string aux = Convert.ToString(alic);
                return aux;
            }
            else
            {
                return string.Empty;
            }
        }

        private static void GenerarDetalleMonedaExtranjera(string TipoDeCambio, string TipoCbte, FeaEntidades.Turismo.detalle det, System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas, int i, string TipoPtoVta)
        {
            det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
            det.linea[i].importe_iva = Math.Round(listadelineas[i].importe_iva * Convert.ToDouble(TipoDeCambio), 2);
            det.linea[i].importe_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
            det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * Convert.ToDouble(TipoDeCambio), 3);
            det.linea[i].importe_total_articulo = Math.Round(listadelineas[i].importe_total_articulo * Convert.ToDouble(TipoDeCambio), 2);

            FeaEntidades.InterFacturas.lineaImportes_moneda_origen limo = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
            limo.importe_total_articuloSpecified = true;

            limo.precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
            limo.importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
            limo.importe_iva = listadelineas[i].importe_iva;
            limo.precio_unitario = listadelineas[i].precio_unitario;
            limo.importe_total_articulo = listadelineas[i].importe_total_articulo;

            det.linea[i].importes_moneda_origen = limo;
        }

        private static void GenerarDetalleMonedaLocal(string TipoCbte, FeaEntidades.Turismo.detalle det, System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas, int i, string TipoPtoVta)
        {
            det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
            det.linea[i].precio_unitario = listadelineas[i].precio_unitario;
            det.linea[i].importe_total_articulo = listadelineas[i].importe_total_articulo;
            det.linea[i].importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
            det.linea[i].importe_iva = listadelineas[i].importe_iva;
        }

        private static void GenerarDetallesIndExGravado(string TipoPtoVta, string TipoCbte, FeaEntidades.Turismo.detalle det, System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas, int i)
        {
            if (listadelineas[i].indicacion_exento_gravado != null)
            {
                if (!listadelineas[i].indicacion_exento_gravado.Equals(string.Empty))
                {
                    det.linea[i].indicacion_exento_gravado = listadelineas[i].indicacion_exento_gravado;
                }
            }
        }

        private static void GenerarDetallesAlicuotaIVA(string TipoPtoVta, string TipoCbte, FeaEntidades.Turismo.detalle det, System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas, int i)
        {
            if (listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
            {
                //throw new Exception("La alícuota de IVA es obligatoria");
                det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
                det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
            }
            else
            {
                det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
                det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
            }
        }
    }
}
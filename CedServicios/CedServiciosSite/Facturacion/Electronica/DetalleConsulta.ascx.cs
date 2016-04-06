using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class DetalleConsulta : System.Web.UI.UserControl
    {
        System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas;
        private System.Globalization.CultureInfo cedeiraCultura;
        string puntoDeVenta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);
            }
            else
            {
                puntoDeVenta = Convert.ToString(ViewState["puntoDeVenta"]);
            }
        }
        public void ResetearGrillas()
        {
            lineas = new System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>();
            FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
            lineas.Add(linea);
            detalleGridView.DataSource = lineas;
            ViewState["lineas"] = lineas;
            detalleGridView.DataBind();
            BindearDropDownLists();
        }
        public System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> Lineas
        {
            get
            {
                System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]);
                return refs;
            }
        }
        public string PuntoDeVenta
        {
            set
            {
                ViewState["puntoDeVenta"] = value;
            }
        }
        public void CompletarDetallesWS(org.dyndns.cedweb.consulta.ConsultarResult lc)
        {
            lineas = new System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>();
            foreach (org.dyndns.cedweb.consulta.ConsultarResultComprobanteDetalleLinea l in lc.comprobante[0].detalle.linea)
            {
                FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
                //Compatibilidad con archivos xml viejos. Verificar si la descripcion está en Hexa.
                if (l.descripcion != "" && l.descripcion.Substring(0, 1) == "%")
                {
                    linea.descripcion = RN.Funciones.HexToString(l.descripcion).Replace("<br>", System.Environment.NewLine);
                }
                else
                {
                    linea.descripcion = l.descripcion.Replace("<br>", System.Environment.NewLine);
                }
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
                linea.cantidad = l.cantidad;
                linea.cantidadSpecified = l.cantidadSpecified;
                linea.codigo_producto_comprador = l.codigo_producto_comprador;
                linea.codigo_producto_vendedor = l.codigo_producto_vendedor;
                linea.indicacion_exento_gravado = l.indicacion_exento_gravado;

                if (l.importes_moneda_origen == null)
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
            BindearDropDownLists();
            ViewState["lineas"] = lineas;
        }
        public void CompletarDetalles(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            lineas = new System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>();
            foreach (FeaEntidades.InterFacturas.linea l in lc.comprobante[0].detalle.linea)
            {
                FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
                if (l.GTINSpecified)
                {
                    linea.GTIN = l.GTIN;
                    linea.GTINSpecified = true;
                }
                //Compatibilidad con archivos xml viejos. Verificar si la descripcion está en Hexa.
                if (l.descripcion.Substring(0, 1) == "%")
                {
                    linea.descripcion = RN.Funciones.HexToString(l.descripcion).Replace("<br>", System.Environment.NewLine);
                }
                else
                {
                    linea.descripcion = l.descripcion.Replace("<br>", System.Environment.NewLine);
                }
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
 
        public FeaEntidades.InterFacturas.detalle GenerarDetalles(string MonedaComprobante, string TipoDeCambio, string TipoPtoVta, string TipoCbte)
        {
            FeaEntidades.InterFacturas.detalle det = new FeaEntidades.InterFacturas.detalle();
            System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"];
            for (int i = 0; i < listadelineas.Count; i++)
            {
                det.linea[i] = new FeaEntidades.InterFacturas.linea();
                det.linea[i].numeroLinea = i + 1;
                if (listadelineas[i].descripcion == null)
                {
                    throw new Exception("Debe informar al menos un artículo");
                }
                string textoSinSaltoDeLinea = listadelineas[i].descripcion.Replace("\n", "<br>").Replace("\r", string.Empty);
                det.linea[i].descripcion = RN.Funciones.ConvertToHex(textoSinSaltoDeLinea);

                GenerarDetallesAlicuotaIVA(TipoPtoVta, TipoCbte, det, listadelineas, i);

                if (!listadelineas[i].unidad.Equals(Convert.ToString(new FeaEntidades.CodigosUnidad.SinInformar().Codigo)))
                {
                    det.linea[i].unidad = listadelineas[i].unidad;
                }
                det.linea[i].cantidad = listadelineas[i].cantidad;
                det.linea[i].cantidadSpecified = listadelineas[i].cantidadSpecified;
                det.linea[i].GTIN = listadelineas[i].GTIN;
                det.linea[i].GTINSpecified = listadelineas[i].GTINSpecified;
                if (TipoPtoVta.Equals("RG2904"))
                {
                    det.linea[i].informacion_adicional = new FeaEntidades.InterFacturas.lineaInformacion_adicional[1];
                    det.linea[i].informacion_adicional[0] = new FeaEntidades.InterFacturas.lineaInformacion_adicional();
                    det.linea[i].informacion_adicional[0].tipo = "UNIDAD_MTX";
                    det.linea[i].informacion_adicional[0].valor = listadelineas[i].unidad;
                }
                det.linea[i].codigo_producto_comprador = listadelineas[i].codigo_producto_comprador;
                det.linea[i].codigo_producto_vendedor = listadelineas[i].codigo_producto_vendedor;

                GenerarDetallesIndExGravado(TipoPtoVta, TipoCbte, det, listadelineas, i);

                if (MonedaComprobante.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
                {

                    GenerarDetalleMonedaLocal(TipoCbte, det, listadelineas, i);
                }
                else
                {
                    GenerarDetalleMonedaExtranjera(TipoDeCambio, TipoCbte, det, listadelineas, i);
                }
            }
            return det;
        }

        private static void GenerarDetalleMonedaExtranjera(string TipoDeCambio, string TipoCbte, FeaEntidades.InterFacturas.detalle det, System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas, int i)
        {
            det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
            switch (TipoCbte)
            {
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "40":
                case "61":
                case "64":
                    det.linea[i].importe_iva = 0;
                    det.linea[i].importe_ivaSpecified = false;
                    if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                    {
                        det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * Convert.ToDouble(TipoDeCambio) * (1 + listadelineas[i].alicuota_iva / 100), 3);
                    }
                    else
                    {
                        det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * Convert.ToDouble(TipoDeCambio), 3);
                    }
                    det.linea[i].importe_total_articulo = Math.Round(((listadelineas[i].importe_total_articulo) + listadelineas[i].importe_iva) * Convert.ToDouble(TipoDeCambio), 2);
                    break;
                default:
                    det.linea[i].importe_iva = Math.Round(listadelineas[i].importe_iva * Convert.ToDouble(TipoDeCambio), 2);
                    det.linea[i].importe_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
                    det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * Convert.ToDouble(TipoDeCambio), 3);
                    det.linea[i].importe_total_articulo = Math.Round(listadelineas[i].importe_total_articulo * Convert.ToDouble(TipoDeCambio), 2);
                    break;
            }

            FeaEntidades.InterFacturas.lineaImportes_moneda_origen limo = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
            limo.importe_total_articuloSpecified = true;

            limo.precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;

            switch (TipoCbte)
            {
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "40":
                case "61":
                case "64":
                    limo.importe_ivaSpecified = false;
                    limo.importe_iva = 0;
                    if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                    {
                        limo.precio_unitario = Math.Round(listadelineas[i].precio_unitario * (1 + listadelineas[i].alicuota_iva / 100), 3);
                    }
                    else
                    {
                        limo.precio_unitario = Math.Round(listadelineas[i].precio_unitario, 3);
                    }
                    limo.importe_total_articulo = Math.Round(listadelineas[i].importe_total_articulo + listadelineas[i].importe_iva, 2);
                    break;
                default:
                    limo.importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
                    limo.importe_iva = listadelineas[i].importe_iva;
                    limo.precio_unitario = listadelineas[i].precio_unitario;
                    limo.importe_total_articulo = listadelineas[i].importe_total_articulo;
                    break;
            }
            det.linea[i].importes_moneda_origen = limo;
        }

        private static void GenerarDetalleMonedaLocal(string TipoCbte, FeaEntidades.InterFacturas.detalle det, System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas, int i)
        {
            switch (TipoCbte)
            {
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "40":
                case "61":
                case "64":
                    if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                    {
                        det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * (1 + listadelineas[i].alicuota_iva / 100), 3);
                    }
                    else
                    {
                        det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario, 3);
                    }
                    det.linea[i].importe_total_articulo = Math.Round(listadelineas[i].importe_total_articulo + listadelineas[i].importe_iva, 2);
                    det.linea[i].importe_ivaSpecified = false;
                    det.linea[i].importe_iva = 0;
                    break;
                default:
                    det.linea[i].precio_unitario = listadelineas[i].precio_unitario;
                    det.linea[i].importe_total_articulo = listadelineas[i].importe_total_articulo;
                    det.linea[i].importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
                    det.linea[i].importe_iva = listadelineas[i].importe_iva;
                    break;
            }
            det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
        }

        private static void GenerarDetallesIndExGravado(string TipoPtoVta, string TipoCbte, FeaEntidades.InterFacturas.detalle det, System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas, int i)
        {
            if (listadelineas[i].indicacion_exento_gravado != null)
            {
                if (!listadelineas[i].indicacion_exento_gravado.Equals(string.Empty))
                {
                    if (!(TipoPtoVta.Equals("Comun") || TipoPtoVta.Equals("RG2904")))
                    {
                        det.linea[i].indicacion_exento_gravado = listadelineas[i].indicacion_exento_gravado;
                    }
                    else
                    {
                        switch (TipoCbte)
                        {
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                            case "10":
                            case "40":
                            case "61":
                            case "64":
                                det.linea[i].indicacion_exento_gravado = null;
                                break;
                            default:
                                det.linea[i].indicacion_exento_gravado = listadelineas[i].indicacion_exento_gravado;
                                break;
                        }
                    }
                }
            }
        }

        private static void GenerarDetallesAlicuotaIVA(string TipoPtoVta, string TipoCbte, FeaEntidades.InterFacturas.detalle det, System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas, int i)
        {
            if (!(TipoPtoVta.Equals("Comun") || TipoPtoVta.Equals("RG2904")))
            {
                det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
                if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                {
                    det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
                }
            }
            else
            {
                if (TipoPtoVta.Equals("RG2904"))
                {
                    if (listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                    {
                        throw new Exception("La alícuota de IVA es obligatoria para RG2904");
                    }
                    else
                    {
                        det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
                        det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
                    }
                }
                else
                {
                    switch (TipoCbte)
                    {
                        case "6":
                        case "7":
                        case "8":
                        case "9":
                        case "10":
                        case "40":
                        case "61":
                        case "64":
                            det.linea[i].alicuota_ivaSpecified = false;
                            det.linea[i].alicuota_iva = 0;
                            break;
                        default:
                            det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
                            if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                            {
                                det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
                            }
                            break;
                    }
                }
            }
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
    }
}
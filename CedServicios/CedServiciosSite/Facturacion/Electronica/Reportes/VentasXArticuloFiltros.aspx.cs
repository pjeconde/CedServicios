using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;

namespace CedServicios.Site.Facturacion.Electronica.Reportes
{
    public partial class VentasXArticuloFiltros : System.Web.UI.Page
    {
        List<Entidades.IvaVentasTotXImpuestos> listaTotXIMP;
        List<Entidades.IvaVentasTotXIVA> listaTotXIVA;
        List<Entidades.IvaVentasTotXIVA> listaTotIVAxComprobante;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FechaDesdeTextBox.Text = DateTime.Now.ToString("yyyyMM01");
                FechaHastaTextBox.Text = DateTime.Now.ToString("yyyyMMdd");
                FormatosRptExportarDropDownList.DataValueField = "Codigo";
                FormatosRptExportarDropDownList.DataTextField = "Descr";
                FormatosRptExportarDropDownList.DataSource = Entidades.FormatosRptExportar.FormatoRptExportar.Lista();
                FormatosRptExportarDropDownList.DataBind();
                DataBind();
            }
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                try
                {
                    MensajeLabel.Text = "";
                    bool monedasExtranjeras = false;
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    List<Entidades.Comprobante> listaC = new List<Entidades.Comprobante>();

                    List<Entidades.Estado> estados = new List<Entidades.Estado>();
                    Entidades.Estado es = new Entidades.Estado();
                    es.Id = "Vigente";
                    estados.Add(es);
                    Entidades.Persona persona = new Entidades.Persona();
                    Entidades.NaturalezaComprobante nc = new Entidades.NaturalezaComprobante();
                    nc.Id = "Venta";
                    listaC = RN.Comprobante.ListaFiltradaIvaVentas(estados, FechaDesdeTextBox.Text, FechaHastaTextBox.Text, persona, nc, false, "", sesion);

                    Entidades.VentasXArticulo ventas = new Entidades.VentasXArticulo();

                    ventas.Cuit = sesion.Cuit.Nro;
                    ventas.RazSoc = sesion.Cuit.RazonSocial;
                    ventas.PeriodoDsd = FechaDesdeTextBox.Text.Substring(6, 2) + "/" + FechaDesdeTextBox.Text.Substring(4, 2) + "/" + FechaDesdeTextBox.Text.Substring(0, 4);
                    ventas.PeriodoHst = FechaHastaTextBox.Text.Substring(6, 2) + "/" + FechaHastaTextBox.Text.Substring(4, 2) + "/" + FechaHastaTextBox.Text.Substring(0, 4);

                    System.Xml.Serialization.XmlSerializer x;
                    byte[] bytes;
                    System.IO.MemoryStream ms;
                    FeaEntidades.InterFacturas.lote_comprobantes lote;

                    ventas.VentasXArticuloDetalle = new List<Entidades.VentasXArticuloDetalle>();
                    List<Entidades.VentasXArticuloDetalle> lvd = new List<Entidades.VentasXArticuloDetalle>();
                    Entidades.VentasXArticuloDetalle vd;
                    foreach (Entidades.Comprobante comprobante in listaC)
                    {
                        lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                        x = new System.Xml.Serialization.XmlSerializer(lote.GetType());

                        comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                        bytes = new byte[comprobante.Response.Length * sizeof(char)];
                        System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                        ms = new System.IO.MemoryStream(bytes);
                        ms.Seek(0, System.IO.SeekOrigin.Begin);
                        lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                        //Totales por artículo
                        if (lote.comprobante[0].detalle.linea != null)
                        {
                            for (int z = 0; z < lote.comprobante[0].detalle.linea.Length; z++)
                            {
                                double signo = 1;
                                if (("/3/8/13/").IndexOf("/" + Convert.ToInt32(lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante).ToString().Trim() + "/") != -1)
                                {
                                    signo = -1;
                                }

                                //Verificar el articulo ya existe en la lista.
                                //List<Entidades.VentasXArticuloDetalle> listaAux = lvd.FindAll(delegate(Entidades.VentasXArticuloDetalle vxad)
                                //{
                                //    return vxad.IdArticulo == lote.comprobante[0].detalle.linea[z].codigo_producto_vendedor;
                                //});
                                //if (listaAux.Count == 0 || lote.comprobante[0].detalle.linea[z].codigo_producto_vendedor.Trim() == "")
                                //{
                                //}
                                vd = new Entidades.VentasXArticuloDetalle();
                                vd.IdArticulo = lote.comprobante[0].detalle.linea[z].codigo_producto_vendedor;
                                vd.GTIN = lote.comprobante[0].detalle.linea[z].GTIN.ToString();
                                vd.IdArticuloEmp = lote.comprobante[0].detalle.linea[z].codigo_producto_comprador;
                                if (lote.comprobante[0].detalle.linea[z].indicacion_exento_gravado != null)
                                {
                                    vd.IndicacionExentoGravado = lote.comprobante[0].detalle.linea[z].indicacion_exento_gravado;
                                }
                                else
                                {
                                    vd.IndicacionExentoGravado = "";
                                }
                                vd.NumeroLinea = lote.comprobante[0].detalle.linea[z].numeroLinea;
                                vd.UnidadCod = lote.comprobante[0].detalle.linea[z].unidad;
                                vd.UnidadDescr = lote.comprobante[0].detalle.linea[z].unidadDescripcion;
                                vd.CompTipo = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString();
                                vd.CompNro = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString();
                                vd.CompPtoVta = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString();
                                vd.CompFecEmi = lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision.Substring(6, 2) + "/" + lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision.Substring(4, 2) + "/" + lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision.Substring(0, 4);

                                vd.EmpNroDoc = lote.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio.ToString();
                                vd.EmpCodDoc = lote.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString();
                                vd.EmpDescrDoc = ""; //Obtener la descripcion; 
                                vd.EmpNombre = lote.comprobante[0].cabecera.informacion_comprador.denominacion;

                                if (lote.comprobante[0].detalle.linea[z].descripcion.Length > 0 && lote.comprobante[0].detalle.linea[z].descripcion.Substring(0, 1) == "%")
                                {
                                    vd.Descr = RN.Funciones.HexToString(lote.comprobante[0].detalle.linea[z].descripcion);
                                }
                                else
                                {
                                    vd.Descr = lote.comprobante[0].detalle.linea[z].descripcion;
                                }
                                vd.ImporteTotal = lote.comprobante[0].detalle.linea[z].importe_total_articulo * signo;
                                if (lote.comprobante[0].detalle.linea[z].cantidadSpecified == true && lote.comprobante[0].detalle.linea[z].precio_unitarioSpecified == true)
                                {
                                    vd.Cantidad = lote.comprobante[0].detalle.linea[z].cantidad * signo;
                                    vd.PrecioUnitario = lote.comprobante[0].detalle.linea[z].precio_unitario * signo;
                                }
                                if (lote.comprobante[0].detalle.linea[z].alicuota_ivaSpecified == true && lote.comprobante[0].detalle.linea[z].importe_ivaSpecified == true)
                                {
                                    vd.AlicuotaIVA = lote.comprobante[0].detalle.linea[z].alicuota_iva;
                                    vd.ImporteIVA = lote.comprobante[0].detalle.linea[z].importe_iva * signo;
                                }
                                lvd.Add(vd); 
                            }
                        }
                    }
                    if (lvd.Count != 0)
                    {
                        ventas.VentasXArticuloDetalle = lvd;
                    }
                    Session["formatoRptExportar"] = FormatosRptExportarDropDownList.SelectedValue;
                    Session["mostrarFechaYHora"] = FechaYHoraCheckBox.Checked;
                    Session["mostrarDetalleComprobantes"] = DetalleComprobanteCheckBox.Checked;
                    Session["monedasExtranjeras"] = monedasExtranjeras;
                    if (ventas.VentasXArticuloDetalle.Count != 0)
                    {
                        Session["ventasXArticulo"] = ventas;
                        Response.Redirect("~/Facturacion/Electronica/Reportes/VentasXArticuloWebForm.aspx", true);
                    }
                    else
                    {
                        MensajeLabel.Text = "No hay información.";
                    }
                }
                catch (System.Threading.ThreadAbortException)
                {
                    Trace.Warn("Thread abortado");
                }
                catch (Exception ex)
                {
                    WebForms.Excepciones.Redireccionar(ex, "~/NotificacionDeExcepcion.aspx");
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
            }
        }
    }
}
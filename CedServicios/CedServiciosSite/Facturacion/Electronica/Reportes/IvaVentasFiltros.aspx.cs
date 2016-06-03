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
    public partial class IvaVentasFiltros : System.Web.UI.Page
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

                    Entidades.IvaVentas ivaVentas = new Entidades.IvaVentas();
                    ivaVentas.Cuit = sesion.Cuit.Nro;
                    ivaVentas.PeriodoDsd = FechaDesdeTextBox.Text.Substring(6, 2) + "/" + FechaDesdeTextBox.Text.Substring(4, 2) + "/" + FechaDesdeTextBox.Text.Substring(0, 4);
                    ivaVentas.PeriodoHst = FechaHastaTextBox.Text.Substring(6, 2) + "/" + FechaHastaTextBox.Text.Substring(4, 2) + "/" + FechaHastaTextBox.Text.Substring(0, 4);

                    System.Xml.Serialization.XmlSerializer x;
                    byte[] bytes;
                    System.IO.MemoryStream ms;
                    FeaEntidades.InterFacturas.lote_comprobantes lote;

                    ivaVentas.IvaVentasComprobantes = new List<Entidades.IvaVentasComprobantes>();

                    listaTotXIMP = new List<Entidades.IvaVentasTotXImpuestos>();
                    listaTotXIVA = new List<Entidades.IvaVentasTotXIVA>();
                    foreach (Entidades.Comprobante comprobante in listaC)
                    {
                        Entidades.IvaVentasComprobantes ivc = new Entidades.IvaVentasComprobantes();
                        ivc.PtoVta = comprobante.NroPuntoVta.ToString();
                        ivc.TipoComp = comprobante.TipoComprobante.Descr;
                        ivc.NroComp = comprobante.Nro.ToString();
                        ivc.NroDoc = comprobante.NroDoc.ToString();
                        ivc.TipoCompCodigo = comprobante.TipoComprobante.Id.ToString();
                        ivc.RazSoc = comprobante.RazonSocial;
                        if (comprobante.Documento.Tipo.Id != "99")
                        {
                            ivc.TipoDoc = comprobante.DescrTipoDoc;
                        }
                        else
                        {
                            if (ivc.RazSoc == "")
                            {
                                ivc.TipoDoc = "Sin identificar/venta global";
                            }
                            else
                            {
                                ivc.TipoDoc = "";
                            }
                        }
                        
                        double signo = 1;
                        if (("/3/8/13/").IndexOf("/" + ivc.TipoCompCodigo + "/") != -1)
                        {
                            signo = -1;
                        }

                        ivc.ImporteTotal = comprobante.Importe;
                        ivc.FechaEmi = comprobante.Fecha.ToString("dd/MM/yyyy");

                        lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                        x = new System.Xml.Serialization.XmlSerializer(lote.GetType());

                        comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                        bytes = new byte[comprobante.Response.Length * sizeof(char)];
                        System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                        ms = new System.IO.MemoryStream(bytes);
                        ms.Seek(0, System.IO.SeekOrigin.Begin);
                        lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                        ivc.Exento = lote.comprobante[0].resumen.importe_operaciones_exentas * signo;
                        ivc.NoGravado = lote.comprobante[0].resumen.importe_total_concepto_no_gravado * signo;
                        ivc.Gravado = lote.comprobante[0].resumen.importe_total_neto_gravado * signo;
                        double otrosImp = Math.Round(lote.comprobante[0].resumen.importe_total_ingresos_brutos + lote.comprobante[0].resumen.importe_total_impuestos_nacionales + lote.comprobante[0].resumen.importe_total_impuestos_municipales + lote.comprobante[0].resumen.importe_total_impuestos_internos, 2);
                        ivc.OtrosImp = otrosImp * signo;
                        ivc.Iva = lote.comprobante[0].resumen.impuesto_liq * signo;
                        
                        ivc.Moneda = lote.comprobante[0].resumen.codigo_moneda;
                        if (ivc.Moneda != "PES")
                        {
                            monedasExtranjeras = true;
                        }
                        ivc.Cambio = lote.comprobante[0].resumen.tipo_de_cambio;
                        ivc.Concepto = lote.comprobante[0].cabecera.informacion_comprobante.codigo_concepto.ToString();
                        if (lote.comprobante[0].resumen.importes_moneda_origen != null)
                        {
                            ivc.ImporteTotalME = lote.comprobante[0].resumen.importes_moneda_origen.importe_total_factura * signo;
                        }
                        ivaVentas.IvaVentasComprobantes.Add(ivc);
                        
                        //Totales por Impuestos y Totales por alicuota de IVA y concepto
                        ivaVentas.IvaVentasTotXImpuestos = new List<Entidades.IvaVentasTotXImpuestos>();
                        ivaVentas.IvaVentasTotXIVA = new List<Entidades.IvaVentasTotXIVA>();
                        if (lote.comprobante[0].resumen.impuestos != null)
                        {
                            for (int z = 0; z < lote.comprobante[0].resumen.impuestos.Length; z++)
                            {
                                double importe = lote.comprobante[0].resumen.impuestos[z].importe_impuesto * signo;
                                listaTotIVAxComprobante = new List<Entidades.IvaVentasTotXIVA>();
                                if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 1)
                                {
                                    string concepto = lote.comprobante[0].cabecera.informacion_comprobante.codigo_concepto.ToString();
                                    double alicuota = lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto;
                                    double baseImponible = lote.comprobante[0].resumen.impuestos[z].base_imponible * signo;
                                    if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                    {
                                        if (lote.comprobante[0].detalle.linea == null || lote.comprobante[0].detalle.linea[0] == null)
                                        {
                                            //Si no hay renglones uso este método de cálculo para obtener la base imponible.
                                            baseImponible = Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2) * signo;
                                        }
                                        else if (lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante == 6 || lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante == 7 || lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante == 8)
                                        {
                                            //Si hay renglones y es un comprobante 'B' también uso este método de cálculo para obtener la base imponible.
                                            baseImponible = Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2) * signo;
                                        }
                                        else
                                        {
                                            //Si hay reglones, obtengo la base imponible sumando los renglones de detalle del comprobante según corresponda.
                                            baseImponible = 0;
                                            for (int k = 0; k < lote.comprobante[0].detalle.linea.Length; k++)
                                            {
                                                if (lote.comprobante[0].detalle.linea[k].indicacion_exento_gravado != null && lote.comprobante[0].detalle.linea[k].indicacion_exento_gravado.Trim().ToUpper() == "G" && lote.comprobante[0].detalle.linea[k].alicuota_iva == alicuota)
                                                {
                                                    baseImponible += Math.Round(lote.comprobante[0].detalle.linea[k].importe_total_articulo, 2) * signo;
                                                }
                                            }
                                            //Verificar el impuesto IVA que no exista mas de una vez la misma alicuota.
                                            List<Entidades.IvaVentasTotXIVA> listaAux = listaTotIVAxComprobante.FindAll(delegate(Entidades.IvaVentasTotXIVA txi)
                                            {
                                                return txi.Concepto == concepto && txi.Alicuota == alicuota;
                                            });
                                            if (listaAux.Count == 0)
                                            {
                                                TotalesIVAXComprobante(concepto, alicuota, baseImponible, importe);
                                            }
                                            else
                                            {
                                                //Comprobante con alícuota repetida.
                                            }
                                        }
                                    }
                                    TotalesXIVA(concepto, alicuota, baseImponible, importe);
                                    TotalesXImpuestos("IVA", importe);
                                }
                                else if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 2)
                                {
                                    TotalesXImpuestos("Impuestos Internos", importe);
                                }
                                else if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 3)
                                {
                                    TotalesXImpuestos("Otros Impuestos", importe);
                                }
                                else if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 4)
                                {
                                    TotalesXImpuestos("Impuestos Nacionales", importe);
                                }
                                else if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 5)
                                {
                                    TotalesXImpuestos("Impuestos Municipales", importe);
                                }
                                else if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 6)
                                {
                                    TotalesXImpuestos("Ingresos Brutos", importe);
                                }
                            }
                        }
                    }
                    if (listaTotXIMP.Count != 0)
                    {
                        ivaVentas.IvaVentasTotXImpuestos = listaTotXIMP;
                    }
                    else
                    {
                        //Para arreglar bug en towebs.
                        Entidades.IvaVentasTotXImpuestos totXimp = new Entidades.IvaVentasTotXImpuestos();
                        totXimp.Descr = "";
                        totXimp.ImporteTotal = 0;
                        ivaVentas.IvaVentasTotXImpuestos.Add(totXimp);
                    }
                    if (listaTotXIVA.Count != 0)
                    {
                        ivaVentas.IvaVentasTotXIVA = listaTotXIVA;
                    }
                    else
                    {
                        //Para arreglar bug en towebs.
                        Entidades.IvaVentasTotXIVA totXiva = new Entidades.IvaVentasTotXIVA();
                        totXiva.Concepto = "";
                        totXiva.Alicuota = 0;
                        totXiva.ImporteNG = 0;
                        totXiva.ImporteTotal = 0;
                        ivaVentas.IvaVentasTotXIVA.Add(totXiva);
                    }
                    Session["formatoRptExportar"] = FormatosRptExportarDropDownList.SelectedValue;
                    Session["mostrarFechaYHora"] = FechaYHoraCheckBox.Checked;
                    Session["monedasExtranjeras"] = monedasExtranjeras;
                    if (ivaVentas.IvaVentasComprobantes.Count != 0)
                    {
                        Session["ivaVentas"] = ivaVentas;
                        Response.Redirect("~/Facturacion/Electronica/Reportes/IvaVentasWebForm.aspx", true);
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
        private void TotalesXImpuestos(string descr, double importe) 
        {
            List<Entidades.IvaVentasTotXImpuestos> listaAux = listaTotXIMP.FindAll(delegate(Entidades.IvaVentasTotXImpuestos txi)
            {
                return txi.Descr == descr;
            });
            if (listaAux.Count == 0)
            {
                Entidades.IvaVentasTotXImpuestos itximp = new Entidades.IvaVentasTotXImpuestos();
                itximp.Descr = descr;
                itximp.ImporteTotal = importe;
                listaTotXIMP.Add(itximp);
            }
            else
            {
                listaAux[0].ImporteTotal += importe;
            }
        }
        
        private void TotalesXIVA(string concepto, double alicuota, double importeNG, double importeIVA) 
        {
            List<Entidades.IvaVentasTotXIVA> listaAux = listaTotXIVA.FindAll(delegate(Entidades.IvaVentasTotXIVA txi)
            {
                return txi.Concepto == concepto && txi.Alicuota == alicuota;
            });
            if (listaAux.Count == 0)
            {
                Entidades.IvaVentasTotXIVA itxiva = new Entidades.IvaVentasTotXIVA();
                itxiva.Concepto = concepto;
                itxiva.ImporteNG = importeNG;
                itxiva.ImporteTotal = importeIVA;
                itxiva.Alicuota = alicuota;
                listaTotXIVA.Add(itxiva);
            }
            else
            {
                listaAux[0].ImporteNG += importeNG;
                listaAux[0].ImporteTotal += importeIVA;
            }
        }
        private void TotalesIVAXComprobante(string concepto, double alicuota, double importeNG, double importeIVA)
        {
            List<Entidades.IvaVentasTotXIVA> listaAux = listaTotIVAxComprobante.FindAll(delegate(Entidades.IvaVentasTotXIVA txi)
            {
                return txi.Concepto == concepto && txi.Alicuota == alicuota;
            });
            if (listaAux.Count == 0)
            {
                Entidades.IvaVentasTotXIVA itxiva = new Entidades.IvaVentasTotXIVA();
                itxiva.Concepto = concepto;
                itxiva.ImporteNG = importeNG;
                itxiva.ImporteTotal = importeIVA;
                itxiva.Alicuota = alicuota;
                listaTotIVAxComprobante.Add(itxiva);
            }
            else
            {
                listaAux[0].ImporteNG += importeNG;
            }
        }
    }
}
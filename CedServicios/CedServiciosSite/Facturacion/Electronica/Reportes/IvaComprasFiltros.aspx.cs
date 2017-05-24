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
    public partial class IvaComprasFiltros : System.Web.UI.Page
    {
        List<Entidades.IvaComprasTotXImpuestos> listaTotXIMP;
        List<Entidades.IvaComprasTotXIVA> listaTotXIVA;
        List<Entidades.IvaComprasTotXIVA> listaTotIVAxComprobante;

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
                    nc.Id = "Compra";
                    listaC = RN.Comprobante.ListaFiltradaIvaYMovimientos(estados, FechaDesdeTextBox.Text, FechaHastaTextBox.Text, persona, nc, false, "", sesion);

                    Entidades.IvaCompras ivaCompras = new Entidades.IvaCompras();
                    ivaCompras.Cuit = sesion.Cuit.Nro;
                    ivaCompras.PeriodoDsd = FechaDesdeTextBox.Text.Substring(6, 2) + "/" + FechaDesdeTextBox.Text.Substring(4, 2) + "/" + FechaDesdeTextBox.Text.Substring(0, 4);
                    ivaCompras.PeriodoHst = FechaHastaTextBox.Text.Substring(6, 2) + "/" + FechaHastaTextBox.Text.Substring(4, 2) + "/" + FechaHastaTextBox.Text.Substring(0, 4);

                    System.Xml.Serialization.XmlSerializer x;
                    byte[] bytes;
                    System.IO.MemoryStream ms;
                    FeaEntidades.InterFacturas.lote_comprobantes lote;

                    ivaCompras.IvaComprasComprobantes = new List<Entidades.IvaComprasComprobantes>();

                    listaTotXIMP = new List<Entidades.IvaComprasTotXImpuestos>();
                    listaTotXIVA = new List<Entidades.IvaComprasTotXIVA>();
                    foreach (Entidades.Comprobante comprobante in listaC)
                    {
                        Entidades.IvaComprasComprobantes icc = new Entidades.IvaComprasComprobantes();
                        icc.PtoVta = comprobante.NroPuntoVta.ToString();
                        icc.TipoComp = comprobante.TipoComprobante.Descr;
                        icc.NroComp = comprobante.Nro.ToString();
                        icc.NroDoc = comprobante.NroDoc.ToString();
                        icc.TipoCompCodigo = comprobante.TipoComprobante.Id.ToString();
                        icc.RazSoc = comprobante.RazonSocial;
                        if (comprobante.Documento.Tipo.Id != "99")
                        {
                            icc.TipoDoc = comprobante.DescrTipoDoc;
                        }
                        else
                        {
                            if (icc.RazSoc == "")
                            {
                                icc.TipoDoc = "Sin identificar/compra global";
                            }
                            else
                            {
                                icc.TipoDoc = "";
                            }
                        }
                        
                        double signo = 1;
                        if (("/3/8/13/").IndexOf("/" + icc.TipoCompCodigo + "/") != -1)
                        {
                            signo = -1;
                        }

                        icc.ImporteTotal = comprobante.Importe * signo;
                        icc.FechaEmi = comprobante.Fecha.ToString("dd/MM/yyyy");

                        lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                        x = new System.Xml.Serialization.XmlSerializer(lote.GetType());

                        comprobante.Request = comprobante.Request.Replace("iso-8859-1", "utf-16");
                        bytes = new byte[comprobante.Request.Length * sizeof(char)];
                        System.Buffer.BlockCopy(comprobante.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
                        ms = new System.IO.MemoryStream(bytes);
                        ms.Seek(0, System.IO.SeekOrigin.Begin);
                        lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                        icc.Exento = lote.comprobante[0].resumen.importe_operaciones_exentas * signo;
                        icc.NoGravado = lote.comprobante[0].resumen.importe_total_concepto_no_gravado * signo;
                        icc.Gravado = lote.comprobante[0].resumen.importe_total_neto_gravado * signo;
                        double otrosImp = Math.Round(lote.comprobante[0].resumen.importe_total_ingresos_brutos + lote.comprobante[0].resumen.importe_total_impuestos_nacionales + lote.comprobante[0].resumen.importe_total_impuestos_municipales + lote.comprobante[0].resumen.importe_total_impuestos_internos, 2);
                        icc.OtrosImp = otrosImp * signo;
                        icc.Iva = lote.comprobante[0].resumen.impuesto_liq * signo;
                        
                        icc.Moneda = lote.comprobante[0].resumen.codigo_moneda;
                        if (icc.Moneda != "PES")
                        {
                            monedasExtranjeras = true;
                        }
                        icc.Cambio = lote.comprobante[0].resumen.tipo_de_cambio;
                        icc.Concepto = lote.comprobante[0].cabecera.informacion_comprobante.codigo_concepto.ToString();
                        if (lote.comprobante[0].resumen.importes_moneda_origen != null)
                        {
                            icc.ImporteTotalME = lote.comprobante[0].resumen.importes_moneda_origen.importe_total_factura * signo;
                        }
                        ivaCompras.IvaComprasComprobantes.Add(icc);
                        
                        //Totales por Impuestos y Totales por alicuota de IVA y concepto
                        ivaCompras.IvaComprasTotXImpuestos = new List<Entidades.IvaComprasTotXImpuestos>();
                        ivaCompras.IvaComprasTotXIVA = new List<Entidades.IvaComprasTotXIVA>();
                        if (lote.comprobante[0].resumen.impuestos != null)
                        {
                            for (int z = 0; z < lote.comprobante[0].resumen.impuestos.Length; z++)
                            {
                                double importe = lote.comprobante[0].resumen.impuestos[z].importe_impuesto * signo;
                                listaTotIVAxComprobante = new List<Entidades.IvaComprasTotXIVA>();
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
                                            List<Entidades.IvaComprasTotXIVA> listaAux = listaTotIVAxComprobante.FindAll(delegate(Entidades.IvaComprasTotXIVA txi)
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
                    if (ivaCompras.IvaComprasComprobantes.Count != 0)
                    {
                        if (listaTotXIMP.Count != 0)
                        {
                            ivaCompras.IvaComprasTotXImpuestos = listaTotXIMP;
                        }
                        else
                        {
                            //Para arreglar bug en towebs.
                            Entidades.IvaComprasTotXImpuestos totXimp = new Entidades.IvaComprasTotXImpuestos();
                            totXimp.Descr = "";
                            totXimp.ImporteTotal = 0;
                            ivaCompras.IvaComprasTotXImpuestos.Add(totXimp);
                        }
                        if (listaTotXIVA.Count != 0)
                        {
                            ivaCompras.IvaComprasTotXIVA = listaTotXIVA;
                        }
                        else
                        {
                            //Para arreglar bug en towebs.
                            Entidades.IvaComprasTotXIVA totXiva = new Entidades.IvaComprasTotXIVA();
                            totXiva.Concepto = "";
                            totXiva.Alicuota = 0;
                            totXiva.ImporteNG = 0;
                            totXiva.ImporteTotal = 0;
                            ivaCompras.IvaComprasTotXIVA.Add(totXiva);
                        }
                    }
                    Session["formatoRptExportar"] = FormatosRptExportarDropDownList.SelectedValue;
                    Session["mostrarFechaYHora"] = FechaYHoraCheckBox.Checked;
                    Session["monedasExtranjeras"] = monedasExtranjeras;
                    if (ivaCompras.IvaComprasComprobantes.Count != 0)
                    {
                        Session["ivaCompras"] = ivaCompras;
                        Response.Redirect("~/Facturacion/Electronica/Reportes/IvaComprasWebForm.aspx", true);
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
            List<Entidades.IvaComprasTotXImpuestos> listaAux = listaTotXIMP.FindAll(delegate(Entidades.IvaComprasTotXImpuestos txi)
            {
                return txi.Descr == descr;
            });
            if (listaAux.Count == 0)
            {
                Entidades.IvaComprasTotXImpuestos itximp = new Entidades.IvaComprasTotXImpuestos();
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
            List<Entidades.IvaComprasTotXIVA> listaAux = listaTotXIVA.FindAll(delegate(Entidades.IvaComprasTotXIVA txi)
            {
                return txi.Concepto == concepto && txi.Alicuota == alicuota;
            });
            if (listaAux.Count == 0)
            {
                Entidades.IvaComprasTotXIVA itxiva = new Entidades.IvaComprasTotXIVA();
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
            List<Entidades.IvaComprasTotXIVA> listaAux = listaTotIVAxComprobante.FindAll(delegate(Entidades.IvaComprasTotXIVA txi)
            {
                return txi.Concepto == concepto && txi.Alicuota == alicuota;
            });
            if (listaAux.Count == 0)
            {
                Entidades.IvaComprasTotXIVA itxiva = new Entidades.IvaComprasTotXIVA();
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
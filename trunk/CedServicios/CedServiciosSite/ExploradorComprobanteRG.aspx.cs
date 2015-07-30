﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Xml;
using System.IO;
using Ionic.Zip;
using System.Diagnostics;
using System.Net;

namespace CedServicios.Site
{
    public partial class ExploradorComprobanteRG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    ViewState["NaturalezaComprobante"] = RN.NaturalezaComprobante.Lista(Entidades.Enum.Elemento.Comprobante, sesion);
                    NaturalezaComprobanteDropDownList.DataSource = (List<Entidades.NaturalezaComprobante>)ViewState["NaturalezaComprobante"];
                    NaturalezaComprobanteDropDownList.SelectedIndex = 0;
                    if (sesion.UsuarioDemo == true)
                    {
                        FechaDesdeTextBox.Text = "20130101";
                        FechaHastaTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                    }
                    else
                    {
                        FechaDesdeTextBox.Text = DateTime.Today.ToString("yyyyMM01");
                        FechaHastaTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                    }
                    ComprobantesGridView.Columns[Funciones.IndiceColumnaXNombre(ComprobantesGridView, "Fecha emi.")].Visible = false;

                    EstadoVigenteCheckBox.Checked = true;
                    EstadoPteEnvioCheckBox.Checked = false;
                    EstadoPteConfCheckBox.Checked = false;
                    EstadoDeBajaCheckBox.Checked = false;
                    EstadoPteAutorizCheckBox.Checked = false;
                    EstadoRechCheckBox.Checked = false;
                    ComprobantesGridView.Columns[0].Visible = true;
                    
                    ViewState["Personas"] = RN.Persona.ListaPorCuit(false, true, Entidades.Enum.TipoPersona.Ambos, sesion);
                    ClienteDropDownList.DataSource = (List<Entidades.Persona>)ViewState["Personas"];
                    DataBind();
                    if (ClienteDropDownList.Items.Count > 0)
                    {
                        ClienteDropDownList.SelectedValue = "0";
                    }
                }
            }
        }
        protected void ComprobantesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MensajeLabel.Text = "";
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
            Entidades.Comprobante comprobante = lista[item];
            string script;

            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            string DetalleIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["DetalleIBKUtilizarServidorExterno"];
            org.dyndns.cedweb.detalle.DetalleIBK clcdyndns = new org.dyndns.cedweb.detalle.DetalleIBK();
            org.dyndns.cedweb.detalle.cecd cecd = new org.dyndns.cedweb.detalle.cecd();
            List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado> listaR = new List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado>();

            switch (e.CommandName)
            {
                case "Consulta":
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Consulta, comprobante);
                    script = "window.open('/ComprobanteConsulta.aspx', '');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    break;
            }
        }
        private void GrabarLogTexto(string archivo, string mensaje)
        {
            try
            {
                using (FileStream fs = File.Open(Server.MapPath(archivo), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + "  " + mensaje);
                    }
                }
            }
            catch
            {
            }
        }
        public string Truncate(string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
        protected void ComprobantesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[Funciones.IndiceColumnaXNombre((GridView)sender, "Estado")].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
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
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<Entidades.Comprobante> lista = new List<Entidades.Comprobante>();
                MensajeLabel.Text = String.Empty;
                Entidades.Persona persona;
                if (ClienteDropDownList.SelectedIndex >= 0)
                {
                    persona = ((List<Entidades.Persona>)ViewState["Personas"])[ClienteDropDownList.SelectedIndex];
                }
                else
                {
                    persona = new Entidades.Persona();
                }
                Entidades.NaturalezaComprobante naturalezaComprobante;
                if (NaturalezaComprobanteDropDownList.SelectedIndex >= 0)
                {
                    naturalezaComprobante = ((List<Entidades.NaturalezaComprobante>)ViewState["NaturalezaComprobante"])[NaturalezaComprobanteDropDownList.SelectedIndex];
                }
                else
                {
                    naturalezaComprobante = new Entidades.NaturalezaComprobante();
                }
                List<Entidades.Estado> estados = new List<Entidades.Estado>();
                if (EstadoVigenteCheckBox.Checked) estados.Add(new Entidades.EstadoVigente());
                if (EstadoPteEnvioCheckBox.Checked) estados.Add(new Entidades.EstadoPteEnvio());
                if (EstadoPteConfCheckBox.Checked) estados.Add(new Entidades.EstadoPteConf());
                if (EstadoDeBajaCheckBox.Checked) estados.Add(new Entidades.EstadoDeBaja());
                if (EstadoPteAutorizCheckBox.Checked) estados.Add(new Entidades.EstadoPteAutoriz());
                if (EstadoRechCheckBox.Checked) estados.Add(new Entidades.EstadoRech());
                lista = RN.Comprobante.ListaFiltrada(estados, FechaDesdeTextBox.Text, FechaHastaTextBox.Text, persona, naturalezaComprobante, false, DetalleTextBox.Text, sesion);
                if (lista.Count == 0)
                {
                    DescargarButton.Enabled = false;
                    ComprobantesGridView.DataSource = null;
                    ComprobantesGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Comprobantes que satisfagan la busqueda";
                }
                else
                {
                    DescargarButton.Enabled = true;
                    ComprobantesGridView.DataSource = lista;
                    ViewState["Comprobantes"] = lista;
                    ComprobantesGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
        protected void AccionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int item = row.RowIndex;
            List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
            Entidades.Comprobante comprobante = lista[item];
            string comando = ddl.SelectedValue;
            ddl.ClearSelection();

            switch (comando)
            {
                case "ExportarRG3685":
                    #region ExportarRG3685
                    List<Entidades.Comprobante> laux = new List<Entidades.Comprobante>();
                    laux.Add(lista[item]);
                    GenerarInterfazRG3685(laux);
                    #endregion
                    break;
            }
        }

        protected void DescargarButton_Click(object sender, EventArgs e)
        {
            List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
            foreach (Entidades.Comprobante comprobante in lista)
            {
                if (comprobante.Estado != "Vigente")
                {

                    MensajeLabel.Text = "No es posible descargar la Interfaz RG3586. Hay comprobantes que no están vigentes.";
                    DescargarButton.Enabled = false;
                    return;
                }
            }
            GenerarInterfazRG3685(lista);
        }

        private void GenerarInterfazRG3685(List<Entidades.Comprobante> Comprobantes)
        {
            System.Xml.Serialization.XmlSerializer x;
            byte[] bytes;
            System.IO.MemoryStream ms;
            string script;
            FeaEntidades.InterFacturas.lote_comprobantes lote;
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            bool HayVentas = false;
            bool HayCompras = false;

            //Crear nombre de archivo default sin extensión
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(sesion.Cuit.Nro);
            sb.Append("-");
            sb.Append(DateTime.Now.ToString("yyyyMMdd"));


            if (Comprobantes.Count > 0)
            {
                //Crear nombre de archivo ZIP
                System.Text.StringBuilder sbZIP = new System.Text.StringBuilder();
                sbZIP.Append(sb.ToString() + ".zip");

                //Crear archivo VENTAS CABECERA
                System.Text.StringBuilder sbVENTASCab = new System.Text.StringBuilder();
                sbVENTASCab.Append("REGINFO_CV_VENTAS_CBTE.TXT");    //sb.ToString() + "-CABECERA_EMISOR.txt");
                System.IO.MemoryStream m = new System.IO.MemoryStream();
                System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbVENTASCab.ToString()), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();

                //Crear archivo VENTAS ALICUOTAS
                System.Text.StringBuilder sbVENTASAlic = new System.Text.StringBuilder();
                sbVENTASAlic.Append("REGINFO_CV_VENTAS_ALICUOTAS.TXT");     //sb.ToString() + "-DETALLE.txt");
                m = new System.IO.MemoryStream();
                fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbVENTASAlic.ToString()), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();

                //Crear archivo COMPRAS CABECERA
                System.Text.StringBuilder sbCOMPRASCab = new System.Text.StringBuilder();
                sbCOMPRASCab.Append("REGINFO_CV_COMPRAS_CBTE.TXT");    //sb.ToString() + "-CABECERA_EMISOR.txt");
                m = new System.IO.MemoryStream();
                fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbCOMPRASCab.ToString()), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();

                //Crear archivo COMPRAS ALICUOTAS
                System.Text.StringBuilder sbCOMPRASAlic = new System.Text.StringBuilder();
                sbCOMPRASAlic.Append("REGINFO_CV_COMPRAS_ALICUOTAS.TXT");     //sb.ToString() + "-DETALLE.txt");
                m = new System.IO.MemoryStream();
                fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbCOMPRASAlic.ToString()), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();

                foreach (Entidades.Comprobante comprobante in Comprobantes)
                {
                    if (comprobante.NaturalezaComprobante.Id == "Venta")
                    {
                        HayVentas = true;
                        lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                        x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                        if (comprobante.Estado != "Vigente")
                        {
                            MensajeLabel.Text = "El comprobante no está vigente.";
                            return;
                        }
                        try
                        {
                            comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                            bytes = new byte[comprobante.Response.Length * sizeof(char)];
                            System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                            ms = new System.IO.MemoryStream(bytes);
                            ms.Seek(0, System.IO.SeekOrigin.Begin);
                            lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                            //Guardar info en archivo VENTAS CABECERA
                            System.Text.StringBuilder sbDataVENTASCab = new System.Text.StringBuilder();
                            //string Campo2 = String.Format("{0,11}", sesion.Cuit.Nro);
                            string Campo1 = lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision;
                            string Campo2 = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("000");
                            string Campo3 = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString("00000");
                            string Campo4 = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString(new string(Convert.ToChar("0"), 20));
                            string Campo5 = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString(new string(Convert.ToChar("0"), 20));
                            string Campo6 = lote.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString("00");
                            string Campo7 = lote.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio.ToString(new string(Convert.ToChar("0"), 20));
                            string Campo8 = Truncate(String.Format("{0,-30}", lote.comprobante[0].cabecera.informacion_comprador.denominacion), 30);

                            string Campo9 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo10 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            //string CampoXX = String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo11 = new string(Convert.ToChar("0"), 15);   //Percepción a no categorizados
                            string Campo12 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            //Importe de percepciones o pagos a cuenta de impuestos nacionales
                            string Campo13 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo14 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo15 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo16 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo17 = String.Format("{0,-3}", lote.comprobante[0].resumen.codigo_moneda);
                            string Campo18 = String.Format("{0,11}", lote.comprobante[0].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 4) + ".000000")).Substring(0, 4) + String.Format("{0,11}", lote.comprobante[0].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 4) + ".000000")).Substring(5, 6);
                            int CantAlicuotas = 0;
                            if (lote.comprobante[0].resumen.cant_alicuotas_iva == 0)
                            {
                                if (lote.comprobante[0].resumen.impuestos != null)
                                {
                                    for (int z = 0; z < lote.comprobante[0].resumen.impuestos.Length; z++)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 1)
                                        {
                                            CantAlicuotas += 1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                CantAlicuotas = lote.comprobante[0].resumen.cant_alicuotas_iva;
                            }
                            string Campo19 = String.Format("{0,1}", CantAlicuotas);
                            string Campo20 = String.Format("{0,1}", lote.comprobante[0].cabecera.informacion_comprobante.codigo_operacion);
                            string Campo21 = new string(Convert.ToChar("0"), 15);  //Otros Tributos
                            string Campo22 = String.Format("{0,-8}", lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento);

                            sbDataVENTASCab.AppendLine(Campo1 + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11 + Campo12 + Campo13 + Campo14 + Campo15 + Campo16 + Campo17 + Campo18 + Campo19 + Campo20 + Campo21 + Campo22);
                            using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbVENTASCab.ToString())))
                            {
                                outfile.Write(sbDataVENTASCab.ToString());
                            }

                            //Guardar info en archivo VENTAS ALICUOTAS
                            System.Text.StringBuilder sbDataVENTASAlic = new System.Text.StringBuilder();
                            for (int z = 0; z < lote.comprobante[0].resumen.impuestos.Length; z++)
                            {
                                if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 1)
                                {
                                    Campo1 = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("000");
                                    Campo2 = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString("00000");
                                    Campo3 = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString(new string(Convert.ToChar("0"), 20));

                                    double baseImponible = lote.comprobante[0].resumen.impuestos[z].base_imponible;
                                    if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 0)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            for (int k = 0; k < lote.comprobante[0].detalle.linea.Length; k++)
                                            {
                                                if (lote.comprobante[0].detalle.linea[k] == null) { break; }
                                                if (lote.comprobante[0].detalle.linea[k].indicacion_exento_gravado != null && lote.comprobante[0].detalle.linea[k].indicacion_exento_gravado.Trim().ToUpper() == "G" && lote.comprobante[0].detalle.linea[k].alicuota_iva == 0)
                                                {
                                                    baseImponible += Math.Round(lote.comprobante[0].detalle.linea[k].importe_total_articulo, 2);
                                                }
                                            }
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0003";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                    if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 10.5)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            baseImponible += Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2);
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0004";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                    else if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 21)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            baseImponible += Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2);
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0005";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                    else if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 27)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            baseImponible += Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2);
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0006";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                    else if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 5)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            baseImponible += Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2);
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0008";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                    else if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 2.5)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            baseImponible += Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2);
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0009";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                }
                            }

                            sbDataVENTASAlic.AppendLine(Campo1 + Campo2 + Campo3 + Campo4 + Campo5 + Campo6);
                            using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbVENTASAlic.ToString())))
                            {
                                outfile.Write(sbDataVENTASAlic.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            script = "Problemas para generar la interfaz.\\n" + ex.Message + "\\n" + ex.StackTrace;
                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                            MensajeLabel.Text = script;
                        }
                    }
                    else if (comprobante.NaturalezaComprobante.Id == "Compra")
                    {
                        HayCompras = true;
                        lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                        x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                        if (comprobante.Estado != "Vigente")
                        {
                            MensajeLabel.Text = "El comprobante no está vigente.";
                            return;
                        }
                        try
                        {
                            comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                            bytes = new byte[comprobante.Response.Length * sizeof(char)];
                            System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                            ms = new System.IO.MemoryStream(bytes);
                            ms.Seek(0, System.IO.SeekOrigin.Begin);
                            lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                            //Guardar info en archivo COMPRAS CABECERA
                            System.Text.StringBuilder sbDataCOMPRASCab = new System.Text.StringBuilder();
                            //string Campo2 = String.Format("{0,11}", sesion.Cuit.Nro);
                            string Campo1 = lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision;
                            string Campo2 = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("000");
                            string Campo3 = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString("00000");
                            string Campo4 = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString(new string(Convert.ToChar("0"), 20));
                            string Campo5 = new string(Convert.ToChar("0"), 20);  //Nro. de despacho de importación
                            string Campo6 = "80";
                            string Campo7 = lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString(new string(Convert.ToChar("0"), 20));
                            string Campo8 = Truncate(String.Format("{0,-30}", lote.comprobante[0].cabecera.informacion_comprador.denominacion), 30);

                            string Campo9 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo10 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            //string CampoXX = String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo11 = new string(Convert.ToChar("0"), 15);   //Percepción a no categorizados
                            string Campo12 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            //Importe de percepciones o pagos a cuenta de impuestos nacionales
                            string Campo13 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo14 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo15 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo16 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo17 = String.Format("{0,-3}", lote.comprobante[0].resumen.codigo_moneda);
                            string Campo18 = String.Format("{0,11}", lote.comprobante[0].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 4) + ".000000")).Substring(0, 4) + String.Format("{0,11}", lote.comprobante[0].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 4) + ".000000")).Substring(5, 6);
                            int CantAlicuotas = 0;
                            if (lote.comprobante[0].resumen.cant_alicuotas_iva == 0)
                            {
                                if (lote.comprobante[0].resumen.impuestos != null)
                                {
                                    for (int z = 0; z < lote.comprobante[0].resumen.impuestos.Length; z++)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 1)
                                        {
                                            CantAlicuotas += 1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                CantAlicuotas = lote.comprobante[0].resumen.cant_alicuotas_iva;
                            }
                            string Campo19 = String.Format("{0,1}", CantAlicuotas);
                            string Campo20 = String.Format("{0,1}", lote.comprobante[0].cabecera.informacion_comprobante.codigo_operacion);
                            string Campo21 = new string(Convert.ToChar("0"), 15);           //Crédito Fiscal Computable
                            string Campo22 = new string(Convert.ToChar("0"), 15);           //Otros Tributos
                            string Campo23 = new string(Convert.ToChar("0"), 11);           //CUIT emisor / corredor
                            string Campo24 = Truncate(String.Format("{0,-30}", ""), 30);    //Denominación del emisor / corredor
                            string Campo25 = new string(Convert.ToChar("0"), 15);           //IVA comisión

                            //string Campo25 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_neto_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_neto_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            //string Campo26 = String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);

                            sbDataCOMPRASCab.AppendLine(Campo1 + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11 + Campo12 + Campo13 + Campo14 + Campo15 + Campo16 + Campo17 + Campo18 + Campo19 + Campo20 + Campo21 + Campo22 + Campo23 + Campo24 + Campo25);
                            using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbCOMPRASCab.ToString())))
                            {
                                outfile.Write(sbDataCOMPRASCab.ToString());
                            }

                            //Guardar info en archivo COMPRAS ALICUOTAS
                            System.Text.StringBuilder sbDataCOMPRASAlic = new System.Text.StringBuilder();
                            for (int z = 0; z < lote.comprobante[0].resumen.impuestos.Length; z++)
                            {
                                if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 1)
                                {
                                    Campo1 = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("000");
                                    Campo2 = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString("00000");
                                    Campo3 = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString(new string(Convert.ToChar("0"), 20));

                                    double baseImponible = lote.comprobante[0].resumen.impuestos[z].base_imponible;
                                    if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 0)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            for (int k = 0; k < lote.comprobante[0].detalle.linea.Length; k++)
                                            {
                                                if (lote.comprobante[0].detalle.linea[k] == null) { break; }
                                                if (lote.comprobante[0].detalle.linea[k].indicacion_exento_gravado != null && lote.comprobante[0].detalle.linea[k].indicacion_exento_gravado.Trim().ToUpper() == "G" && lote.comprobante[0].detalle.linea[k].alicuota_iva == 0)
                                                {
                                                    baseImponible += Math.Round(lote.comprobante[0].detalle.linea[k].importe_total_articulo, 2);
                                                }
                                            }
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0003";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                    if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 10.5)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            baseImponible += Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2);
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0004";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                    else if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 21)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            baseImponible += Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2);
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0005";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                    else if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 27)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            baseImponible += Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2);
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0006";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                    else if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 5)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            baseImponible += Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2);
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0008";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                    else if (lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto == 2.5)
                                    {
                                        if (lote.comprobante[0].resumen.impuestos[z].base_imponible == 0)
                                        {
                                            baseImponible += Math.Round((lote.comprobante[0].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[0].resumen.impuestos[z].porcentaje_impuesto, 2);
                                        }
                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        Campo5 = "0009";
                                        Campo6 = String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                    }
                                }
                            }

                            sbDataCOMPRASAlic.AppendLine(Campo1 + Campo2 + Campo3 + Campo4 + Campo5 + Campo6);
                            using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbCOMPRASAlic.ToString())))
                            {
                                outfile.Write(sbDataCOMPRASAlic.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            script = "Problemas para generar la interfaz.\\n" + ex.Message + "\\n" + ex.StackTrace;
                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                            MensajeLabel.Text = script;
                        }
                    }
                    else
                    {
                        MensajeLabel.Text = "La naturaleza del comprobante (" + comprobante.NaturalezaComprobante.Id + ") no está permitida para la generación de la Interfaz RG.3685";
                    }

                    //Descargar ZIP ( Ventas y Alicuotas )
                    string filename = sbZIP.ToString();
                    String dlDir = @"~/Temp/";
                    String path = Server.MapPath(dlDir + filename);
                    System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                    System.IO.FileInfo toVENTASCab = new System.IO.FileInfo(Server.MapPath(dlDir + sbVENTASCab.ToString()));
                    System.IO.FileInfo toVENTASAlic = new System.IO.FileInfo(Server.MapPath(dlDir + sbVENTASAlic.ToString()));
                    System.IO.FileInfo toCOMPRASCab = new System.IO.FileInfo(Server.MapPath(dlDir + sbCOMPRASCab.ToString()));
                    System.IO.FileInfo toCOMPRASAlic = new System.IO.FileInfo(Server.MapPath(dlDir + sbCOMPRASAlic.ToString()));

                    using (ZipFile zip = new ZipFile())
                    {
                        if (HayVentas)
                        {
                            zip.AddFile(Server.MapPath(dlDir + sbVENTASCab.ToString()), "");
                            zip.AddFile(Server.MapPath(dlDir + sbVENTASAlic.ToString()), "");
                        }
                        if (HayCompras)
                        {
                            zip.AddFile(Server.MapPath(dlDir + sbCOMPRASCab.ToString()), "");
                            zip.AddFile(Server.MapPath(dlDir + sbCOMPRASAlic.ToString()), "");
                        }
                        zip.Save(Server.MapPath(dlDir + filename));
                        toVENTASCab.Delete();
                        toVENTASAlic.Delete();
                        toCOMPRASCab.Delete();
                        toCOMPRASAlic.Delete();
                    }
                    if (toDownload.Exists)
                    {
                        script = "window.open('DescargaTemporarios.aspx?archivo=" + sbZIP.ToString() + "', '');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    }
                    else
                    {
                        WebForms.Excepciones.Redireccionar(new EX.Validaciones.ArchivoInexistente(filename), "~/NotificacionDeExcepcion.aspx");
                    }
                }
            }
            else
            {
                MensajeLabel.Text = "No hay información para procesar la Interfaz RG.3685";
            }
        }

        private bool Existe(string URLfile)
        {
            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(URLfile);
            bool existe = true;
            request.Method = "HEAD";
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                existe = false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return existe;
        }
    }
}

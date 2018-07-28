using System;
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
    public partial class ExploradorComprobante : System.Web.UI.Page
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
                    string parametros = @HttpContext.Current.Request.Url.Query.ToString().Replace("?", String.Empty);
                    char[] delimitador = { '-' };
                    string[] itemsParametros = parametros.Split(delimitador);
                    TratamientoTextBox.Text = itemsParametros[0];
                    ElementoTextBox.Text = itemsParametros[1];
                    switch (ElementoTextBox.Text)
                    {
                        case "Comprobante":
                            if (TratamientoTextBox.Text == "Envio")
                            {
                                ViewState["NaturalezaComprobante"] = RN.NaturalezaComprobante.Lista("Venta", sesion);
                            }
                            else
                            {
                                ViewState["NaturalezaComprobante"] = RN.NaturalezaComprobante.Lista(Entidades.Enum.Elemento.Comprobante, sesion);
                            }
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
                            break;
                        case "Contrato":
                            ViewState["NaturalezaComprobante"] = RN.NaturalezaComprobante.Lista(Entidades.Enum.Elemento.Contrato, sesion);
                            NaturalezaComprobanteDropDownList.DataSource = (List<Entidades.NaturalezaComprobante>)ViewState["NaturalezaComprobante"];
                            ComprobantesGridView.Columns[Funciones.IndiceColumnaXNombre(ComprobantesGridView, "Naturaleza")].Visible = false;
                            ComprobantesGridView.Columns[Funciones.IndiceColumnaXNombre(ComprobantesGridView, "Fecha")].Visible = false;
                            ComprobantesGridView.Columns[Funciones.IndiceColumnaXNombre(ComprobantesGridView, "Fecha Vto")].Visible = false;
                            ComprobantesGridView.Columns[Funciones.IndiceColumnaXNombre(ComprobantesGridView, "Nro.Lote")].Visible = false;
                            ComprobantesGridView.Columns[Funciones.IndiceColumnaXNombre(ComprobantesGridView, "Acción")].Visible = false;
                            DetallePanel.Visible = false;
                            PeriodoEmisionPanel.Visible = false;
                            break;
                    }
                    string descrTratamiento = TratamientoTextBox.Text;
                    switch (TratamientoTextBox.Text)
                    {
                        case "Consulta":
                            EstadoVigenteCheckBox.Checked = true;
                            EstadoPteEnvioCheckBox.Checked = true;
                            EstadoPteConfCheckBox.Checked = true;
                            EstadoDeBajaCheckBox.Checked = false;
                            EstadoPteAutorizCheckBox.Checked = true;
                            EstadoRechCheckBox.Checked = false;
                            ComprobantesGridView.Columns[0].Visible = true;
                            break;
                        case "Baja/Anul.baja":
                            EstadoVigenteCheckBox.Checked = ElementoTextBox.Text == "Contrato";
                            EstadoPteEnvioCheckBox.Checked = true;
                            EstadoPteConfCheckBox.Checked = true;
                            EstadoDeBajaCheckBox.Checked = true;
                            EstadoPteAutorizCheckBox.Checked = true;
                            EstadoRechCheckBox.Checked = true;
                            ComprobantesGridView.Columns[1].Visible = true;
                            ComprobantesGridView.Columns[2].Visible = true;
                            ComprobantesGridView.Columns[Funciones.IndiceColumnaXNombre(ComprobantesGridView, "Acción")].Visible = false;
                            EstadosPanel.Enabled = false;
                            break;
                        case "Envio":
                            EstadoVigenteCheckBox.Checked = false;
                            EstadoPteEnvioCheckBox.Checked = true;
                            EstadoPteConfCheckBox.Checked = false;
                            EstadoDeBajaCheckBox.Checked = false;
                            EstadoPteAutorizCheckBox.Checked = false;
                            EstadoRechCheckBox.Checked = false;
                            ComprobantesGridView.Columns[3].Visible = true;
                            ComprobantesGridView.Columns[Funciones.IndiceColumnaXNombre(ComprobantesGridView, "Acción")].Visible = false;
                            EstadosPanel.Enabled = false;
                            descrTratamiento += " (AFIP/ITF)";
                            break;
                        case "Modificacion":
                            EstadoVigenteCheckBox.Checked = ElementoTextBox.Text == "Contrato";
                            EstadoPteEnvioCheckBox.Checked = true;
                            EstadoPteConfCheckBox.Checked = true;
                            EstadoDeBajaCheckBox.Checked = false;
                            EstadoPteAutorizCheckBox.Checked = true;
                            EstadoRechCheckBox.Checked = false;
                            ComprobantesGridView.Columns[4].Visible = true;
                            ComprobantesGridView.Columns[Funciones.IndiceColumnaXNombre(ComprobantesGridView, "Acción")].Visible = false;
                            EstadosPanel.Enabled = false;
                            descrTratamiento = "Modificación";
                            break;
                    }
                    TituloPaginaLabel.Text = descrTratamiento + " de " + ElementoTextBox.Text + "s";
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
            int auxPV;
            string idtipo;

            switch (e.CommandName)
            {
                case "Consulta":
                    RN.Comprobante.LeerMinutas(comprobante, sesion);
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Consulta, comprobante);
                    if (comprobante.NaturalezaComprobante.Id == "Compra")
                    {
                        script = "window.open('/ComprobanteConsulta.aspx', '');";
                    }
                    else
                    {
                        auxPV = Convert.ToInt32(comprobante.NroPuntoVta);
                        idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        if (idtipo != "Turismo")
                        {
                            script = "window.open('/ComprobanteConsulta.aspx', '');";
                        }
                        else
                        {
                            script = "window.open('/ComprobanteConsultaTurismo.aspx', '');";
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    break;
                case "Baja/Anul.baja":
                    RN.Comprobante.LeerMinutas(comprobante, sesion);
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Baja_AnulBaja, comprobante);
                    if (comprobante.NaturalezaComprobante.Id == "Compra")
                    {
                        script = "window.open('/ComprobanteConsulta.aspx', '');";
                    }
                    else
                    {
                        auxPV = Convert.ToInt32(comprobante.NroPuntoVta);
                        idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        if (idtipo != "Turismo")
                        {
                            script = "window.open('/ComprobanteConsulta.aspx', '');";
                        }
                        else
                        {
                            script = "window.open('/ComprobanteConsultaTurismo.aspx', '');";
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    break;
                case "BajaFisica":
                    RN.Comprobante.LeerMinutas(comprobante, sesion);
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Baja_Fisica, comprobante);
                    if (comprobante.NaturalezaComprobante.Id == "Compra")
                    {
                        script = "window.open('/ComprobanteConsulta.aspx', '');";
                    }
                    else
                    {
                        auxPV = Convert.ToInt32(comprobante.NroPuntoVta);
                        idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        if (idtipo != "Turismo")
                        {
                            script = "window.open('/ComprobanteConsulta.aspx', '');";
                        }
                        else
                        {
                            script = "window.open('/ComprobanteConsultaTurismo.aspx', '');";
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    break;
                case "Envio":
                    RN.Comprobante.LeerMinutas(comprobante, sesion);
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Envio, comprobante);
                    if (comprobante.NaturalezaComprobante.Id == "Compra")
                    {
                        script = "window.open('/ComprobanteConsulta.aspx', '');";
                    }
                    else
                    {
                        auxPV = Convert.ToInt32(comprobante.NroPuntoVta);
                        idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        if (idtipo != "Turismo")
                        {
                            script = "window.open('/ComprobanteConsulta.aspx', '');";
                        }
                        else
                        {
                            script = "window.open('/ComprobanteConsultaTurismo.aspx', '');";
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    break;
                case "Modificacion":
                    if (comprobante.NaturalezaComprobante.Id == "VentaContrato") 
                    {
                        Entidades.Persona persona = new Entidades.Persona();
                        persona.Cuit = comprobante.Cuit;
                        persona.Documento.Tipo = comprobante.Documento.Tipo;
                        persona.Documento.Nro = comprobante.Documento.Nro;
                        persona.IdPersona = comprobante.IdPersona;
                        persona.DesambiguacionCuitPais = comprobante.DesambiguacionCuitPais;
                        RN.Persona.LeerDestinatariosFrecuentes(persona, true, sesion);
                        comprobante.DatosEmailAvisoComprobanteContrato.DestinatariosFrecuentes = persona.DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes;
                    }
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Modificacion, comprobante);
                    if (comprobante.NaturalezaComprobante.Id == "Compra")
                    {
                        script = "window.open('/Facturacion/Electronica/Lote.aspx', '');";
                    }
                    else
                    {
                        auxPV = Convert.ToInt32(comprobante.NroPuntoVta);
                        idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        if (idtipo != "Turismo")
                        {
                            script = "window.open('/Facturacion/Electronica/Lote.aspx', '');";
                        }
                        else
                        {
                            script = "window.open('/Facturacion/Electronica/LoteCT.aspx', '');";
                        }
                    }
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
        private bool ValidacionFiltrosOK()
        {
            if (!RN.Funciones.ValidarFechaYYYYMMDD(FechaDesdeTextBox.Text))
            {
                MensajeLabel.Text = "Fecha Desde inválida. Formato correcto de 8 dígitos (YYYYMMDD).";
                return false;
            }
            if (!RN.Funciones.ValidarFechaYYYYMMDD(FechaHastaTextBox.Text))
            {
                MensajeLabel.Text = "Fecha Hasta inválida. Formato correcto de 8 dígitos (YYYYMMDD).";
                return false;
            }
            return true;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (ElementoTextBox.Text == "Contrato" || ValidacionFiltrosOK()) 
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

                    ContentPlaceHolder contentPlaceDefault = ((ContentPlaceHolder)Master.FindControl("ContentPlaceDefault"));
                    System.Web.UI.HtmlControls.HtmlAnchor control = ((System.Web.UI.HtmlControls.HtmlAnchor)contentPlaceDefault.FindControl("AyudaGrilla"));
                    control.Visible = false;
                    if (lista.Count == 0)
                    {
                        ComprobantesGridView.DataSource = null;
                        ComprobantesGridView.DataBind();
                        MensajeLabel.Text = "No se han encontrado " + ((naturalezaComprobante.Id == "VentaContrato") ? "Contrato" : "Comprobante") + "s que satisfagan la busqueda";
                    }
                    else
                    {
                        ComprobantesGridView.DataSource = lista;
                        ViewState["Comprobantes"] = lista;
                        ComprobantesGridView.DataBind();
                        control.Visible = true;
                    }
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
            FeaEntidades.InterFacturas.lote_comprobantes lote;
            FeaEntidades.Turismo.lote_comprobantes loteT;
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            string certificado;
            string DetalleIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["DetalleIBKUtilizarServidorExterno"];
            org.dyndns.cedweb.detalle.DetalleIBK clcdyndns = new org.dyndns.cedweb.detalle.DetalleIBK();
            org.dyndns.cedweb.detalle.cecd cecd = new org.dyndns.cedweb.detalle.cecd();
            List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado> listaR = new List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado>();
            System.Xml.Serialization.XmlSerializer x;
            byte[] bytes;
            System.IO.MemoryStream ms;
            string resp;
            string script;

            Session.Remove("ComprobanteATratar");
            Session.Remove("EsComprobanteOriginal");
            switch (comando)
            {
                case "ActualizarOnLine":
                    #region ActualizarOnLine
                    try
                    {
                        if (comprobante.NaturalezaComprobante.Id == "Venta")
                        {
                            if (comprobante.Estado == "Vigente")
                            {
                                MensajeLabel.Text = "El comprobante ya está vigente. No es posible actualizar su estado.";
                                return;
                            }
                            if (comprobante.IdDestinoComprobante == "ITF")
                            {
                                if (sesion.Cuit.NroSerieCertifITF.Equals(string.Empty))
                                {
                                    MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                                    return;
                                }

                                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Consulta de Lote CUIT: " + comprobante.Cuit + "  Nro.Lote: " + comprobante.NroLote + "  Nro. Punto de Vta.: " + comprobante.NroPuntoVta);
                                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "NroSerieCertifITF: " + sesion.Cuit.NroSerieCertifITF);

                                certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(sesion.Cuit.NroSerieCertifITF, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                                org.dyndns.cedweb.consulta.ConsultaIBK clcdyndnsConsultaIBK = new org.dyndns.cedweb.consulta.ConsultaIBK();
                                string ConsultaIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKUtilizarServidorExterno"];
                                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Parametro ConsultaIBKUtilizarServidorExterno: " + ConsultaIBKUtilizarServidorExterno);
                                if (ConsultaIBKUtilizarServidorExterno == "SI")
                                {
                                    clcdyndnsConsultaIBK.Url = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"];
                                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Parametro ConsultaIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"]);
                                }
                                org.dyndns.cedweb.consulta.ConsultarResult clcrdyndns = new org.dyndns.cedweb.consulta.ConsultarResult();
                                clcrdyndns = clcdyndnsConsultaIBK.Consultar(Convert.ToInt64(comprobante.Cuit), comprobante.NroLote, comprobante.NroPuntoVta, certificado);
                                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                                lc = Funciones.Ws2Fea(clcrdyndns);
                                string XML = "";
                                RN.Comprobante.SerializarLc(out XML, lc);
                                comprobante.Response = XML;
                                if (lc.cabecera_lote.resultado == "A")
                                {
                                    //Controlar que sea el mismo comprobante (local vs on-line)
                                    if (comprobante.Nro != lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante)
                                    {
                                        MensajeLabel.Text = "(Campo: Nro. de Comprobante). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. No se puede actualizar el estado.";
                                        return;
                                    }
                                    if (comprobante.TipoComprobante.Id != lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)
                                    {
                                        MensajeLabel.Text = "(Campo: Tipo de Comprobante). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. No se puede actualizar el estado.";
                                        return;
                                    }
                                    if (comprobante.Importe != lc.comprobante[0].resumen.importe_total_factura)
                                    {
                                        MensajeLabel.Text += "(Campo: Importe). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. Igualmente se pudo actualizar la información y el estado.";
                                        comprobante.Importe = lc.comprobante[0].resumen.importe_total_factura;
                                    }
                                    if (comprobante.Moneda != lc.comprobante[0].resumen.codigo_moneda)
                                    {
                                        MensajeLabel.Text += "(Campo: Moneda). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. Igualmente se pudo actualizar la información y el estado.";
                                        comprobante.Moneda = lc.comprobante[0].resumen.codigo_moneda;
                                    }
                                    if (lc.comprobante[0].resumen.importes_moneda_origen != null)
                                    {
                                        if (comprobante.ImporteMoneda != lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura)
                                        {
                                            MensajeLabel.Text += "(Campo: Importe Moneda). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. Igualmente se pudo actualizar la información y el estado.";
                                            comprobante.ImporteMoneda = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura;
                                        }
                                    }
                                    else
                                    {
                                        if (comprobante.ImporteMoneda != 0)
                                        {
                                            MensajeLabel.Text += "(Campo: Importe Moneda). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. Igualmente se pudo actualizar la información y el estado.";
                                            comprobante.ImporteMoneda = 0;
                                        }
                                    }
                                    if (comprobante.TipoCambio != lc.comprobante[0].resumen.tipo_de_cambio)
                                    {
                                        MensajeLabel.Text += "(Campo: Tipo de cambio). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. Igualmente se pudo actualizar la información y el estado.";
                                        comprobante.TipoCambio = lc.comprobante[0].resumen.tipo_de_cambio;
                                    }
                                    //if (comprobante.Fecha != lc.comprobante[0].cabecera.informacion_comprobante.fecha_emision)
                                    //{
                                    //    MensajeLabel.Text += "(Campo: Tipo de cambio). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. Igualmente se pudo actualizar la información y el estado.";
                                    //    comprobante.Fecha = lc.comprobante[0].resumen.fecha_emision;
                                    //}
                                    //if (comprobante.Fecha != lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento)
                                    //{
                                    //    MensajeLabel.Text += "(Campo: Tipo de cambio). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. Igualmente se pudo actualizar la información y el estado.";
                                    //    comprobante.FechaVto = lc.comprobante[0].resumen.fecha_vencimiento;
                                    //}
                                    if (comprobante.Documento.Tipo.Id != lc.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString())
                                    {
                                        MensajeLabel.Text += "(Campo: Cod.Doc). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. Igualmente se pudo actualizar la información y el estado.";
                                        comprobante.Documento.Tipo.Id = lc.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString();
                                    }
                                    if (comprobante.Documento.Nro != lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio.ToString())
                                    {
                                        MensajeLabel.Text += "(Campo: Nro.Doc). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. Igualmente se pudo actualizar la información y el estado.";
                                        comprobante.Documento.Nro = lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio.ToString();
                                    }

                                    comprobante.WF.Estado = "Vigente";
                                    RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Consulta, comprobante);
                                    script = "window.open('/ComprobanteConsulta.aspx', '');";
                                    BuscarButton_Click(sender, new EventArgs());
                                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                                }
                                else if (lc.cabecera_lote.resultado == "R")
                                {
                                    comprobante.WF.Estado = "Rechazado";
                                    RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                                    string motivo = "";
                                    if (lc.cabecera_lote.motivo != null)
                                    {
                                        motivo = "Motivo: " + lc.cabecera_lote.motivo;
                                    }
                                    if (lc.comprobante != null && lc.comprobante[0].cabecera.informacion_comprobante.motivo != null)
                                    {
                                        if (motivo != "")
                                        {
                                            motivo += "  ";
                                        }
                                        motivo += "Motivo del comprobante: " + lc.comprobante[0].cabecera.informacion_comprobante.motivo;
                                    }
                                    script = Funciones.TextoScript("Respuesta de ITF o AFIP: " + "Resultado: " + lc.cabecera_lote.resultado + "  " + motivo);
                                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                                    MensajeLabel.Text = script;
                                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", script, true);
                                }
                                else
                                {
                                    MensajeLabel.Text = "No se puede realizar la actualización, cuando el comprobante se encuentra en el siguiente estado en Interfacturas ( Estado: " + clcrdyndns.comprobante[0].cabecera.informacion_comprobante.resultado + ").";
                                    return;
                                }
                            }
                            else
                            {
                                string respuesta = "";
                                int auxPV = Convert.ToInt32(comprobante.NroPuntoVta);
                                string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                                {
                                    return pv.Nro == auxPV;
                                }).IdTipoPuntoVta;
                                if (idtipo != "Turismo")
                                {
                                    //Deserializar
                                    FeaEntidades.InterFacturas.lote_comprobantes lcFea = new FeaEntidades.InterFacturas.lote_comprobantes();
                                    string xml = comprobante.Request;
                                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(FeaEntidades.InterFacturas.lote_comprobantes));
                                    using (TextReader reader = new StringReader(xml))
                                    {
                                        lcFea = (FeaEntidades.InterFacturas.lote_comprobantes)serializer.Deserialize(reader);
                                    }
                                    string caeNro;
                                    string caeFecVto;
                                    string caeFecPro;
                                    respuesta = RN.ComprobanteAFIP.ConsultarAFIP(out caeNro, out caeFecVto, out caeFecPro, lcFea, (Entidades.Sesion)Session["Sesion"]);
                                    if (respuesta.Length >= 12 && respuesta.Substring(0, 12) == "Resultado: A")
                                    {
                                        comprobante.WF.Estado = "Vigente";
                                        if (caeNro != "")
                                        {
                                            lcFea.cabecera_lote.resultado = "A";
                                            lcFea.comprobante[0].cabecera.informacion_comprobante.resultado = "A";
                                            lcFea.comprobante[0].cabecera.informacion_comprobante.cae = caeNro;
                                            lcFea.comprobante[0].cabecera.informacion_comprobante.caeSpecified = true;
                                            lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae = caeFecVto;
                                            lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
                                            lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_cae = caeFecPro;
                                            lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = true;
                                        }
                                        string XML = "";
                                        RN.Comprobante.SerializarLc(out XML, lcFea);
                                        comprobante.Response = XML;

                                        RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                                        Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Consulta, comprobante);
                                        script = "window.open('/ComprobanteConsulta.aspx', '');";
                                        BuscarButton_Click(sender, new EventArgs());
                                        RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                                    }
                                    else
                                    {
                                        MensajeLabel.Text = respuesta;
                                    }
                                }
                                else
                                {
                                    //Deserializar Turismo
                                    FeaEntidades.InterFacturas.lote_comprobantes lcFea = new FeaEntidades.InterFacturas.lote_comprobantes();
                                    FeaEntidades.Turismo.comprobante cTur = new FeaEntidades.Turismo.comprobante();
                                    string xml = comprobante.Request;
                                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(FeaEntidades.Turismo.comprobante));
                                    using (TextReader reader = new StringReader(xml))
                                    {
                                        cTur = (FeaEntidades.Turismo.comprobante)serializer.Deserialize(reader);
                                    }
                                    lcFea.comprobante[0] = new FeaEntidades.InterFacturas.comprobante();
                                    lcFea.comprobante[0].cabecera = new FeaEntidades.InterFacturas.cabecera();
                                    lcFea.comprobante[0].cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                                    lcFea.comprobante[0].cabecera.informacion_comprobante.punto_de_venta = cTur.cabecera.informacion_comprobante.punto_de_venta;
                                    lcFea.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante = cTur.cabecera.informacion_comprobante.tipo_de_comprobante;
                                    lcFea.comprobante[0].cabecera.informacion_comprobante.numero_comprobante = cTur.cabecera.informacion_comprobante.numero_comprobante;
                                    string caeNro;
                                    string caeFecVto;
                                    string caeFecPro;
                                    respuesta = RN.ComprobanteAFIP.ConsultarAFIP(out caeNro, out caeFecVto, out caeFecPro, lcFea, (Entidades.Sesion)Session["Sesion"]);
                                    if (respuesta.Length >= 12 && respuesta.Substring(0, 12) == "Resultado: A")
                                    {
                                        comprobante.WF.Estado = "Vigente";
                                        if (caeNro != "")
                                        {
                                            cTur.cabecera.informacion_comprobante.resultado = "A";
                                            cTur.cabecera.informacion_comprobante.cae = caeNro;
                                            cTur.cabecera.informacion_comprobante.caeSpecified = true;
                                            cTur.cabecera.informacion_comprobante.fecha_vencimiento_cae = caeFecVto;
                                            cTur.cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
                                            cTur.cabecera.informacion_comprobante.fecha_obtencion_cae = caeFecPro;
                                            cTur.cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = true;
                                        }
                                        string XML = "";
                                        RN.Comprobante.SerializarLc(out XML, cTur);
                                        comprobante.Response = XML;

                                        RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                                        Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Consulta, comprobante);
                                        script = "window.open('/ComprobanteConsultaTurismo.aspx', '');";
                                        BuscarButton_Click(sender, new EventArgs());
                                        RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MensajeLabel.Text = "Esta opción está disponible sólo para comprobantes de venta electrónica";
                        }
                    }
                    catch (System.Web.Services.Protocols.SoapException soapEx)
                    {
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(soapEx.Detail.OuterXml);
                            XmlNamespaceManager nsManager = new
                                XmlNamespaceManager(doc.NameTable);
                            nsManager.AddNamespace("errorNS",
                                "http://www.cedeira.com.ar/webservices");
                            XmlNode Node =
                                doc.DocumentElement.SelectSingleNode("errorNS:Error", nsManager);
                            string errorNumber =
                                Node.SelectSingleNode("errorNS:ErrorNumber",
                                nsManager).InnerText;
                            string errorMessage =
                                Node.SelectSingleNode("errorNS:ErrorMessage",
                                nsManager).InnerText;
                            string errorSource =
                                Node.SelectSingleNode("errorNS:ErrorSource",
                                nsManager).InnerText;
                            MensajeLabel.Text = soapEx.Actor + "\\n" + errorMessage.Replace("\r", "").Replace("\n", "");
                        }
                        catch (Exception)
                        {
                            throw soapEx;
                        }
                    }
                    #endregion
                    break;
                case "PDF-Viewer":
                    #region PDF-Viewer
                    if (comprobante.NaturalezaComprobante.Id == "Venta" && comprobante.IdDestinoComprobante == "ITF")
                    {
                        if (comprobante.Estado != "Vigente")
                        {
                            MensajeLabel.Text = "El comprobante no está vigente.";
                            return;
                        }
                        MensajeLabel.Text = String.Empty;
                        cecd.cuit_canal = Convert.ToInt64("30690783521");
                        cecd.cuit_vendedor = Convert.ToInt64(comprobante.Cuit);
                        cecd.punto_de_venta = Convert.ToInt32(comprobante.NroPuntoVta);
                        cecd.tipo_de_comprobante = Convert.ToInt32(comprobante.TipoComprobante.Id);
                        cecd.numero_comprobante = comprobante.Nro;
                        cecd.id_Lote = 0;
                        cecd.id_LoteSpecified = false;
                        cecd.estado = "PR";

                        if (sesion.Cuit.NroSerieCertifITF.Equals(string.Empty))
                        {
                            MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                            return;
                        }
                        GrabarLogTexto("~/Detallar.txt", "Consulta de Lote CUIT: " + sesion.Cuit.Nro + "  Fecha Desde: " + FechaDesdeTextBox.Text + "  Fecha Hasta: " + FechaHastaTextBox.Text);
                        GrabarLogTexto("~/Detallar.txt", "NroSerieCertifITF: " + sesion.Cuit.NroSerieCertifITF);
                        if (sesion.Cuit.NroSerieCertifITF.Equals(string.Empty))
                        {
                            MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                            return;
                        }

                        certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(sesion.Cuit.NroSerieCertifITF, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                        GrabarLogTexto("~/Detallar.txt", "Parametro DetalleIBKUtilizarServidorExterno: " + DetalleIBKUtilizarServidorExterno);
                        if (DetalleIBKUtilizarServidorExterno == "SI")
                        {
                            clcdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"];
                            GrabarLogTexto("~/Detallar.txt", "Parametro DetalleIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"]);
                        }
                        resp = clcdyndns.DetallarIBK(cecd, certificado);

                        try
                        {
                            string comprobanteXML = resp;

                            GrabarLogTexto("~/Detallar.txt", "Inicia ExecuteCommand");
                            org.dyndns.cedweb.generoPDF.GeneroPDF pdfdyndns = new org.dyndns.cedweb.generoPDF.GeneroPDF();

                            string GenerarPDFUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["GenerarPDFUtilizarServidorExterno"];
                            GrabarLogTexto("~/Detallar.txt", "Parametro GenerarPDFUtilizarServidorExterno: " + GenerarPDFUtilizarServidorExterno);
                            if (GenerarPDFUtilizarServidorExterno == "SI")
                            {
                                pdfdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["GenerarPDFurl"];
                                GrabarLogTexto("~/Detallar.txt", "Parametro GenerarPDFurl: " + System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"]);
                            }
                            string RespPDF = pdfdyndns.GenerarPDF(comprobante.Cuit, comprobante.NroPuntoVta, comprobante.TipoComprobante.Id, comprobante.Nro, comprobante.IdDestinoComprobante, comprobanteXML);
                            GrabarLogTexto("~/Detallar.txt", "Finaliza ExecuteCommand");

                            script = "window.open('" + RespPDF + "', '');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                        }
                        catch (Exception ex)
                        {
                            script = "Problemas para generar el PDF.\\n" + ex.Message;
                            script += ex.StackTrace;
                            if (ex.InnerException != null)
                            {
                                script = ex.InnerException.Message;
                            }
                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Detallar.txt"), script);
                            MensajeLabel.Text = script;
                        }
                    }
                    else
                    {
                        MensajeLabel.Text = "Esta opción está disponible sólo para comprobantes de venta electrónica, canal ITF (Interfacturas)";
                    }
                    #endregion  
                    break;
                case "XML-ClonarAlta":
                    #region XML-ClonarAlta
                    if (comprobante.NaturalezaComprobante.Id == "Venta")
                    {
                        Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Clonado, comprobante);
                        int auxPV = Convert.ToInt32(comprobante.NroPuntoVta);
                        string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        if (idtipo != "Turismo")
                        {
                            script = "window.open('/Facturacion/Electronica/Lote.aspx', '');";
                        }
                        else
                        {
                            script = "window.open('/Facturacion/Electronica/LoteCT.aspx', '');";
                        }
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    }
                    else if (comprobante.NaturalezaComprobante.Id == "Compra")
                    {
                        Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Clonado, comprobante);
                        script = "window.open('/Facturacion/Electronica/Lote.aspx', '');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    }
                    else
                    {
                        MensajeLabel.Text = "Esta opción está disponible sólo para comprobantes de venta electrónica o compra.";
                    }                    
                    #endregion
                    break;
                case "PDF":
                    if (comprobante.NaturalezaComprobante.Id == "Venta")
                    {
                        if (comprobante.IdDestinoComprobante == "ITF")
                        {
                            #region PDF (InterFacturas)
                            //OBTENCIÓN DE PDF DE INTERFACTURAS
                            if (comprobante.Estado != "Vigente")
                            {
                                MensajeLabel.Text = "El comprobante no está vigente.";
                                return;
                            }
                            MensajeLabel.Text = String.Empty;
                            //<?xml version=\"1.0\" encoding=\"iso-8859-1\"?><lote_comprobantes  xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"http://lote.schemas.cfe.ib.com.ar/\"><cabecera_lote><id_lote>20140804151246</id_lote><cuit_canal>30690783521</cuit_canal><cuit_vendedor>30710015062</cuit_vendedor><cantidad_reg>1</cantidad_reg><punto_de_venta>35</punto_de_venta><resultado>A</resultado></cabecera_lote><comprobante><cabecera><informacion_comprobante><tipo_de_comprobante>1</tipo_de_comprobante><numero_comprobante>57</numero_comprobante><punto_de_venta>35</punto_de_venta><fecha_emision>20140804</fecha_emision><fecha_vencimiento>20140831</fecha_vencimiento><fecha_serv_desde /><fecha_serv_hasta /><condicion_de_pago>30 
                            //Off-Line
                            //resp = comprobante.Response.Replace("iso-8859-1", "utf-8");
                            //resp = resp.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                            //Fin Off-Line

                            //On-Line
                            cecd.cuit_canal = Convert.ToInt64("30690783521");
                            cecd.cuit_vendedor = Convert.ToInt64(comprobante.Cuit);
                            cecd.punto_de_venta = Convert.ToInt32(comprobante.NroPuntoVta);
                            cecd.tipo_de_comprobante = Convert.ToInt32(comprobante.TipoComprobante.Id);
                            cecd.numero_comprobante = comprobante.Nro;
                            cecd.id_Lote = 0;
                            cecd.id_LoteSpecified = false;
                            cecd.estado = "PR";

                            if (sesion.Cuit.NroSerieCertifITF.Equals(string.Empty))
                            {
                                MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                                return;
                            }
                            GrabarLogTexto("~/Detallar.txt", "Consulta de Lote CUIT: " + sesion.Cuit.Nro + "  Fecha Desde: " + FechaDesdeTextBox.Text + "  Fecha Hasta: " + FechaHastaTextBox.Text);
                            GrabarLogTexto("~/Detallar.txt", "NroSerieCertifITF: " + sesion.Cuit.NroSerieCertifITF);
                            if (sesion.Cuit.NroSerieCertifITF.Equals(string.Empty))
                            {
                                MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                                return;
                            }

                            certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(sesion.Cuit.NroSerieCertifITF, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                            GrabarLogTexto("~/Detallar.txt", "Parametro DetalleIBKUtilizarServidorExterno: " + DetalleIBKUtilizarServidorExterno);
                            if (DetalleIBKUtilizarServidorExterno == "SI")
                            {
                                clcdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"];
                                GrabarLogTexto("~/Detallar.txt", "Parametro DetalleIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"]);
                            }
                            resp = clcdyndns.DetallarIBK(cecd, certificado);
                            resp = resp.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                            resp = resp.Replace(" xmlns:xsi=\"http://lote.schemas.cfe.ib.com.ar/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", " xmlns=\"http://lote.schemas.cfe.ib.com.ar/\"");
                            resp = resp.Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", " xmlns=\"http://lote.schemas.cfe.ib.com.ar/\"");
                            //Fin On-Line

                            try
                            {
                                string comprobanteXML = resp;

                                GrabarLogTexto("~/Detallar.txt", "Inicia ExecuteCommand");
                                org.dyndns.cedweb.generoPDF.GeneroPDF pdfdyndns = new org.dyndns.cedweb.generoPDF.GeneroPDF();

                                string GenerarPDFUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["GenerarPDFUtilizarServidorExterno"];
                                GrabarLogTexto("~/Detallar.txt", "Parametro GenerarPDFUtilizarServidorExterno: " + GenerarPDFUtilizarServidorExterno);
                                if (GenerarPDFUtilizarServidorExterno == "SI")
                                {
                                    pdfdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["GenerarPDFurl"];
                                    GrabarLogTexto("~/Detallar.txt", "Parametro GenerarPDFurl: " + System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"]);
                                }
                                string RespPDF = pdfdyndns.GenerarPDF(comprobante.Cuit, comprobante.NroPuntoVta, comprobante.TipoComprobante.Id, comprobante.Nro, comprobante.IdDestinoComprobante, comprobanteXML);
                                GrabarLogTexto("~/Detallar.txt", "Finaliza ExecuteCommand");

                                //Crear nombre de archivo default sin extensión
                                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                sb.Append(comprobante.Cuit);
                                sb.Append("-");
                                sb.Append(comprobante.NroPuntoVta.ToString("0000"));
                                sb.Append("-");
                                sb.Append(comprobante.TipoComprobante.Id.ToString("00"));
                                sb.Append("-");
                                sb.Append(comprobante.Nro.ToString("00000000"));
                                sb.Append(".pdf");

                                string url = RespPDF;
                                string filename = sb.ToString();
                                String dlDir = @"~/TempRender/";
                                new System.Net.WebClient().DownloadFile(url, Server.MapPath(dlDir + filename));

                                script = "window.open('DescargaTemporarios.aspx?archivo=" + sb.ToString() + "&path=" + @"~/TempRender/" + "', '');";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                            }
                            catch (Exception ex)
                            {
                                script = "Problemas para generar el PDF.\\n" + ex.Message;
                                script += ex.StackTrace;
                                if (ex.InnerException != null)
                                {
                                    script = ex.InnerException.Message;
                                }
                                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Detallar.txt"), script);
                                MensajeLabel.Text = script;
                            }
                            #endregion
                        }
                        else
                        {
                            #region PDF (AFIP)
                            //GENERACIÓN DE PDF A PARTIR DE DATOS LOCALES
                            if (comprobante.Estado != "Vigente")
                            {
                                MensajeLabel.Text = "El comprobante no está vigente.";
                                return;
                            }
                            try
                            {
                                int auxPV = Convert.ToInt32(comprobante.NroPuntoVta);
                                string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                                {
                                    return pv.Nro == auxPV;
                                }).IdTipoPuntoVta;
                                if (idtipo != "Turismo")
                                {
                                    lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                                    x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                            
                                    comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                                    bytes = new byte[comprobante.Response.Length * sizeof(char)];
                                    System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                                    ms = new System.IO.MemoryStream(bytes);
                                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                                    lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                                    RN.Comprobante.AjustarLoteParaImprimirPDF(lote);
                                    Session["lote"] = lote;
                                }
                                else
                                {
                                    loteT = new FeaEntidades.Turismo.lote_comprobantes();
                                    FeaEntidades.Turismo.comprobante compT = new FeaEntidades.Turismo.comprobante();
                                    x = new System.Xml.Serialization.XmlSerializer(compT.GetType());

                                    comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                                    bytes = new byte[comprobante.Response.Length * sizeof(char)];
                                    System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                                    ms = new System.IO.MemoryStream(bytes);
                                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                                    compT = (FeaEntidades.Turismo.comprobante)x.Deserialize(ms);
                                    loteT.comprobante[0] = compT;
                                    RN.Comprobante.AjustarLoteTParaImprimirPDF(loteT);
                                    Session["lote"] = loteT;
                                }
                                
                                //Response.Redirect("~\\Facturacion\\Electronica\\Reportes\\FacturaWebForm.aspx", true);
                                if (idtipo != "Turismo")
                                {
                                    script = "window.open('/Facturacion/Electronica/Reportes/FacturaWebForm.aspx', '');";
                                }
                                else
                                {
                                    script = "window.open('/Facturacion/Electronica/Reportes/FacturaWebFormT.aspx', '');";
                                }
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                            }
                            catch (Exception ex)
                            {
                                script = "Problemas para generar el PDF.\\n" + ex.Message;
                                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                                MensajeLabel.Text = script;
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        MensajeLabel.Text = "Esta opción está disponible sólo para comprobantes de venta electrónica";
                    }
                    break;
                case "XMLOnLine":
                    #region XMLOnLine
                    if (comprobante.NaturalezaComprobante.Id == "Venta" && comprobante.IdDestinoComprobante == "ITF")
                    {
                        if (comprobante.Estado != "Vigente")
                        {
                            MensajeLabel.Text = "El comprobante no está vigente.";
                            return;
                        }
                        MensajeLabel.Text = String.Empty;
                        Entidades.Persona persona = ((List<Entidades.Persona>)ViewState["Personas"])[ClienteDropDownList.SelectedIndex];
                        //resp = RN.Comprobante.ComprobanteDetalleIBK(((Entidades.Sesion)Session["Sesion"]).Cuit.Nro, comprobante.NroPuntoVta.ToString(), comprobante.TipoComprobante.Id.ToString(), comprobante.Nro, 0, ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF);

                        cecd.cuit_canal = Convert.ToInt64("30690783521");
                        cecd.cuit_vendedor = Convert.ToInt64(comprobante.Cuit);
                        cecd.punto_de_venta = Convert.ToInt32(comprobante.NroPuntoVta);
                        cecd.tipo_de_comprobante = Convert.ToInt32(comprobante.TipoComprobante.Id);
                        cecd.numero_comprobante = comprobante.Nro;
                        cecd.id_Lote = 0;
                        cecd.id_LoteSpecified = false;
                        cecd.estado = "PR";

                        if (sesion.Cuit.NroSerieCertifITF.Equals(string.Empty))
                        {
                            MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                            return;
                        }
                        GrabarLogTexto("~/Detallar.txt", "Consulta de Lote CUIT: " + sesion.Cuit.Nro + "  Fecha Desde: " + FechaDesdeTextBox.Text + "  Fecha Hasta: " + FechaHastaTextBox.Text);
                        GrabarLogTexto("~/Detallar.txt", "NroSerieCertifITF: " + sesion.Cuit.NroSerieCertifITF);
                        if (sesion.Cuit.NroSerieCertifITF.Equals(string.Empty))
                        {
                            MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                            return;
                        }

                        certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(sesion.Cuit.NroSerieCertifITF, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                        GrabarLogTexto("~/Detallar.txt", "Parametro DetalleIBKUtilizarServidorExterno: " + DetalleIBKUtilizarServidorExterno);
                        if (DetalleIBKUtilizarServidorExterno == "SI")
                        {
                            clcdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"];
                            GrabarLogTexto("~/Detallar.txt", "Parametro DetalleIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"]);
                        }
                        resp = clcdyndns.DetallarIBK(cecd, certificado);

                        try
                        {
                            string comprobanteXML = resp;
                            System.Text.StringBuilder sbXMLData = new System.Text.StringBuilder();
                            sbXMLData.AppendLine(comprobanteXML);

                            //Crear nombre de archivo default sin extensión
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append(comprobante.Cuit);
                            sb.Append("-");
                            sb.Append(comprobante.NroPuntoVta.ToString("0000"));
                            sb.Append("-");
                            sb.Append(comprobante.TipoComprobante.Id.ToString("00"));
                            sb.Append("-");
                            sb.Append(comprobante.Nro.ToString("00000000"));

                            //Crear nombre de archivo XML
                            System.Text.StringBuilder sbXML = new System.Text.StringBuilder();
                            sbXML.Append(sb.ToString() + ".xml");

                            //Crear archivo comprobante XML
                            System.IO.MemoryStream m = new System.IO.MemoryStream();
                            System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbXML.ToString()), System.IO.FileMode.Create);
                            m.WriteTo(fs);
                            fs.Close();

                            //Grabar información comprobante XML
                            using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbXML.ToString())))
                            {
                                outfile.Write(sbXMLData.ToString());
                            }
                            script = "window.open('DescargaTemporarios.aspx?archivo=" + sbXML.ToString() + "', '');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                        }
                        catch (Exception ex)
                        {
                            script = "Problemas para generar el XML.\\n" + ex.Message;
                            script += ex.StackTrace;
                            if (ex.InnerException != null)
                            {
                                script = ex.InnerException.Message;
                            }
                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Detallar.txt"), script);
                            MensajeLabel.Text += script;
                        }
                    }
                    else
                    {
                        MensajeLabel.Text = "Esta opción está disponible sólo para comprobantes de venta electrónica, canal ITF (Interfacturas)";
                    }
                    #endregion
                    break;
                case "XMLLocal":
                    if (comprobante.NaturalezaComprobante.Id == "Venta")
                    {
                        try
                        {
                            //Crear nombre de archivo default sin extensión
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append(comprobante.Cuit);
                            sb.Append("-");
                            sb.Append(comprobante.NroPuntoVta.ToString("0000"));
                            sb.Append("-");
                            sb.Append(comprobante.TipoComprobante.Id.ToString("00"));
                            sb.Append("-");
                            sb.Append(comprobante.Nro.ToString("00000000"));

                            System.Text.StringBuilder sbXMLData;
                            if (comprobante.Estado != "Vigente")
                            {
                                sbXMLData = new System.Text.StringBuilder();
                                sbXMLData.AppendLine(comprobante.Request);
                                sb.Append("-BORRADOR");
                                MensajeLabel.Text = "El comprobante no está vigente. Usted está descargando un XML de BORRADOR.";
                            }
                            else
                            {
                                sbXMLData = new System.Text.StringBuilder();
                                sbXMLData.AppendLine(comprobante.Response);
                            }

                            //Crear nombre de archivo XML
                            System.Text.StringBuilder sbXML = new System.Text.StringBuilder();
                            sbXML.Append(sb.ToString() + ".xml");

                            //Crear archivo comprobante XML
                            System.IO.MemoryStream m = new System.IO.MemoryStream();
                            System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbXML.ToString()), System.IO.FileMode.Create);
                            m.WriteTo(fs);
                            fs.Close();

                            //Grabar información comprobante XML
                            using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbXML.ToString())))
                            {
                                outfile.Write(sbXMLData.ToString());
                            }
                            script = "window.open('DescargaTemporarios.aspx?archivo=" + sbXML.ToString() + "', '');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                        }
                        catch (Exception ex)
                        {
                            script = "Problemas para generar el XML.\\n" + ex.Message;
                            script += ex.StackTrace;
                            if (ex.InnerException != null)
                            {
                                script = ex.InnerException.Message;
                            }
                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Detallar.txt"), script);
                            MensajeLabel.Text += script;
                        }
                    }
                    break;
                case "ExportarRG2485":
                    #region ExportarRG2485
                    if (comprobante.NaturalezaComprobante.Id == "Venta")
                    {
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

                            //Crear nombre de archivo default sin extensión
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append(lote.cabecera_lote.cuit_vendedor);
                            sb.Append("-");
                            sb.Append(lote.cabecera_lote.punto_de_venta.ToString("0000"));
                            sb.Append("-");
                            sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00"));
                            sb.Append("-");
                            sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000"));

                            //Crear nombre de archivo ZIP
                            System.Text.StringBuilder sbZIP = new System.Text.StringBuilder();
                            sbZIP.Append(sb.ToString() + ".zip");

                            //Crear archivo CABECERA EMISOR
                            System.Text.StringBuilder sbCabeceraE = new System.Text.StringBuilder();
                            sbCabeceraE.Append(sb.ToString() + "-CABECERA_EMISOR.txt");
                            System.IO.MemoryStream m = new System.IO.MemoryStream();
                            System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbCabeceraE.ToString()), System.IO.FileMode.Create);
                            m.WriteTo(fs);
                            fs.Close();
                            //Guardar info en archivo CABECERA EMISOR
                            System.Text.StringBuilder sbDataCabeceraE = new System.Text.StringBuilder();
                            string Campo2 = String.Format("{0,11}", sesion.Cuit.Nro);
                            string Campo3 = String.Format("{0,-30}", Truncate(sesion.Cuit.RazonSocial, 30));
                            string Campo4 = String.Format("{0,-30}", sesion.Cuit.DatosImpositivos.NroIngBrutos);
                            string Campo5 = sesion.Cuit.DatosImpositivos.IdCondIVA.ToString("00");
                            string Campo6 = String.Format("{0,-30}", "");
                            try
                            {
                                string RespAux6 = FeaEntidades.CondicionesIVA.CondicionIVA.Lista().Find(delegate(FeaEntidades.CondicionesIVA.CondicionIVA ci)
                                {
                                    return (ci.Codigo == sesion.Cuit.DatosImpositivos.IdCondIVA);
                                }).Descr;
                                Campo6 = String.Format("{0,-27}", Truncate(RespAux6, 27));
                            }
                            catch
                            {
                            }
                            string Campo7 = String.Format("{0,-8}", sesion.Cuit.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd"));
                            string Campo8 = String.Format("{0,-30}", sesion.Cuit.Domicilio.Calle);
                            string Campo9 = String.Format("{0,-6}", sesion.Cuit.Domicilio.Nro);
                            string Campo10 = String.Format("{0,-5}", sesion.Cuit.Domicilio.Piso);
                            string Campo11 = String.Format("{0,-5}", sesion.Cuit.Domicilio.Depto);
                            string Campo12 = String.Format("{0,-5}", sesion.Cuit.Domicilio.Sector);
                            string Campo13 = String.Format("{0,-5}", sesion.Cuit.Domicilio.Torre);
                            string Campo14 = String.Format("{0,-5}", sesion.Cuit.Domicilio.Manzana);
                            string Campo15 = Convert.ToInt32(sesion.Cuit.Domicilio.Provincia.Id).ToString("00");
                            string Campo16 = String.Format("{0,-8}", sesion.Cuit.Domicilio.CodPost);
                            string Campo17 = String.Format("{0,-25}", Truncate(sesion.Cuit.Domicilio.Localidad, 25));
                            sbDataCabeceraE.AppendLine("1" + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11 + Campo12 + Campo13 + Campo14 + Campo15 + Campo16 + Campo17);
                            using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbCabeceraE.ToString())))
                            {
                                outfile.Write(sbDataCabeceraE.ToString());
                            }

                            //Crear archivo CABECERA COMPROBANTE 
                            System.Text.StringBuilder sbCabeceraC = new System.Text.StringBuilder();
                            sbCabeceraC.Append(sb.ToString() + "-CABECERA_COMPROBANTE.txt");
                            m = new System.IO.MemoryStream();
                            fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbCabeceraC.ToString()), System.IO.FileMode.Create);
                            m.WriteTo(fs);
                            fs.Close();
                            //Guardar info en archivo CABECERA COMPROBANTE
                            System.Text.StringBuilder sbDataCabeceraC = new System.Text.StringBuilder();
                            Campo2 = "ORIGINAL";
                            Campo3 = String.Format("{0,-8}", lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision);
                            Campo4 = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00");
                            if (Campo4 == "01" || Campo4 == "02" || Campo4 == "03" || Campo4 == "04" || Campo4 == "05" || Campo4 == "39" || Campo4 == "60" || Campo4 == "63")
                            {
                                Campo5 = "A";
                            }
                            else if (Campo4 == "06" || Campo4 == "07" || Campo4 == "08" || Campo4 == "09" || Campo4 == "10" || Campo4 == "40" || Campo4 == "61" || Campo4 == "64")
                            {
                                Campo5 = "B";
                            }
                            else
                            {
                                Campo5 = " ";
                            }
                            Campo6 = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString("0000");
                            Campo7 = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000");
                            Campo8 = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000");
                            Campo9 = lote.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString("00");
                            Campo10 = lote.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio.ToString("00000000000");
                            Campo11 = String.Format("{0,-30}", lote.comprobante[0].cabecera.informacion_comprador.denominacion);
                            Campo12 = lote.comprobante[0].cabecera.informacion_comprador.condicion_IVA.ToString("00");
                            Campo13 = String.Format("{0,-30}", Truncate(lote.comprobante[0].cabecera.informacion_comprador.domicilio_calle, 30));
                            Campo14 = String.Format("{0,-6}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_numero);
                            Campo15 = String.Format("{0,-5}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_piso);
                            Campo16 = String.Format("{0,-5}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_depto);
                            Campo17 = String.Format("{0,-5}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_sector);
                            string Campo18 = String.Format("{0,-5}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_torre);
                            string Campo19 = String.Format("{0,-5}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_manzana);
                            string Campo20 = String.Format("{0,2}", lote.comprobante[0].cabecera.informacion_comprador.provincia);
                            string Campo21 = String.Format("{0,-8}", lote.comprobante[0].cabecera.informacion_comprador.cp);
                            string Campo22 = String.Format("{0,-25}", Truncate(lote.comprobante[0].cabecera.informacion_comprador.localidad, 25));
                            string Campo23 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo24 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo25 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_neto_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_neto_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo26 = String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo27 = String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo28 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo29 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo30 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo31 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo32 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                            string Campo33 = String.Format("{0,-3}", lote.comprobante[0].resumen.codigo_moneda);
                            string Campo34 = String.Format("{0,11}", lote.comprobante[0].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 8) + ".00")).Substring(0, 8) + String.Format("{0,11}", lote.comprobante[0].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 8) + ".00")).Substring(9, 2);
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
                            string Campo35 = String.Format("{0,1}", CantAlicuotas);
                            string Campo36 = String.Format("{0,1}", lote.comprobante[0].cabecera.informacion_comprobante.codigo_operacion);
                            string Campo37 = String.Format("{0,-14}", lote.comprobante[0].cabecera.informacion_comprobante.cae);
                            string Campo38 = String.Format("{0,-8}", lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae);
                            string Campo39 = String.Format("{0,8}", "        ");

                            sbDataCabeceraC.AppendLine("1" + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11 + Campo12 + Campo13 + Campo14 + Campo15 + Campo16 + Campo17 + Campo18 + Campo19 + Campo20 + Campo21 + Campo22 + Campo23 + Campo24 + Campo25 + Campo26 + Campo27 + Campo28 + Campo29 + Campo30 + Campo31 + Campo32 + Campo33 + Campo34 + Campo35 + Campo36 + Campo37 + Campo38 + Campo39);
                            using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbCabeceraC.ToString())))
                            {
                                outfile.Write(sbDataCabeceraC.ToString());
                            }

                            //Crear archivo DETALLE
                            System.Text.StringBuilder sbDetalle = new System.Text.StringBuilder();
                            sbDetalle.Append(sb.ToString() + "-DETALLE.txt");
                            m = new System.IO.MemoryStream();
                            fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbDetalle.ToString()), System.IO.FileMode.Create);
                            m.WriteTo(fs);
                            fs.Close();
                            //Guardar info en archivo DETALLE
                            System.Text.StringBuilder sbDataDetalle = new System.Text.StringBuilder();
                            for (int i = 0; i < lote.comprobante[0].detalle.linea.Length; i++)
                            {
                                string descr = lote.comprobante[0].detalle.linea[i].descripcion;
                                if (descr.Length > 0 && descr.Substring(0, 1) == "%")
                                {
                                    descr = RN.Funciones.HexToString(descr);
                                }
                                Campo2 = String.Format("{0,-100}", Truncate(descr, 100));
                                //cantidad de 12 (7 + 5)
                                Campo3 = String.Format("{0,13}", lote.comprobante[0].detalle.linea[i].cantidad.ToString(new string(Convert.ToChar("0"), 7) + ".00000")).Substring(0, 7) + String.Format("{0,13}", lote.comprobante[0].detalle.linea[i].cantidad.ToString(new string(Convert.ToChar("0"), 7) + ".00000")).Substring(8, 5);
                                //ojo format
                                Campo4 = Convert.ToInt32(lote.comprobante[0].detalle.linea[i].unidad).ToString("00");
                                Campo5 = String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].precio_unitario.ToString(new string(Convert.ToChar("0"), 13) + ".000")).Substring(0, 13) + String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].precio_unitario.ToString(new string(Convert.ToChar("0"), 13) + ".000")).Substring(14, 3);
                                Campo6 = String.Format("{0,16}", lote.comprobante[0].detalle.linea[i].importe_total_descuentos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].detalle.linea[i].importe_total_descuentos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                //importe ajuste
                                Campo7 = String.Format("{0,16}", new string(Convert.ToChar("0"), 16));
                                Campo8 = String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].importe_total_articulo.ToString(new string(Convert.ToChar("0"), 13) + ".000")).Substring(0, 13) + String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].importe_total_articulo.ToString(new string(Convert.ToChar("0"), 13) + ".000")).Substring(14, 3);
                                Campo9 = String.Format("{0,5}", lote.comprobante[0].detalle.linea[i].alicuota_iva.ToString("00.00")).Substring(0, 2) + String.Format("{0,5}", lote.comprobante[0].detalle.linea[i].alicuota_iva.ToString("00.00")).Substring(3, 2);
                                Campo10 = String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].importe_iva.ToString(new string(Convert.ToChar("0"), 14) + ".00")).Substring(0, 14) + String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].importe_iva.ToString(new string(Convert.ToChar("0"), 14) + ".00")).Substring(15, 2);
                                Campo11 = String.Format("{0,1}", lote.comprobante[0].detalle.linea[i].indicacion_exento_gravado);
                                sbDataDetalle.AppendLine("3" + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11);
                            }
                            using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbDetalle.ToString())))
                            {
                                outfile.Write(sbDataDetalle.ToString());
                            }

                            //Descargar ZIP ( Cabecera Emisor, Cabecera Comprobante y Detalle )
                            string filename = sbZIP.ToString();
                            String dlDir = @"~/Temp/";
                            String path = Server.MapPath(dlDir + filename);
                            System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                            System.IO.FileInfo toCabeceraE = new System.IO.FileInfo(Server.MapPath(dlDir + sbCabeceraE.ToString()));
                            System.IO.FileInfo toCabeceraC = new System.IO.FileInfo(Server.MapPath(dlDir + sbCabeceraC.ToString()));
                            System.IO.FileInfo toDetalle = new System.IO.FileInfo(Server.MapPath(dlDir + sbDetalle.ToString()));

                            using (ZipFile zip = new ZipFile())
                            {
                                zip.AddFile(Server.MapPath(dlDir + sbCabeceraE.ToString()), "");
                                zip.AddFile(Server.MapPath(dlDir + sbCabeceraC.ToString()), "");
                                zip.AddFile(Server.MapPath(dlDir + sbDetalle.ToString()), "");
                                zip.Save(Server.MapPath(dlDir + filename));
                                toCabeceraE.Delete();
                                toCabeceraC.Delete();
                                toDetalle.Delete();
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
                        catch (Exception ex)
                        {
                            script = "Problemas para generar la interfaz.\\n" + ex.Message + "\\n" + ex.StackTrace;
                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                            MensajeLabel.Text = script;
                        }
                    }
                    else
                    {
                        MensajeLabel.Text = "Esta opción está disponible sólo para comprobantes de venta electrónica";
                    }
                    #endregion
                    break;
                case "ConsultarInterfacturas":
                    #region ConsultarOnLine
                    try
                    {
                        if (comprobante.NaturalezaComprobante.Id == "Venta" && comprobante.IdDestinoComprobante == "ITF")
                        {
                            string NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
                            if (NroCertif.Equals(string.Empty))
                            {
                                MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                                return;
                            }
                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Consulta de Lote CUIT: " + comprobante.Cuit + "  Nro.Lote: " + comprobante.NroLote + "  Nro. Punto de Vta.: " + comprobante.NroPuntoVta);
                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "NroSerieCertifITF: " + NroCertif);
                            if (NroCertif.Equals(string.Empty))
                            {
                                MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                                return;
                            }
                            certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(NroCertif, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                            org.dyndns.cedweb.consulta.ConsultaIBK clcdyndns1 = new org.dyndns.cedweb.consulta.ConsultaIBK();
                            string ConsultaIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKUtilizarServidorExterno"];
                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Parametro ConsultaIBKUtilizarServidorExterno: " + ConsultaIBKUtilizarServidorExterno);
                            if (ConsultaIBKUtilizarServidorExterno == "SI")
                            {
                                clcdyndns1.Url = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"];
                                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Parametro ConsultaIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"]);
                            }
                            org.dyndns.cedweb.consulta.ConsultarResult clcrdyndns = new org.dyndns.cedweb.consulta.ConsultarResult();
                            clcrdyndns = clcdyndns1.Consultar(Convert.ToInt64(comprobante.Cuit), comprobante.NroLote, comprobante.NroPuntoVta, certificado);
                            FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                            lc = Funciones.Ws2Fea(clcrdyndns);
                            lc.comprobante[0].IdNaturalezaComprobante = "Venta";
                            //Controlar que sea el mismo comprobante (local vs on-line)
                            if (comprobante.Nro != lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante)
                            {
                                MensajeLabel.Text = "(Campo: Nro. de Comprobante). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. No se puede actualizar el estado.";
                                return;
                            }
                            if (comprobante.TipoComprobante.Id != lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)
                            {
                                MensajeLabel.Text = "(Campo: Tipo de Comprobante). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. No se puede actualizar el estado.";
                                return;
                            }
                            Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.Consulta, comprobante);
                            script = "window.open('/ComprobanteConsulta.aspx', '');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                        }
                        else
                        {
                            MensajeLabel.Text = "Esta opción está disponible sólo para comprobantes de venta electrónica, canal ITF (Interfacturas)";
                        }
                    }
                    catch (System.Web.Services.Protocols.SoapException soapEx)
                    {
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(soapEx.Detail.OuterXml);
                            XmlNamespaceManager nsManager = new
                                XmlNamespaceManager(doc.NameTable);
                            nsManager.AddNamespace("errorNS",
                                "http://www.cedeira.com.ar/webservices");
                            XmlNode Node =
                                doc.DocumentElement.SelectSingleNode("errorNS:Error", nsManager);
                            string errorNumber =
                                Node.SelectSingleNode("errorNS:ErrorNumber",
                                nsManager).InnerText;
                            string errorMessage =
                                Node.SelectSingleNode("errorNS:ErrorMessage",
                                nsManager).InnerText;
                            string errorSource =
                                Node.SelectSingleNode("errorNS:ErrorSource",
                                nsManager).InnerText;
                            MensajeLabel.Text = soapEx.Actor + " : " + errorMessage.Replace("\r", "").Replace("\n", "");
                        }
                        catch (Exception)
                        {
                            throw soapEx;
                        }
                    }
                    #endregion
                    break;
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
        protected void VerificarEstadosPosibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue == "Compra")
            {
                //EstadoVigenteCheckBox.Checked = true;
            }
            else
            {
                //EstadoVigenteCheckBox.Checked = false;
            }
        }
    }
}

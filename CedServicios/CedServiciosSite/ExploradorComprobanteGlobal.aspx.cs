using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorComprobanteGlobal : System.Web.UI.Page
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
                    FechaDesdeTextBox.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    FechaHastaTextBox.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //ViewState["Clientes"] = RN.Cliente.ListaPorCuit(false, true, sesion);
                    //ClienteDropDownList.DataSource = (List<Entidades.Cliente>)ViewState["Clientes"];
                    DataBind();
                    //ClienteDropDownList.SelectedValue = "0";
                    CUITTextBox.Text = "";
                    CUITRazonSocialTextBox.Text = "";
                    NroComprobanteTextBox.Text = "";
                }
            }
        }
        protected void ComprobantesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
            System.Xml.Serialization.XmlSerializer x;
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
            Entidades.Comprobante comprobante = lista[item];
            switch (e.CommandName)
            {
                case "Seleccionar":
                    x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                    byte[] bytes = new byte[comprobante.Request.Length * sizeof(char)];
                    System.Buffer.BlockCopy(comprobante.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                    Cache["ComprobanteAConsultar"] = lote;
                    string script = "window.open('/ComprobanteConsulta.aspx', '');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    break;
                case "XML":
                    ////Generar Lote
                    //lote = GenerarLote(false);

                    ////Grabar en base de datos
                    //RN.Comprobante c = new RN.Comprobante();
                    //lote.cabecera_lote.DestinoComprobante = "ITF";
                    //lote.comprobante[0].cabecera.informacion_comprobante.Observacion = "";
                    //c.Registrar(lote, null, "ITF", ((Entidades.Sesion)Session["Sesion"]));

                    x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(comprobante.Cuit);
                    sb.Append("-");
                    sb.Append(comprobante.NroPuntoVta.ToString("0000"));
                    sb.Append("-");
                    sb.Append(comprobante.TipoComprobante.Id.ToString("00"));
                    sb.Append("-");
                    sb.Append(comprobante.Nro.ToString("00000000"));
                    sb.Append(".xml");

                    //System.IO.MemoryStream m = new System.IO.MemoryStream();
                    //System.IO.StreamWriter sw = new System.IO.StreamWriter(m);
                    //sw.Flush();
                    //System.Xml.XmlWriter writerdememoria = new System.Xml.XmlTextWriter(m, System.Text.Encoding.GetEncoding("ISO-8859-1"));

                    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.LoadXml(comprobante.Request);
                    xmlDoc.Save(Server.MapPath(@"~/Temp/" + sb.ToString()));

                    //x.Serialize(writerdememoria, xmlDoc);
                    //m.Seek(0, System.IO.SeekOrigin.Begin);

                    //Descarga directa del XML
                    //System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sb.ToString()), System.IO.FileMode.Create);
                    //m.WriteTo(fs);
                    //fs.Close();
                    Server.Transfer("~/DescargaTemporarios.aspx?archivo=" + sb.ToString(), false);
                    break;
                default:
                    break;
            }
        }
        protected void ComprobantesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[17].Text != "Vigente")
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
                //Entidades.Cliente cliente = ((List<Entidades.Cliente>)ViewState["Clientes"])[ClienteDropDownList.SelectedIndex];
                Entidades.Cliente cliente = new Entidades.Cliente();
                lista = RN.Comprobante.ListaGlobalFiltrada(SoloVigentesCheckBox.Checked, FechaAltaRadioButton.Checked, FechaDesdeTextBox.Text, FechaHastaTextBox.Text, cliente, CUITTextBox.Text, CUITRazonSocialTextBox.Text, NroComprobanteTextBox.Text, sesion);
                if (lista.Count == 0)
                {
                    ComprobantesGridView.DataSource = null;
                    ComprobantesGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Comprobantes que satisfagan la busqueda";
                }
                else
                {
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

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
                    FechaDesdeTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                    FechaHastaTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                    ViewState["Clientes"] = RN.Cliente.ListaPorCuit(false, true, sesion);
                    ClienteDropDownList.DataSource = (List<Entidades.Cliente>)ViewState["Clientes"];
                    DataBind();
                    ClienteDropDownList.SelectedValue = "0";
                }
            }
        }
        protected void ComprobantesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
            Entidades.Comprobante comprobante = lista[item];
            FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
            byte[] bytes = new byte[comprobante.Request.Length * sizeof(char)];
            System.Buffer.BlockCopy(comprobante.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
            Cache["ComprobanteAConsultar"] = lote;
            string script = "window.open('/ComprobanteConsulta.aspx', '');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
        }
        protected void ComprobantesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[13].Text != "Vigente")
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
                Entidades.Cliente cliente = ((List<Entidades.Cliente>)ViewState["Clientes"])[ClienteDropDownList.SelectedIndex];
                lista = RN.Comprobante.ListaFiltrada(SoloVigentesCheckBox.Checked, FechaDesdeTextBox.Text, FechaHastaTextBox.Text, cliente, sesion);
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
    }
}
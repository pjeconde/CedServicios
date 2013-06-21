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
            //int item = Convert.ToInt32(e.CommandArgument);
            //List<Entidades.Permiso> lista = (List<Entidades.Permiso>)ViewState["Permisos"];
            //Entidades.Permiso permiso = lista[item];
            //switch (e.CommandName)
            //{
            //    case "CambiarEstado":
            //        if (permiso.WF.Estado == "Vigente" || permiso.WF.Estado == "DeBaja")
            //        {
            //            TituloConfirmacionLabel.Text = "Confirmar " + (permiso.WF.Estado == "Vigente" ? "Baja" : "Anulación Baja");
            //            AccionLabel.Text = permiso.Accion.Tipo + " nº " + permiso.Accion.Nro;
            //            CuitLabel.Text = permiso.Cuit;
            //            IdTipoPermisoLabel.Text = permiso.TipoPermiso.Id;
            //            EstadoLabel.Text = permiso.WF.Estado;
            //            FechaFinVigenciaLabel.Text = permiso.FechaFinVigencia.ToString("dd/MM/yyyy");
            //            UNLabel.Text = permiso.IdUN.ToString();
            //            UsuarioLabel.Text = permiso.Usuario.Id;
            //            UsuarioSolicitanteLabel.Text = permiso.UsuarioSolicitante.Id;
            //            ViewState["Permiso"] = permiso;
            //            ModalPopupExtender1.Show();
            //        }
            //        else
            //        {
            //            MensajeLabel.Text = "El cambio de estado sólo puede usarse para Bajas o Anulaciones de bajas.";
            //        }
            //        break;
            //}
        }
        protected void ComprobantesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[12].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
        protected void CambiarEstadoButton_Click(object sender, EventArgs e)
        {
            //if (Funciones.SessionTimeOut(Session))
            //{
            //    Response.Redirect("~/SessionTimeout.aspx");
            //}
            //else
            //{
            //    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            //    Entidades.Permiso permiso = (Entidades.Permiso)ViewState["Permiso"];
            //    RN.Permiso.CambiarEstado(permiso, (permiso.WF.Estado == "Vigente" ? "DeBaja" : "Vigente"), sesion);
            //    BuscarButton_Click(BuscarButton, new EventArgs());
            //    Funciones.PersonalizarControlesMaster(Master, true, sesion);
            //}
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
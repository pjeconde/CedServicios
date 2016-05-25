using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CedServicios.Site
{
    public partial class PrecioIngresoManual : System.Web.UI.Page
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
                    CUITTextBox.Text = sesion.Cuit.Nro;
                    CUITTextBox.Enabled = false;
                    List<Entidades.ListaPrecio> listasPrecio = RN.ListaPrecio.ListaPorCuit(true, false, sesion);
                    ViewState["ListasPrecio"] = listasPrecio;
                    ViewState["MatrizDePrecios"] = RN.Precio.Matriz(listasPrecio, sesion);
                    ActualizarGrilla();
                }
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                if (sesion.UsuarioDemo == true)
                {
                    Response.Redirect("~/MensajeUsuarioDEMO.aspx");
                }
                try
                {
                    DataTable dt = (DataTable)ViewState["MatrizDePrecios"];
                    List<Entidades.ListaPrecio> listasPrecio = (List<Entidades.ListaPrecio>) ViewState["ListasPrecio"];
                    RN.Precio.ImpactarMatriz(listasPrecio, dt, sesion);
                    AceptarButton.Enabled = false;
                    preciosGridView.Enabled = false;
                    SalirButton.Text = "Salir";
                    MensajeLabel.Text = "Las Listas de Precios fueron actualizadas satisfactoriamente";
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
        protected void preciosGridView_RowCancelingEdit(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            preciosGridView.EditIndex = -1;
            ActualizarGrilla();
        }
        protected void preciosGridView_RowCommand(object sender, EventArgs e)
        {
        }
        protected void preciosGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            preciosGridView.EditIndex = e.NewEditIndex;
            ActualizarGrilla();
        }
        protected void preciosGridView_RowUpdated(object sender, EventArgs e)
        {
        }
        protected void preciosGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            GridViewRow row = preciosGridView.Rows[e.RowIndex];
            DataTable dt = (DataTable)ViewState["MatrizDePrecios"];
            for (int i=3; i<=dt.Columns.Count; i++)
            {
                dt.Rows[e.RowIndex][i-1] = (row.Cells[i].Controls[0] as TextBox).Text;
            }
            dt.AcceptChanges();
            ViewState["MatrizDePrecios"] = dt;
            preciosGridView.EditIndex = -1;
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            MensajeLabel.Text = String.Empty;
            preciosGridView.DataSource = (DataTable)ViewState["MatrizDePrecios"];
            preciosGridView.DataBind();
        }
    }
}
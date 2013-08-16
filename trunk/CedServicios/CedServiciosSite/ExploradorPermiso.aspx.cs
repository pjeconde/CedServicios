using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorPermiso : System.Web.UI.Page
    {
        List<Entidades.Permiso> permisos = new List<Entidades.Permiso>();

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
                    IdTipoPermisoDropDownList.DataSource = RN.TipoPermiso.Lista(true, sesion);
                    EstadoDropDownList.DataSource = RN.Estado.Lista(true, sesion);
                    DataBind();
                    IdTipoPermisoDropDownList.SelectedValue = String.Empty;
                    EstadoDropDownList.SelectedValue = String.Empty;
                }
            }
        }
        protected void PermisosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.Permiso> lista = (List<Entidades.Permiso>)ViewState["Permisos"];
            Entidades.Permiso permiso = lista[item];
            switch (e.CommandName)
            {
                case "CambiarEstado":
                    if (permiso.WF.Estado == "Vigente" || permiso.WF.Estado == "DeBaja")
                    {
                        TituloConfirmacionLabel.Text = "Confirmar " + (permiso.WF.Estado == "Vigente" ? "Baja" : "Anulación Baja");
                        AccionLabel.Text = permiso.Accion.Tipo + " nº " + permiso.Accion.Nro;
                        CuitLabel.Text = permiso.Cuit;
                        IdTipoPermisoLabel.Text = permiso.TipoPermiso.Id;
                        EstadoLabel.Text = permiso.WF.Estado;
                        FechaFinVigenciaLabel.Text = permiso.FechaFinVigencia.ToString("dd/MM/yyyy");
                        UNLabel.Text = permiso.IdUN.ToString();
                        UsuarioLabel.Text = permiso.Usuario.Id;
                        UsuarioSolicitanteLabel.Text = permiso.UsuarioSolicitante.Id;
                        ViewState["Permiso"] = permiso;
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        MensajeLabel.Text = "El cambio de estado sólo puede usarse para Bajas o Anulaciones de bajas.";
                    }
                    break;
            }
        }
        protected void PermisosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
        protected void CambiarEstadoButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                Entidades.Permiso permiso = (Entidades.Permiso)ViewState["Permiso"];
                string idEstadoHst = (permiso.WF.Estado == "Vigente" ? "DeBaja" : "Vigente");
                string idEvento = (idEstadoHst == "Vigente" ? "AnulBaja" : "Baja");
                RN.Permiso.CambiarEstado(permiso, idEvento, idEstadoHst, sesion);
                BuscarButton_Click(BuscarButton, new EventArgs());
                Funciones.PersonalizarControlesMaster(Master, true, sesion);
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
                List<Entidades.Permiso> lista = new List<Entidades.Permiso>();
                MensajeLabel.Text = String.Empty;
                lista = RN.Permiso.LeerListaPermisosFiltrados(IdUsuarioTextBox.Text, CUITTextBox.Text, IdTipoPermisoDropDownList.SelectedValue, EstadoDropDownList.SelectedValue, sesion);
                if (lista.Count == 0)
                {
                    PermisosGridView.DataSource = null;
                    PermisosGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Permisos que satisfagan la busqueda";
                }
                else
                {
                    PermisosGridView.DataSource = lista;
                    ViewState["Permisos"] = lista;
                    PermisosGridView.DataBind();
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class SolicPermisoOperServUN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SolicitarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Cuit cuit = new Entidades.Cuit();
                cuit.Nro = CUITTextBox.Text;
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                RN.Cuit.Leer(cuit, sesion);

                Entidades.UN un = new Entidades.UN();
                un.Cuit = cuit.Nro;
                un.Id = Convert.ToInt32(IdUNDropDownList.SelectedValue);
                RN.UN.Leer(un, sesion);

                Entidades.TipoPermiso tipoPermiso = new Entidades.TipoPermiso();
                tipoPermiso.Id = IdTipoPermisoDropDownList.SelectedValue.ToString();
                RN.TipoPermiso.Leer(tipoPermiso, sesion);

                string referenciaAAprobadores = String.Empty;

                RN.Permiso.SolicitarPermisoParaUsuario(cuit, un, tipoPermiso, out referenciaAAprobadores, sesion);

                CUITTextBox.Enabled = false;
                SolicitarButton.Enabled = false;
                CancelarButton.Enabled = false;
                MensajeLabel.Text = "El permiso fue enviado para su aprobación.<br />Autorizador(es): " + referenciaAAprobadores;
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void LeerListaUNsButton_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Cuit cuit = new Entidades.Cuit();
                cuit.Nro = CUITTextBox.Text;
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                RN.Cuit.Leer(cuit, sesion);
                IdUNDropDownList.DataSource = RN.UN.ListaVigentesPorCuit(cuit, sesion);
                DataBind();
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
        protected void LeerListaTipoPermisosUNButton_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.UN uN = new Entidades.UN();
                uN.Cuit = CUITTextBox.Text;
                uN.Id = Convert.ToInt32(IdUNDropDownList.SelectedValue);
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                IdTipoPermisoDropDownList.DataSource = RN.TipoPermiso.ListaPorUN(uN, sesion);
                DataBind();
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class UNModificar : System.Web.UI.Page
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
                    IdUNTextBox.Text = sesion.UN.Id.ToString();
                    IdUNTextBox.Enabled = false;
                    DescrUNTextBox.Text = sesion.UN.Descr;
                }
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
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
                    Entidades.UN un = RN.UN.ObternerCopia(sesion.UN);
                    un.Cuit = CUITTextBox.Text;
                    un.Id = Convert.ToInt32(IdUNTextBox.Text);
                    un.Descr = DescrUNTextBox.Text;
                    RN.UN.Modificar(un, sesion);

                    CUITTextBox.Enabled = false;
                    IdUNTextBox.Enabled = false;
                    DescrUNTextBox.Enabled = false;
                    AceptarButton.Enabled = false;
                    SalirButton.Enabled = false;
                    MensajeLabel.Text = "La Unidad de negocio fué modificada satisfactoriamente";
                }
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                return;
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}
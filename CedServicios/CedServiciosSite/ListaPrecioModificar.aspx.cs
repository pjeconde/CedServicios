using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ListaPrecioModificar : System.Web.UI.Page
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
                    Entidades.ListaPrecio listaPrecio = (Entidades.ListaPrecio)Session["ListaPrecio"];

                    CUITTextBox.Text = listaPrecio.Cuit;
                    IdTextBox.Text = listaPrecio.Id;
                    DescrTextBox.Text = listaPrecio.Descr;
                    CUITTextBox.Enabled = false;
                    IdTextBox.Enabled = false;
                    DescrTextBox.Focus();
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
                Entidades.ListaPrecio listaPrecioDesde = (Entidades.ListaPrecio)Session["ListaPrecio"];
                Entidades.ListaPrecio listaPrecioHasta = RN.ListaPrecio.ObternerCopia(listaPrecioDesde);
                try
                {
                    listaPrecioHasta.Cuit = CUITTextBox.Text;
                    listaPrecioHasta.Id = IdTextBox.Text;
                    listaPrecioHasta.Descr = DescrTextBox.Text;
                    RN.ListaPrecio.Modificar(listaPrecioDesde, listaPrecioHasta, sesion);

                    CUITTextBox.Enabled = false;
                    IdTextBox.Enabled = false;
                    DescrTextBox.Enabled = false;

                    AceptarButton.Enabled = false;
                    SalirButton.Text = "Salir";

                    MensajeLabel.Text = "La Lista de Precios fué modificada satisfactoriamente";
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                    return;
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ListaPrecioBaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
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
                    OrdenTextBox.Text = listaPrecio.Orden.ToString();
                    IdTipoListaPrecioDropDownList.SelectedValue = listaPrecio.IdTipo;

                    CUITTextBox.Enabled = false;
                    IdTextBox.Enabled = false;
                    DescrTextBox.Enabled = false;
                    OrdenTextBox.Enabled = false;
                    IdTipoListaPrecioDropDownList.Enabled = false;

                    if (listaPrecio.WF.Estado == "Vigente")
                    {
                        TituloPaginaLabel.Text = "Baja de Lista de Precios";
                        AceptarButton.Text = "Dar de Baja";
                    }
                    else
                    {
                        TituloPaginaLabel.Text = "Anulación de Baja de Lista de Precios";
                        AceptarButton.Text = "Anular Baja";
                    }
                    AceptarButton.Focus();
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
                Entidades.ListaPrecio listaPrecio = (Entidades.ListaPrecio)Session["ListaPrecio"];
                try
                {
                    if (AceptarButton.Text == "Dar de Baja")
                    {
                        RN.ListaPrecio.CambiarEstado(listaPrecio, "DeBaja", sesion);
                    }
                    else
                    {
                        RN.ListaPrecio.CambiarEstado(listaPrecio, "Vigente", sesion);
                    }
                    AceptarButton.Enabled = false;
                    SalirButton.Text = "Salir";

                    MensajeLabel.Text = "El cambio de estado fué registrado satisfactoriamente";
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class PuntoVtaSeleccionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string a = HttpContext.Current.Request.Url.Query.ToString().Replace("?", String.Empty);
                    switch (a)
                    {
                        case "Modificar":
                            TituloPaginaLabel.Text = "Modificación de Punto de Venta";
                            break;
                    }
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    IdUNDropDownList.DataSource = sesion.Cuit.UNs;
                    PuntoVtaDropDownList.DataSource = sesion.UN.PuntosVta;
                    DataBind();

                    CUITTextBox.Text = sesion.Cuit.Nro;
                    CUITTextBox.Enabled = false;
                    IdUNDropDownList.SelectedValue = sesion.UN.Id.ToString();
                    IdUNDropDownList.Enabled = false;
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                }
            }
        }
        protected void ContinuarButton_Click(object sender, EventArgs e)
        {
            if (PuntoVtaDropDownList.SelectedValue == String.Empty)
            {
                MensajeLabel.Text = "No ha seleccionado ningún Punto de Venta";
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                Session["PuntoVta"] = sesion.UN.PuntosVta[PuntoVtaDropDownList.SelectedIndex];
                Response.Redirect("~/PuntoVtaModificar.aspx");
            }
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
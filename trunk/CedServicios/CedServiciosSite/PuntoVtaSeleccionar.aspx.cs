using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

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
                            ViewState["IrA"] = "~/PuntoVtaModificar.aspx";
                            break;
                        case "Baja":
                            TituloPaginaLabel.Text = "Baja/Anul.baja de Punto de Venta";
                            ViewState["IrA"] = "~/PuntoVtaBaja.aspx";
                            break;
                    }
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    IdUNDropDownList.DataSource = sesion.Cuit.UNs;
                    //PuntoVtaDropDownList.DataSource = sesion.UN.PuntosVta;
                    PuntosVtaGridView.DataSource = sesion.UN.PuntosVta;
                    PuntosVtaGridView.DataBind();
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
        protected void PuntosVtaGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.PuntoVta puntoVta = sesion.UN.PuntosVta[item];
            switch (e.CommandName)
            {
                case "Seleccionar":
                    Session["PuntoVta"] = puntoVta;
                    Response.Redirect(ViewState["IrA"].ToString());
                    break;
            }
        }
        protected void PuntosVtaGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
    }
}
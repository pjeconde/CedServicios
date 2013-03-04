using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class FacturaElectronica : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MensajeGeneralLabel.Text = ((Entidades.Sesion)Session["Sesion"]).MensajeGeneral;
            //if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre != null)
            //{
            //    NombreCuentaLabel.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
            //    Separador1Label.Visible = true;
            //    ConfiguracionLinkButton.Visible = true;
            //    Separador2Label.Visible = true;
            //    BackupLinkButton.Visible = true;
            //    Separador3Label.Visible = true;
            //    SalirLinkButton.Visible = true;
            //    switch (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.TipoCuenta.Id)
            //    {
            //        case "Admin":
            //            AdministracionLinkButton.Visible = true;
            //            break;
            //        case "Prem":
            //            switch (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.EstadoCuenta.Id)
            //            {
            //                case "Vigente":
            //                    ServicioPremiumEstadoLabel.Text = "Servicio Premium vigente";
            //                    TimeSpan n = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.FechaVtoPremium.Subtract(DateTime.Today);
            //                    if (n.Days == 0)
            //                    {
            //                        ServicioPremiumVtoLabel.Text = "(caduca hoy)";
            //                    }
            //                    else
            //                    {
            //                        if (n.Days == 1)
            //                        {
            //                            ServicioPremiumVtoLabel.Text = "(caduca mañana)";
            //                        }
            //                        else
            //                        {
            //                            if (n.Days > 1 && n.Days < 10)
            //                            {
            //                                ServicioPremiumVtoLabel.Text = "(caduca en " + n.Days.ToString() + " días)";
            //                            }
            //                        }
            //                    }
            //                    break;
            //                case "Suspend":
            //                    ServicioPremiumEstadoLabel.Text = "Servicio Premium suspendido";
            //                    break;
            //            }
            //            break;
            //        case "Free":
            //            ServicioPremiumEstadoLabel.Text = "Servicio Premium no activado";
            //            break;
            //    }
            //}
            //else
            //{
            //    NombreCuentaLabel.Text = string.Empty;
            //    Separador1Label.Visible = false;
            //    ConfiguracionLinkButton.Visible = false;
            //    Separador2Label.Visible = false;
            //    BackupLinkButton.Visible = false;
            //    Separador3Label.Visible = false;
            //    SalirLinkButton.Visible = false;
            //    AdministracionLinkButton.Visible = false;
            //    ServicioPremiumEstadoLabel.Text = string.Empty;
            //}
            //if (Request.UrlReferrer != null)
            //{
            //    Session["ref"] = Request.UrlReferrer.AbsoluteUri;
            //}
        }
        public void SalirLinkButton_Click(object sender, EventArgs e)
        {
            CaducarIdentificacion();
			Response.Redirect("~/Inicio.aspx");
		}
        public void CaducarIdentificacion()
        {
            //CedWebEntidades.Sesion sesion = (CedWebEntidades.Sesion)Session["Sesion"];
            //sesion.Cuenta = new CedWebEntidades.Cuenta();
            //NombreCuentaLabel.Text = String.Empty;
            //Separador1Label.Visible = false;
            //ConfiguracionLinkButton.Visible = false;
            //Separador2Label.Visible = false;
            //BackupLinkButton.Visible = false;
            //Separador3Label.Visible = false;
            //SalirLinkButton.Visible = false;
            //AdministracionLinkButton.Visible = false;
            //Session["AceptarTYC"] = null;
        }
    }
}

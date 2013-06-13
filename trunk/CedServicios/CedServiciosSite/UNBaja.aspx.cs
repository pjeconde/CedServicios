using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class UNBaja : System.Web.UI.Page
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
                    IdUNTextBox.Text = sesion.UN.Id.ToString();
                    DescrUNTextBox.Text = sesion.UN.Descr;

                    CUITTextBox.Enabled = false;
                    IdUNTextBox.Enabled = false;
                    DescrUNTextBox.Enabled = false;

                    if (sesion.UN.WF.Estado == "Vigente")
                    {
                        TituloPaginaLabel.Text = "Baja de Unidad de Negocio";
                        AceptarButton.Text = "Dar de Baja";
                    }
                    else
                    {
                        TituloPaginaLabel.Text = "Anulación de Baja de Unidad de Negocio";
                        AceptarButton.Text = "Anular Baja";
                    }
                    AceptarButton.Focus();
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
                    if (AceptarButton.Text == "Dar de Baja")
                    {
                        RN.UN.CambiarEstado(sesion.UN, "DeBaja", sesion);
                    }
                    else
                    {
                        RN.UN.CambiarEstado(sesion.UN, "Vigente", sesion);
                    }

                    AceptarButton.Enabled = false;
                    SalirButton.Text = "Salir";

                    MensajeLabel.Text = "El cambio de estado fué registrado satisfactoriamente";
                }
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                return;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class PuntoVtaCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];

                IdUNDropDownList.DataSource = RN.UN.ListaVigentesPorCuit(sesion.Cuit, sesion);
                IdTipoPuntoVtaDropDownList.DataSource = RN.TipoPuntoVta.Lista(sesion);
                IdMetodoGeneracionNumeracionLoteDropDownList.DataSource = RN.MetodoGeneracionNumeracionLote.Lista(sesion);
                DataBind();

                CUITTextBox.Text = sesion.Cuit.Nro;
                CUITTextBox.Enabled = false;
                IdUNDropDownList.SelectedValue = sesion.UN.Id.ToString();
                IdUNDropDownList.Enabled = false;
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void UsaSetPropioDeDatosCuitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Domicilio.Visible = !UsaSetPropioDeDatosCuitCheckBox.Checked;
            Contacto.Visible = !UsaSetPropioDeDatosCuitCheckBox.Checked;
            DatosImpositivos.Visible = !UsaSetPropioDeDatosCuitCheckBox.Checked;
            DatosIdentificatorios.Visible = !UsaSetPropioDeDatosCuitCheckBox.Checked;
        }
    }
}
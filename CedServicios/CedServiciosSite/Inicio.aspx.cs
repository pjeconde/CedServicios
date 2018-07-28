using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string EmailContactoValue = "";

        protected void ContactoButton_Click(object sender, EventArgs e)
        {
            EmailContactoValue = Request.Form["EmailContacto"];
            Entidades.ContactoSite contacto = new Entidades.ContactoSite();
            contacto.Nombre = NombreContacto.Value;
            contacto.Email = Request.Form["EmailContacto"];
            contacto.Mensaje = MensajeContacto.Value;
            if (optFea.Checked)
            {
                contacto.Motivo = "FactElectronica";
            }
            else
            {
                contacto.Motivo = "Otro";
            }
            try
            {
                RN.ContactoSite.ValidarSimple(contacto);
                RN.ContactoSite.Registrar(contacto);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Formulario enviado satisfactoriamente');", true);
                NombreContacto.Value = "";
                MensajeContacto.Value = "";
                EmailContactoValue = "";
            }
            catch (Exception ex)
            {
                string MensajeLabel = EX.Funciones.Detalle(ex);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + MensajeLabel.ToString().Replace("'", "") + "');", true);
            }
        }

    }
}
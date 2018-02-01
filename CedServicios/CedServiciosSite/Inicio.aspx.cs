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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Entidades.ContactoSite contacto = new Entidades.ContactoSite();
            contacto.Nombre = Request.Form["NombreContacto"];
            contacto.Email = Request.Form["EmailContacto"];
            contacto.Mensaje = Request.Form["MensajeContacto"];
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
            }
            catch (Exception ex)
            {
                string MensajeLabel = EX.Funciones.Detalle(ex);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + MensajeLabel.ToString().Replace("'", "") + "');", true);
            }
        }

    }
}
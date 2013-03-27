using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class CuitCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.Cuit cuit = new Entidades.Cuit();

            
            try
            {
                cuit.Nro =CUITTextBox.Text;
                cuit.RazonSocial = RazonSocialTextBox.Text;
                cuit.Domicilio.Calle = Domicilio.Calle;
                cuit.Domicilio.Nro = Domicilio.Nro;
                cuit.Domicilio.Piso = Domicilio.Piso;
                cuit.Domicilio.Depto = Domicilio.Depto;
                cuit.Domicilio.Manzana = Domicilio.Manzana;
                cuit.Domicilio.Sector = Domicilio.Sector;
                cuit.Domicilio.Torre = Domicilio.Torre;
                cuit.Domicilio.Localidad = Domicilio.Localidad;
                cuit.Domicilio.Provincia.Id = Domicilio.Provincia;
                cuit.Domicilio.CodPost = Domicilio.CodPost;
                cuit.Contacto.Nombre = "";
                cuit.Contacto.Email = "";
                cuit.Contacto.Telefono = "";
                cuit.DatosImpositivos.IdCondIVA = 0;
                cuit.DatosImpositivos.IdCondIngBrutos = 0;
                cuit.DatosImpositivos.NroIngBrutos = "";
                cuit.DatosImpositivos.FechaInicioActividades = DateTime.Now;
                cuit.DatosIdentificatorios.GLN = 0;
                cuit.DatosIdentificatorios.CodigoInterno = "";
                cuit.Medio.Id = "";
                RN.Cuit.Registrar(cuit, sesion);
                //CUITTextBox.Enabled = false;
                //IdUNTextBox.Enabled = false;
                //DescrUNTextBox.Enabled = false;
                AceptarButton.Enabled = false;
                CancelarButton.Enabled = false;
                MensajeLabel.Text = "El CUIT fué creado satisfactoriamente";
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                return;
            }
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
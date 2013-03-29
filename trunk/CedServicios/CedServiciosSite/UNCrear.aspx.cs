using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class UNCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.Cuit cuit = new Entidades.Cuit();
            Entidades.UN un = new Entidades.UN();
            Entidades.TipoPermiso tipoPermiso = new Entidades.TipoPermiso();
            try
            {
                cuit.Nro = CUITTextBox.Text;
                RN.Cuit.Leer(cuit, sesion);
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                return;
            }
            try
            {
                un.Cuit = CUITTextBox.Text;
                un.Id = Convert.ToInt32(IdUNTextBox.Text);
                RN.UN.Leer(un, sesion);
                throw new EX.Validaciones.ElementoYaInexistente("Unidad de negocio '" + un.Id + "' del Cuit " + un.Cuit);
            }
            catch (EX.Validaciones.ElementoInexistente)
            {
                string referenciaAAprobadores = String.Empty;
                un.Descr = DescrUNTextBox.Text;
                string estadoPermisoUsoCUITxUN = String.Empty;
                RN.UN.Registrar(un, out referenciaAAprobadores, out estadoPermisoUsoCUITxUN, sesion);

                CUITTextBox.Enabled = false;
                IdUNTextBox.Enabled = false;
                DescrUNTextBox.Enabled = false;
                AceptarButton.Enabled = false;
                CancelarButton.Enabled = false;
                if (estadoPermisoUsoCUITxUN == "Vigente")
                {
                    MensajeLabel.Text = "La Unidad de negocio fué creada satisfactoriamente";
                }
                else
                {
                    MensajeLabel.Text = "La Unidad de negocio fué creada satisfactoriamente.<br />Se ha solicitado la autorización de su vinculación con el CUIT<br />Autorizador(es): " + referenciaAAprobadores;
                }
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
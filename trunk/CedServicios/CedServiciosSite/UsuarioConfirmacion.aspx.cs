using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class UsuarioConfirmacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string a = HttpContext.Current.Request.Url.Query.ToString();
                if (a == String.Empty)
                {
                    throw new EX.Usuario.UsuarioConfFormatoMsgErroneo();
                }
                else
                {
                    if (a.Substring(0, 4) == "?Id=")
                    {
                        a = a.Substring(4);
                    }
                    string idUsuario = a;
                    Entidades.Usuario usuario = new Entidades.Usuario();
                    usuario.Id = idUsuario;
                    RN.Usuario.Confirmar(usuario, true, true, (Entidades.Sesion)Session["Sesion"]);
                    MensajeLabel.Text = "Felicitaciones !!!.<br /><br />Su nueva cuenta '" + usuario.Id + "' ya está disponible.<br />Para ingresar a la aplicación, haga click en 'Iniciar sesión'";
                }
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(new EX.Usuario.UsuarioConfFormatoMsgErroneo());
            }
            catch (System.FormatException)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(new EX.Usuario.UsuarioConfFormatoMsgErroneo());
            }
            catch (EX.Validaciones.ElementoInexistente)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(new EX.Usuario.UsuarioConfFormatoMsgErroneo());
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
    }
}
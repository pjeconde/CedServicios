using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioTextBox.Focus();
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                sesion.URLsite = HttpContext.Current.Request.Url.AbsoluteUri.Replace("UsuarioLogin.aspx", string.Empty);
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Menu menu = ((Menu)Master.FindControl("MenuContentPlaceHolder").FindControl("Menu"));
            Funciones.RemoverMenuItem(menu, "Iniciar sesión");
        }
        protected void LoginUsuarioDEMOButton_Click(object sender, EventArgs e)
        {
            try
            {
                MensajeLabel.Text = String.Empty;
                Entidades.Usuario usuarioAux = new Entidades.Usuario();
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                //Leer para obtener el usuario de DEMO de la tabla Configuracion.
                Entidades.Configuracion confUsuarioDEMO = RN.Configuracion.LeerUsuarioDEMO(sesion);
                usuarioAux.Id = confUsuarioDEMO.IdUsuario;
                //Leer para obtener la password actual.
                RN.Usuario.Leer(usuarioAux, sesion);
                
                //Hacer el login, agregando la marca de modalidad DEMO.
                Entidades.Usuario usuario = new Entidades.Usuario();
                usuario.Id = usuarioAux.Id;
                usuario.Password = usuarioAux.Password;
                sesion.UsuarioDemo = true;
                RN.Usuario.Login(usuario, sesion);
                RN.Sesion.AsignarUsuario(usuario, sesion);
                RN.ReporteActividad.EnviarSiCorresponde(sesion);
                Response.Redirect(usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (EX.Validaciones.ElementoInexistente ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                UsuarioTextBox.Focus();
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                UsuarioTextBox.Focus();
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                MensajeLabel.Text = String.Empty;
                Entidades.Usuario usuario = new Entidades.Usuario();
                usuario.Id = UsuarioTextBox.Text;
                usuario.Password = PasswordTextBox.Text;
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                RN.Usuario.Login(usuario, sesion);
                RN.Sesion.AsignarUsuario(usuario, sesion);
                RN.ReporteActividad.EnviarSiCorresponde(sesion);
                Response.Redirect(usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (EX.Validaciones.ElementoInexistente ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                UsuarioTextBox.Focus();
            }
            catch (EX.Usuario.LoginRechazadoXPasswordInvalida ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                PasswordTextBox.Focus();
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                UsuarioTextBox.Focus();
            }
        }
        protected void UsuarioTextBox_TextChanged(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
        }
        protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
        }
        protected void MultiCuitLinkButton_Click(object sender, EventArgs e)
        {
            AclaracionTituloLabel.Text = "Entorno Multi-CUIT";
            AclaracionDetalleLabel.Text = "Con la misma Cuenta se pueden operar uno o más CUITs.";
        }
        protected void MultiUNLinkButton_Click(object sender, EventArgs e)
        {
            AclaracionTituloLabel.Text = "Entorno Multi-Unidad de Negocio";
            AclaracionDetalleLabel.Text = "Para cada CUIT se puede definir una o más Unidades de Negocio (*).<br /><br />(*) Concepto asimilable al de 'sucursal'";
        }
        protected void MultiUsuarioLinkButton_Click(object sender, EventArgs e)
        {
            AclaracionTituloLabel.Text = "Entorno Multi-Usuario";
            AclaracionDetalleLabel.Text = "Uno o más usuarios pueden compartir su trabajo dentro de su propio grupo.<br />Los usuarios administradores (de CUITs y de Unidades de Negocio), serán<br />los responsables de autorizar el acceso a los usuarios operadores.";
        }
    }
}
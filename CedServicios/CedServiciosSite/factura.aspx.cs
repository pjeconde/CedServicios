using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //UsuarioTextBox.Focus();
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                sesion.URLsite = HttpContext.Current.Request.Url.AbsoluteUri.Replace("factura.aspx", string.Empty);
            }
            if (Page.Request["LoginButton"] == "LoginButton")
            {
                LoginButton_Click(Page.Request["UsuarioTextBox"].ToString(), Page.Request["PasswordTextBox"].ToString());
            }
        }

        //protected void LoginUsuarioDEMOButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        MensajeLabel.Text = String.Empty;
        //        Entidades.Usuario usuarioAux = new Entidades.Usuario();
        //        Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
        //        //Leer para obtener el usuario de DEMO de la tabla Configuracion.
        //        Entidades.Configuracion confUsuarioDEMO = RN.Configuracion.LeerUsuarioDEMO(sesion);
        //        usuarioAux.Id = confUsuarioDEMO.IdUsuario;
        //        //Leer para obtener la password actual.
        //        RN.Usuario.Leer(usuarioAux, sesion);

        //        //Hacer el login, agregando la marca de modalidad DEMO.
        //        Entidades.Usuario usuario = new Entidades.Usuario();
        //        usuario.Id = usuarioAux.Id;
        //        usuario.Password = usuarioAux.Password;
        //        sesion.UsuarioDemo = true;
        //        RN.Usuario.Login(usuario, sesion);
        //        RN.Sesion.AsignarUsuario(usuario, sesion, Request.UserHostAddress);
        //        RN.ReporteActividad.EnviarSiCorresponde(sesion);
        //        Response.Redirect(usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        //    }
        //    catch (System.Threading.ThreadAbortException)
        //    {
        //        Trace.Warn("Thread abortado");
        //    }
        //    catch (EX.Validaciones.ElementoInexistente ex)
        //    {
        //        MensajeLabel.Text = EX.Funciones.Detalle(ex);
        //        UsuarioTextBox.Focus();
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeLabel.Text = EX.Funciones.Detalle(ex);
        //        UsuarioTextBox.Focus();
        //    }
        //}

        private void LoginButton_Click(string user, string clave)
        {
            try
            {
                MensajeLabel.Text = String.Empty;
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                Entidades.Usuario usuario = new Entidades.Usuario();
                usuario.Id = user;
                usuario.Password = clave;
                sesion.UsuarioDemo = false;
                RN.Usuario.Login(usuario, sesion);
                RN.Sesion.AsignarUsuario(usuario, sesion, Request.UserHostAddress);
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
                //UsuarioTextBox.Focus();
            }
            catch (EX.Usuario.LoginRechazadoXPasswordInvalida ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                //PasswordTextBox.Focus();
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                //UsuarioTextBox.Focus();
            }
        }

        //protected void LoginButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        MensajeLabel.Text = String.Empty;
        //        Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
        //        Entidades.Usuario usuario = new Entidades.Usuario();
        //        usuario.Id = UsuarioTextBox.Value;
        //        usuario.Password = PasswordTextBox.Value;
        //        sesion.UsuarioDemo = false;
        //        RN.Usuario.Login(usuario, sesion);
        //        RN.Sesion.AsignarUsuario(usuario, sesion, Request.UserHostAddress);
        //        RN.ReporteActividad.EnviarSiCorresponde(sesion);
        //        Response.Redirect(usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        //    }
        //    catch (System.Threading.ThreadAbortException)
        //    {
        //        Trace.Warn("Thread abortado");
        //    }
        //    catch (EX.Validaciones.ElementoInexistente ex)
        //    {
        //        MensajeLabel.Text = EX.Funciones.Detalle(ex);
        //        UsuarioTextBox.Focus();
        //    }
        //    catch (EX.Usuario.LoginRechazadoXPasswordInvalida ex)
        //    {
        //        MensajeLabel.Text = EX.Funciones.Detalle(ex);
        //        PasswordTextBox.Focus();
        //    }
        //    catch (Exception ex)
        //    {
        //        MensajeLabel.Text = EX.Funciones.Detalle(ex);
        //        UsuarioTextBox.Focus();
        //    }
        //}
        protected void UsuarioTextBox_TextChanged(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
        }
        protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
        }
    }
}
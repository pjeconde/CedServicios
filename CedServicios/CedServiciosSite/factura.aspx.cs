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
                sesion.URLsite = HttpContext.Current.Request.Url.AbsoluteUri.Replace("factura.aspx", string.Empty).Replace("?login=salir", string.Empty).Replace("?login=ingresar", string.Empty);
                if (sesion.Usuario.Id != null)
                {
                    formlogin.Visible = false;
                    if (Request.QueryString["login"] == "ingresar")
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    formLoginActivo.Visible = true;
                    if (Request.QueryString["login"] == "salir")
                    {
                        Salir();
                        formlogin.Visible = true;
                        formLoginActivo.Visible = false;
                    }
                }
                else
                {
                    formlogin.Visible = true;
                    formLoginActivo.Visible = false;
                }
            }
            if (Page.Request["LoginButton"] == "LoginButton")
            {
                LoginButton_Click(Page.Request["UsuarioTextBox"].ToString(), Page.Request["PasswordTextBox"].ToString());
            }
            if (Page.Request["SuscribirButton"] == "SuscribirButton")
            {
                SuscribirButton_Click(Page.Request["EmailTextBox"].ToString());
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

        private void Salir()
        {
            MensajeLabel.Text = String.Empty;
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            RN.Sesion.Cerrar(sesion);
        }
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
        private void SuscribirButton_Click(string email)
        {
            try
            {
                MensajeLabel.Text = String.Empty;
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                Entidades.BusquedaLaboral busquedaLaboral = new Entidades.BusquedaLaboral();
                busquedaLaboral.Email = email;
                busquedaLaboral.Estado = "Vigente";
                RN.BusquedaLaboral.Crear(busquedaLaboral, sesion);
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
        }

        //protected void UsuarioTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    MensajeLabel.Text = String.Empty;
        //}
        //protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    MensajeLabel.Text = String.Empty;
        //}
    }
}
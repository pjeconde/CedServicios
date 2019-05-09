using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class Autorizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string a = RN.Funciones.Desencriptar(HttpContext.Current.Request.Url.Query.ToString().Substring(1));
                string[] delim=new string[]{"<<<>>>"};
                string[] b = a.Split(delim, StringSplitOptions.None);

                Entidades.Permiso permiso = new Entidades.Permiso();
                permiso.Usuario.Id = b[0];
                permiso.Cuit = b[1];
                permiso.UN.Id = Convert.ToInt32(b[2]);
                permiso.TipoPermiso.Id = b[3];
                string idUsuarioAutorizador = b[4];
                
                Entidades.Usuario usuarioAutorizador = new Entidades.Usuario();
                usuarioAutorizador.Id = idUsuarioAutorizador;
                RN.Usuario.Leer(usuarioAutorizador, (Entidades.Sesion)Session["Sesion"]);
                List<Entidades.Usuario> usuarioAutorizadorLista = new List<Entidades.Usuario>();
                usuarioAutorizadorLista.Add(usuarioAutorizador);
                IdUsuarioAutorizadorDropDownList.DataSource = usuarioAutorizadorLista;
                IdUsuarioAutorizadorDropDownList.SelectedValue = idUsuarioAutorizador;

                RN.TipoPermiso.Leer(permiso.TipoPermiso, (Entidades.Sesion)Session["Sesion"]);
                List<Entidades.TipoPermiso> tipoPermisoLista = new List<Entidades.TipoPermiso>();
                tipoPermisoLista.Add(permiso.TipoPermiso);
                IdTipoPermisoDropDownList.DataSource = tipoPermisoLista;
                IdTipoPermisoDropDownList.SelectedValue = permiso.TipoPermiso.Id;

                CUITTextBox.Text = permiso.Cuit;

                if (permiso.UN.Id != 0)
                {
                    Entidades.Cuit cuit = new Entidades.Cuit();
                    cuit.Nro = permiso.Cuit;
                    RN.Cuit.Leer(cuit, (Entidades.Sesion)Session["Sesion"]);
                    RN.Cuit.CompletarUNsYPuntosVta(new List<Entidades.Cuit> { cuit }, (Entidades.Sesion)Session["Sesion"]);
                    IdUNDropDownList.DataSource = cuit.UNs;
                    IdUNDropDownList.SelectedValue = permiso.UN.Id.ToString();
                }
                else
                {
                    IdUNLabel.Visible = false;
                    IdUNDropDownList.Visible = false;
                }

                RN.Usuario.Leer(permiso.Usuario, (Entidades.Sesion)Session["Sesion"]);
                List<Entidades.Usuario> usuarioLista = new List<Entidades.Usuario>();
                usuarioLista.Add(permiso.Usuario);
                IdUsuarioDropDownList.DataSource = usuarioLista;
                IdUsuarioDropDownList.SelectedValue = permiso.Usuario.Id;

                try
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    RN.Permiso.Leer(permiso, sesion);
                    RN.Usuario.Leer(permiso.UsuarioSolicitante, sesion);
                }
                catch (EX.Validaciones.ElementoInexistente)
                {
                    MensajeLabel.Text = "Esta intervensión ya no resulta necesaria, porque la solicitud ha cambiado de estado" + TextoIniciarSesion();
                    DeshabilitarBotones();
                }
                ViewState["Permiso"] = permiso;

                DataBind();
            }
        }
        protected void AutorizarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Sesion s = (Entidades.Sesion)Session["Sesion"];
                if (s.UsuarioDemo == true)
                {
                    Response.Redirect("~/MensajeUsuarioDEMO.aspx");
                }
                Entidades.Sesion sesion = ClonarSesion(IdUsuarioAutorizadorDropDownList.SelectedValue);
                if (RN.Permiso.Autorizar((Entidades.Permiso)ViewState["Permiso"], sesion))
                    MensajeLabel.Text = "La autorización fué registrada satisfactoriamente.";
                else
                    MensajeLabel.Text = "La autorización no es posible porque la solicitud ya ha cambiado de estado.";
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
            finally
            {
                MensajeLabel.Text += TextoIniciarSesion();
                DeshabilitarBotones();
            }
        }
        protected void RechazarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Sesion sesion = ClonarSesion(IdUsuarioAutorizadorDropDownList.SelectedValue);
                if (RN.Permiso.Rechazar((Entidades.Permiso)ViewState["Permiso"], sesion))
                    MensajeLabel.Text = "El rechazo fué registrado satisfactoriamente.";
                else
                    MensajeLabel.Text = "El rechazo no es posible porque la solicitud ya ha cambiado de estado.";
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
            finally
            {
                MensajeLabel.Text += TextoIniciarSesion();
                DeshabilitarBotones();
            }
        }
        private Entidades.Sesion ClonarSesion(string IdUsuario)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.Sesion sesionClonada = new Entidades.Sesion();
            sesionClonada.CnnStr = sesion.CnnStr;
            sesionClonada.Usuario.Id = IdUsuario;
            RN.Usuario.Leer(sesionClonada.Usuario, sesion);
            return sesionClonada;
        }
        private void DeshabilitarBotones()
        {
            AutorizarButton.Enabled = false;
            RechazarButton.Enabled = false;
            SalirButton.Text = "Salir";
        }
        private string TextoIniciarSesion()
        {
            return "<br />Para ingresar a la aplicación, haga click en 'Ingresar'";
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}
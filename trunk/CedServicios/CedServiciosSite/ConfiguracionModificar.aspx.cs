using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ConfiguracionModificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    MensajeLabel.Text = String.Empty;
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    TituloPaginaLabel.Text = "Modificación datos de Configuración";
                    String path = Server.MapPath("~/ImagenesSubidas/");
                    string[] archivos = System.IO.Directory.GetFiles(path, sesion.Usuario.Id + ".*", System.IO.SearchOption.TopDirectoryOnly);
                    if (archivos.Length > 0)
                    {
                        Image1.ImageUrl = "~/ImagenesSubidas/" + archivos[0].Replace(Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                    }
                    if (sesion.Usuario.CuitPredef != String.Empty)
                    {
                        CUITTextBox.Text = sesion.Usuario.CuitPredef;
                        if (sesion.Usuario.IdUNPredef != 0)
                        {
                            IdUNTextBox.Text = sesion.Usuario.IdUNPredef.ToString();
                            Entidades.UN un = new Entidades.UN();
                            un.Cuit = sesion.Usuario.CuitPredef;
                            un.Id = sesion.Usuario.IdUNPredef;
                            RN.UN.Leer(un, sesion);
                            DescrUNTextBox.Text = un.Descr;
                        }
                        else
                        {
                            DescrUNTextBox.Text = "ninguno";
                            IdUNTextBox.Text = String.Empty;
                        }
                    }
                    else
                    {
                        CUITTextBox.Text = "ninguno";
                        DescrUNTextBox.Text = "ninguno";
                        IdUNTextBox.Text = String.Empty;
                    }
                    CantidadFilasXPaginaTextBox.Text = sesion.Usuario.CantidadFilasXPagina.ToString();
                }
            }
        }
        protected void SubirImagenButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                if (sesion.UsuarioDemo == true)
                {
                    Response.Redirect("~/MensajeUsuarioDEMO.aspx");
                }
                Boolean fileOK = false;
                String fileExtension = String.Empty;
                String path = Server.MapPath("~/ImagenesSubidas/");
                if (FileUpload1.HasFile)
                {
                    fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    String[] allowedExtensions = { ".jpg", ".png", ".jpeg", ".gif" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }
                if (fileOK)
                {
                    try
                    {
                        BorrarImagenButton_Click(BorrarImagenButton, new EventArgs());
                        FileUpload1.PostedFile.SaveAs(path + sesion.Usuario.Id + fileExtension);
                        Image1.ImageUrl = "ImagenesSubidas/" + sesion.Usuario.Id + fileExtension;
                    }
                    catch (Exception ex)
                    {
                        MensajeLabel.Text = "No se pudo subir el archivo.<br />" + EX.Funciones.Detalle(ex);
                    }
                }
                else
                {
                    MensajeLabel.Text = "Tipo de archivo erróneo";
                }
            }
        }
        protected void BorrarImagenButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                if (sesion.UsuarioDemo == true)
                {
                    Response.Redirect("~/MensajeUsuarioDEMO.aspx");
                }
                String path = Server.MapPath("~/ImagenesSubidas/");
                string[] archivos = System.IO.Directory.GetFiles(path, sesion.Usuario.Id + ".*", System.IO.SearchOption.TopDirectoryOnly);
                for (int i = 0; i < archivos.Length; i++)
                {
                    System.IO.File.Delete(archivos[i]);
                    Image1.ImageUrl = "Imagenes/Interrogacion.jpg";
                }
            }
        }
        protected void PredefinirCUITyUNactualesButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                if (sesion.UsuarioDemo == true)
                {
                    Response.Redirect("~/MensajeUsuarioDEMO.aspx");
                }
                if (sesion.Cuit.Nro != null)
                {
                    CUITTextBox.Text = sesion.Cuit.Nro;
                }
                else
                {
                    CUITTextBox.Text = "ninguno";
                }
                if (sesion.UN.Id != 0)
                {
                    DescrUNTextBox.Text = sesion.UN.Descr;
                    IdUNTextBox.Text = sesion.UN.Id.ToString();
                }
                else
                {
                    DescrUNTextBox.Text = "ninguno";
                    IdUNTextBox.Text = String.Empty;
                }
                if (CUITTextBox.Text != "ninguno" && DescrUNTextBox.Text != "ninguno")
                {
                    RN.Configuracion.EstablecerCUITUNpredef(CUITTextBox.Text, Convert.ToInt32(IdUNTextBox.Text), sesion);
                    sesion.Usuario.CuitPredef = CUITTextBox.Text;
                    sesion.Usuario.IdUNPredef = Convert.ToInt32(IdUNTextBox.Text);
                }
                else
                {
                    MensajeLabel.Text = "No hay CUIT/UN seleccionados";
                }
            }
        }
        protected void ConfirmarCantidadFilasXPaginaButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            if (sesion.UsuarioDemo == true)
            {
                Response.Redirect("~/MensajeUsuarioDEMO.aspx");
            }
            MensajeLabel.Text = String.Empty;
            int cantidadFilasXPagina;
            if (!int.TryParse(CantidadFilasXPaginaTextBox.Text, out cantidadFilasXPagina) || cantidadFilasXPagina < 1)
            {
                MensajeLabel.Text = "Valor inválido (ingresar un valor numérico, mayor a cero)";
                CantidadFilasXPaginaTextBox.Focus();
            }
            else
            {
                RN.Configuracion.EstablecerCantidadFilasXPagina(cantidadFilasXPagina, (Entidades.Sesion)Session["Sesion"]);
            }
        }
    }
}
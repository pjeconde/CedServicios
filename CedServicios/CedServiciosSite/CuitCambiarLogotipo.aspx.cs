using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class CuitCambiarLogotipo : System.Web.UI.Page
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
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    CUITTextBox.Text = sesion.Cuit.Nro;
                    CUITTextBox.Enabled = false;
                    String path = Server.MapPath("~/ImagenesSubidas/");
                    string[] archivos = System.IO.Directory.GetFiles(path, CUITTextBox.Text + ".*", System.IO.SearchOption.TopDirectoryOnly);
                    if (archivos.Length > 0)
                    {
                        LogotipoImage.ImageUrl = "~/ImagenesSubidas/" + archivos[0].Replace(Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                    }
                }
            }
        }
        protected void SubirImagenButton_Click(object sender, EventArgs e)
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
                String[] allowedExtensions = { ".bmp" };
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
                    FileUpload1.PostedFile.SaveAs(path + CUITTextBox.Text + fileExtension);
                    LogotipoImage.ImageUrl = "ImagenesSubidas/" + CUITTextBox.Text + fileExtension;
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
        protected void BorrarImagenButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            if (sesion.UsuarioDemo == true)
            {
                Response.Redirect("~/MensajeUsuarioDEMO.aspx");
            }
            String path = Server.MapPath("~/ImagenesSubidas/");
            string[] archivos = System.IO.Directory.GetFiles(path, CUITTextBox.Text + ".*", System.IO.SearchOption.TopDirectoryOnly);
            for (int i = 0; i < archivos.Length; i++)
            {
                System.IO.File.Delete(archivos[i]);
                LogotipoImage.ImageUrl = "Imagenes/Interrogacion.jpg";
            }
        }
    }
}
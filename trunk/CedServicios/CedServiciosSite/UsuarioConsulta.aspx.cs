using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class UsuarioConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                TituloPaginaLabel.Text = sesion.Usuario.Nombre;
                DatosPersonalesLabel.Text = "Id: " + sesion.Usuario.Id;
                DatosPersonalesLabel.Text += "<br />Email: " + sesion.Usuario.Email;
                if (!sesion.Usuario.EmailSMS.Equals(String.Empty)) DatosPersonalesLabel.Text += "<br />SMS: " + sesion.Usuario.EmailSMS;
                if (!sesion.Usuario.Telefono.Equals(String.Empty)) DatosPersonalesLabel.Text += "<br />Telefono: " + sesion.Usuario.Telefono;
                PermisosGridView.DataSource = sesion.Usuario.Permisos;
                PermisosGridView.DataBind();
                String path = Server.MapPath("~/ImagenesSubidas/");
                string[] archivos = System.IO.Directory.GetFiles(path, sesion.Usuario.Id + ".*", System.IO.SearchOption.TopDirectoryOnly);
                if (archivos.Length > 0)
                {
                    Image1.ImageUrl = "~/ImagenesSubidas/" + archivos[0].Replace(Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                }
            }
        }
        protected void PermisosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }

        }
        protected void SubirImagenButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
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
        protected void BorrarImagenButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            String path = Server.MapPath("~/ImagenesSubidas/");
            string[] archivos = System.IO.Directory.GetFiles(path, sesion.Usuario.Id + ".*", System.IO.SearchOption.TopDirectoryOnly);
            for (int i = 0; i < archivos.Length; i++)
            {
                System.IO.File.Delete(archivos[i]);
                Image1.ImageUrl = "Imagenes/Interrogacion.jpg";
            }
        }
    }
}
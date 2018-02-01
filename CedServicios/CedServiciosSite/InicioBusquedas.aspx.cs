using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class InicioBusquedas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SubirCVButton_Click(object sender, EventArgs e)
        {
            //MensajeLabel.Text = "";
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Boolean fileOK = false;
            String fileExtension = String.Empty;
            String path = Server.MapPath("~/CVs/");
            if (FileUpload1.HasFile)
            {
                fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions = { ".pdf", ".doc", ".docx" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                        break;
                    }
                }
            }
            if (fileOK)
            {
                try
                {
                    if (FileUpload1.FileBytes.Length > 2097152)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('El archivo seleccionado excede los 2Mb de tamaño.');", true);
                    }
                    else
                    {
                        FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                        string[] archivos = System.IO.Directory.GetFiles(path, FileUpload1.FileName, System.IO.SearchOption.TopDirectoryOnly);
                        if (archivos.Length != 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Archivo subido satisfactoriamente');", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" +"Problemas subiendo el archivo.<br />" + EX.Funciones.Detalle(ex) + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Tipo de archivo no permitido. Solo se admiten formatos PDF, DOC y DOCX');", true);
            }
        }
    }
}
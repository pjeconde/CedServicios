using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class busquedas : System.Web.UI.Page
    {
        public string EmailValue = "";
        public string NombreValue = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                IdBusquedaPerfilDropDownList.DataSource = RN.BusquedaPerfil.Lista(sesion);
                IdBusquedaPerfilDropDownList.DataBind();
            }
        }
        private bool ValidarDatos()
        {
            bool resp = true;
            Entidades.BusquedaLaboral bl = new Entidades.BusquedaLaboral();
            bl.Email = Request.Form["EmailCV"];
            bl.Nombre = Request.Form["NombreCV"];
            bl.BusquedaPerfil.IdBusquedaPerfil = IdBusquedaPerfilDropDownList.SelectedValue;
            if (bl.Email.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar su Email"), false);
                return false;
            }
            if (bl.Nombre.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar su Nombre"), false);
                return false;
            }
            if (!RN.Funciones.IsValidEmail(bl.Email))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato de Email inválido"), false);
                return false;
            }
            if (bl.BusquedaPerfil.IdBusquedaPerfil.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar su Perfil"), false);
                return false;
            }
            return resp;
        }
        protected void SubirCVButton_Click(object sender, EventArgs e)
        {
            EmailValue = Request.Form["EmailCV"];
            NombreValue = Request.Form["NombreCV"];
            if (ValidarDatos())
            {
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
                                Entidades.BusquedaLaboral bl = new Entidades.BusquedaLaboral();
                                bl.Email = Request.Form["EmailCV"];
                                bl.Nombre = Request.Form["NombreCV"];
                                bl.BusquedaPerfil.IdBusquedaPerfil = IdBusquedaPerfilDropDownList.SelectedValue;
                                bl.NombreArchCV = FileUpload1.FileName;
                                Entidades.BusquedaLaboral blAux = new Entidades.BusquedaLaboral();
                                blAux.Email = bl.Email;
                                try
                                {
                                    RN.BusquedaLaboral.Leer(blAux, sesion);
                                }
                                catch (EX.Validaciones.ElementoInexistente)
                                {
                                }
                                if (blAux.BusquedaPerfil.IdBusquedaPerfil == null)
                                {
                                    bl.Estado = "Vigente";
                                    RN.BusquedaLaboral.Crear(bl, sesion);
                                }
                                else
                                {
                                    RN.BusquedaLaboral.ModificarCV(blAux, bl, sesion);
                                }
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Archivo subido satisfactoriamente');", true);
                                IdBusquedaPerfilDropDownList.SelectedValue = "";
                                NombreValue = "";
                                EmailValue = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + "Problemas subiendo el archivo.<br />" + EX.Funciones.Detalle(ex) + "');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Tipo de archivo no permitido. Solo se admiten formatos PDF, DOC y DOCX');", true);
                }
            }
        }
    }
}
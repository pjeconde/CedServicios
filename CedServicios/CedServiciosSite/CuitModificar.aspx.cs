using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class CuitModificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];

                Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                MedioDropDownList.DataSource = RN.Medio.Lista(sesion);
                DataBind();

                CUITTextBox.Text = sesion.Cuit.Nro;
                CUITTextBox.Enabled = false;
                RazonSocialTextBox.Text = sesion.Cuit.RazonSocial;
                Domicilio.Calle = sesion.Cuit.Domicilio.Calle;
                Domicilio.Nro = sesion.Cuit.Domicilio.Nro;
                Domicilio.Piso = sesion.Cuit.Domicilio.Piso;
                Domicilio.Depto = sesion.Cuit.Domicilio.Depto;
                Domicilio.Manzana = sesion.Cuit.Domicilio.Manzana;
                Domicilio.Sector = sesion.Cuit.Domicilio.Sector;
                Domicilio.Torre = sesion.Cuit.Domicilio.Torre;
                Domicilio.Localidad = sesion.Cuit.Domicilio.Localidad;
                Domicilio.IdProvincia = sesion.Cuit.Domicilio.Provincia.Id;
                Domicilio.CodPost = sesion.Cuit.Domicilio.CodPost;
                Contacto.Nombre = sesion.Cuit.Contacto.Nombre;
                Contacto.Email = sesion.Cuit.Contacto.Email;
                Contacto.Telefono = sesion.Cuit.Contacto.Telefono;
                DatosImpositivos.IdCondIVA = sesion.Cuit.DatosImpositivos.IdCondIVA;
                DatosImpositivos.IdCondIngBrutos = sesion.Cuit.DatosImpositivos.IdCondIngBrutos;
                DatosImpositivos.NroIngBrutos = sesion.Cuit.DatosImpositivos.NroIngBrutos;
                DatosImpositivos.FechaInicioActividades = sesion.Cuit.DatosImpositivos.FechaInicioActividades;
                DatosIdentificatorios.GLN = sesion.Cuit.DatosIdentificatorios.GLN;
                DatosIdentificatorios.CodigoInterno = sesion.Cuit.DatosIdentificatorios.CodigoInterno;
                MedioDropDownList.SelectedValue = sesion.Cuit.Medio.Id;
                String path = Server.MapPath("~/ImagenesSubidas/");
                string[] archivos = System.IO.Directory.GetFiles(path, CUITTextBox.Text + ".*", System.IO.SearchOption.TopDirectoryOnly);
                if (archivos.Length > 0)
                {
                    LogotipoImage.ImageUrl = "~/ImagenesSubidas/" + archivos[0].Replace(Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                }
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.Cuit cuit = RN.Cuit.ObtenerCopia((Entidades.Cuit)sesion.Cuit);
            try
            {
                cuit.Nro = CUITTextBox.Text;
                cuit.RazonSocial = RazonSocialTextBox.Text;
                cuit.Domicilio.Calle = Domicilio.Calle;
                cuit.Domicilio.Nro = Domicilio.Nro;
                cuit.Domicilio.Piso = Domicilio.Piso;
                cuit.Domicilio.Depto = Domicilio.Depto;
                cuit.Domicilio.Manzana = Domicilio.Manzana;
                cuit.Domicilio.Sector = Domicilio.Sector;
                cuit.Domicilio.Torre = Domicilio.Torre;
                cuit.Domicilio.Localidad = Domicilio.Localidad;
                cuit.Domicilio.Provincia.Id = Domicilio.IdProvincia;
                cuit.Domicilio.Provincia.Descr = Domicilio.DescrProvincia;
                cuit.Domicilio.CodPost = Domicilio.CodPost;
                cuit.Contacto.Nombre = Contacto.Nombre;
                cuit.Contacto.Email = Contacto.Email;
                cuit.Contacto.Telefono = Contacto.Telefono;
                cuit.DatosImpositivos.IdCondIVA = DatosImpositivos.IdCondIVA;
                cuit.DatosImpositivos.DescrCondIVA = DatosImpositivos.DescrCondIVA;
                cuit.DatosImpositivos.IdCondIngBrutos = DatosImpositivos.IdCondIngBrutos;
                cuit.DatosImpositivos.DescrCondIngBrutos = DatosImpositivos.DescrCondIngBrutos;
                cuit.DatosImpositivos.NroIngBrutos = DatosImpositivos.NroIngBrutos;
                cuit.DatosImpositivos.FechaInicioActividades = DatosImpositivos.FechaInicioActividades;
                cuit.DatosIdentificatorios.GLN = DatosIdentificatorios.GLN;
                cuit.DatosIdentificatorios.CodigoInterno = DatosIdentificatorios.CodigoInterno;
                cuit.Medio.Id = MedioDropDownList.SelectedValue;
                cuit.Medio.Descr = MedioDropDownList.Text;
                RN.Cuit.Modificar(cuit, sesion);

                CUITTextBox.Enabled = false;
                RazonSocialTextBox.Enabled = false;
                Domicilio.Enabled = false;
                Contacto.Enabled = false;
                DatosImpositivos.Enabled = false;
                DatosIdentificatorios.Enabled = false;
                MedioDropDownList.Enabled = false;
                AceptarButton.Enabled = false;
                SalirButton.Text = "Salir";

                MensajeLabel.Text = "El CUIT fué modificado satisfactoriamente";
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                return;
            }
        }
        protected void SubirImagenButton_Click(object sender, EventArgs e)
        {
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
            String path = Server.MapPath("~/ImagenesSubidas/");
            string[] archivos = System.IO.Directory.GetFiles(path, CUITTextBox.Text + ".*", System.IO.SearchOption.TopDirectoryOnly);
            for (int i = 0; i < archivos.Length; i++ )
            {
                System.IO.File.Delete(archivos[i]);
                LogotipoImage.ImageUrl = "Imagenes/Interrogacion.jpg";
            }
        }
    }
}
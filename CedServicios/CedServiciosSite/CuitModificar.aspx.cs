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
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
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
                    NroSerieCertifAFIPTextBox.Text = sesion.Cuit.NroSerieCertifAFIP;
                    NroSerieCertifITFTextBox.Text = sesion.Cuit.NroSerieCertifITF;
                }
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
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
                    cuit.NroSerieCertifAFIP = NroSerieCertifAFIPTextBox.Text;
                    cuit.NroSerieCertifITF = NroSerieCertifITFTextBox.Text;
                    RN.Cuit.Modificar(cuit, sesion);

                    CUITTextBox.Enabled = false;
                    RazonSocialTextBox.Enabled = false;
                    Domicilio.Enabled = false;
                    Contacto.Enabled = false;
                    DatosImpositivos.Enabled = false;
                    DatosIdentificatorios.Enabled = false;
                    MedioDropDownList.Enabled = false;
                    NroSerieCertifAFIPTextBox.Enabled = false;
                    NroSerieCertifITFTextBox.Enabled = false;
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
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}
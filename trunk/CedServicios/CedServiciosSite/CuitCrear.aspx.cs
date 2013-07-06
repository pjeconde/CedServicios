using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class CuitCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    MedioDropDownList.DataSource = RN.Medio.Lista(sesion);
                    DataBind();
                    CUITTextBox.Focus();
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
                Entidades.Cuit cuit = new Entidades.Cuit();
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
                    RN.Cuit.Crear(cuit, sesion);

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

                    Funciones.PersonalizarControlesMaster(Master, true, sesion);
                    MensajeLabel.Text = "El CUIT fué creado satisfactoriamente";
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                    return;
                }
            }
        }
    }
}
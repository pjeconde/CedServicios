using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class CuitBaja : System.Web.UI.Page
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
                    DestinoComprobanteAFIPCheckBox.Checked = sesion.Cuit.DestinoComprobanteAFIP;
                    UsaCertificadoAFIPPropioCheckBox.Checked = sesion.Cuit.UsaCertificadoAFIPPropio;
                    DestinoComprobanteITFCheckBox.Checked = sesion.Cuit.DestinoComprobanteITF;
                    NroSerieCertifITFTextBox.Text = sesion.Cuit.NroSerieCertifITF;

                    CUITTextBox.Enabled = false;
                    RazonSocialTextBox.Enabled = false;
                    Domicilio.Enabled = false;
                    Contacto.Enabled = false;
                    DatosImpositivos.Enabled = false;
                    DatosIdentificatorios.Enabled = false;
                    MedioDropDownList.Enabled = false;
                    DestinoComprobanteAFIPCheckBox.Enabled = false;
                    UsaCertificadoAFIPPropioCheckBox.Enabled = false;
                    DestinoComprobanteITFCheckBox.Enabled = false;
                    NroSerieCertifITFTextBox.Enabled = false;

                    if (sesion.Cuit.WF.Estado == "Vigente")
                    {
                        TituloPaginaLabel.Text = "Baja de CUIT";
                        AceptarButton.Text = "Dar de Baja";
                    }
                    else
                    {
                        TituloPaginaLabel.Text = "Anulación de Baja de CUIT";
                        AceptarButton.Text = "Anular Baja";
                    } AceptarButton.Focus();
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

                    if (AceptarButton.Text == "Dar de Baja")
                    {
                        RN.Cuit.CambiarEstado(cuit, "DeBaja", sesion);
                    }
                    else
                    {
                        RN.Cuit.CambiarEstado(cuit, "Vigente", sesion);
                    }

                    AceptarButton.Enabled = false;
                    SalirButton.Text = "Salir";

                    MensajeLabel.Text = "El cambio de estado fué registrado satisfactoriamente";
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
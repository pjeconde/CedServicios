using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ClienteCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
                DataBind();
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                CUITTextBox.Text = sesion.Cuit.Nro;
                CUITTextBox.Enabled = false;
                TipoDocDropDownList.SelectedValue = new FeaEntidades.Documentos.CUIT().Codigo.ToString();
                NroDocTextBox.Focus();
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.Cliente cliente = new Entidades.Cliente();
            try
            {
                cliente.Cuit = CUITTextBox.Text;
                cliente.RazonSocial = RazonSocialTextBox.Text;
                cliente.Domicilio.Calle = Domicilio.Calle;
                cliente.Domicilio.Nro = Domicilio.Nro;
                cliente.Domicilio.Piso = Domicilio.Piso;
                cliente.Domicilio.Depto = Domicilio.Depto;
                cliente.Domicilio.Manzana = Domicilio.Manzana;
                cliente.Domicilio.Sector = Domicilio.Sector;
                cliente.Domicilio.Torre = Domicilio.Torre;
                cliente.Domicilio.Localidad = Domicilio.Localidad;
                cliente.Domicilio.Provincia.Id = Domicilio.IdProvincia;
                cliente.Domicilio.Provincia.Descr = Domicilio.DescrProvincia;
                cliente.Domicilio.CodPost = Domicilio.CodPost;
                cliente.Contacto.Nombre = Contacto.Nombre;
                cliente.Contacto.Email = Contacto.Email;
                cliente.Contacto.Telefono = Contacto.Telefono;
                cliente.DatosImpositivos.IdCondIVA = DatosImpositivos.IdCondIVA;
                cliente.DatosImpositivos.DescrCondIVA = DatosImpositivos.DescrCondIVA;
                cliente.DatosImpositivos.IdCondIngBrutos = DatosImpositivos.IdCondIngBrutos;
                cliente.DatosImpositivos.DescrCondIngBrutos = DatosImpositivos.DescrCondIngBrutos;
                cliente.DatosImpositivos.NroIngBrutos = DatosImpositivos.NroIngBrutos;
                cliente.DatosImpositivos.FechaInicioActividades = DatosImpositivos.FechaInicioActividades;
                cliente.DatosIdentificatorios.GLN = DatosIdentificatorios.GLN;
                cliente.DatosIdentificatorios.CodigoInterno = DatosIdentificatorios.CodigoInterno;
                //RN.Cuit.Crear(cliente, sesion);

                CUITTextBox.Enabled = false;
                RazonSocialTextBox.Enabled = false;
                Domicilio.Enabled = false;
                Contacto.Enabled = false;
                DatosImpositivos.Enabled = false;
                DatosIdentificatorios.Enabled = false;
                AceptarButton.Enabled = false;
                CancelarButton.Text = "Salir";

                Funciones.PersonalizarControlesMaster(Master, true, sesion);
                MensajeLabel.Text = "El Cliente fué creado satisfactoriamente";
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                return;
            }
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
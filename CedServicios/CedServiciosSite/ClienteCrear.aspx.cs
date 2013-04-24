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
                TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
                Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
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
                cliente.Documento.Tipo.Id = TipoDocDropDownList.SelectedValue;
                cliente.Documento.Tipo.Descr = TipoDocDropDownList.SelectedItem.Text;
                cliente.Documento.Nro = Convert.ToInt64(NroDocTextBox.Text);
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
                cliente.IdCliente = IdClienteTextBox.Text;
                cliente.EmailAvisoVisualizacion = EmailAvisoVisualizacionTextBox.Text;
                cliente.PasswordAvisoVisualizacion = PasswordAvisoVisualizacionTextBox.Text;
                RN.Cliente.Crear(cliente, sesion);

                CUITTextBox.Enabled = false;
                TipoDocDropDownList.Enabled = false;
                NroDocTextBox.Enabled = false;
                RazonSocialTextBox.Enabled = false;
                Domicilio.Enabled = false;
                Contacto.Enabled = false;
                DatosImpositivos.Enabled = false;
                DatosIdentificatorios.Enabled = false;
                IdClienteTextBox.Enabled = false;
                EmailAvisoVisualizacionTextBox.Enabled = false;
                PasswordAvisoVisualizacionTextBox.Enabled = false;
                AceptarButton.Enabled = false;
                CancelarButton.Text = "Salir";

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
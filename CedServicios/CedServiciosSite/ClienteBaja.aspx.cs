using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ClienteBaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];

                TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
                DestinosCuitDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.Lista();
                Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                DataBind();

                Entidades.Cliente cliente = (Entidades.Cliente)Session["Cliente"];

                CUITTextBox.Text = cliente.Cuit;
                TipoDocDropDownList.SelectedValue = cliente.Documento.Tipo.Id;
                TipoDocDropDownList_SelectedIndexChanged(TipoDocDropDownList, new EventArgs());
                if (TipoDocDropDownList.SelectedValue.Equals(new FeaEntidades.Documentos.CUITPais().Codigo.ToString()))
                {
                    DestinosCuitDropDownList.SelectedValue = cliente.Documento.Nro.ToString();
                }
                else
                {
                    NroDocTextBox.Text = cliente.Documento.Nro.ToString();
                }
                RazonSocialTextBox.Text = cliente.RazonSocial;
                Domicilio.Calle = cliente.Domicilio.Calle;
                Domicilio.Nro = cliente.Domicilio.Nro;
                Domicilio.Piso = cliente.Domicilio.Piso;
                Domicilio.Depto = cliente.Domicilio.Depto;
                Domicilio.Manzana = cliente.Domicilio.Manzana;
                Domicilio.Sector = cliente.Domicilio.Sector;
                Domicilio.Torre = cliente.Domicilio.Torre;
                Domicilio.Localidad = cliente.Domicilio.Localidad;
                Domicilio.IdProvincia = cliente.Domicilio.Provincia.Id;
                cliente.Domicilio.CodPost = Domicilio.CodPost;
                Contacto.Nombre = cliente.Contacto.Nombre;
                Contacto.Email = cliente.Contacto.Email;
                Contacto.Telefono = cliente.Contacto.Telefono;
                DatosImpositivos.IdCondIVA = cliente.DatosImpositivos.IdCondIVA;
                DatosImpositivos.IdCondIngBrutos = cliente.DatosImpositivos.IdCondIngBrutos;
                DatosImpositivos.NroIngBrutos = cliente.DatosImpositivos.NroIngBrutos;
                DatosImpositivos.FechaInicioActividades = cliente.DatosImpositivos.FechaInicioActividades;
                DatosIdentificatorios.GLN = cliente.DatosIdentificatorios.GLN;
                DatosIdentificatorios.CodigoInterno = cliente.DatosIdentificatorios.CodigoInterno;
                IdClienteTextBox.Text = cliente.IdCliente;
                EmailAvisoVisualizacionTextBox.Text = cliente.EmailAvisoVisualizacion;
                PasswordAvisoVisualizacionTextBox.Text = cliente.PasswordAvisoVisualizacion;

                CUITTextBox.Enabled = false;
                TipoDocDropDownList.Enabled = false;
                NroDocTextBox.Enabled = false;
                DestinosCuitDropDownList.Enabled = false;
                RazonSocialTextBox.Enabled = false;
                Domicilio.Enabled = false;
                Contacto.Enabled = false;
                DatosImpositivos.Enabled = false;
                DatosIdentificatorios.Enabled = false;
                IdClienteTextBox.Enabled = false;
                EmailAvisoVisualizacionTextBox.Enabled = false;
                PasswordAvisoVisualizacionTextBox.Enabled = false;

                AceptarButton.Focus();
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.Cliente clienteDesde = (Entidades.Cliente)Session["Cliente"];
            Entidades.Cliente clienteHasta = RN.Cliente.ObternerCopia(clienteDesde);
            try
            {
                clienteHasta.Cuit = CUITTextBox.Text;
                clienteHasta.Documento.Tipo.Id = TipoDocDropDownList.SelectedValue;
                clienteHasta.Documento.Tipo.Descr = TipoDocDropDownList.SelectedItem.Text;
                if (TipoDocDropDownList.SelectedValue.Equals(new FeaEntidades.Documentos.CUITPais().Codigo.ToString()))
                {
                    clienteHasta.Documento.Nro = Convert.ToInt64(DestinosCuitDropDownList.SelectedItem.Value);
                }
                else
                {
                    clienteHasta.Documento.Nro = Convert.ToInt64(NroDocTextBox.Text);
                }
                clienteHasta.RazonSocial = RazonSocialTextBox.Text;
                clienteHasta.Domicilio.Calle = Domicilio.Calle;
                clienteHasta.Domicilio.Nro = Domicilio.Nro;
                clienteHasta.Domicilio.Piso = Domicilio.Piso;
                clienteHasta.Domicilio.Depto = Domicilio.Depto;
                clienteHasta.Domicilio.Manzana = Domicilio.Manzana;
                clienteHasta.Domicilio.Sector = Domicilio.Sector;
                clienteHasta.Domicilio.Torre = Domicilio.Torre;
                clienteHasta.Domicilio.Localidad = Domicilio.Localidad;
                clienteHasta.Domicilio.Provincia.Id = Domicilio.IdProvincia;
                clienteHasta.Domicilio.Provincia.Descr = Domicilio.DescrProvincia;
                clienteHasta.Domicilio.CodPost = Domicilio.CodPost;
                clienteHasta.Contacto.Nombre = Contacto.Nombre;
                clienteHasta.Contacto.Email = Contacto.Email;
                clienteHasta.Contacto.Telefono = Contacto.Telefono;
                clienteHasta.DatosImpositivos.IdCondIVA = DatosImpositivos.IdCondIVA;
                clienteHasta.DatosImpositivos.DescrCondIVA = DatosImpositivos.DescrCondIVA;
                clienteHasta.DatosImpositivos.IdCondIngBrutos = DatosImpositivos.IdCondIngBrutos;
                clienteHasta.DatosImpositivos.DescrCondIngBrutos = DatosImpositivos.DescrCondIngBrutos;
                clienteHasta.DatosImpositivos.NroIngBrutos = DatosImpositivos.NroIngBrutos;
                clienteHasta.DatosImpositivos.FechaInicioActividades = DatosImpositivos.FechaInicioActividades;
                clienteHasta.DatosIdentificatorios.GLN = DatosIdentificatorios.GLN;
                clienteHasta.DatosIdentificatorios.CodigoInterno = DatosIdentificatorios.CodigoInterno;
                clienteHasta.IdCliente = IdClienteTextBox.Text;
                clienteHasta.EmailAvisoVisualizacion = EmailAvisoVisualizacionTextBox.Text;
                clienteHasta.PasswordAvisoVisualizacion = PasswordAvisoVisualizacionTextBox.Text;
                RN.Cliente.Modificar(clienteDesde, clienteHasta, sesion);

                AceptarButton.Enabled = false;
                SalirButton.Text = "Salir";

                MensajeLabel.Text = "El Cliente fué modificado satisfactoriamente";
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
                return;
            }
        }
        protected void TipoDocDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoDocDropDownList.SelectedValue.Equals(new FeaEntidades.Documentos.CUITPais().Codigo.ToString()))
            {
                NroDocTextBox.Visible = false;
                DestinosCuitDropDownList.Visible = true;
            }
            else
            {
                NroDocTextBox.Visible = true;
                DestinosCuitDropDownList.Visible = false;
            }
        }
    }
}
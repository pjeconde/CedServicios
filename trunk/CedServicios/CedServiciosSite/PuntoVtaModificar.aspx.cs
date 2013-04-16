using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class PuntoVtaModificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];

                IdUNDropDownList.DataSource = RN.UN.ListaVigentesPorCuit(sesion.Cuit, sesion);
                IdTipoPuntoVtaDropDownList.DataSource = RN.TipoPuntoVta.Lista(sesion);
                IdMetodoGeneracionNumeracionLoteDropDownList.DataSource = RN.MetodoGeneracionNumeracionLote.Lista(sesion);
                DataBind();

                CUITTextBox.Text = sesion.Cuit.Nro;
                CUITTextBox.Enabled = false;
                IdUNDropDownList.SelectedValue = sesion.UN.Id.ToString();
                IdUNDropDownList.Enabled = false;
                IdTipoPuntoVtaDropDownList.SelectedValue = "Comun";
                IdMetodoGeneracionNumeracionLoteDropDownList.SelectedValue = "Autonumerador";
                UltNroLoteTextBox.Text = "0";
                UsaDatosCuitCheckBox.Checked = true;
                UsaDatosCuitCheckBox_CheckedChanged(UsaDatosCuitCheckBox, new EventArgs());
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.PuntoVta puntoVtaDesde = new Entidades.PuntoVta();
            Entidades.PuntoVta puntoVtaHasta = new Entidades.PuntoVta();
            try
            {
                puntoVtaHasta.Cuit = CUITTextBox.Text;
                puntoVtaHasta.Nro = Convert.ToInt32(NroTextBox.Text);
                puntoVtaHasta.IdUN = Convert.ToInt32(IdUNDropDownList.SelectedValue);
                puntoVtaHasta.IdTipoPuntoVta = IdTipoPuntoVtaDropDownList.SelectedValue;
                puntoVtaHasta.UsaSetPropioDeDatosCuit = !UsaDatosCuitCheckBox.Checked;
                if (puntoVtaHasta.UsaSetPropioDeDatosCuit)
                {
                    puntoVtaHasta.Domicilio.Calle = Domicilio.Calle;
                    puntoVtaHasta.Domicilio.Nro = Domicilio.Nro;
                    puntoVtaHasta.Domicilio.Piso = Domicilio.Piso;
                    puntoVtaHasta.Domicilio.Depto = Domicilio.Depto;
                    puntoVtaHasta.Domicilio.Manzana = Domicilio.Manzana;
                    puntoVtaHasta.Domicilio.Sector = Domicilio.Sector;
                    puntoVtaHasta.Domicilio.Torre = Domicilio.Torre;
                    puntoVtaHasta.Domicilio.Localidad = Domicilio.Localidad;
                    puntoVtaHasta.Domicilio.Provincia.Id = Domicilio.IdProvincia;
                    puntoVtaHasta.Domicilio.Provincia.Descr = Domicilio.DescrProvincia;
                    puntoVtaHasta.Domicilio.CodPost = Domicilio.CodPost;
                    puntoVtaHasta.Contacto.Nombre = Contacto.Nombre;
                    puntoVtaHasta.Contacto.Email = Contacto.Email;
                    puntoVtaHasta.Contacto.Telefono = Contacto.Telefono;
                    puntoVtaHasta.DatosImpositivos.IdCondIVA = DatosImpositivos.IdCondIVA;
                    puntoVtaHasta.DatosImpositivos.DescrCondIVA = DatosImpositivos.DescrCondIVA;
                    puntoVtaHasta.DatosImpositivos.IdCondIngBrutos = DatosImpositivos.IdCondIngBrutos;
                    puntoVtaHasta.DatosImpositivos.DescrCondIngBrutos = DatosImpositivos.DescrCondIngBrutos;
                    puntoVtaHasta.DatosImpositivos.NroIngBrutos = DatosImpositivos.NroIngBrutos;
                    puntoVtaHasta.DatosImpositivos.FechaInicioActividades = DatosImpositivos.FechaInicioActividades;
                    puntoVtaHasta.DatosIdentificatorios.GLN = DatosIdentificatorios.GLN;
                    puntoVtaHasta.DatosIdentificatorios.CodigoInterno = DatosIdentificatorios.CodigoInterno;
                }
                else
                {
                    puntoVtaHasta.Domicilio.Calle = String.Empty;
                    puntoVtaHasta.Domicilio.Nro = String.Empty;
                    puntoVtaHasta.Domicilio.Piso = String.Empty;
                    puntoVtaHasta.Domicilio.Depto = String.Empty;
                    puntoVtaHasta.Domicilio.Manzana = String.Empty;
                    puntoVtaHasta.Domicilio.Sector = String.Empty;
                    puntoVtaHasta.Domicilio.Torre = String.Empty;
                    puntoVtaHasta.Domicilio.Localidad = String.Empty;
                    puntoVtaHasta.Domicilio.Provincia.Id = String.Empty;
                    puntoVtaHasta.Domicilio.Provincia.Descr = String.Empty;
                    puntoVtaHasta.Domicilio.CodPost = String.Empty;
                    puntoVtaHasta.Contacto.Nombre = String.Empty;
                    puntoVtaHasta.Contacto.Email = String.Empty;
                    puntoVtaHasta.Contacto.Telefono = String.Empty;
                    puntoVtaHasta.DatosImpositivos.IdCondIVA = 0;
                    puntoVtaHasta.DatosImpositivos.DescrCondIVA = String.Empty;
                    puntoVtaHasta.DatosImpositivos.IdCondIngBrutos = 0;
                    puntoVtaHasta.DatosImpositivos.DescrCondIngBrutos = String.Empty;
                    puntoVtaHasta.DatosImpositivos.NroIngBrutos = String.Empty;
                    puntoVtaHasta.DatosImpositivos.FechaInicioActividades = new DateTime(1900, 1, 1);
                    puntoVtaHasta.DatosIdentificatorios.GLN = 0;
                    puntoVtaHasta.DatosIdentificatorios.CodigoInterno = String.Empty;
                }
                puntoVtaHasta.IdMetodoGeneracionNumeracionLote = IdMetodoGeneracionNumeracionLoteDropDownList.SelectedValue;
                puntoVtaHasta.UltNroLote = Convert.ToInt64(UltNroLoteTextBox.Text);
                RN.PuntoVta.Modificar(puntoVtaDesde, puntoVtaHasta, sesion);

                CUITTextBox.Enabled = false;
                NroTextBox.Enabled = false;
                IdUNDropDownList.Enabled = false;
                IdTipoPuntoVtaDropDownList.Enabled = false;
                UsaDatosCuitCheckBox.Enabled = false;
                Domicilio.Enabled = false;
                Contacto.Enabled = false;
                DatosImpositivos.Enabled = false;
                DatosIdentificatorios.Enabled = false;
                IdMetodoGeneracionNumeracionLoteDropDownList.Enabled = false;
                UltNroLoteTextBox.Enabled = false;
                AceptarButton.Enabled = false;
                CancelarButton.Text = "Salir";

                MensajeLabel.Text = "El Punto de Venta fué creado satisfactoriamente";
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
        protected void UsaDatosCuitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Domicilio.Visible = !UsaDatosCuitCheckBox.Checked;
            Contacto.Visible = !UsaDatosCuitCheckBox.Checked;
            DatosImpositivos.Visible = !UsaDatosCuitCheckBox.Checked;
            DatosIdentificatorios.Visible = !UsaDatosCuitCheckBox.Checked;
        }
    }
}
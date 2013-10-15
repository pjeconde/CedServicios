using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class PuntoVtaCrear : System.Web.UI.Page
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
                    NroTextBox.Focus();
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
                Entidades.PuntoVta puntoVta = new Entidades.PuntoVta();
                try
                {
                    puntoVta.Cuit = CUITTextBox.Text;
                    puntoVta.Nro = Convert.ToInt32(NroTextBox.Text);
                    puntoVta.IdUN = Convert.ToInt32(IdUNDropDownList.SelectedValue);
                    puntoVta.IdTipoPuntoVta = IdTipoPuntoVtaDropDownList.SelectedValue;
                    puntoVta.UsaSetPropioDeDatosCuit = !UsaDatosCuitCheckBox.Checked;
                    if (puntoVta.UsaSetPropioDeDatosCuit)
                    {
                        puntoVta.Domicilio.Calle = Domicilio.Calle;
                        puntoVta.Domicilio.Nro = Domicilio.Nro;
                        puntoVta.Domicilio.Piso = Domicilio.Piso;
                        puntoVta.Domicilio.Depto = Domicilio.Depto;
                        puntoVta.Domicilio.Manzana = Domicilio.Manzana;
                        puntoVta.Domicilio.Sector = Domicilio.Sector;
                        puntoVta.Domicilio.Torre = Domicilio.Torre;
                        puntoVta.Domicilio.Localidad = Domicilio.Localidad;
                        puntoVta.Domicilio.Provincia.Id = Domicilio.IdProvincia;
                        puntoVta.Domicilio.Provincia.Descr = Domicilio.DescrProvincia;
                        puntoVta.Domicilio.CodPost = Domicilio.CodPost;
                        puntoVta.Contacto.Nombre = Contacto.Nombre;
                        puntoVta.Contacto.Email = Contacto.Email;
                        puntoVta.Contacto.Telefono = Contacto.Telefono;
                        puntoVta.DatosImpositivos.IdCondIVA = DatosImpositivos.IdCondIVA;
                        puntoVta.DatosImpositivos.DescrCondIVA = DatosImpositivos.DescrCondIVA;
                        puntoVta.DatosImpositivos.IdCondIngBrutos = DatosImpositivos.IdCondIngBrutos;
                        puntoVta.DatosImpositivos.DescrCondIngBrutos = DatosImpositivos.DescrCondIngBrutos;
                        puntoVta.DatosImpositivos.NroIngBrutos = DatosImpositivos.NroIngBrutos;
                        puntoVta.DatosImpositivos.FechaInicioActividades = DatosImpositivos.FechaInicioActividades;
                        puntoVta.DatosIdentificatorios.GLN = DatosIdentificatorios.GLN;
                        puntoVta.DatosIdentificatorios.CodigoInterno = DatosIdentificatorios.CodigoInterno;
                    }
                    else
                    {
                        puntoVta.Domicilio.Calle = String.Empty;
                        puntoVta.Domicilio.Nro = String.Empty;
                        puntoVta.Domicilio.Piso = String.Empty;
                        puntoVta.Domicilio.Depto = String.Empty;
                        puntoVta.Domicilio.Manzana = String.Empty;
                        puntoVta.Domicilio.Sector = String.Empty;
                        puntoVta.Domicilio.Torre = String.Empty;
                        puntoVta.Domicilio.Localidad = String.Empty;
                        puntoVta.Domicilio.Provincia.Id = String.Empty;
                        puntoVta.Domicilio.Provincia.Descr = String.Empty;
                        puntoVta.Domicilio.CodPost = String.Empty;
                        puntoVta.Contacto.Nombre = String.Empty;
                        puntoVta.Contacto.Email = String.Empty;
                        puntoVta.Contacto.Telefono = String.Empty;
                        puntoVta.DatosImpositivos.IdCondIVA = 0;
                        puntoVta.DatosImpositivos.DescrCondIVA = String.Empty;
                        puntoVta.DatosImpositivos.IdCondIngBrutos = 0;
                        puntoVta.DatosImpositivos.DescrCondIngBrutos = String.Empty;
                        puntoVta.DatosImpositivos.NroIngBrutos = String.Empty;
                        puntoVta.DatosImpositivos.FechaInicioActividades = new DateTime(1900, 1, 1);
                        puntoVta.DatosIdentificatorios.GLN = 0;
                        puntoVta.DatosIdentificatorios.CodigoInterno = String.Empty;
                    }
                    puntoVta.IdMetodoGeneracionNumeracionLote = IdMetodoGeneracionNumeracionLoteDropDownList.SelectedValue;
                    puntoVta.UltNroLote = Convert.ToInt64(UltNroLoteTextBox.Text);
                    RN.PuntoVta.Crear(puntoVta, sesion);

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
                    SalirButton.Text = "Salir";

                    MensajeLabel.Text = "El Punto de Venta fué creado satisfactoriamente";
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                    if (MensajeLabel.Text.IndexOf("PK_Table_PuntoVta") != 0)
                    {
                        MensajeLabel.Text = "Ya existe un Punto de Venta con este 'Nro'";
                    }
                    return;
                }
            }
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
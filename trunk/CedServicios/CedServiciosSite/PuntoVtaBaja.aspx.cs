using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class PuntoVtaBaja : System.Web.UI.Page
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

                Entidades.PuntoVta puntoVta = (Entidades.PuntoVta)Session["PuntoVta"];

                CUITTextBox.Text = puntoVta.Cuit;
                NroTextBox.Text = puntoVta.Nro.ToString();
                IdUNDropDownList.SelectedValue = puntoVta.IdUN.ToString();
                IdTipoPuntoVtaDropDownList.SelectedValue = puntoVta.IdTipoPuntoVta;
                UsaDatosCuitCheckBox.Checked = !puntoVta.UsaSetPropioDeDatosCuit;
                UsaDatosCuitCheckBox_CheckedChanged(UsaDatosCuitCheckBox, new EventArgs());
                if (puntoVta.UsaSetPropioDeDatosCuit)
                {
                    Domicilio.Calle = puntoVta.Domicilio.Calle;
                    Domicilio.Nro = puntoVta.Domicilio.Nro;
                    Domicilio.Piso = puntoVta.Domicilio.Piso;
                    Domicilio.Depto = puntoVta.Domicilio.Depto;
                    Domicilio.Manzana = puntoVta.Domicilio.Manzana;
                    Domicilio.Sector = puntoVta.Domicilio.Sector;
                    Domicilio.Torre = puntoVta.Domicilio.Torre;
                    Domicilio.Localidad = puntoVta.Domicilio.Localidad;
                    Domicilio.IdProvincia = puntoVta.Domicilio.Provincia.Id;
                    puntoVta.Domicilio.CodPost = Domicilio.CodPost;
                    Contacto.Nombre = puntoVta.Contacto.Nombre;
                    Contacto.Email = puntoVta.Contacto.Email;
                    Contacto.Telefono = puntoVta.Contacto.Telefono;
                    DatosImpositivos.IdCondIVA = puntoVta.DatosImpositivos.IdCondIVA;
                    DatosImpositivos.IdCondIngBrutos = puntoVta.DatosImpositivos.IdCondIngBrutos;
                    DatosImpositivos.NroIngBrutos = puntoVta.DatosImpositivos.NroIngBrutos;
                    DatosImpositivos.FechaInicioActividades = puntoVta.DatosImpositivos.FechaInicioActividades;
                    DatosIdentificatorios.GLN = puntoVta.DatosIdentificatorios.GLN;
                    DatosIdentificatorios.CodigoInterno = puntoVta.DatosIdentificatorios.CodigoInterno;
                }
                IdMetodoGeneracionNumeracionLoteDropDownList.SelectedValue = puntoVta.IdMetodoGeneracionNumeracionLote;
                UltNroLoteTextBox.Text = puntoVta.UltNroLote.ToString();

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

                if (puntoVta.WF.Estado == "Vigente")
                {
                    TituloPaginaLabel.Text = "Baja de Punto de Venta";
                    AceptarButton.Text = "Dar de Baja";
                }
                else
                {
                    TituloPaginaLabel.Text = "Anulación de Baja de Punto de Venta";
                    AceptarButton.Text = "Anular Baja";
                }
                AceptarButton.Focus();
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.PuntoVta puntoVta = (Entidades.PuntoVta)Session["PuntoVta"];
            try
            {

                if (AceptarButton.Text == "Dar de Baja")
                {
                    RN.PuntoVta.CambiarEstado(puntoVta, "DeBaja", sesion);
                }
                else
                {
                    RN.PuntoVta.CambiarEstado(puntoVta, "Vigente", sesion);
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
        protected void UsaDatosCuitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Domicilio.Visible = !UsaDatosCuitCheckBox.Checked;
            Contacto.Visible = !UsaDatosCuitCheckBox.Checked;
            DatosImpositivos.Visible = !UsaDatosCuitCheckBox.Checked;
            DatosIdentificatorios.Visible = !UsaDatosCuitCheckBox.Checked;
        }
    }
}
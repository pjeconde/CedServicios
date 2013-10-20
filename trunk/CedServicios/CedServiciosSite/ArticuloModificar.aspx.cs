using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ArticuloModificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                UnidadDropDownList.DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
                IndicacionExentoGravadoDropDownList.DataSource = FeaEntidades.Indicacion.Indicacion.Lista();
                AlicuotaIVADropDownList.DataSource = FeaEntidades.IVA.IVA.Lista();
                DataBind();

                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Articulo articulo = (Entidades.Articulo)Session["Articulo"];

                    CUITTextBox.Text = articulo.Cuit;
                    IdTextBox.Text = articulo.Id;
                    DescrTextBox.Text = articulo.Descr;
                    GTINTextBox.Text = articulo.GTIN;
                    UnidadDropDownList.SelectedValue = articulo.Unidad.Id;
                    UnidadDropDownList.SelectedItem.Text = articulo.Unidad.Descr;
                    IndicacionExentoGravadoDropDownList.SelectedValue = articulo.IndicacionExentoGravado;
                    AlicuotaIVADropDownList.SelectedValue = articulo.AlicuotaIVA.ToString();
                    CUITTextBox.Enabled = false;
                    IdTextBox.Enabled = false;
                    DescrTextBox.Focus();
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
                Entidades.Articulo articuloDesde = (Entidades.Articulo)Session["Articulo"];
                Entidades.Articulo articuloHasta = RN.Articulo.ObternerCopia(articuloDesde);
                try
                {
                    articuloHasta.Cuit = CUITTextBox.Text;
                    articuloHasta.Id = IdTextBox.Text;
                    articuloHasta.Descr = DescrTextBox.Text;
                    articuloHasta.GTIN = GTINTextBox.Text;
                    articuloHasta.Unidad.Id = UnidadDropDownList.SelectedValue;
                    articuloHasta.Unidad.Descr = UnidadDropDownList.SelectedItem.Text;
                    articuloHasta.IndicacionExentoGravado = IndicacionExentoGravadoDropDownList.SelectedValue;
                    articuloHasta.AlicuotaIVA = Convert.ToDouble(AlicuotaIVADropDownList.SelectedValue);
                    RN.Articulo.Modificar(articuloDesde, articuloHasta, sesion);

                    CUITTextBox.Enabled = false;
                    IdTextBox.Enabled = false;
                    DescrTextBox.Enabled = false;
                    GTINTextBox.Enabled = false;
                    UnidadDropDownList.Enabled = false;
                    IndicacionExentoGravadoDropDownList.Enabled = false;
                    AlicuotaIVADropDownList.Enabled = false;

                    AceptarButton.Enabled = false;
                    SalirButton.Text = "Salir";

                    MensajeLabel.Text = "El Artículo fué modificado satisfactoriamente";
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
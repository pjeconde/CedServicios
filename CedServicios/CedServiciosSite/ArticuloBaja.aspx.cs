using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ArticuloBaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                UnidadDropDownList.DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
                IndicacionExentoGravadoDropDownList.DataSource = FeaEntidades.Indicacion.Indicacion.Lista();
                AlicuotaIVADropDownList.DataSource = FeaEntidades.IVA.IVA.Lista();
                DataBind();

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
                DescrTextBox.Enabled = false;
                GTINTextBox.Enabled = false;
                UnidadDropDownList.Enabled = false;
                IndicacionExentoGravadoDropDownList.Enabled = false;
                AlicuotaIVADropDownList.Enabled = false;

                if (articulo.Estado=="Vigente")
                {
                    TituloPaginaLabel.Text = "Baja de Artículo";
                    AceptarButton.Text = "Dar de Baja";
                }
                else
                {
                    TituloPaginaLabel.Text = "Anulación de Baja de Artículo";
                    AceptarButton.Text = "Anular Baja";
                }
                AceptarButton.Focus();
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.Articulo articulo = (Entidades.Articulo)Session["Articulo"];
            try
            {

                if (AceptarButton.Text == "Dar de Baja")
                {
                    RN.Articulo.CambiarEstado(articulo, "DeBaja", sesion);
                }
                else
                {
                    RN.Articulo.CambiarEstado(articulo, "Vigente", sesion);
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
}
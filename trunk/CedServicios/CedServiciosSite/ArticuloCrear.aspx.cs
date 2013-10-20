using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ArticuloCrear : System.Web.UI.Page
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
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    CUITTextBox.Text = sesion.Cuit.Nro;
                    CUITTextBox.Enabled = false;
                    UnidadDropDownList.SelectedValue = new FeaEntidades.CodigosUnidad.Unidad().Codigo.ToString();
                    IndicacionExentoGravadoDropDownList.SelectedValue = new FeaEntidades.Indicacion.Gravado().Codigo.ToString();
                    AlicuotaIVADropDownList.SelectedValue = new FeaEntidades.IVA.Veintiuno().Codigo.ToString();
                    IdTextBox.Focus();
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
                Entidades.Articulo articulo = new Entidades.Articulo();
                try
                {
                    articulo.Cuit = CUITTextBox.Text;
                    articulo.Id = IdTextBox.Text;
                    articulo.Descr = DescrTextBox.Text;
                    articulo.GTIN = GTINTextBox.Text;
                    articulo.Unidad.Id = UnidadDropDownList.SelectedValue;
                    articulo.Unidad.Descr = UnidadDropDownList.SelectedItem.Text;
                    articulo.IndicacionExentoGravado = IndicacionExentoGravadoDropDownList.SelectedValue;
                    articulo.AlicuotaIVA = Convert.ToDouble(AlicuotaIVADropDownList.SelectedValue);
                    RN.Articulo.Crear(articulo, sesion);

                    CUITTextBox.Enabled = false;
                    IdTextBox.Enabled = false;
                    DescrTextBox.Enabled = false;
                    GTINTextBox.Enabled = false;
                    UnidadDropDownList.Enabled = false;
                    IndicacionExentoGravadoDropDownList.Enabled = false;
                    AlicuotaIVADropDownList.Enabled = false;
                    AceptarButton.Enabled = false;
                    SalirButton.Text = "Salir";

                    MensajeLabel.Text = "El Artículo fué creado satisfactoriamente";
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                    if (MensajeLabel.Text.IndexOf("PK_Table_Articulo") != 0)
                    {
                        MensajeLabel.Text = "Ya existe un Artículo con este 'Id.'";
                    }
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}
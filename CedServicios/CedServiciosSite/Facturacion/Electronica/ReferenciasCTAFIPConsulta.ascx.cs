using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class ReferenciasCTAFIPConsulta : System.Web.UI.UserControl
	{
		System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> referencias;
        string puntoDeVenta;

		protected void Page_Load(object sender, EventArgs e)
		{
            puntoDeVenta = Convert.ToString(ViewState["puntoDeVenta"]);
            if (!this.IsPostBack)
            {
                ResetearGrillas();
                //DataBind();
            }
		}

        public string PuntoDeVenta
        {
            set
            {
                ViewState["puntoDeVenta"] = value;
                puntoDeVenta = value;
            }
        }

		public void BindearDropDownLists()
		{
		
		}

		public bool HayReferencias
		{
			get
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
				if (refs[0].codigo_de_referencia.Equals(0))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}
		public System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> ListaReferencias
		{
			get
			{
                System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
				return refs;
			}
		}
		public void CompletarReferencias(FeaEntidades.Turismo.comprobante Comprobante)
		{
			//Permisos de exportación
			referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
            if (Comprobante.cabecera.informacion_comprobante != null && Comprobante.cabecera.informacion_comprobante.referencias != null)
			{
				foreach (FeaEntidades.InterFacturas.informacion_comprobanteReferencias r in Comprobante.cabecera.informacion_comprobante.referencias)
				{
					//descripcioncodigo_de_permiso ( XmlIgnoreAttribute )
					//Se busca la descripción a través del código.
					try
					{
						if (r != null)
						{
							string descrcodigo = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
                            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedValue = r.codigo_de_referencia.ToString();
                            descrcodigo = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
							r.descripcioncodigo_de_referencia = descrcodigo;
							referencias.Add(r);
						}
					}
					catch
					//Referencia no valida
					{
					}
				}
			}
			if (referencias.Count.Equals(0))
			{
                referencias.Add(new FeaEntidades.InterFacturas.informacion_comprobanteReferencias());
			}
            referenciasGridView.DataSource = referencias;
			referenciasGridView.DataBind();
            ViewState["referencias"] = referencias;
		}
		public void ResetearGrillas()
		{
            referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
            FeaEntidades.InterFacturas.informacion_comprobanteReferencias referencia = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
            referencias.Add(referencia);
            referenciasGridView.DataSource = referencias;
            referenciasGridView.DataBind();
            ViewState["referencias"] = referencias;

            BindearDropDownLists();
		}
	}
}
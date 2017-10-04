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
	public partial class ReferenciasCTAFIP: System.Web.UI.UserControl
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
			if (referenciasGridView.FooterRow!=null)
			{
                AjustarCodigosDeReferenciaEnFooter();
			}
		}

        private void AjustarCodigosDeReferenciaEnFooter()
        {
            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataValueField = "Codigo";
            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataTextField = "Descr";
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaTurismoAFIP();
                ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = true;
                ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = false;
                ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataBind();
            }
        }

		protected void referenciasGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
				FeaEntidades.InterFacturas.informacion_comprobanteReferencias r = refs[e.RowIndex];
				refs.Remove(r);
				if (refs.Count.Equals(0))
				{
                    FeaEntidades.InterFacturas.informacion_comprobanteReferencias nuevo = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
					refs.Add(nuevo);
				}
				referenciasGridView.EditIndex = -1;
                referenciasGridView.DataSource = ViewState["referencias"];
				referenciasGridView.DataBind();
				BindearDropDownLists();
			}
			catch
			{
			}
		}

		protected void referenciasGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			referenciasGridView.EditIndex = -1;
            referenciasGridView.DataSource = ViewState["referencias"];
			referenciasGridView.DataBind();
			BindearDropDownLists();
		}

		protected void referenciasGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
            if (e.CommandName.Equals("Addreferencias"))
            {
                try
                {
                    FeaEntidades.InterFacturas.informacion_comprobanteReferencias r = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();

                    string auxCodRef = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedValue.ToString();
                    string auxDescrCodRef = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
                    if (!auxCodRef.Equals(string.Empty))
                    {
                        r.codigo_de_referencia = Convert.ToInt32(auxCodRef);
                        r.descripcioncodigo_de_referencia = auxDescrCodRef;
                    }
                    else
                    {
                        throw new Exception("Referencia no agregada porque el código de referencia no puede estar vacío");
                    }
                    string auxDatoRef = ((TextBox)referenciasGridView.FooterRow.FindControl("txtdato_de_referencia")).Text;
                    if (auxDatoRef.Contains("?"))
                    {
                        throw new Exception("Referencia no agregada porque el número de referencia no respeta el formato para exportación");
                    }
                    else
                    {
                        r.dato_de_referencia = auxDatoRef;
                    }
                    ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]).Add(r);
                    //Me fijo si elimino la fila automática
                    System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
                    if (refs[0].codigo_de_referencia == 0)
                    {
                        ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]).Remove(refs[0]);
                    }

                    //Saco de edición la fila que estén modificando
                    if (!referenciasGridView.EditIndex.Equals(-1))
                    {
                        referenciasGridView.EditIndex = -1;
                    }

                    referenciasGridView.DataSource = ViewState["referencias"];
                    referenciasGridView.DataBind();
                    BindearDropDownLists();
                }
				catch (Exception ex)
				{
					ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
				}
			}
		}

		protected void referenciasGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(e.Exception.Message), false);
				e.ExceptionHandled = true;
			}
		}

		protected void referenciasGridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			referenciasGridView.EditIndex = e.NewEditIndex;

            referenciasGridView.DataSource = ViewState["referencias"];
			referenciasGridView.DataBind();
			BindearDropDownLists();

            AjustarCodigoReferenciaEnEdicion(sender, e);
			try
			{
                ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"])[e.NewEditIndex].codigo_de_referencia.ToString());
				li.Selected = true;
			}
			catch
			{
			}
            
		}
        private void AjustarTipoComprobanteAFIPEnEdicion(object sender, GridViewEditEventArgs e)
        {
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataTextField = "Descr";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataSource = FeaEntidades.TipoComprobanteAFIP.TipoComprobanteAFIP.Lista();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataBind();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).Visible = true;
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataBind();
        }

        private void AjustarCodigoReferenciaEnEdicion(object sender, GridViewEditEventArgs e)
        {
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataTextField = "Descr";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaTurismoAFIP();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataBind();
            ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = true;
            ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = false;
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataBind();
        }

		protected void referenciasGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(e.Exception.Message), false);
				e.ExceptionHandled = true;
			}
		}

		protected void referenciasGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
            try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
				FeaEntidades.InterFacturas.informacion_comprobanteReferencias r = refs[e.RowIndex];
				string auxCodRef = ((DropDownList)referenciasGridView.Rows[e.RowIndex].FindControl("ddlcodigo_de_referenciaEdit")).SelectedValue.ToString();
				string auxDescrCodRef = ((DropDownList)referenciasGridView.Rows[e.RowIndex].FindControl("ddlcodigo_de_referenciaEdit")).SelectedItem.Text;
				if (!auxCodRef.Equals(string.Empty))
				{
					r.codigo_de_referencia = Convert.ToInt32(auxCodRef);
					r.descripcioncodigo_de_referencia = auxDescrCodRef;
				}
				else
				{
					throw new Exception("Referencia no actualizada porque el código de referencia no puede estar vacío");
				}
				string auxDatoRef = ((TextBox)referenciasGridView.Rows[e.RowIndex].FindControl("txtdato_de_referencia")).Text;
				if (auxDatoRef.Contains("?"))
				{
					throw new Exception("Referencia no actualizada porque el número de referencia no respeta el formato para exportación");
				}
				else
				{
					r.dato_de_referencia = auxDatoRef;
				}

				referenciasGridView.EditIndex = -1;
				referenciasGridView.DataSource = ViewState["referencias"];
				referenciasGridView.DataBind();
				BindearDropDownLists();
			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
			}
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
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
	public partial class ReferenciasAFIP: System.Web.UI.UserControl
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
                AjustarTipoComprobanteAFIPEnFooter();
			}
		}
        private void AjustarTipoComprobanteAFIPEnFooter()
        {
            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).DataValueField = "Codigo";
            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).DataTextField = "Descr";
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (((Entidades.Sesion)Session["Sesion"]).Usuario != null)
                {
                    if (!puntoDeVenta.ToString().Equals(string.Empty))
                    {
                        int auxPV;
                        try
                        {
                            auxPV = Convert.ToInt32(puntoDeVenta.ToString());
                            string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.Nro == auxPV;
                            }).IdTipoPuntoVta;
                            switch (idtipo)
                            {
                                case "Comun":
                                case "RG2904":
                                case "BonoFiscal":
                                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).DataSource = FeaEntidades.TipoComprobanteAFIP.TipoComprobanteAFIP.Lista();
                                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).Visible = true;
                                    break;
                                default:
                                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).DataSource = FeaEntidades.TipoComprobanteAFIP.TipoComprobanteAFIP.Lista();
                                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).Visible = false;
                                    break;
                            }
                        }
                        catch
                        {
                            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).DataSource = FeaEntidades.TipoComprobanteAFIP.TipoComprobanteAFIP.Lista();
                            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).Visible = false;
                        }
                    }
                    else
                    {
                        ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).DataSource = FeaEntidades.TipoComprobanteAFIP.TipoComprobanteAFIP.Lista();
                        ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).Visible = false;
                    }
                }
                else
                {
                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).DataSource = FeaEntidades.TipoComprobanteAFIP.TipoComprobanteAFIP.Lista();
                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).Visible = false;
                }
                ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).DataBind();
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
                if (((Entidades.Sesion)Session["Sesion"]).Usuario != null && !puntoDeVenta.ToString().Equals(string.Empty))
                {
                    int auxPV;
                    try
                    {
                        auxPV = Convert.ToInt32(puntoDeVenta.ToString());
                        string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        switch (idtipo)
                        {
                            case "Comun":
                            case "RG2904":
                            case "BonoFiscal":
                                if (((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).SelectedValue.ToString() == "S")
                                {
                                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompletaAFIPSinInf();
                                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                                    ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = false;
                                }
                                else
                                {
                                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                                    ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                                }
                                break;
                            case "Exportacion":
                                ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.Exportaciones.Exportacion.Lista();
                                ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = true;
                                ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = false;
                                break;
                            default:
                                throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
                        }
                    }
                    catch
                    {
                        ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                        ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                        ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                    }
                }
                else
                {
                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                    ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                }
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

                    if (((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).Visible == true)
                    {
                        string auxTipoComprobanteAFIP = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).SelectedValue.ToString();
                        if (!auxTipoComprobanteAFIP.Equals(string.Empty))
                        {
                            r.tipo_comprobante_afip = auxTipoComprobanteAFIP;
                        }
                    }
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
                        throw new Exception("Referencia no agregada porque el número de referencia no respeta el formato");
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

            AjustarTipoComprobanteAFIPEnEdicion(sender, e);
            try
            {
                ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"])[e.NewEditIndex].tipo_comprobante_afip.ToString());
                li.Selected = true;
            }
            catch
            {
            }

            AjustarCodigoReferenciaEnEdicion(sender, e);
			try
			{
                ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"])[e.NewEditIndex].codigo_de_referencia.ToString());
				li.Selected = true;
                if (li.Value == "203")
                {
                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditMiPyMEsMaskedEditExtender")).Enabled = true;
                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                    ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = false;
                }
                else
                {
                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditMiPyMEsMaskedEditExtender")).Enabled = false;
                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = true;
                    ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = false;
                }
            }
            catch
			{
			}
            
        }
        private void AjustarTipoComprobanteAFIPEnEdicion(object sender, GridViewEditEventArgs e)
        {
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataTextField = "Descr";
            if (!puntoDeVenta.ToString().Equals(string.Empty))
            {
                int auxPV;
                try
                {
                    auxPV = Convert.ToInt32(puntoDeVenta.ToString());
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                    else
                    {
                        string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        switch (idtipo)
                        {
                            case "Comun":
                            case "RG2904":
                            case "BonoFiscal":
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataSource = FeaEntidades.TipoComprobanteAFIP.TipoComprobanteAFIP.Lista();
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataBind();
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).Visible = true;
                                break;
                            default:
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataSource = FeaEntidades.TipoComprobanteAFIP.TipoComprobanteAFIP.Lista();
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataBind();
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).Visible = false;
                                break;
                        }
                    }
                }
                catch
                {
                    ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataSource = FeaEntidades.TipoComprobanteAFIP.TipoComprobanteAFIP.Lista();
                    ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataBind();
                    ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).Visible = true;
                }
            }
            else
            {
                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataSource = FeaEntidades.TipoComprobanteAFIP.TipoComprobanteAFIP.Lista();
                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataBind();
                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).Visible = true;
            }
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).DataBind();
        }

        private void AjustarCodigoReferenciaEnEdicion(object sender, GridViewEditEventArgs e)
        {
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataTextField = "Descr";
            if (!puntoDeVenta.ToString().Equals(string.Empty))
            {
                int auxPV;
                try
                {
                    auxPV = Convert.ToInt32(puntoDeVenta.ToString());
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                    else
                    {
                        string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        switch (idtipo)
                        {
                            case "Comun":
                            case "RG2904":
                            case "BonoFiscal":
                                if (((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).SelectedValue.ToString() == "S")
                                {
                                    ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompletaAFIPSinInf();
                                    ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataBind();
                                    if (((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedValue.ToString() == "203")
                                    {
                                        ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterMiPyMEsMaskedEditExtender")).Enabled = true;
                                        ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                                    }
                                    else
                                    {
                                        ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterMiPyMEsMaskedEditExtender")).Enabled = false;
                                        ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = true;
                                    }
                                    ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = false;
                                }
                                else
                                {
                                    ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                                    ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataBind();
                                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                                    ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
                                }
                                break;
                            case "Exportacion":
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.Exportaciones.Exportacion.Lista();
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataBind();
                                ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = true;
                                ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = false;
                                break;
                            default:
                                throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
                        }
                    }
                }
                catch
                {
                    ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                    ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataBind();
                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                    ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
                }
            }
            else
            {
                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataBind();
                ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
            }
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
                string auxTipoComprobanteAFIP = ((DropDownList)referenciasGridView.Rows[e.RowIndex].FindControl("ddltipo_comprobante_afipEdit")).SelectedValue.ToString();
                if (!auxTipoComprobanteAFIP.Equals(string.Empty))
				{
                    r.tipo_comprobante_afip = auxTipoComprobanteAFIP;
                }
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
		public void CompletarReferencias(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			//Permisos de exportación
			referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
            if (lc.comprobante[0].cabecera.informacion_comprobante != null && lc.comprobante[0].cabecera.informacion_comprobante.referencias != null)
			{
				foreach (FeaEntidades.InterFacturas.informacion_comprobanteReferencias r in lc.comprobante[0].cabecera.informacion_comprobante.referencias)
				{
					//descripcioncodigo_de_permiso ( XmlIgnoreAttribute )
					//Se busca la descripción a través del código.
					try
					{
						if (r != null)
						{
                            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).SelectedValue = r.codigo_de_referencia.ToString();

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

        protected void ddltipo_comprobante_afip_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //DropDownList ddlAFIP = (DropDownList)sender;
            //string educationEstablishmentCode = ddlAFIP.SelectedValue;

            ////Get the GridViewRow in which this master DropDownList exists
            //GridViewRow row = (GridViewRow)ddlAFIP.NamingContainer;
            
            //DropDownList ddlREF = (DropDownList)row.FindControl("ddlcodigo_de_referencia");
            //ddlREF.DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
            //ddlREF.DataValueField = "Codigo";
            //ddlREF.DataTextField = "Descr";
            //ddlREF.DataBind();
            //TextBox TextREF = (TextBox)row.FindControl("txtdato_de_referencia");
            //TextREF.Text = "1234-12345678";

            AjustarCodigosDeReferenciaEnFooter();
            referenciasUpdatePanel.Update();
        }

        protected void ddltipo_comprobante_afipEdit_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DropDownList ddlAFIP = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlAFIP.NamingContainer;
            GridView griview = (GridView)row.NamingContainer;
            GridViewEditEventArgs ev = new GridViewEditEventArgs(row.RowIndex);
            AjustarCodigoReferenciaEnEdicion(griview, ev);
            
            referenciasUpdatePanel.Update();
        }

        private void AjustarDatoDeReferenciaEnFooter()
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (((Entidades.Sesion)Session["Sesion"]).Usuario != null && !puntoDeVenta.ToString().Equals(string.Empty))
                {
                    int auxPV;
                    try
                    {
                        auxPV = Convert.ToInt32(puntoDeVenta.ToString());
                        string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate (Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        switch (idtipo)
                        {
                            case "Comun":
                            case "RG2904":
                            case "BonoFiscal":
                                if (((DropDownList)referenciasGridView.FooterRow.FindControl("ddltipo_comprobante_afip")).SelectedValue.ToString() == "S")
                                {
                                    if (((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedValue.ToString() == "203")
                                    {
                                        ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterMiPyMEsMaskedEditExtender")).Enabled = true;
                                        ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                                        ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = false;
                                    }
                                    else
                                    {
                                        ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterMiPyMEsMaskedEditExtender")).Enabled = false;
                                        ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = true;
                                        ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = false;
                                    }
                                }
                                else
                                {
                                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterMiPyMEsMaskedEditExtender")).Enabled = false;
                                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                                    ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                                }
                                break;
                            case "Exportacion":
                                ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterMiPyMEsMaskedEditExtender")).Enabled = false;
                                ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = true;
                                ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = false;
                                break;
                            default:
                                throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
                        }
                    }
                    catch
                    {
                        ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                        ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterMiPyMEsMaskedEditExtender")).Enabled = false;
                        ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                        ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                    }
                }
                else
                {
                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterMiPyMEsMaskedEditExtender")).Enabled = false;
                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                    ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                }
            }
        }

        protected void ddlcodigo_de_referencia_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            AjustarDatoDeReferenciaEnFooter();
            referenciasUpdatePanel.Update();
        }

        protected void ddlcodigo_de_referenciaEdit_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DropDownList ddlcodigoRef = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlcodigoRef.NamingContainer;
            GridView griview = (GridView)row.NamingContainer;
            GridViewEditEventArgs ev = new GridViewEditEventArgs(row.RowIndex);
            AjustarDatoDeReferenciaEnEdicion(griview, ev);

            referenciasUpdatePanel.Update();
        }

        private void AjustarDatoDeReferenciaEnEdicion(object sender, GridViewEditEventArgs e)
        {
            if (!puntoDeVenta.ToString().Equals(string.Empty))
            {
                int auxPV;
                try
                {
                    auxPV = Convert.ToInt32(puntoDeVenta.ToString());
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                    else
                    {
                        string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate (Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        switch (idtipo)
                        {
                            case "Comun":
                            case "RG2904":
                            case "BonoFiscal":
                                if (((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_comprobante_afipEdit")).SelectedValue.ToString() == "S")
                                {
                                    if (((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).SelectedValue.ToString() == "203")
                                    {
                                        ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditMiPyMEsMaskedEditExtender")).Enabled = true;
                                        ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                                        ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = false;
                                    }
                                    else
                                    {
                                        ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditMiPyMEsMaskedEditExtender")).Enabled = false;
                                        ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = true;
                                        ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = false;
                                    }
                                }
                                else
                                {
                                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditMiPyMEsMaskedEditExtender")).Enabled = false;
                                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                                    ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
                                }
                                break;
                            case "Exportacion":
                                ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditMiPyMEsMaskedEditExtender")).Enabled = false;
                                ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = true;
                                ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = false;
                                break;
                            default:
                                throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
                        }
                    }
                }
                catch
                {
                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditMiPyMEsMaskedEditExtender")).Enabled = false;
                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                    ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
                }
            }
            else
            {
                ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditMiPyMEsMaskedEditExtender")).Enabled = false;
                ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
            }
        }

        protected void referenciasGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (Page.IsPostBack)
            //{
            //    if (e.Row.RowType == DataControlRowType.Footer)
            //    {
            //        DropDownList ddl = e.Row.FindControl("ddltipo_comprobante_afip") as DropDownList;
            //        if (ddl != null)
            //        {
            //            
            //        }
            //    }
            //}
        }

        protected void referenciasGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //Control ddlTipoCompAFIP = e.Row.Cells[0].FindControl("ddltipo_comprobante_afip");
            //if (ddlTipoCompAFIP != null)
            //{
            //    MasterPage Master = this.Parent.Page.Master as MasterPage;
            //    ScriptManager sm = ((ScriptManager)Master.FindControl("MasterScriptManager"));
            //    sm.RegisterAsyncPostBackControl(ddlTipoCompAFIP);
            //}
        }
	}
}
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
	public partial class Descuentos : System.Web.UI.UserControl
	{
		System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> descuentos;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				ResetearGrillas();
			}
		}
		protected void descuentosGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			descuentosGridView.EditIndex = -1;
			descuentosGridView.DataSource = ViewState["descuentos"];
			descuentosGridView.DataBind();
			BindearDropDownLists();
		}

		protected void descuentosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName.Equals("Adddescuentos"))
			{
				try
				{
					FeaEntidades.InterFacturas.resumenDescuentos rd = new FeaEntidades.InterFacturas.resumenDescuentos();

					string auxDescr = ((TextBox)descuentosGridView.FooterRow.FindControl("txtdescripcion")).Text;
					if (!auxDescr.Equals(string.Empty))
					{
						rd.descripcion_descuento = auxDescr;
					}
					else
					{
						throw new Exception("Descuento no agregado porque la descripción no puede estar vacía");
					}

					try
					{
						double pd = Convert.ToDouble(((TextBox)descuentosGridView.FooterRow.FindControl("txtporcentaje")).Text);
						rd.porcentaje_descuento = pd;
						if (!pd.Equals(0))
						{
							rd.porcentaje_descuentoSpecified = true;
						}
						else
						{
							rd.porcentaje_descuentoSpecified = false;
						}
					}
					catch
					{
						rd.porcentaje_descuento = 0;
						rd.porcentaje_descuentoSpecified = false;
					}

					string auxTotal = ((TextBox)descuentosGridView.FooterRow.FindControl("txtimporte_descuento")).Text;
					rd.importe_descuento = Convert.ToDouble(auxTotal);

					double auxAliIVA = Convert.ToDouble(((DropDownList)descuentosGridView.FooterRow.FindControl("ddlalicuota_iva")).SelectedValue);
					string auxDescAliIVA = ((DropDownList)descuentosGridView.FooterRow.FindControl("ddlalicuota_iva")).SelectedItem.Text;
					if (!auxDescAliIVA.Equals(string.Empty))
					{
						rd.alicuota_iva_descuentoSpecified = true;
						rd.alicuota_iva_descuento = auxAliIVA;
					}
					else
					{
						rd.alicuota_iva_descuentoSpecified = false;
						rd.alicuota_iva_descuento = new FeaEntidades.IVA.SinInformar().Codigo;
					}

					try
					{
						double iid = Convert.ToDouble(((TextBox)descuentosGridView.FooterRow.FindControl("txtimporte_iva")).Text);
						rd.importe_iva_descuento = iid;
						if (!iid.Equals(0))
						{
							rd.importe_iva_descuentoSpecified = true;
						}
						else
						{
							rd.importe_iva_descuentoSpecified = false;
						}
					}
					catch
					{
						rd.importe_iva_descuento = 0;
						rd.importe_iva_descuentoSpecified = false;
					}

					rd.indicacion_exento_gravado_descuento = ((DropDownList)descuentosGridView.FooterRow.FindControl("ddlindicacion")).SelectedValue;

					((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]).Add(rd);


					//Me fijo si elimino la fila automática
					System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> rds = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]);
					if (rds[0].descripcion_descuento == null)
					{
						((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]).Remove(rds[0]);
					}

					//Saco de edición la fila que estén modificando
					if (!descuentosGridView.EditIndex.Equals(-1))
					{
						descuentosGridView.EditIndex = -1;
					}

					descuentosGridView.DataSource = ViewState["descuentos"];
					descuentosGridView.DataBind();
					BindearDropDownLists();
				}
				catch (Exception ex)
				{
					ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", "alert('" + ex.Message.ToString().Replace("'", "") + "');", true);
				}
			}
		}

		protected void descuentosGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", RN.Funciones.TextoScript(e.Exception.Message), false);
				e.ExceptionHandled = true;
			}
		}

		protected void descuentosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> rds = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]);
				FeaEntidades.InterFacturas.resumenDescuentos rd = rds[e.RowIndex];
				rds.Remove(rd);

				if (rds.Count.Equals(0))
				{
					FeaEntidades.InterFacturas.resumenDescuentos nuevo = new FeaEntidades.InterFacturas.resumenDescuentos();
					rds.Add(nuevo);
				}

				descuentosGridView.EditIndex = -1;

				descuentosGridView.DataSource = ViewState["descuentos"];
				descuentosGridView.DataBind();
				BindearDropDownLists();
			}
			catch
			{
			}
		}

		protected void descuentosGridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			descuentosGridView.EditIndex = e.NewEditIndex;
			descuentosGridView.DataSource = ViewState["descuentos"];
			descuentosGridView.DataBind();
			BindearDropDownLists();

			double aux;
			aux = Convert.ToDouble(((System.Web.UI.WebControls.TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_iva"))).Text);
			((System.Web.UI.WebControls.TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_iva"))).Text = aux.ToString("0.00");

			aux = Convert.ToDouble(((System.Web.UI.WebControls.TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtporcentaje"))).Text);
			((System.Web.UI.WebControls.TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtporcentaje"))).Text = aux.ToString("0.00");

			aux = Convert.ToDouble(((System.Web.UI.WebControls.TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_descuento"))).Text);
			((System.Web.UI.WebControls.TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_descuento"))).Text = aux.ToString("0.00");

			ListItem li;
			try
			{
				li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_ivaEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"])[e.NewEditIndex].alicuota_iva_descuento.ToString());
				li.Selected = true;
			}
			catch
			{
			}

			try
			{
				li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacionEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"])[e.NewEditIndex].indicacion_exento_gravado_descuento.ToString());
				li.Selected = true;
			}
			catch
			{
			}

		}

		protected void descuentosGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", "alert('" + e.Exception.Message.ToString().Replace("'", "") + "');", true);
				e.ExceptionHandled = true;
			}
		}

		protected void descuentosGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> rds = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]);

				FeaEntidades.InterFacturas.resumenDescuentos rd = rds[e.RowIndex];
				string auxDescr = ((TextBox)descuentosGridView.Rows[e.RowIndex].FindControl("txtdescripcion")).Text;
				if (!auxDescr.Equals(string.Empty))
				{
					rd.descripcion_descuento = auxDescr;
				}
				else
				{
					throw new Exception("Descuento no actualizado porque la descripción no puede estar vacía");
				}

				try
				{
					double pd = Convert.ToDouble(((TextBox)descuentosGridView.Rows[e.RowIndex].FindControl("txtporcentaje")).Text);
					rd.porcentaje_descuento = pd;
					if (!pd.Equals(0))
					{
						rd.porcentaje_descuentoSpecified = true;
					}
					else
					{
						rd.porcentaje_descuentoSpecified = false;
					}
				}
				catch
				{
					rd.porcentaje_descuentoSpecified = false;
					rd.porcentaje_descuento = 0;
				}

				string auxTotal = ((TextBox)descuentosGridView.Rows[e.RowIndex].FindControl("txtimporte_descuento")).Text;
				if (!auxTotal.Contains(","))
				{
					if (auxTotal.Split('.').Length>2)
					{
						throw new Exception("Descuento no actualizado porque hay más de un separador de decimales en el importe dto");
					}
					double id=Convert.ToDouble(auxTotal);
					if (id.Equals(0))
					{
						throw new Exception("El importe del impuesto global no puede informarse en 0");
					}
					else 
					{
						rd.importe_descuento = id;
					}
				}
				else
				{
					throw new Exception("Descuento no actualizado porque el separador de decimales debe ser el punto");
				}

				double auxAliIVA = Convert.ToDouble(((DropDownList)descuentosGridView.Rows[e.RowIndex].FindControl("ddlalicuota_ivaEdit")).SelectedValue);
				string auxDescAliIVA = ((DropDownList)descuentosGridView.Rows[e.RowIndex].FindControl("ddlalicuota_ivaEdit")).SelectedItem.Text;
				if (!auxDescAliIVA.Equals(string.Empty))
				{
					rd.alicuota_iva_descuentoSpecified = true;
					rd.alicuota_iva_descuento = auxAliIVA;
				}
				else
				{
					rd.alicuota_iva_descuentoSpecified = false;
					rd.alicuota_iva_descuento = new FeaEntidades.IVA.SinInformar().Codigo;
				}

				if (((TextBox)descuentosGridView.Rows[e.RowIndex].FindControl("txtimporte_iva")).Text.Split('.').Length > 2)
				{
					throw new Exception("Descuento no actualizado porque hay más de un separador de decimales en el importe IVA dto");
				}
				try
				{

					double iid = Convert.ToDouble(((TextBox)descuentosGridView.Rows[e.RowIndex].FindControl("txtimporte_iva")).Text);
					rd.importe_iva_descuento = iid;
					if (!iid.Equals(0))
					{
						rd.importe_iva_descuentoSpecified = true;
					}
					else
					{
						rd.importe_iva_descuentoSpecified = false;
					}
				}
				catch (FormatException)
				{
					rd.importe_iva_descuento = 0;
					rd.importe_iva_descuentoSpecified = false;
				}
			

				rd.indicacion_exento_gravado_descuento = ((DropDownList)descuentosGridView.Rows[e.RowIndex].FindControl("ddlindicacionEdit")).SelectedValue;

				descuentosGridView.EditIndex = -1;
				descuentosGridView.DataSource = ViewState["descuentos"];
				descuentosGridView.DataBind();
				BindearDropDownLists();
			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", RN.Funciones.TextoScript(ex.Message), false);
			}
		}

		public void Completar(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			descuentos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>();
			if (lc.comprobante[0].resumen.descuentos != null)
			{
				foreach (FeaEntidades.InterFacturas.resumenDescuentos r in lc.comprobante[0].resumen.descuentos)
				{
					if (r.importe_descuento_moneda_origenSpecified)
					{
						r.importe_descuento = r.importe_descuento_moneda_origen;
					}
					if (r.importe_iva_descuento_moneda_origenSpecified)
					{
						r.importe_iva_descuento = r.importe_iva_descuento_moneda_origen;
					}
					descuentos.Add(r);
				}
			}
			if (descuentos.Count.Equals(0))
			{
				descuentos.Add(new FeaEntidades.InterFacturas.resumenDescuentos());
			}
			descuentosGridView.DataSource = descuentos;
			descuentosGridView.DataBind();
			BindearDropDownLists();
			ViewState["descuentos"] = descuentos;
		}
		public void ResetearGrillas()
		{
			descuentos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>();
			FeaEntidades.InterFacturas.resumenDescuentos descuento = new FeaEntidades.InterFacturas.resumenDescuentos();
			descuentos.Add(descuento);
			descuentosGridView.DataSource = descuentos;
			ViewState["descuentos"] = descuentos;
			DataBind();
			BindearDropDownLists();
		}
		public void CompletarDetallesWS(org.dyndns.cedweb.consulta.ConsultarResult lc)
		{
			if (lc.comprobante[0].resumen.descuentos != null)
			{
				descuentos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>();
				foreach (org.dyndns.cedweb.consulta.ConsultarResultComprobanteResumenDescuentos r in lc.comprobante[0].resumen.descuentos)
				{
					if (r.importe_descuento_moneda_origenSpecified)
					{
						r.importe_descuento = r.importe_descuento_moneda_origen;
					}
					FeaEntidades.InterFacturas.resumenDescuentos rd = new FeaEntidades.InterFacturas.resumenDescuentos();
					rd.alicuota_iva_descuento = r.alicuota_iva_descuento;
					rd.alicuota_iva_descuentoSpecified = r.alicuota_iva_descuentoSpecified;
					rd.descripcion_descuento = r.descripcion_descuento;
					rd.importe_descuento = r.importe_descuento;
					rd.importe_descuento_moneda_origen = r.importe_descuento_moneda_origen;
					rd.importe_descuento_moneda_origenSpecified = r.importe_descuento_moneda_origenSpecified;
					rd.importe_iva_descuento = r.importe_iva_descuento;
					rd.importe_iva_descuento_moneda_origen = r.importe_iva_descuento_moneda_origen;
					rd.importe_iva_descuento_moneda_origenSpecified = r.importe_iva_descuento_moneda_origenSpecified;
					rd.importe_iva_descuentoSpecified = r.importe_iva_descuentoSpecified;
					rd.porcentaje_descuento = r.porcentaje_descuento;
					rd.porcentaje_descuentoSpecified = r.porcentaje_descuentoSpecified;
					descuentos.Add(rd);
				}
				if (descuentos.Count.Equals(0))
				{
					descuentos.Add(new FeaEntidades.InterFacturas.resumenDescuentos());
				}
				descuentosGridView.DataSource = descuentos;
				descuentosGridView.DataBind();
				ViewState["descuentos"] = descuentos;
			}

		}
		public void BindearDropDownLists()
		{
			if (descuentosGridView.FooterRow != null)
			{
				((DropDownList)descuentosGridView.FooterRow.FindControl("ddlalicuota_iva")).DataValueField = "Codigo";
				((DropDownList)descuentosGridView.FooterRow.FindControl("ddlalicuota_iva")).DataTextField = "Descr";
				((DropDownList)descuentosGridView.FooterRow.FindControl("ddlalicuota_iva")).DataSource = FeaEntidades.IVA.IVA.Lista();
				((DropDownList)descuentosGridView.FooterRow.FindControl("ddlalicuota_iva")).DataBind();

				((DropDownList)descuentosGridView.FooterRow.FindControl("ddlindicacion")).DataValueField = "Codigo";
				((DropDownList)descuentosGridView.FooterRow.FindControl("ddlindicacion")).DataTextField = "Descr";
				((DropDownList)descuentosGridView.FooterRow.FindControl("ddlindicacion")).DataSource = FeaEntidades.Indicacion.Indicacion.Lista();
				((DropDownList)descuentosGridView.FooterRow.FindControl("ddlindicacion")).DataBind();
			}
			if (!descuentosGridView.EditIndex.Equals(-1))
			{
				((DropDownList)descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("ddlalicuota_ivaEdit")).DataValueField = "Codigo";
				((DropDownList)descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("ddlalicuota_ivaEdit")).DataTextField = "Descr";
				((DropDownList)descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("ddlalicuota_ivaEdit")).DataSource = FeaEntidades.IVA.IVA.Lista();
				((DropDownList)descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("ddlalicuota_ivaEdit")).DataBind();

				((DropDownList)descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("ddlindicacionEdit")).DataValueField = "Codigo";
				((DropDownList)descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("ddlindicacionEdit")).DataTextField = "Descr";
				((DropDownList)descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("ddlindicacionEdit")).DataSource = FeaEntidades.Indicacion.Indicacion.Lista();
				((DropDownList)descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("ddlindicacionEdit")).DataBind();
			}
		}

		public void GenerarResumen(FeaEntidades.InterFacturas.comprobante comp, string monedaComprobante, string tipoDeCambio)
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> listadedescuentos = (System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"];
			comp.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[listadedescuentos.Count];
			for (int i = 0; i < listadedescuentos.Count; i++)
			{
				if (listadedescuentos[i].descripcion_descuento != null && !listadedescuentos[i].descripcion_descuento.Equals(string.Empty))
				{
					comp.resumen.descuentos[i] = new FeaEntidades.InterFacturas.resumenDescuentos();
					comp.resumen.descuentos[i].alicuota_iva_descuento = listadedescuentos[i].alicuota_iva_descuento;
					comp.resumen.descuentos[i].alicuota_iva_descuentoSpecified = listadedescuentos[i].alicuota_iva_descuentoSpecified;
					comp.resumen.descuentos[i].descripcion_descuento = listadedescuentos[i].descripcion_descuento;
					comp.resumen.descuentos[i].importe_iva_descuento = listadedescuentos[i].importe_iva_descuento;
					comp.resumen.descuentos[i].importe_iva_descuentoSpecified = listadedescuentos[i].importe_iva_descuentoSpecified;
					comp.resumen.descuentos[i].porcentaje_descuento = listadedescuentos[i].porcentaje_descuento;
					comp.resumen.descuentos[i].porcentaje_descuentoSpecified = listadedescuentos[i].porcentaje_descuentoSpecified;
					comp.resumen.descuentos[i].indicacion_exento_gravado_descuento = listadedescuentos[i].indicacion_exento_gravado_descuento;

					if (monedaComprobante.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
					{
						comp.resumen.descuentos[i].importe_descuento = listadedescuentos[i].importe_descuento;
					}
					else
					{
						comp.resumen.descuentos[i].importe_descuento = Math.Round(listadedescuentos[i].importe_descuento * Convert.ToDouble(tipoDeCambio), 2);
						comp.resumen.descuentos[i].importe_descuento_moneda_origen = listadedescuentos[i].importe_descuento;
						comp.resumen.descuentos[i].importe_descuento_moneda_origenSpecified = true;
						if (!comp.resumen.descuentos[i].importe_iva_descuento.Equals(0))
						{
							comp.resumen.descuentos[i].importe_iva_descuento = Math.Round(listadedescuentos[i].importe_iva_descuento * Convert.ToDouble(tipoDeCambio), 2);
							comp.resumen.descuentos[i].importe_iva_descuento_moneda_origen = listadedescuentos[i].importe_iva_descuento;
							comp.resumen.descuentos[i].importe_iva_descuento_moneda_origenSpecified = true;
						}
					}
				}
			}
		}
		protected string GetAlicuotaIVA(double alic)
		{
			if (alic != 99)
			{
				string aux = Convert.ToString(alic);
				return aux;
			}
			else
			{
				return string.Empty;
			}
		}
		protected string Formatear2Decimales(double aux)
		{
			return aux.ToString("0.00");
		}
		protected void CalcularImporteDtoEdit(object sender, EventArgs e)
		{
			try
			{
				double aux;
				if (!((System.Web.UI.Control)(sender)).ID.Equals("txtimporte_descuento"))
				{
					aux = ((Lote)this.Parent.Page).Articulos.CalcularTotalImporte();
					try
					{
						aux = aux * Convert.ToDouble(((TextBox)sender).Text) / 100;
						((TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_descuento"))).Text = Math.Round(aux, 2).ToString("0.00");
					}
					catch (FormatException)
					{
						aux = Convert.ToDouble(((TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_descuento"))).Text);
					}
				}
				else
				{
					aux = Convert.ToDouble(((TextBox)sender).Text);
				}
				string auxImpIVAString = ((DropDownList)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("ddlalicuota_ivaEdit"))).SelectedValue;
				if (!auxImpIVAString.Equals("99"))
				{
					double auxImpIVA = aux * Convert.ToDouble(auxImpIVAString);
					((TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_iva"))).Text = Math.Round(auxImpIVA / 100, 2).ToString("0.00");
				}
				else
				{
					((TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_iva"))).Text = "";
				}
			}
			catch(FormatException)
			{
				throw new Exception("Importes no actualizados porque hay más de un separador de decimales");
			}
		}
		protected void CalcularImporteDtoFooter(object sender, EventArgs e)
		{
			try
			{
				double aux;
				if (!((System.Web.UI.Control)(sender)).ID.Equals("txtimporte_descuento"))
				{
					 aux = ((Lote)this.Parent.Page).Articulos.CalcularTotalImporte();
					try
					{
						aux = aux * Convert.ToDouble(((TextBox)sender).Text) / 100;
						((TextBox)(descuentosGridView.FooterRow.FindControl("txtimporte_descuento"))).Text = Math.Round(aux, 2).ToString("0.00");
					}
					catch (FormatException)
					{
						aux = Convert.ToDouble(((TextBox)(descuentosGridView.FooterRow.FindControl("txtimporte_descuento"))).Text);
					}
				}
				else
				{
					aux = Convert.ToDouble(((TextBox)sender).Text);
				}
				string auxImpIVAString = ((DropDownList)(descuentosGridView.FooterRow.FindControl("ddlalicuota_iva"))).SelectedValue;
				if (!auxImpIVAString.Equals("99"))
				{
					double auxImpIVA = aux * Convert.ToDouble(auxImpIVAString);
					((TextBox)(descuentosGridView.FooterRow.FindControl("txtimporte_iva"))).Text = Math.Round(auxImpIVA / 100, 2).ToString("0.00");
				}
				else
				{
					((TextBox)(descuentosGridView.FooterRow.FindControl("txtimporte_iva"))).Text = "";
				}
			}
			catch (FormatException)
			{
				throw new Exception("Importes no actualizados porque hay más de un separador de decimales");
			}
		}
		protected void ddlalicuota_ivaEdit_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				double imptot = Convert.ToDouble(((TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_descuento"))).Text);
				double alic = Convert.ToDouble(((DropDownList)sender).SelectedValue);
				if (!imptot.Equals(0) && !alic.Equals(99))
				{
					double aux = imptot * alic / 100;
					((TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_iva"))).Text = Math.Round(aux, 2).ToString("0.00");
				}
				if (alic.Equals(99))
				{
					((TextBox)(descuentosGridView.Rows[descuentosGridView.EditIndex].FindControl("txtimporte_iva"))).Text = string.Empty;
				}
			}
			catch
			{
			}
		}
		protected void ddlalicuota_ivaFooter_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				double imptot = Convert.ToDouble(((TextBox)(descuentosGridView.FooterRow.FindControl("txtimporte_descuento"))).Text);
				double alic = Convert.ToDouble(((DropDownList)sender).SelectedValue);
				if (!imptot.Equals(0) && !alic.Equals(99))
				{
					double aux = imptot * alic / 100;
					((TextBox)(descuentosGridView.FooterRow.FindControl("txtimporte_iva"))).Text = Math.Round(aux, 2).ToString("0.00");
				}
				if (alic.Equals(99))
				{
					((TextBox)(descuentosGridView.FooterRow.FindControl("txtimporte_iva"))).Text = string.Empty;
				}
			}
			catch
			{
			}
		}
		public void AplicarDtosATotales(ref double totalGravado, ref double totalNoGravado, ref double total_Operaciones_Exentas, ref double totalIVA)
		{
			//Proceso DESCUENTOS GLOBALES
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> listadedescuentos = (System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"];
			for (int i = 0; i < listadedescuentos.Count; i++)
			{
				if (listadedescuentos[i].descripcion_descuento != null && !listadedescuentos[i].descripcion_descuento.Equals(string.Empty))
				{
					switch (listadedescuentos[i].indicacion_exento_gravado_descuento)
					{
						case "G":
							totalGravado -= listadedescuentos[i].importe_descuento;
							totalIVA -= listadedescuentos[i].importe_iva_descuento;
							break;
						case "N":
							totalNoGravado -= listadedescuentos[i].importe_descuento;
							break;
						case "E":
							total_Operaciones_Exentas -= listadedescuentos[i].importe_descuento;
							break;
					}
				}
			}
		}
		internal void RestarDescuentosAImpuestosGlobales(System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos)
		{
			descuentos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]);
			
			System.Collections.Generic.List<FeaEntidades.IVA.IVA> listaIVA = FeaEntidades.IVA.IVA.ListaMinima();
			double[] impivas = new double[listaIVA.Count];
			for (int i = 0; i < descuentos.Count; i++)
			{
				if (descuentos[i].importe_iva_descuento != 0)
				{
					if (descuentos[i].alicuota_iva_descuentoSpecified)
					{
						FeaEntidades.IVA.IVA auxIVA=listaIVA.Find(delegate(FeaEntidades.IVA.IVA e)
						{
							return e.Codigo == descuentos[i].alicuota_iva_descuento;
						});
						FeaEntidades.InterFacturas.resumenImpuestos ri = impuestos.Find(delegate(FeaEntidades.InterFacturas.resumenImpuestos r)
						{
							return auxIVA.Codigo == r.porcentaje_impuesto;
						});
						if (ri != null)
						{
							ri.importe_impuesto -= descuentos[i].importe_iva_descuento;
						}
						else
						{
							ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", RN.Funciones.TextoScript("La alícuota de IVA de un descuento (" + auxIVA.Codigo + ") no coincide con ninguna alícuota de los impuestos"), false);
						}
					}
				}
			}
		}
	}
}
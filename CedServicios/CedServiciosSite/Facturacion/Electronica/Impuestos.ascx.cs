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
	public partial class Impuestos : System.Web.UI.UserControl
	{
        string puntoDeVenta;
		System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos;
		protected void Page_Load(object sender, EventArgs e)
		{
            puntoDeVenta = Convert.ToString(ViewState["puntoDeVenta"]);
			if (!this.IsPostBack)
			{
                Object o = Session["ComprobanteATratar"];
                if (o == null || ((Entidades.ComprobanteATratar)o).Tratamiento == Entidades.Enum.TratamientoComprobante.Alta)
                {
                    ResetearGrillas();
                }
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
			if (impuestosGridView.FooterRow != null)
			{
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataValueField = "Codigo";
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataTextField = "Descr";
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataSource = FeaEntidades.CodigosImpuesto.CodigoImpuesto.Lista();
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataBind();

				((DropDownList)impuestosGridView.FooterRow.FindControl("ddljurisdiccion")).DataValueField = "Codigo";
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddljurisdiccion")).DataTextField = "Descr";
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddljurisdiccion")).DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddljurisdiccion")).DataBind();

			}
			if (!impuestosGridView.EditIndex.Equals(-1))
			{
				((DropDownList)impuestosGridView.Rows[impuestosGridView.EditIndex].FindControl("ddlcodigo_impuestoEdit")).DataValueField = "Codigo";
				((DropDownList)impuestosGridView.Rows[impuestosGridView.EditIndex].FindControl("ddlcodigo_impuestoEdit")).DataTextField = "Descr";
				((DropDownList)impuestosGridView.Rows[impuestosGridView.EditIndex].FindControl("ddlcodigo_impuestoEdit")).DataSource = FeaEntidades.CodigosImpuesto.CodigoImpuesto.Lista();
				((DropDownList)impuestosGridView.Rows[impuestosGridView.EditIndex].FindControl("ddlcodigo_impuestoEdit")).DataBind();

				((DropDownList)impuestosGridView.Rows[impuestosGridView.EditIndex].FindControl("ddljurisdiccionEdit")).DataValueField = "Codigo";
				((DropDownList)impuestosGridView.Rows[impuestosGridView.EditIndex].FindControl("ddljurisdiccionEdit")).DataTextField = "Descr";
				((DropDownList)impuestosGridView.Rows[impuestosGridView.EditIndex].FindControl("ddljurisdiccionEdit")).DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
				((DropDownList)impuestosGridView.Rows[impuestosGridView.EditIndex].FindControl("ddljurisdiccionEdit")).DataBind();
			}
		}
		public void ResetearGrillas()
		{
			impuestos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>();
			FeaEntidades.InterFacturas.resumenImpuestos impuesto = new FeaEntidades.InterFacturas.resumenImpuestos();
			impuestos.Add(impuesto);
			impuestosGridView.DataSource = impuestos;
			ViewState["impuestos"] = impuestos;
			DataBind();

			BindearDropDownLists();

		}

		public void Completar(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			impuestos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>();
			if (lc.comprobante[0].resumen.impuestos != null)
			{
				foreach (FeaEntidades.InterFacturas.resumenImpuestos imp in lc.comprobante[0].resumen.impuestos)
				{
					if (imp.importe_impuesto_moneda_origenSpecified)
					{
						imp.importe_impuesto = imp.importe_impuesto_moneda_origen;
					}
					impuestos.Add(imp);
				}
			}
			if (impuestos.Count.Equals(0))
			{
				impuestos.Add(new FeaEntidades.InterFacturas.resumenImpuestos());
			}
			impuestosGridView.DataSource = impuestos;
			impuestosGridView.DataBind();
			ViewState["impuestos"] = impuestos;


		}
		public void CompletarWS(org.dyndns.cedweb.consulta.ConsultarResult lc)
		{
			if (lc.comprobante[0].resumen.impuestos != null)
			{
				impuestos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>();
				foreach (org.dyndns.cedweb.consulta.ConsultarResultComprobanteResumenImpuestos imp in lc.comprobante[0].resumen.impuestos)
				{
					if (imp.importe_impuesto_moneda_origenSpecified)
					{
						imp.importe_impuesto = imp.importe_impuesto_moneda_origen;
					}
					FeaEntidades.InterFacturas.resumenImpuestos ri = new FeaEntidades.InterFacturas.resumenImpuestos();
					ri.codigo_impuesto = imp.codigo_impuesto;
					ri.codigo_jurisdiccion = imp.codigo_jurisdiccion;
					ri.codigo_jurisdiccionSpecified = imp.codigo_jurisdiccionSpecified;
					ri.descripcion = imp.descripcion;
					ri.importe_impuesto = imp.importe_impuesto;
					ri.importe_impuesto_moneda_origen = imp.importe_impuesto_moneda_origen;
					ri.importe_impuesto_moneda_origenSpecified = imp.importe_impuesto_moneda_origenSpecified;
					ri.jurisdiccion_municipal = imp.jurisdiccion_municipal;
					ri.porcentaje_impuesto = imp.porcentaje_impuesto;
					ri.porcentaje_impuestoSpecified = imp.porcentaje_impuestoSpecified;
					impuestos.Add(ri);
				}
				if (impuestos.Count.Equals(0))
				{
					impuestos.Add(new FeaEntidades.InterFacturas.resumenImpuestos());
				}
				impuestosGridView.DataSource = impuestos;
				impuestosGridView.DataBind();
				ViewState["impuestos"] = impuestos;
			}
		}
		public System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> Lista
		{
			get
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
				return refs;
			}
		}
		public System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> EliminarImpuestosIVA()
		{
			impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
			impuestos.RemoveAll(delegate(FeaEntidades.InterFacturas.resumenImpuestos e)
				{
					return e.codigo_impuesto == new FeaEntidades.CodigosImpuesto.IVA().Codigo;
				});

			if (impuestos.Count.Equals(0))
			{
				FeaEntidades.InterFacturas.resumenImpuestos nueva = new FeaEntidades.InterFacturas.resumenImpuestos();
				impuestos.Add(nueva);
			}

			impuestosGridView.DataSource = impuestos;
			impuestosGridView.DataBind();
			ViewState["impuestos"] = impuestos;
			BindearDropDownLists();
			return impuestos;
		}
		protected void impuestosGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			impuestosGridView.EditIndex = -1;
			impuestosGridView.DataSource = ViewState["impuestos"];
			impuestosGridView.DataBind();
			BindearDropDownLists();
		}
		protected void impuestosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName.Equals("AddImpuestoGlobal"))
			{
				try
				{
					FeaEntidades.InterFacturas.resumenImpuestos r = new FeaEntidades.InterFacturas.resumenImpuestos();
					
					int auxcodigo_impuesto = Convert.ToInt32(((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).SelectedValue);
					r.codigo_impuesto = auxcodigo_impuesto;

					string auxpi = ((TextBox)impuestosGridView.FooterRow.FindControl("txtalicuota")).Text;
					if (!auxpi.Equals(string.Empty))
					{
						double auxporcentaje_impuesto = Convert.ToDouble(auxpi);
						r.porcentaje_impuesto = auxporcentaje_impuesto;
						r.porcentaje_impuestoSpecified = true;
					}
					else
					{
						r.porcentaje_impuestoSpecified = false;
					}

					int auxcodigo_jurisdiccion = Convert.ToInt32(((DropDownList)impuestosGridView.FooterRow.FindControl("ddljurisdiccion")).SelectedValue);
                    if (!auxcodigo_jurisdiccion.Equals(0))
                    {
                        r.codigo_jurisdiccion = auxcodigo_jurisdiccion;
                        r.codigo_jurisdiccionSpecified = true;
                    }
                    else
                    {
                        r.codigo_jurisdiccion = 0;
                        r.codigo_jurisdiccionSpecified = false;
                    }


					r.descripcion = ((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).SelectedItem.Text;

					string auxTotal = ((TextBox)impuestosGridView.FooterRow.FindControl("txtimporte_impuesto")).Text;
					if (!auxTotal.Contains(","))
					{
						double auxImp = Convert.ToDouble(auxTotal);
						if (!auxImp.Equals(0))
						{
							r.importe_impuesto = auxImp;
						}
						else
						{
                            if (r.porcentaje_impuesto != 0)
                            {
                                throw new Exception("Impuesto global no agregado porque el importe debe ser mayor a 0");
                            }
						}
					}
					else
					{
						throw new Exception("Impuesto global no agregado porque el separador de decimales debe ser el punto");
					}

					((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]).Add(r);


					//Me fijo si elimino la fila automática
					EliminarFilaAutomatica();

					//Saco de edición la fila que estén modificando
					if (!impuestosGridView.EditIndex.Equals(-1))
					{
						impuestosGridView.EditIndex = -1;
					}

					impuestosGridView.DataSource = ViewState["impuestos"];
					impuestosGridView.DataBind();
					BindearDropDownLists();
                    Session["FaltaCalcularTotales"] = true;

				}
				catch (Exception ex)
				{
					ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
				}
			}
		}

		private void EliminarFilaAutomatica()
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
			FeaEntidades.InterFacturas.resumenImpuestos impuestoInicial = impuestos[0];
			if (impuestoInicial.codigo_impuesto == 0)
			{
				((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]).Remove(impuestoInicial);
			}
		}

		protected void impuestosGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(e.Exception.Message), false);
				e.ExceptionHandled = true;
			}
		}
		protected void impuestosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
				FeaEntidades.InterFacturas.resumenImpuestos r = impuestos[e.RowIndex];
				impuestos.Remove(r);

				if (impuestos.Count.Equals(0))
				{
					FeaEntidades.InterFacturas.resumenImpuestos nueva = new FeaEntidades.InterFacturas.resumenImpuestos();
					impuestos.Add(nueva);
				}
				impuestosGridView.EditIndex = -1;
				impuestosGridView.DataSource = ViewState["impuestos"];
				impuestosGridView.DataBind();
				BindearDropDownLists();
                Session["FaltaCalcularTotales"] = true;
			}
			catch
			{
			}
		}
		protected void impuestosGridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			impuestosGridView.EditIndex = e.NewEditIndex;

			impuestosGridView.DataSource = ViewState["impuestos"];
			impuestosGridView.DataBind();
			BindearDropDownLists();


			try
			{
				ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"])[e.NewEditIndex].codigo_impuesto.ToString());
				li.Selected = true;
			}
			catch
			{
			}

			try
			{
				ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddljurisdiccionEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"])[e.NewEditIndex].codigo_jurisdiccion.ToString());
				li.Selected = true;
			}
			catch
			{
			}

		}
		protected void impuestosGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(e.Exception.Message), false);
				e.ExceptionHandled = true;
			}
		}
		protected void impuestosGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);

				FeaEntidades.InterFacturas.resumenImpuestos r = impuestos[e.RowIndex];
				int auxcodigo_impuesto = Convert.ToInt32(((DropDownList)impuestosGridView.Rows[e.RowIndex].FindControl("ddlcodigo_impuestoEdit")).SelectedValue);
				r.codigo_impuesto = auxcodigo_impuesto;

				string auxdescr_impuesto = ((DropDownList)impuestosGridView.Rows[e.RowIndex].FindControl("ddlcodigo_impuestoEdit")).SelectedItem.Text;
				r.descripcion = auxdescr_impuesto;

                string auxAlicuota = ((TextBox)impuestosGridView.Rows[e.RowIndex].FindControl("txtalicuota")).Text;
                if (!auxAlicuota.Contains(","))
                {
                    r.porcentaje_impuesto = Convert.ToDouble(auxAlicuota);
                    r.porcentaje_impuestoSpecified = true;
                    //if (!r.porcentaje_impuesto.Equals(0))
                    //{
                    //    r.porcentaje_impuestoSpecified = true;
                    //}
                    //else
                    //{
                    //    r.porcentaje_impuestoSpecified = false;
                    //}
                }
                else
                {
                    throw new Exception("Impuesto global no actualizado porque el separador de decimales debe ser el punto");
                }

				string auxTotal = ((TextBox)impuestosGridView.Rows[e.RowIndex].FindControl("txtimporte_impuesto")).Text;
				if (!auxTotal.Contains(","))
				{
					double auxImp = Convert.ToDouble(auxTotal);
					if (!auxImp.Equals(0))
					{
						r.importe_impuesto = auxImp;
					}
					else
					{
                        if (r.porcentaje_impuesto != 0)
                        {
                            throw new Exception("Impuesto global no actualizado porque el importe debe ser mayor a 0");
                        }
					}
				}
				else
				{
					throw new Exception("Impuesto global no actualizado porque el separador de decimales debe ser el punto");
				}

				int auxjurisdiccion= Convert.ToInt32(((DropDownList)impuestosGridView.Rows[e.RowIndex].FindControl("ddljurisdiccionEdit")).SelectedValue);
				if (!auxjurisdiccion.Equals(0))
				{
					r.codigo_jurisdiccion = auxjurisdiccion;
					r.codigo_jurisdiccionSpecified = true;
				}
				else
				{
					r.codigo_jurisdiccion = 0;
					r.codigo_jurisdiccionSpecified = false;
				}

				impuestosGridView.EditIndex = -1;
				impuestosGridView.DataSource = ViewState["impuestos"];
				impuestosGridView.DataBind();
				BindearDropDownLists();
                Session["FaltaCalcularTotales"] = true;

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
			}
		}
		public bool HayImpuestos
		{
			get
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);

				if (impuestos[0].importe_impuesto.Equals(0))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}
		public void GenerarImpuestos(FeaEntidades.InterFacturas.comprobante comp, string monedaComprobante, string tipoDeCambio)
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> listadeimpuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
			comp.resumen.impuestos = new FeaEntidades.InterFacturas.resumenImpuestos[listadeimpuestos.Count];
			for (int i = 0; i < listadeimpuestos.Count; i++)
			{
				if (!listadeimpuestos[i].codigo_impuesto.Equals(0))
				{
					comp.resumen.impuestos[i] = new FeaEntidades.InterFacturas.resumenImpuestos();
					comp.resumen.impuestos[i].codigo_impuesto = listadeimpuestos[i].codigo_impuesto;
					comp.resumen.impuestos[i].codigo_jurisdiccion = listadeimpuestos[i].codigo_jurisdiccion;
					comp.resumen.impuestos[i].codigo_jurisdiccionSpecified = listadeimpuestos[i].codigo_jurisdiccionSpecified;
					comp.resumen.impuestos[i].descripcion = listadeimpuestos[i].descripcion;
					comp.resumen.impuestos[i].porcentaje_impuesto = listadeimpuestos[i].porcentaje_impuesto;
					comp.resumen.impuestos[i].porcentaje_impuestoSpecified = listadeimpuestos[i].porcentaje_impuestoSpecified;
					if (monedaComprobante.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
					{
						comp.resumen.impuestos[i].importe_impuesto = listadeimpuestos[i].importe_impuesto;
					}
					else
					{
						comp.resumen.impuestos[i].importe_impuesto = Math.Round(listadeimpuestos[i].importe_impuesto * Convert.ToDouble(tipoDeCambio), 2);
						comp.resumen.impuestos[i].importe_impuesto_moneda_origen = listadeimpuestos[i].importe_impuesto;
						comp.resumen.impuestos[i].importe_impuesto_moneda_origenSpecified = true;
					}
				}
			}
		}
		protected string GetJurisdiccion(int codjurisdiccion)
		{
			if (codjurisdiccion != 0)
			{
				string aux = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista()
							.Find(
							delegate(FeaEntidades.CodigosProvincia.CodigoProvincia cp)
							{
								return cp.Codigo == Convert.ToInt16(codjurisdiccion);
							}
							).Descr;
				return aux;
			}
			else
			{
				return string.Empty;
			}
		}
		protected string GetAlicuota(double alic)
		{
            return Convert.ToString(alic);
		}

		internal void AgregarImpuestosIVA(System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas)
		{
            //System.Collections.Generic.List<FeaEntidades.IVA.IVA> listaIVA = FeaEntidades.IVA.IVA.ListaMinimaSinCero();
            System.Collections.Generic.List<FeaEntidades.IVA.IVA> listaIVA = FeaEntidades.IVA.IVA.ListaMinima();
			double[] impivas = new double[listaIVA.Count];
            bool[] impivasinformados = new bool[listaIVA.Count];
            for (int i = 0; i < listadelineas.Count; i++)
            {
                if (listadelineas[i].alicuota_ivaSpecified)
                {
                    int k = listaIVA.FindIndex(delegate(FeaEntidades.IVA.IVA e)
                    {
                        return e.Codigo == listadelineas[i].alicuota_iva;
                    });
                    if (k >= 0)
                    {
                        if (listadelineas[i].indicacion_exento_gravado == "G" && !listadelineas[i].alicuota_iva.Equals(99))
                        {
                            double imptot = listadelineas[i].importe_total_articulo;
                            System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.IdTipoPuntoVta == "RG2904" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                            });
                            if (listaPV.Count != 0)
                            {
                                try
                                {
                                    imptot -= listadelineas[i].importe_iva;
                                }
                                catch { }
                            }
                            impivas[k] += imptot * listadelineas[i].alicuota_iva / 100; //listadelineas[i].importe_iva;
                            impivasinformados[k] = true;
                        }
                    }
                }
            }
			for (int j = 0; j<impivas.Length; j++)
			{
                if (impivasinformados[j])
                {
                    impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
                    FeaEntidades.InterFacturas.resumenImpuestos imp = new FeaEntidades.InterFacturas.resumenImpuestos();
                    FeaEntidades.CodigosImpuesto.IVA iva = new FeaEntidades.CodigosImpuesto.IVA();
                    imp.codigo_impuesto = iva.Codigo;
                    imp.importe_impuesto = Math.Round(impivas[j], 2);
                    imp.porcentaje_impuestoSpecified = true;
                    //imp.porcentaje_impuesto = FeaEntidades.IVA.IVA.ListaMinimaSinCero()[j].Codigo;
                    imp.porcentaje_impuesto = FeaEntidades.IVA.IVA.ListaMinima()[j].Codigo;
                    imp.descripcion = iva.Descr;
                    EliminarFilaAutomatica();
                    impuestos.Add(imp);
                }
			}
			impuestosGridView.DataSource = impuestos;
			impuestosGridView.DataBind();
			ViewState["impuestos"] = impuestos;
			BindearDropDownLists();
		}

		internal void Actualizar(System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> i)
		{
			impuestosGridView.DataSource = i;
			impuestosGridView.DataBind();
			ViewState["impuestos"] = i;
			BindearDropDownLists();
		}
	}
}
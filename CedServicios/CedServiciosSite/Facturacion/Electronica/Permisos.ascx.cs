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
	public partial class Permisos : System.Web.UI.UserControl
	{
		System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos> permisos;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				ResetearGrillas();
			}
		}

		public void BindearDropDownLists()
		{
			if (permisosGridView.FooterRow!=null)
			{
				((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).DataValueField = "Codigo";
				((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).DataTextField = "Descr";
				((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).DataSource = FeaEntidades.DestinosPais.DestinoPais.ListaSinInformar();
				((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).DataBind();
			}
		}

		protected void permisosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>)ViewState["permisos"]);
				FeaEntidades.InterFacturas.permisos r = refs[e.RowIndex];
				refs.Remove(r);
				if (refs.Count.Equals(0))
				{
					FeaEntidades.InterFacturas.permisos nuevo = new FeaEntidades.InterFacturas.permisos();
					refs.Add(nuevo);
				}
				permisosGridView.EditIndex = -1;
				permisosGridView.DataSource = ViewState["permisos"];
				permisosGridView.DataBind();
				BindearDropDownLists();
			}
			catch
			{
			}
		}

		protected void permisosGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			permisosGridView.EditIndex = -1;
			permisosGridView.DataSource = ViewState["permisos"];
			permisosGridView.DataBind();
			BindearDropDownLists();
		}

		protected void permisosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName.Equals("Addpermisos"))
			{
				try
				{
					FeaEntidades.InterFacturas.permisos r = new FeaEntidades.InterFacturas.permisos();
					string auxCodRef = ((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).SelectedValue.ToString();
					string auxDescrCodRef = ((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).SelectedItem.Text;
					if (!auxCodRef.Equals("0"))
					{
						r.destino_mercaderia = Convert.ToInt32(auxCodRef);
						r.descripcion_destino_mercaderia = auxDescrCodRef;
					}
					else
					{
						throw new Exception("Permiso no agregado porque el destino de mercadería no puede estar vacío");
					}
					string auxDatoRef = ((TextBox)permisosGridView.FooterRow.FindControl("txtdato_de_permiso")).Text;
					r.id_permiso = auxDatoRef;
					((System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>)ViewState["permisos"]).Add(r);
					//Me fijo si elimino la fila automática
					System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>)ViewState["permisos"]);
					if (refs[0].destino_mercaderia.Equals(0))
					{
						((System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>)ViewState["permisos"]).Remove(refs[0]);
					}

					//Saco de edición la fila que estén modificando
					if (!permisosGridView.EditIndex.Equals(-1))
					{
						permisosGridView.EditIndex = -1;
					}

					permisosGridView.DataSource = ViewState["permisos"];
					permisosGridView.DataBind();
					BindearDropDownLists();
				}
				catch (Exception ex)
				{
					ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
				}
			}
		}

		protected void permisosGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(e.Exception.Message), false);
				e.ExceptionHandled = true;
			}
		}

		protected void permisosGridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			permisosGridView.EditIndex = e.NewEditIndex;

			permisosGridView.DataSource = ViewState["permisos"];
			permisosGridView.DataBind();
			BindearDropDownLists();

			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_permisoEdit")).DataValueField = "Codigo";
			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_permisoEdit")).DataTextField = "Descr";
			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_permisoEdit")).DataSource = FeaEntidades.DestinosPais.DestinoPais.ListaSinInformar();
			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_permisoEdit")).DataBind();

			try
			{
				ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_permisoEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>)ViewState["permisos"])[e.NewEditIndex].destino_mercaderia.ToString());
				li.Selected = true;
			}
			catch
			{
			}
		}

		protected void permisosGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(e.Exception.Message), false);
				e.ExceptionHandled = true;
			}
		}

		protected void permisosGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>)ViewState["permisos"]);
				FeaEntidades.InterFacturas.permisos r = refs[e.RowIndex];
				string auxCodRef = ((DropDownList)permisosGridView.Rows[e.RowIndex].FindControl("ddlcodigo_de_permisoEdit")).SelectedValue.ToString();
				string auxDescrCodRef = ((DropDownList)permisosGridView.Rows[e.RowIndex].FindControl("ddlcodigo_de_permisoEdit")).SelectedItem.Text;
				if (!auxCodRef.Equals("0"))
				{
					r.destino_mercaderia = Convert.ToInt32(auxCodRef);
					r.descripcion_destino_mercaderia = auxDescrCodRef;
				}
				else
				{
					throw new Exception("Permiso no actualizado porque el destino de mercadería no puede estar vacío");
				}
				string auxDatoRef = ((TextBox)permisosGridView.Rows[e.RowIndex].FindControl("txtdato_de_permiso")).Text;
				r.id_permiso = auxDatoRef;
				permisosGridView.EditIndex = -1;
				permisosGridView.DataSource = ViewState["permisos"];
				permisosGridView.DataBind();
				BindearDropDownLists();
			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
			}
		}
		public bool HayPermisos
		{
			get
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>)ViewState["permisos"]);
				if (refs[0].destino_mercaderia.Equals(0))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}
		public System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos> PermisosExportacion
		{
			get
			{
				System.Collections.Generic.List <FeaEntidades.InterFacturas.permisos> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>)ViewState["permisos"]);
				return refs;
			}
		}
		public void CompletarPermisos(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			//Permisos de exportación
			permisos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>();
            if (lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion != null && lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permisos != null)
			{
				foreach (FeaEntidades.InterFacturas.permisos r in lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permisos)
				{
					//descripcioncodigo_de_permiso ( XmlIgnoreAttribute )
					//Se busca la descripción a través del código.
					try
					{
						if (r != null)
						{
							string descrcodigo = ((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).SelectedItem.Text;
							((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).SelectedValue = r.destino_mercaderia.ToString();
							descrcodigo = ((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).SelectedItem.Text;
							r.descripcion_destino_mercaderia = descrcodigo;
							permisos.Add(r);
						}
					}
					catch
					//Referencia no valida
					{
					}
				}
			}
			if (permisos.Count.Equals(0))
			{
				permisos.Add(new FeaEntidades.InterFacturas.permisos());
			}
			permisosGridView.DataSource = permisos;
			permisosGridView.DataBind();
			ViewState["permisos"] = permisos;
		}
		public void ResetearGrillas()
		{
			permisos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>();
			FeaEntidades.InterFacturas.permisos permiso = new FeaEntidades.InterFacturas.permisos();
			permisos.Add(permiso);
			permisosGridView.DataSource = permisos;
			ViewState["permisos"] = permisos;
			DataBind();

			BindearDropDownLists();
		}
	}
}
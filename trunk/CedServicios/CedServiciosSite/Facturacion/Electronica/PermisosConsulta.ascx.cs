using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class PermisosConsulta : System.Web.UI.UserControl
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
            if (permisosGridView.FooterRow != null)
            {
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
                System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.permisos>)ViewState["permisos"]);
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
                            //string descrcodigo = ((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).SelectedItem.Text;
                            //((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).SelectedValue = r.destino_mercaderia.ToString();
                            //descrcodigo = ((DropDownList)permisosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).SelectedItem.Text;
                            //r.descripcion_destino_mercaderia = descrcodigo;
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
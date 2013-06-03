using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class DescuentosConsulta : System.Web.UI.UserControl
    {
        System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> descuentos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ResetearGrillas();
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
                //((DropDownList)descuentosGridView.FooterRow.FindControl("ddlalicuota_iva")).DataValueField = "Codigo";
                //((DropDownList)descuentosGridView.FooterRow.FindControl("ddlalicuota_iva")).DataTextField = "Descr";
                //((DropDownList)descuentosGridView.FooterRow.FindControl("ddlalicuota_iva")).DataSource = FeaEntidades.IVA.IVA.Lista();
                //((DropDownList)descuentosGridView.FooterRow.FindControl("ddlalicuota_iva")).DataBind();

                //((DropDownList)descuentosGridView.FooterRow.FindControl("ddlindicacion")).DataValueField = "Codigo";
                //((DropDownList)descuentosGridView.FooterRow.FindControl("ddlindicacion")).DataTextField = "Descr";
                //((DropDownList)descuentosGridView.FooterRow.FindControl("ddlindicacion")).DataSource = FeaEntidades.Indicacion.Indicacion.Lista();
                //((DropDownList)descuentosGridView.FooterRow.FindControl("ddlindicacion")).DataBind();
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
    }
}
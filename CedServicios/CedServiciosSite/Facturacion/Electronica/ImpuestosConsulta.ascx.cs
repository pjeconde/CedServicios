using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class ImpuestosConsulta : System.Web.UI.UserControl
    {
        System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //ResetearGrillas();
            }
        }
        public void BindearDropDownLists()
        {
            //((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataValueField = "Codigo";
            //((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataTextField = "Descr";
            //((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataSource = FeaEntidades.CodigosImpuesto.CodigoImpuesto.Lista();
            //((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataBind();

            //((DropDownList)impuestosGridView.FooterRow.FindControl("ddljurisdiccion")).DataValueField = "Codigo";
            //((DropDownList)impuestosGridView.FooterRow.FindControl("ddljurisdiccion")).DataTextField = "Descr";
            //((DropDownList)impuestosGridView.FooterRow.FindControl("ddljurisdiccion")).DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
            //((DropDownList)impuestosGridView.FooterRow.FindControl("ddljurisdiccion")).DataBind();
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

        private void EliminarFilaAutomatica()
        {
            System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
            FeaEntidades.InterFacturas.resumenImpuestos impuestoInicial = impuestos[0];
            if (impuestoInicial.codigo_impuesto == 0)
            {
                ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]).Remove(impuestoInicial);
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
            System.Collections.Generic.List<FeaEntidades.IVA.IVA> listaIVA = FeaEntidades.IVA.IVA.ListaMinimaSinCero();
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
                        impivas[k] += listadelineas[i].importe_iva;
                        impivasinformados[k] = true;
                    }
                }
            }
            for (int j = 0; j < impivas.Length; j++)
            {
                if (impivasinformados[j])
                {
                    impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
                    FeaEntidades.InterFacturas.resumenImpuestos imp = new FeaEntidades.InterFacturas.resumenImpuestos();
                    FeaEntidades.CodigosImpuesto.IVA iva = new FeaEntidades.CodigosImpuesto.IVA();
                    imp.codigo_impuesto = iva.Codigo;
                    imp.importe_impuesto = Math.Round(impivas[j], 2);
                    imp.porcentaje_impuestoSpecified = true;
                    imp.porcentaje_impuesto = FeaEntidades.IVA.IVA.ListaMinimaSinCero()[j].Codigo;
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
    }
}
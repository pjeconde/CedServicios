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
    public partial class ImpuestosCTConsulta : System.Web.UI.UserControl
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

		public void Completar(FeaEntidades.Turismo.comprobante Comprobante)
		{
			impuestos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>();
			if (Comprobante.resumen.impuestos != null)
			{
				foreach (FeaEntidades.InterFacturas.resumenImpuestos imp in Comprobante.resumen.impuestos)
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
		public System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> Lista
		{
			get
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
				return refs;
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
		public void GenerarImpuestos(FeaEntidades.Turismo.comprobante comp, string monedaComprobante, string tipoDeCambio)
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

		internal void Actualizar(System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> i)
		{
			impuestosGridView.DataSource = i;
			impuestosGridView.DataBind();
			ViewState["impuestos"] = i;
			BindearDropDownLists();
		}
	}
}
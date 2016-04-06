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
using System.Collections.Generic;

namespace CedServicios.Site.Facturacion.Electronica
{
	public partial class ReferenciasConsulta : System.Web.UI.UserControl
	{
		System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> referencias;
        string puntoDeVenta;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				//ResetearGrillas();
			}
            puntoDeVenta = Convert.ToString(ViewState["puntoDeVenta"]);
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
        public List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> ListaReferencias
        {
            get
            {
                List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
                return refs;
            }
        }
		public void CompletarReferencias(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			//Permisos de exportación
			referencias = new List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
            if (lc.comprobante[0].cabecera.informacion_comprobante != null && lc.comprobante[0].cabecera.informacion_comprobante.referencias != null)
			{
				foreach (FeaEntidades.InterFacturas.informacion_comprobanteReferencias r in lc.comprobante[0].cabecera.informacion_comprobante.referencias)
				{
					//descripcioncodigo_de_referencia ( XmlIgnoreAttribute )
					//Se busca la descripción a través del código.
					try
					{
						if (r != null)
                        {
                            List<FeaEntidades.CodigosReferencia.CodigoReferencia> listaCR = new List<FeaEntidades.CodigosReferencia.CodigoReferencia>();
                            List<FeaEntidades.CodigosReferencia.Exportaciones.Exportacion> listaCRExpo = new List<FeaEntidades.CodigosReferencia.Exportaciones.Exportacion>();
                            string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.Nro == Convert.ToInt32(puntoDeVenta);
                            }).IdTipoPuntoVta;
                            switch (idtipo)
                            {
                                case "Comun":
                                case "RG2904":
                                case "BonoFiscal":
                                    listaCR = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                                    r.descripcioncodigo_de_referencia = listaCR.Find(delegate(FeaEntidades.CodigosReferencia.CodigoReferencia cr)
                                    {
                                        return cr.Codigo == r.codigo_de_referencia.ToString();
                                    }).Descr;
                                    break;
                                case "Exportacion":
                                    listaCRExpo = FeaEntidades.CodigosReferencia.Exportaciones.Exportacion.Lista();
                                    r.descripcioncodigo_de_referencia = listaCRExpo.Find(delegate(FeaEntidades.CodigosReferencia.Exportaciones.Exportacion cr)
                                    {
                                        return cr.Codigo == r.codigo_de_referencia.ToString();
                                    }).Descr;
                                    break;
                                default:
                                    throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
                            }
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

        public void CompletarWS(org.dyndns.cedweb.consulta.ConsultarResult lc)
        {
            if (lc.comprobante[0].cabecera.informacion_comprobante.referencias != null)
            {
                referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
                foreach (org.dyndns.cedweb.consulta.ConsultarResultComprobanteCabeceraInformacion_comprobanteReferencias r in lc.comprobante[0].cabecera.informacion_comprobante.referencias)
                {
                    FeaEntidades.InterFacturas.informacion_comprobanteReferencias referencia = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
                    referencia.codigo_de_referencia = r.codigo_de_referencia;
                    referencia.dato_de_referencia = r.dato_de_referencia;

                    List<FeaEntidades.CodigosReferencia.CodigoReferencia> listaCR = new List<FeaEntidades.CodigosReferencia.CodigoReferencia>();
                    List<FeaEntidades.CodigosReferencia.Exportaciones.Exportacion> listaCRExpo = new List<FeaEntidades.CodigosReferencia.Exportaciones.Exportacion>();
                    string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.Nro == Convert.ToInt32(puntoDeVenta);
                    }).IdTipoPuntoVta;
                    switch (idtipo)
                    {
                        case "Comun":
                        case "RG2904":
                        case "BonoFiscal":
                            listaCR = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                            referencia.descripcioncodigo_de_referencia = listaCR.Find(delegate(FeaEntidades.CodigosReferencia.CodigoReferencia cr)
                            {
                                return cr.Codigo == r.codigo_de_referencia.ToString();
                            }).Descr;
                            break;
                        case "Exportacion":
                            listaCRExpo = FeaEntidades.CodigosReferencia.Exportaciones.Exportacion.Lista();
                            referencia.descripcioncodigo_de_referencia = listaCRExpo.Find(delegate(FeaEntidades.CodigosReferencia.Exportaciones.Exportacion cr)
                            {
                                return cr.Codigo == r.codigo_de_referencia.ToString();
                            }).Descr;
                            break;
                        default:
                            throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
                    }
                    referencias.Add(referencia);
                }
                if (referencias.Count.Equals(0))
                {
                    referencias.Add(new FeaEntidades.InterFacturas.informacion_comprobanteReferencias());
                }
                referenciasGridView.DataSource = referencias;
                referenciasGridView.DataBind();
                ViewState["referencias"] = referencias;
            }
        }

		public void ResetearGrillas()
		{
            referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
            FeaEntidades.InterFacturas.informacion_comprobanteReferencias referencia = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
            referencias.Add(referencia);
            referenciasGridView.DataSource = referencias;
            ViewState["referencias"] = referencias;
			DataBind();

			BindearDropDownLists();
		}
	}
}
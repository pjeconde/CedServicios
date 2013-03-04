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
	public partial class Detalle : System.Web.UI.UserControl
	{
		System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas;
		private System.Globalization.CultureInfo cedeiraCultura;
		string puntoDeVenta;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				ResetearGrillas();
			}
			else
			{
				puntoDeVenta = Convert.ToString(ViewState["puntoDeVenta"]);
			}
			
		}
		public void ResetearGrillas()
		{
			lineas = new System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>();
			FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
			lineas.Add(linea);
			detalleGridView.DataSource = lineas;
			ViewState["lineas"] = lineas;
			detalleGridView.DataBind();

			BindearDropDownLists();
		}
		public System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> Lineas
		{
			get
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]);
				return refs;
			}
		}
		public string PuntoDeVenta
		{
			set
			{
				ViewState["puntoDeVenta"] = value;
			}
		}
		public void CompletarDetallesWS(org.dyndns.cedweb.consulta.ConsultarResult lc)
		{
			lineas = new System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>();
			foreach (org.dyndns.cedweb.consulta.ConsultarResultComprobanteDetalleLinea l in lc.comprobante[0].detalle.linea)
			{
				FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
				//Compatibilidad con archivos xml viejos. Verificar si la descripcion está en Hexa.
				RN.Comprobante crn = new RN.Comprobante();
				if (l.descripcion.Substring(0, 1) == "%")
				{
					linea.descripcion = crn.HexToString(l.descripcion).Replace("<br>", System.Environment.NewLine);
				}
				else
				{
					linea.descripcion = l.descripcion.Replace("<br>", System.Environment.NewLine);
				}
				if (l.alicuota_ivaSpecified)
				{
					linea.alicuota_iva = l.alicuota_iva;
				}
				else
				{
					linea.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
				}
				linea.alicuota_ivaSpecified = l.alicuota_ivaSpecified;
				linea.importe_ivaSpecified = l.importe_ivaSpecified;
				if (l.unidad != null)
				{
					linea.unidad = l.unidad;
				}
				else
				{
					linea.unidad = Convert.ToString(new FeaEntidades.CodigosUnidad.SinInformar().Codigo);
				}
				linea.cantidad = l.cantidad;
				linea.cantidadSpecified = l.cantidadSpecified;
				linea.codigo_producto_comprador = l.codigo_producto_comprador;
				linea.codigo_producto_vendedor = l.codigo_producto_vendedor;
				linea.indicacion_exento_gravado = l.indicacion_exento_gravado;

				if (l.importes_moneda_origen == null)
				{
					linea.importe_total_articulo = l.importe_total_articulo;
					linea.importe_iva = l.importe_iva;
					linea.precio_unitario = l.precio_unitario;
					linea.precio_unitarioSpecified = l.precio_unitarioSpecified;
				}
				else
				{
					linea.importe_total_articulo = l.importes_moneda_origen.importe_total_articulo;
					linea.importe_iva = l.importes_moneda_origen.importe_iva;
					linea.precio_unitario = l.importes_moneda_origen.precio_unitario;
					linea.precio_unitarioSpecified = l.importes_moneda_origen.precio_unitarioSpecified;
				}
				lineas.Add(linea);
			}
			detalleGridView.DataSource = lineas;
			detalleGridView.DataBind();
			BindearDropDownLists();
			ViewState["lineas"] = lineas;
		}
		public void CompletarDetalles(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			lineas = new System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>();
			foreach (FeaEntidades.InterFacturas.linea l in lc.comprobante[0].detalle.linea)
			{
				FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
				RN.Comprobante crn = new RN.Comprobante();
				//Compatibilidad con archivos xml viejos. Verificar si la descripcion está en Hexa.
				if (l.descripcion.Substring(0, 1) == "%")
				{
					linea.descripcion = crn.HexToString(l.descripcion).Replace("<br>", System.Environment.NewLine);
				}
				else
				{
					linea.descripcion = l.descripcion.Replace("<br>", System.Environment.NewLine);
				}
				if (l.alicuota_ivaSpecified)
				{
					linea.alicuota_iva = l.alicuota_iva;
				}
				else
				{
					linea.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
				}
				linea.alicuota_ivaSpecified = l.alicuota_ivaSpecified;
				linea.importe_ivaSpecified = l.importe_ivaSpecified;
				if (l.unidad != null)
				{
					linea.unidad = l.unidad;
				}
				else
				{
					linea.unidad = Convert.ToString(new FeaEntidades.CodigosUnidad.SinInformar().Codigo);
				}
				linea.cantidad = l.cantidad;
				linea.cantidadSpecified = l.cantidadSpecified;
				linea.codigo_producto_comprador = l.codigo_producto_comprador;
				linea.codigo_producto_vendedor = l.codigo_producto_vendedor;
				linea.indicacion_exento_gravado = l.indicacion_exento_gravado;

				if (l.importes_moneda_origen == null || l.importes_moneda_origen.importe_total_articulo.Equals(0))
				{
					linea.importe_total_articulo = l.importe_total_articulo;
					linea.importe_iva = l.importe_iva;
					linea.precio_unitario = l.precio_unitario;
					linea.precio_unitarioSpecified = l.precio_unitarioSpecified;
				}
				else
				{
					linea.importe_total_articulo = l.importes_moneda_origen.importe_total_articulo;
					linea.importe_iva = l.importes_moneda_origen.importe_iva;
					linea.precio_unitario = l.importes_moneda_origen.precio_unitario;
					linea.precio_unitarioSpecified = l.importes_moneda_origen.precio_unitarioSpecified;
				}
				lineas.Add(linea);
			}
			detalleGridView.DataSource = lineas;
			detalleGridView.DataBind();
			ViewState["lineas"] = lineas;

		}
        protected void detalleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddDetalle"))
            {
                try
                {
                    if (puntoDeVenta.Equals(string.Empty))
                    {
                        throw new Exception("Debe definir el punto de venta antes de ingresar un detalle");
                    }

                    cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);

                    FeaEntidades.InterFacturas.linea l = new FeaEntidades.InterFacturas.linea();

                    string auxDescr = ((TextBox)detalleGridView.FooterRow.FindControl("txtdescripcion")).Text;
                    if (!auxDescr.Equals(string.Empty))
                    {
                        l.descripcion = auxDescr;
                    }
                    else
                    {
                        throw new Exception("Detalle no agregado porque la descripción no puede estar vacía");
                    }
                    string auxTotal = ((TextBox)detalleGridView.FooterRow.FindControl("txtimporte_total_articulo")).Text;
                    if (auxTotal.Equals(string.Empty))
                    {
                        throw new Exception("Detalle no agregado porque el importe debe ser informado");
                    }
                    if (!auxTotal.Contains(","))
                    {
                        try
                        {
                            l.importe_total_articulo = Convert.ToDouble(auxTotal, cedeiraCultura);
                        }
                        catch
                        {
                            throw new Exception("Detalle no agregado porque el importe tiene más de un separador de decimales");
                        }
                    }
                    else
                    {
                        throw new Exception("Detalle no agregado porque el separador de decimales en el importe debe ser el punto");
                    }

                    string auxNull = ((TextBox)detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo")).Text;
                    if (!auxNull.Equals(string.Empty) && !auxNull.Equals("0"))
                    {
                        try
                        {
                            double auxImporteIVA = Convert.ToDouble(auxNull, cedeiraCultura);
                            l.importe_ivaSpecified = true;
                            l.importe_iva = auxImporteIVA;
                        }
                        catch
                        {
                            throw new Exception("Detalle no agregado porque el importe IVA tiene más de un separador de decimales");
                        }
                    }
                    else
                    {
                        l.importe_ivaSpecified = false;
                        l.importe_iva = 0;
                    }
                    double auxAliIVA = Convert.ToDouble(((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).SelectedValue);
                    string auxDescAliIVA = ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).SelectedItem.Text;
                    if (!auxDescAliIVA.Equals(string.Empty))
                    {
                        l.alicuota_ivaSpecified = true;
                        l.alicuota_iva = auxAliIVA;
                    }
                    else
                    {
                        //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
                        //{
                        if (!puntoDeVenta.Equals(string.Empty))
                        {
                            //OJO - Verifico si es BonoFiscal !!!
                            System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.FindAll(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                            });
                            if (listaPV.Count != 0)
                            {
                                throw new Exception("Detalle no agregado porque la alicuota iva es obligatoria para bono fiscal");
                            }
                            else
                            {
                                l.alicuota_ivaSpecified = false;
                                l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                            }
                        }
                        else
                        {
                            l.alicuota_ivaSpecified = false;
                            l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                        }
                        //}
                        //else
                        //{
                        //    l.alicuota_ivaSpecified = false;
                        //    l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                        //}
                    }

                    string auxUnidad = ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).SelectedItem.Value;
                    //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
                    //{
                    if (!puntoDeVenta.Equals(string.Empty))
                    {
                        //OJO - Verifico si es BonoFiscal !!!
                        System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.FindAll(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                        });
                        if (listaPV.Count != 0)
                        {
                            if (auxUnidad.Equals(string.Empty) || auxUnidad.Equals("0"))
                            {
                                throw new Exception("Detalle no agregado porque la unidad es obligatoria para bono fiscal");
                            }
                            else
                            {
                                l.unidad = auxUnidad;
                            }
                        }
                        else
                        {
                            l.unidad = auxUnidad;
                        }
                    }
                    else
                    {
                        l.unidad = auxUnidad;
                    }
                    //}
                    //else
                    //{
                    //    l.unidad = auxUnidad;
                    //}

                    string auxCantidad = ((TextBox)detalleGridView.FooterRow.FindControl("txtcantidad")).Text;
                    if (!auxCantidad.Contains(","))
                    {
                        if (!auxCantidad.Equals(string.Empty) && !auxCantidad.Equals("0"))
                        {
                            try
                            {
                                l.cantidad = Convert.ToDouble(auxCantidad, cedeiraCultura);
                                l.cantidadSpecified = true;
                            }
                            catch
                            {
                                throw new Exception("Detalle no agregado porque la cantidad tiene más de un separador de decimales");
                            }
                        }
                        else
                        {
                            //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
                            //{
                            if (!puntoDeVenta.Equals(string.Empty))
                            {
                                //OJO - Verifico si es BonoFiscal !!!
                                System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.FindAll(delegate(Entidades.PuntoVta pv)
                                {
                                    return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                                });
                                if (listaPV.Count != 0)
                                {
                                    throw new Exception("Detalle no agregado porque la cantidad es obligatoria para bono fiscal");
                                }
                                else
                                {
                                    l.cantidadSpecified = false;
                                    l.cantidad = 0;
                                }
                            }
                            else
                            {
                                l.cantidadSpecified = false;
                                l.cantidad = 0;
                            }
                            //}
                            //else
                            //{
                            //    l.cantidadSpecified = false;
                            //    l.cantidad = 0;
                            //}
                        }
                    }
                    else
                    {
                        throw new Exception("Detalle no agregado porque el separador de decimales debe ser el punto");
                    }

                    ValidarCodigoProductoComprador(l, ((TextBox)detalleGridView.FooterRow.FindControl("txtcpcomprador")).Text);

                    string auxcpvendedor = ((TextBox)detalleGridView.FooterRow.FindControl("txtcpvendedor")).Text;
                    l.codigo_producto_vendedor = auxcpvendedor;

                    string auxindicacion_exento_gravado = ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).SelectedItem.Value;
                    //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
                    //{
                    if (!puntoDeVenta.Equals(string.Empty))
                    {
                        //OJO - Verifico si es BonoFiscal !!!
                        System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.FindAll(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                        });
                        if (listaPV.Count != 0)
                        {
                            if (auxindicacion_exento_gravado.Equals(string.Empty))
                            {
                                throw new Exception("Detalle no agregado porque la indicacion exento gravado es obligatoria para bono fiscal");
                            }
                            else
                            {
                                l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                            }
                        }
                        else
                        {
                            l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                        }
                        //}
                        //else
                        //{
                        //    l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                        //}
                    }
                    else
                    {
                        l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                    }

                    string auxprecio_unitario = ((TextBox)detalleGridView.FooterRow.FindControl("txtprecio_unitario")).Text;
                    if (!auxprecio_unitario.Equals(string.Empty) && !auxprecio_unitario.Equals("0"))
                    {
                        try
                        {
                            double auxPU = Convert.ToDouble(auxprecio_unitario, cedeiraCultura);
                            l.precio_unitario = auxPU;
                            l.precio_unitarioSpecified = true;
                        }
                        catch
                        {
                            throw new Exception("Detalle no agregado porque el precio unitario tiene más de un separador de decimales");
                        }
                    }
                    else
                    {
                        //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
                        //{
                        if (!puntoDeVenta.Equals(string.Empty))
                        {
                            //OJO - Verifico si es BonoFiscal !!!
                            System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.FindAll(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                            });
                            if (listaPV.Count != 0)
                            {
                                throw new Exception("Detalle no agregado porque el precio unitario es obligatorio para bono fiscal");
                            }
                            else
                            {
                                l.precio_unitario = 0;
                                l.precio_unitarioSpecified = false;
                            }
                        }
                        else
                        {
                            l.precio_unitario = 0;
                            l.precio_unitarioSpecified = false;
                        }
                        //}
                        //else
                        //{
                        //    l.precio_unitario = 0;
                        //    l.precio_unitarioSpecified = false;
                        //}
                    }

                    ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]).Add(l);


                    //Me fijo si elimino la fila automática
                    System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]);
                    FeaEntidades.InterFacturas.linea lineaInicial = lineas[0];
                    if (lineaInicial.descripcion == null)
                    {
                        ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]).Remove(lineaInicial);
                    }

                    //Saco de edición la fila que estén modificando
                    if (!detalleGridView.EditIndex.Equals(-1))
                    {
                        detalleGridView.EditIndex = -1;
                    }

                    detalleGridView.DataSource = ViewState["lineas"];
                    detalleGridView.DataBind();
                    BindearDropDownLists();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
                }
            }
        }

        protected void detalleGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                if (puntoDeVenta.Equals(string.Empty))
                {
                    throw new Exception("Debe definir el punto de venta antes de editar un detalle");
                }

                cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);

                System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]);

                FeaEntidades.InterFacturas.linea l = lineas[e.RowIndex];
                string auxDescr = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtdescripcion")).Text;
                if (!auxDescr.Equals(string.Empty))
                {
                    l.descripcion = auxDescr;
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque la descripción no puede estar vacía");
                }
                string auxTotal = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtimporte_total_articulo")).Text;
                if (auxTotal.Equals(string.Empty))
                {
                    throw new Exception("Detalle no actualizado porque el importe debe ser informado");
                }
                if (!auxTotal.Contains(","))
                {
                    try
                    {
                        l.importe_total_articulo = Convert.ToDouble(auxTotal, cedeiraCultura);
                    }
                    catch
                    {
                        throw new Exception("Detalle no actualizado porque el importe tiene más de un separador de decimales");
                    }
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }

                string auxNull = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtimporte_alicuota_articulo")).Text;
                if (!auxNull.Equals(string.Empty) && !auxNull.Equals("0"))
                {
                    try
                    {
                        double auxImporteIVA = Convert.ToDouble(auxNull);
                        l.importe_ivaSpecified = true;
                        l.importe_iva = auxImporteIVA;
                    }
                    catch
                    {
                        throw new Exception("Detalle no actualizado porque el importe IVA tiene más de un separador de decimales");
                    }
                }
                else
                {
                    l.importe_ivaSpecified = false;
                    l.importe_iva = 0;
                }

                double auxAliIVA = Convert.ToDouble(((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlalicuota_articuloEdit")).SelectedValue);
                string auxDescAliIVA = ((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlalicuota_articuloEdit")).SelectedItem.Text;
                if (!auxDescAliIVA.Equals(string.Empty))
                {
                    l.alicuota_ivaSpecified = true;
                    l.alicuota_iva = auxAliIVA;
                }
                else
                {
                    //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
                    //{
                    if (!puntoDeVenta.Equals(string.Empty))
                    {
                        //OJO - Verifico si es BonoFiscal !!!
                        System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.FindAll(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                        });
                        if (listaPV.Count != 0)
                        {
                            throw new Exception("Detalle no actualizado porque la alicuota iva es obligatoria para bono fiscal");
                        }
                        else
                        {
                            l.alicuota_ivaSpecified = false;
                            l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                        }
                    }
                    else
                    {
                        l.alicuota_ivaSpecified = false;
                        l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                    }
                    //}
                    //else
                    //{
                    //    l.alicuota_ivaSpecified = false;
                    //    l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                    //}
                }
                string auxUnidad = ((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlunidadEdit")).SelectedItem.Value;
                //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
                //{
                if (!puntoDeVenta.Equals(string.Empty))
                {
                    //OJO - Verifico si es BonoFiscal !!!
                    System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.FindAll(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                    });
                    if (listaPV.Count != 0)
                    {
                        if (auxUnidad.Equals(string.Empty) || auxUnidad.Equals("0"))
                        {
                            throw new Exception("Detalle no actualizado porque la unidad es obligatoria para bono fiscal");
                        }
                        else
                        {
                            l.unidad = auxUnidad;
                        }
                    }
                    else
                    {
                        l.unidad = auxUnidad;
                    }
                }
                else
                {
                    l.unidad = auxUnidad;
                }
                //}
                //else
                //{
                //    l.unidad = auxUnidad;
                //}

                string auxCantidad = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtcantidad")).Text;
                if (!auxCantidad.Contains(","))
                {
                    if (!auxCantidad.Equals(string.Empty) && !auxCantidad.Equals("0"))
                    {
                        try
                        {
                            l.cantidad = Convert.ToDouble(auxCantidad, cedeiraCultura);
                            l.cantidadSpecified = true;
                        }
                        catch
                        {
                            throw new Exception("Detalle no actualizado porque la cantidad tiene más de un separador de decimales");
                        }
                    }
                    else
                    {
                        //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
                        //{
                        if (!puntoDeVenta.Equals(string.Empty))
                        {
                            //OJO - Verifico si es BonoFiscal !!!
                            System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.FindAll(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                            });
                            if (listaPV.Count != 0)
                            {
                                throw new Exception("Detalle no actualizado porque la cantidad es obligatoria para bono fiscal");
                            }
                            else
                            {
                                l.cantidadSpecified = false;
                                l.cantidad = 0;
                            }
                        }
                        else
                        {
                            l.cantidadSpecified = false;
                            l.cantidad = 0;
                        }
                        //}
                        //else
                        //{
                        //    l.cantidadSpecified = false;
                        //    l.cantidad = 0;
                        //}
                    }
                }
                else
                {
                    throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
                }

                ValidarCodigoProductoComprador(l, ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtcpcomprador")).Text);

                string auxcodigo_producto_vendedor = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtcpvendedor")).Text;
                l.codigo_producto_vendedor = auxcodigo_producto_vendedor;

                string auxindicacion_exento_gravado = ((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlindicacion_exento_gravadoEdit")).SelectedItem.Value;
                //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
                //{
                if (!puntoDeVenta.Equals(string.Empty))
                {
                    //OJO - Verifico si es BonoFiscal !!!
                    System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.FindAll(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                    });
                    if (listaPV.Count != 0)
                    {
                        if (auxindicacion_exento_gravado.Equals(string.Empty))
                        {
                            throw new Exception("Detalle no actualizado porque la indicacion exento gravado es obligatoria para bono fiscal");
                        }
                        else
                        {
                            l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                        }
                    }
                    else
                    {
                        l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                    }
                }
                else
                {
                    l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                }
                //}
                //else
                //{
                //    l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                //}

                string auxprecio_unitario = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtprecio_unitario")).Text;
                if (!auxprecio_unitario.Equals(string.Empty) && !auxprecio_unitario.Equals("0"))
                {
                    try
                    {
                        double auxPU = Convert.ToDouble(auxprecio_unitario);
                        l.precio_unitario = auxPU;
                        l.precio_unitarioSpecified = true;
                    }
                    catch
                    {
                        throw new Exception("Detalle no actualizado porque el precio unitario tiene más de un separador de decimales");
                    }
                }
                else
                {
                    //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
                    //{
                    if (!puntoDeVenta.Equals(string.Empty))
                    {
                        //OJO - Verifico si es BonoFiscal !!!
                        System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.FindAll(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                        });
                        if (listaPV.Count != 0)
                        {
                            throw new Exception("Detalle no actualizado porque el precio unitario es obligatorio para bono fiscal");
                        }
                        else
                        {
                            l.precio_unitario = 0;
                            l.precio_unitarioSpecified = false;
                        }
                    }
                    else
                    {
                        l.precio_unitario = 0;
                        l.precio_unitarioSpecified = false;
                    }
                    //}
                    //else
                    //{
                    //    l.precio_unitario = 0;
                    //    l.precio_unitarioSpecified = false;
                    //}
                }
                detalleGridView.EditIndex = -1;
                detalleGridView.DataSource = lineas;
                detalleGridView.DataBind();
                BindearDropDownLists();
                ViewState["lineas"] = lineas;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
            }
        }
        protected void detalleGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
                e.ExceptionHandled = true;
            }
        }
        protected void detalleGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            detalleGridView.EditIndex = e.NewEditIndex;
            detalleGridView.DataSource = ViewState["lineas"];
            detalleGridView.DataBind();
            BindearDropDownLists();

            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articuloEdit")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articuloEdit")).DataTextField = "Descr";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articuloEdit")).DataSource = FeaEntidades.IVA.IVA.Lista();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articuloEdit")).DataBind();
            try
            {
                ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articuloEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"])[e.NewEditIndex].alicuota_iva.ToString());
                li.Selected = true;
            }
            catch
            {
            }

            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidadEdit")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidadEdit")).DataTextField = "Descr";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidadEdit")).DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidadEdit")).DataBind();
            try
            {
                ListItem liUnidad = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidadEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"])[e.NewEditIndex].unidad.ToString());
                liUnidad.Selected = true;
            }
            catch
            {
            }

            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataTextField = "Descr";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.ListaDetalle();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataBind();
            try
            {
                ListItem liIndExento = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"])[e.NewEditIndex].indicacion_exento_gravado.ToString());
                liIndExento.Selected = true;
            }
            catch
            {
            }
        }

		protected void detalleGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			detalleGridView.EditIndex = -1;
			detalleGridView.DataSource = ViewState["lineas"];
			detalleGridView.DataBind();
			BindearDropDownLists();
		}

		public void BindearDropDownLists()
		{
			if (detalleGridView.FooterRow != null)
			{
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataValueField = "Codigo";
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataTextField = "Descr";
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataSource = FeaEntidades.IVA.IVA.Lista();
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataBind();

				((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataValueField = "Codigo";
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataTextField = "Descr";
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataBind();
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).AppendDataBoundItems = false;

				((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataValueField = "Codigo";
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataTextField = "Descr";
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.ListaDetalle();
				((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataBind();
			}
			if (!detalleGridView.EditIndex.Equals(-1))
			{
				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articuloEdit")).DataValueField = "Codigo";
				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articuloEdit")).DataTextField = "Descr";
				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articuloEdit")).DataSource = FeaEntidades.IVA.IVA.Lista();
				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articuloEdit")).DataBind();

				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidadEdit")).DataValueField = "Codigo";
				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidadEdit")).DataTextField = "Descr";
				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidadEdit")).DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidadEdit")).DataBind();

				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataValueField = "Codigo";
				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataTextField = "Descr";
				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.ListaDetalle();
				((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataBind();
			}
		}
		protected void detalleGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]);
				FeaEntidades.InterFacturas.linea l = lineas[e.RowIndex];
				lineas.Remove(l);

				if (lineas.Count.Equals(0))
				{
					FeaEntidades.InterFacturas.linea nueva = new FeaEntidades.InterFacturas.linea();
					lineas.Add(nueva);
				}

				detalleGridView.EditIndex = -1;

				detalleGridView.DataSource = ViewState["lineas"];
				detalleGridView.DataBind();
				BindearDropDownLists();
			}
			catch
			{
			}

		}
		protected void detalleGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
				e.ExceptionHandled = true;
			}
		}
        private void ValidarCodigoProductoComprador(FeaEntidades.InterFacturas.linea l, string auxcpcomprador)
        {
            //if (RN.Fun.EstaLogueadoUnUsuarioPremium((Entidades.Sesion)Session["Sesion"]))
            //{
            if (!puntoDeVenta.Equals(string.Empty))
            {
                int auxPV = Convert.ToInt32(puntoDeVenta);
                try
                {
                    string idtipo = ((Entidades.Sesion)Session["Sesion"]).PuntosVtaDeLaUN.Find(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.Nro == auxPV;
                    }).IdTipoPuntoVta;
                    switch (idtipo)
                    {
                        case "Comun":
                        case "Exportacion":
                            l.codigo_producto_comprador = auxcpcomprador;
                            break;
                        case "BonoFiscal":
                            if (auxcpcomprador.Equals(string.Empty))
                            {
                                throw new Exception("Detalle no válido porque el código producto comprador es obligatorio");
                            }
                            else
                            {
                                l.codigo_producto_comprador = auxcpcomprador;
                            }
                            break;
                    }
                }
                catch (System.NullReferenceException)
                {
                    l.codigo_producto_comprador = auxcpcomprador;
                }
            }
            else
            {
                l.codigo_producto_comprador = auxcpcomprador;
            }
            //}
            //else
            //{
            //    l.codigo_producto_comprador = auxcpcomprador;
            //}
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

		public void CalcularTotalesLineas(ref double totalGravado, ref double totalNoGravado, ref double totalIVA, ref double total_Operaciones_Exentas)
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"];
			for (int i = 0; i < listadelineas.Count; i++)
			{
                try
                {
                    if (listadelineas[i].descripcion == null)
                    {
                        throw new Exception("Debe informar al menos un artículo");
                    }
                    if (listadelineas[i].importe_iva != 0)
                    {
                        totalGravado += listadelineas[i].importe_total_articulo;
                    }
                    else if (listadelineas[i].indicacion_exento_gravado.Equals("E"))
                    {
                        total_Operaciones_Exentas += listadelineas[i].importe_total_articulo;
                    }
                    else
                    {
                        totalNoGravado += listadelineas[i].importe_total_articulo;
                    }
                }
                catch (NullReferenceException)
                {
                    totalNoGravado += listadelineas[i].importe_total_articulo;
                }
				totalIVA += listadelineas[i].importe_iva;
			}
		}

		public double CalcularTotalImporte()
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"];
			double total = 0;
			for (int i = 0; i < listadelineas.Count; i++)
			{
				if (listadelineas[i].descripcion == null)
				{
					break;
				}
				total += listadelineas[i].importe_total_articulo;
			}
			return total;
		}

		public FeaEntidades.InterFacturas.detalle GenerarDetalles(string MonedaComprobante, string TipoDeCambio, string TipoPtoVta, string TipoCbte)
		{
			FeaEntidades.InterFacturas.detalle det = new FeaEntidades.InterFacturas.detalle();
			System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"];
			for (int i = 0; i < listadelineas.Count; i++)
			{
				det.linea[i] = new FeaEntidades.InterFacturas.linea();
				det.linea[i].numeroLinea = i + 1;
				if (listadelineas[i].descripcion == null)
				{
					throw new Exception("Debe informar al menos un artículo");
				}
				RN.Comprobante c = new RN.Comprobante();
				string textoSinSaltoDeLinea = listadelineas[i].descripcion.Replace("\n", "<br>").Replace("\r",string.Empty);
				det.linea[i].descripcion = c.ConvertToHex(textoSinSaltoDeLinea);

				GenerarDetallesAlicuotaIVA(TipoPtoVta, TipoCbte, det, listadelineas, i);

				if (!listadelineas[i].unidad.Equals(Convert.ToString(new FeaEntidades.CodigosUnidad.SinInformar().Codigo)))
				{
					det.linea[i].unidad = listadelineas[i].unidad;
				}
				det.linea[i].cantidad = listadelineas[i].cantidad;
				det.linea[i].cantidadSpecified = listadelineas[i].cantidadSpecified;
				det.linea[i].codigo_producto_comprador = listadelineas[i].codigo_producto_comprador;
				det.linea[i].codigo_producto_vendedor = listadelineas[i].codigo_producto_vendedor;

				GenerarDetallesIndExGravado(TipoPtoVta, TipoCbte, det, listadelineas, i);

				if (MonedaComprobante.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
				{

					GenerarDetalleMonedaLocal(TipoCbte, det, listadelineas, i);
				}
				else
				{
					GenerarDetalleMonedaExtranjera(TipoDeCambio, TipoCbte, det, listadelineas, i);
				}
			}
			return det;
		}

		private static void GenerarDetalleMonedaExtranjera(string TipoDeCambio, string TipoCbte, FeaEntidades.InterFacturas.detalle det, System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas, int i)
		{
			det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
			switch (TipoCbte)
			{
				case "6":
				case "7":
				case "8":
				case "9":
				case "10":
				case "40":
				case "61":
				case "64":
					det.linea[i].importe_iva = 0;
					det.linea[i].importe_ivaSpecified = false;
					if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
					{
						det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * Convert.ToDouble(TipoDeCambio) * (1 + listadelineas[i].alicuota_iva / 100), 3);
					}
					else
					{
						det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * Convert.ToDouble(TipoDeCambio), 3);
					}
					det.linea[i].importe_total_articulo = Math.Round(((listadelineas[i].importe_total_articulo) + listadelineas[i].importe_iva) * Convert.ToDouble(TipoDeCambio), 2);
					break;
				default:
					det.linea[i].importe_iva = Math.Round(listadelineas[i].importe_iva * Convert.ToDouble(TipoDeCambio), 2);
					det.linea[i].importe_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
					det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * Convert.ToDouble(TipoDeCambio), 3);
					det.linea[i].importe_total_articulo = Math.Round(listadelineas[i].importe_total_articulo * Convert.ToDouble(TipoDeCambio), 2);
					break;
			}

			FeaEntidades.InterFacturas.lineaImportes_moneda_origen limo = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
			limo.importe_total_articuloSpecified = true;

			limo.precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;

			switch (TipoCbte)
			{
				case "6":
				case "7":
				case "8":
				case "9":
				case "10":
				case "40":
				case "61":
				case "64":
					limo.importe_ivaSpecified = false;
					limo.importe_iva = 0;
					if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
					{
						limo.precio_unitario = Math.Round(listadelineas[i].precio_unitario * (1 + listadelineas[i].alicuota_iva / 100), 3);
					}
					else
					{
						limo.precio_unitario = Math.Round(listadelineas[i].precio_unitario, 3);
					}
					limo.importe_total_articulo = Math.Round(listadelineas[i].importe_total_articulo + listadelineas[i].importe_iva, 2);
					break;
				default:
					limo.importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
					limo.importe_iva = listadelineas[i].importe_iva;
					limo.precio_unitario = listadelineas[i].precio_unitario;
					limo.importe_total_articulo = listadelineas[i].importe_total_articulo;
					break;
			}
			det.linea[i].importes_moneda_origen = limo;
		}

		private static void GenerarDetalleMonedaLocal(string TipoCbte, FeaEntidades.InterFacturas.detalle det, System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas, int i)
		{
			switch (TipoCbte)
			{
				case "6":
				case "7":
				case "8":
				case "9":
				case "10":
				case "40":
				case "61":
				case "64":
					if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
					{
						det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * (1 + listadelineas[i].alicuota_iva / 100), 3);
					}
					else
					{
						det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario, 3);
					}
					det.linea[i].importe_total_articulo = Math.Round(listadelineas[i].importe_total_articulo + listadelineas[i].importe_iva, 2);
					det.linea[i].importe_ivaSpecified = false;
					det.linea[i].importe_iva = 0;
					break;
				default:
					det.linea[i].precio_unitario = listadelineas[i].precio_unitario;
					det.linea[i].importe_total_articulo = listadelineas[i].importe_total_articulo;
					det.linea[i].importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
					det.linea[i].importe_iva = listadelineas[i].importe_iva;
					break;
			}
			det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
		}

		private static void GenerarDetallesIndExGravado(string TipoPtoVta, string TipoCbte, FeaEntidades.InterFacturas.detalle det, System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas, int i)
		{
			if (listadelineas[i].indicacion_exento_gravado != null)
			{
				if (!listadelineas[i].indicacion_exento_gravado.Equals(string.Empty))
				{
					if (!TipoPtoVta.Equals("Comun"))
					{
						det.linea[i].indicacion_exento_gravado = listadelineas[i].indicacion_exento_gravado;
					}
					else
					{
						switch (TipoCbte)
						{
							case "6":
							case "7":
							case "8":
							case "9":
							case "10":
							case "40":
							case "61":
							case "64":
								det.linea[i].indicacion_exento_gravado = null;
								break;
							default:
								det.linea[i].indicacion_exento_gravado = listadelineas[i].indicacion_exento_gravado;
								break;
						}
					}
				}
			}
		}

		private static void GenerarDetallesAlicuotaIVA(string TipoPtoVta, string TipoCbte, FeaEntidades.InterFacturas.detalle det, System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas, int i)
		{
			if (!TipoPtoVta.Equals("Comun"))
			{
				det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
				if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
				{
					det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
				}
			}
			else
			{
				switch (TipoCbte)
				{
					case "6":
					case "7":
					case "8":
					case "9":
					case "10":
					case "40":
					case "61":
					case "64":
						det.linea[i].alicuota_ivaSpecified = false;
						det.linea[i].alicuota_iva = 0;
						break;
					default:
						det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
						if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
						{
							det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
						}
						break;
				}

			}
		}


		public void ActualizarTipoDeCambio(string MonedaComprobante)
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"];
			if (!MonedaComprobante.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
			{
				for (int i = 0; i < listadelineas.Count; i++)
				{
					FeaEntidades.InterFacturas.lineaImportes_moneda_origen limo = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
					limo.importe_total_articuloSpecified = true;
					limo.importe_total_articulo = listadelineas[i].importe_total_articulo;
					limo.importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
					limo.importe_iva = listadelineas[i].importe_iva;
					limo.precio_unitario = listadelineas[i].precio_unitario;
					limo.precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
					listadelineas[i].importes_moneda_origen = limo;
				}
			}
			else
			{
				for (int i = 0; i < listadelineas.Count; i++)
				{
					if (listadelineas[i].importes_moneda_origen != null)
					{
						listadelineas[i].importe_total_articulo = listadelineas[i].importes_moneda_origen.importe_total_articulo;
						listadelineas[i].importe_ivaSpecified = listadelineas[i].importes_moneda_origen.importe_ivaSpecified;
						listadelineas[i].importe_iva = listadelineas[i].importes_moneda_origen.importe_iva;
						listadelineas[i].precio_unitario = listadelineas[i].importes_moneda_origen.precio_unitario;
						listadelineas[i].precio_unitarioSpecified = listadelineas[i].importes_moneda_origen.precio_unitarioSpecified;
					}
				}
			}
		}
		protected void CalcularImporteArtEnEdicion(object sender, EventArgs e)
		{
			try
			{
				double preUni = Convert.ToDouble(((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtprecio_unitario"))).Text);
				double cant = Convert.ToDouble(((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtcantidad"))).Text);
				if (!preUni.Equals(0) && !cant.Equals(0))
				{
					((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_total_articulo"))).Text = Convert.ToString(Math.Round(preUni * cant,2));
				}
				DropDownList ddl = ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articuloEdit"));
				if (!ddl.SelectedValue.Equals("0") && !ddl.SelectedValue.Equals("99"))
				{
					double imptot = Convert.ToDouble(((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_total_articulo"))).Text);
					if (!imptot.Equals(0))
					{
						double aux = imptot * Convert.ToDouble(ddl.SelectedValue) / 100;
						((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_alicuota_articulo"))).Text = Convert.ToString(Math.Round(aux, 2));
					}
				}
				if (ddl.SelectedValue.Equals("99"))
				{
					((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_alicuota_articulo"))).Text = string.Empty;
				}
			}
			catch
			{
			}
		}
		protected void CalcularImporteArtEnFooter(object sender, EventArgs e)
		{
			try
			{
				double preUni = Convert.ToDouble(((TextBox)(detalleGridView.FooterRow.FindControl("txtprecio_unitario"))).Text);
				double cant = Convert.ToDouble(((TextBox)(detalleGridView.FooterRow.FindControl("txtcantidad"))).Text);
				if (!preUni.Equals(0) && !cant.Equals(0))
				{
					((TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_total_articulo"))).Text = Convert.ToString(Math.Round(preUni * cant, 2));
				}
				DropDownList ddl = ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articuloEdit"));
				if (!ddl.SelectedValue.Equals("0") && !ddl.SelectedValue.Equals("99"))
				{
					double imptot = Convert.ToDouble(((TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_total_articulo"))).Text);
					if (!imptot.Equals(0))
					{
						double aux = imptot * Convert.ToDouble(ddl.SelectedValue) / 100;
						((TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo"))).Text = Convert.ToString(Math.Round(aux, 2));
					}
				}
				if (ddl.SelectedValue.Equals("99"))
				{
					((TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo"))).Text = string.Empty;
				}
			}
			catch
			{
			}
		}
		protected void ddlalicuota_articuloEdit_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				double imptot = Convert.ToDouble(((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_total_articulo"))).Text);
				double alic=Convert.ToDouble(((DropDownList)sender).SelectedValue);
				if (!imptot.Equals(0) && !alic.Equals(99))
				{
					double aux = imptot * alic / 100;
					((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_alicuota_articulo"))).Text = Convert.ToString(Math.Round(aux,2));
				}
				if (alic.Equals(99))
				{
					((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_alicuota_articulo"))).Text = string.Empty;
				}
			}
			catch
			{
			}
		}
		protected void ddlalicuota_articuloFooter_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				double imptot = Convert.ToDouble(((TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_total_articulo"))).Text);
				double alic = Convert.ToDouble(((DropDownList)sender).SelectedValue);
				if (!imptot.Equals(0) && !alic.Equals(99))
				{
					double aux = imptot * alic / 100;
					((TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo"))).Text = Convert.ToString(Math.Round(aux, 2));
				}
				if (alic.Equals(99))
				{
					((TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo"))).Text = string.Empty;
				}
			}
			catch
			{
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class DetalleConsulta : System.Web.UI.UserControl
    {
        System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas;
        private System.Globalization.CultureInfo cedeiraCultura;
        string puntoDeVenta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
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
                if (l.GTINSpecified)
                {
                    linea.GTIN = l.GTIN;
                    linea.GTINSpecified = true;
                }
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

        private void ValidarYAsignarPropiedades(FeaEntidades.InterFacturas.linea l)
        {
            //ValidarGTIN(l, (TextBox)detalleGridView.FooterRow.FindControl("txtGTIN"));
            //ValidarDescripcion(l, (TextBox)detalleGridView.FooterRow.FindControl("txtdescripcion"));
            //ValidarImporte(l, (TextBox)detalleGridView.FooterRow.FindControl("txtimporte_total_articulo"));
            //ValidarImporteIVA(l, (TextBox)detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo"));
            //ValidarIndicacionExentoGravado(l, (DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado"));
            //ValidarAlicuotaIVA(l, (DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo"));
            //ValidarUnidad(l, (DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad"));
            //ValidarCantidad(l, (TextBox)detalleGridView.FooterRow.FindControl("txtcantidad"));
            //ValidarCodigoProductoComprador(l, (TextBox)detalleGridView.FooterRow.FindControl("txtcpcomprador"));
            //ValidarCodigoProductoVendedor(l, (TextBox)detalleGridView.FooterRow.FindControl("txtcpvendedor"));
            //ValidarPrecioUnitario(l, (TextBox)detalleGridView.FooterRow.FindControl("txtprecio_unitario"));
        }

        private void ValidarGTIN(FeaEntidades.InterFacturas.linea l, TextBox txtGTIN)
        {
            string auxGTIN = txtGTIN.Text;
            if (!auxGTIN.Equals(string.Empty) && !auxGTIN.Equals("0"))
            {
                try
                {
                    Int64 auxNroGTIN = Convert.ToInt64(auxGTIN, cedeiraCultura);
                    if (!puntoDeVenta.Equals(string.Empty))
                    {
                        System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.IdTipoPuntoVta == "RG2904" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                        });
                        if (listaPV.Count != 0)
                        {
                            if (auxGTIN.Length > 13)
                            {
                                throw new Exception("La longitud del GTIN debe ser menor o igual a 13 dígitos para RG2904");
                            }
                            else
                            {
                                l.GTIN = auxNroGTIN;
                                l.GTINSpecified = true;
                            }
                        }
                        else
                        {
                            l.GTIN = auxNroGTIN;
                            l.GTINSpecified = true;
                        }
                    }
                    else
                    {
                        l.GTIN = auxNroGTIN;
                        l.GTINSpecified = true;
                    }
                }
                catch
                {
                    throw new Exception("El formato del GTIN no es válido (sólo hasta 13 dígitos)");
                }
            }
            else
            {
                if (!puntoDeVenta.Equals(string.Empty))
                {
                    System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.IdTipoPuntoVta == "RG2904" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                    });
                    if (listaPV.Count != 0 && l.unidad != "97")
                    {
                        throw new Exception("El GTIN es obligatorio para RG2904 si la unidad de medida es distinta a 'Anticipos/Señas'");
                    }
                    else
                    {
                        l.GTIN = 0;
                        l.GTINSpecified = false;
                    }
                }
                else
                {
                    l.GTIN = 0;
                    l.GTINSpecified = false;
                }
            }

        }

        private void ValidarCodigoProductoVendedor(FeaEntidades.InterFacturas.linea l, TextBox txtcpvendedor)
        {
            string auxcpvendedor = txtcpvendedor.Text;
            l.codigo_producto_vendedor = auxcpvendedor;
        }

        private void ValidarImporteIVA(FeaEntidades.InterFacturas.linea l, TextBox txtimporte_alicuota_articulo)
        {
            string auxNull = txtimporte_alicuota_articulo.Text;
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
                    throw new Exception("El importe IVA tiene más de un separador de decimales");
                }
            }
            else
            {
                if (!puntoDeVenta.Equals(string.Empty))
                {
                    System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                    {
                        return (pv.IdTipoPuntoVta == "RG2904") && pv.Nro == Convert.ToInt32(puntoDeVenta);
                    });
                    if (listaPV.Count != 0)
                    {

                        l.importe_ivaSpecified = true;
                        l.importe_iva = 0;
                    }
                    else
                    {
                        l.importe_ivaSpecified = false;
                        l.importe_iva = 0;
                    }
                }
                else
                {
                    l.importe_ivaSpecified = false;
                    l.importe_iva = 0;
                }
            }
        }

        private void ValidarImporte(FeaEntidades.InterFacturas.linea l, TextBox txtimporte_total_articulo)
        {
            string auxTotal = txtimporte_total_articulo.Text;
            if (auxTotal.Equals(string.Empty))
            {
                throw new Exception("El importe debe ser informado");
            }
            if (!auxTotal.Contains(","))
            {
                try
                {
                    l.importe_total_articulo = Convert.ToDouble(auxTotal, cedeiraCultura);
                }
                catch
                {
                    throw new Exception("El importe tiene más de un separador de decimales");
                }
            }
            else
            {
                throw new Exception("El separador de decimales en el importe debe ser el punto");
            }
        }

        private void ValidarDescripcion(FeaEntidades.InterFacturas.linea l, TextBox txtdescripcion)
        {
            string auxDescr = txtdescripcion.Text;
            if (!auxDescr.Equals(string.Empty))
            {
                l.descripcion = auxDescr;
            }
            else
            {
                throw new Exception("La descripción no puede estar vacía");
            }
        }

        private void ValidarAlicuotaIVA(FeaEntidades.InterFacturas.linea l, DropDownList ddl)
        {
            double auxAliIVA = Convert.ToDouble(ddl.SelectedValue);
            string auxDescAliIVA = ddl.SelectedItem.Text;
            if (!auxDescAliIVA.Equals(string.Empty))
            {
                if (!puntoDeVenta.Equals(string.Empty))
                {
                    System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                    {
                        return (pv.IdTipoPuntoVta == "RG2904") && pv.Nro == Convert.ToInt32(puntoDeVenta);
                    });
                    if (listaPV.Count != 0 && !auxAliIVA.Equals(0) && (l.indicacion_exento_gravado.Equals("N") || l.indicacion_exento_gravado.Equals("E")))
                    {
                        throw new Exception("La alicuota iva debe ser 0% para RG2904 cuando está exento o no está gravado el artículo");
                    }
                    else
                    {
                        l.alicuota_ivaSpecified = true;
                        l.alicuota_iva = auxAliIVA;
                    }
                }
                else
                {
                    l.alicuota_ivaSpecified = true;
                    l.alicuota_iva = auxAliIVA;
                }
            }
            else
            {
                if (!puntoDeVenta.Equals(string.Empty))
                {
                    //OJO - Verifico si es BonoFiscal !!!
                    System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                    {
                        return (pv.IdTipoPuntoVta == "BonoFiscal" || pv.IdTipoPuntoVta == "RG2904") && pv.Nro == Convert.ToInt32(puntoDeVenta);
                    });
                    if (listaPV.Count != 0)
                    {
                        throw new Exception("La alicuota iva es obligatoria para bono fiscal y RG2904");
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
            }
        }

        private void ValidarUnidad(FeaEntidades.InterFacturas.linea l, DropDownList ddlunidad)
        {
            string auxUnidad = ddlunidad.SelectedItem.Value;
            if (!puntoDeVenta.Equals(string.Empty))
            {
                //OJO - Verifico si es RG2904!!!
                System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                {
                    return (pv.IdTipoPuntoVta == "RG2904") && pv.Nro == Convert.ToInt32(puntoDeVenta);
                });
                if (listaPV.Count != 0 && auxUnidad.Equals("99"))
                {
                    throw new Exception("La unidad BONIFICACIÓN no se admite para RG2904");
                }
                //OJO - Verifico si es BonoFiscal or RG2904!!!
                listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                {
                    return (pv.IdTipoPuntoVta == "BonoFiscal" || pv.IdTipoPuntoVta == "RG2904") && pv.Nro == Convert.ToInt32(puntoDeVenta);
                });
                if (listaPV.Count != 0)
                {
                    if (auxUnidad.Equals(string.Empty) || auxUnidad.Equals("0"))
                    {
                        throw new Exception("La unidad es obligatoria para bono fiscal y para RG2904");
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
        }

        private void ValidarCantidad(FeaEntidades.InterFacturas.linea l, TextBox txtCantidad)
        {
            string auxCantidad = txtCantidad.Text;
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
                        throw new Exception("La cantidad tiene más de un separador de decimales");
                    }
                }
                else
                {
                    if (!puntoDeVenta.Equals(string.Empty))
                    {
                        //OJO - Verifico si es BonoFiscal !!!
                        System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                        });
                        if (listaPV.Count != 0)
                        {
                            throw new Exception("La cantidad es obligatoria para bono fiscal");
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
                }
            }
            else
            {
                throw new Exception("El separador de decimales debe ser el punto");
            }
        }

        private void ValidarIndicacionExentoGravado(FeaEntidades.InterFacturas.linea l, DropDownList ddlindicacion_exento_gravado)
        {
            string auxindicacion_exento_gravado = ddlindicacion_exento_gravado.SelectedItem.Value;
            if (!puntoDeVenta.Equals(string.Empty))
            {
                //OJO - Verifico si es BonoFiscal !!!
                System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                {
                    return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                });
                if (listaPV.Count != 0)
                {
                    if (auxindicacion_exento_gravado.Equals(string.Empty))
                    {
                        throw new Exception("La indicación exento gravado es obligatoria para bono fiscal");
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
        }

        private void ValidarPrecioUnitario(FeaEntidades.InterFacturas.linea l, TextBox txtprecio_unitario)
        {
            string auxprecio_unitario = txtprecio_unitario.Text;
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
                    throw new Exception("El precio unitario tiene más de un separador de decimales");
                }
            }
            else
            {
                if (!puntoDeVenta.Equals(string.Empty))
                {
                    //OJO - Verifico si es BonoFiscal !!!
                    System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.IdTipoPuntoVta == "BonoFiscal" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                    });
                    if (listaPV.Count != 0)
                    {
                        throw new Exception("El precio unitario es obligatorio para bono fiscal");
                    }
                    else
                    {
                        listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.IdTipoPuntoVta == "RG2904" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                        });
                        if (listaPV.Count != 0)
                        {
                            l.precio_unitario = 0;
                            l.precio_unitarioSpecified = true;
                        }
                        else
                        {
                            l.precio_unitario = 0;
                            l.precio_unitarioSpecified = false;
                        }
                    }
                }
                else
                {
                    l.precio_unitario = 0;
                    l.precio_unitarioSpecified = false;
                }
            }
        }

        public void BindearDropDownLists()
        {
            //if (detalleGridView.FooterRow != null)
            //{
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataValueField = "Codigo";
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataTextField = "Descr";
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataSource = FeaEntidades.IVA.IVA.Lista();
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataBind();

            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataValueField = "Codigo";
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataTextField = "Descr";
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataBind();
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).AppendDataBoundItems = false;

            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataValueField = "Codigo";
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataTextField = "Descr";
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.ListaDetalle();
            //    ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataBind();
            //}
            //if (!detalleGridView.EditIndex.Equals(-1))
            //{
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlarticuloselEdit")).DataValueField = "Id";
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlarticuloselEdit")).DataTextField = "Descr";
            //    System.Collections.Generic.List<Entidades.Articulo> articuloslist = new System.Collections.Generic.List<Entidades.Articulo>();
            //    Entidades.Articulo articulo = new Entidades.Articulo();
            //    articulo.Id = "(Elegir artículo)";
            //    articulo.Descr = "(Elegir artículo)";
            //    articuloslist.Add(articulo);
            //    articuloslist.AddRange(((System.Collections.Generic.List<Entidades.Articulo>)ViewState["articulolista"]));
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlarticuloselEdit")).DataSource = articuloslist;
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlarticuloselEdit")).DataBind();

            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articuloEdit")).DataValueField = "Codigo";
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articuloEdit")).DataTextField = "Descr";
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articuloEdit")).DataSource = FeaEntidades.IVA.IVA.Lista();
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articuloEdit")).DataBind();

            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidadEdit")).DataValueField = "Codigo";
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidadEdit")).DataTextField = "Descr";
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidadEdit")).DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidadEdit")).DataBind();

            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataValueField = "Codigo";
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataTextField = "Descr";
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.ListaDetalle();
            //    ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataBind();
            //}
        }
 
        private void ValidarCodigoProductoComprador(FeaEntidades.InterFacturas.linea l, TextBox txtcpcomprador)
        {
            string auxcpcomprador = txtcpcomprador.Text;
            if (!puntoDeVenta.Equals(string.Empty))
            {
                int auxPV = Convert.ToInt32(puntoDeVenta);
                try
                {
                    string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.Nro == auxPV;
                    }).IdTipoPuntoVta;
                    switch (idtipo)
                    {
                        case "Comun":
                        case "Exportacion":
                        case "RG2904":
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
                        default:
                            throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
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
                string textoSinSaltoDeLinea = listadelineas[i].descripcion.Replace("\n", "<br>").Replace("\r", string.Empty);
                det.linea[i].descripcion = c.ConvertToHex(textoSinSaltoDeLinea);

                GenerarDetallesAlicuotaIVA(TipoPtoVta, TipoCbte, det, listadelineas, i);

                if (!listadelineas[i].unidad.Equals(Convert.ToString(new FeaEntidades.CodigosUnidad.SinInformar().Codigo)))
                {
                    det.linea[i].unidad = listadelineas[i].unidad;
                }
                det.linea[i].cantidad = listadelineas[i].cantidad;
                det.linea[i].cantidadSpecified = listadelineas[i].cantidadSpecified;
                det.linea[i].GTIN = listadelineas[i].GTIN;
                det.linea[i].GTINSpecified = listadelineas[i].GTINSpecified;
                if (TipoPtoVta.Equals("RG2904"))
                {
                    det.linea[i].informacion_adicional = new FeaEntidades.InterFacturas.lineaInformacion_adicional[1];
                    det.linea[i].informacion_adicional[0] = new FeaEntidades.InterFacturas.lineaInformacion_adicional();
                    det.linea[i].informacion_adicional[0].tipo = "UNIDAD_MTX";
                    det.linea[i].informacion_adicional[0].valor = listadelineas[i].unidad;
                }
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
                    if (!(TipoPtoVta.Equals("Comun") || TipoPtoVta.Equals("RG2904")))
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
            if (!(TipoPtoVta.Equals("Comun") || TipoPtoVta.Equals("RG2904")))
            {
                det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
                if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                {
                    det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
                }
            }
            else
            {
                if (TipoPtoVta.Equals("RG2904"))
                {
                    if (listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                    {
                        throw new Exception("La alícuota de IVA es obligatoria para RG2904");
                    }
                    else
                    {
                        det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
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
        }
        
        protected void ddlalicuota_articuloFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtprecio_unitario = ((TextBox)(detalleGridView.FooterRow.FindControl("txtprecio_unitario")));
                TextBox txtcantidad = (TextBox)(detalleGridView.FooterRow.FindControl("txtcantidad"));
                DropDownList ddl = (DropDownList)sender;
                TextBox txtimporte_alicuota_articulo = (TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo"));
                TextBox txtimporte_total_articulo = (TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_total_articulo"));
                RecalcularLinea(txtimporte_alicuota_articulo, puntoDeVenta, (Entidades.Sesion)Session["Sesion"], txtimporte_total_articulo, ddl, txtprecio_unitario, txtcantidad);
            }
            catch
            {
            }
        }
        protected void RecalcularLinea(TextBox txtimporte_alicuota_articulo, string puntoDeVenta, Entidades.Sesion sesion, TextBox txtimporte_total_articulo, DropDownList ddl, TextBox txtprecio_unitario, TextBox txtcantidad)
        {
            double preUni;
            try
            {
                preUni = Convert.ToDouble(txtprecio_unitario.Text);
            }
            catch
            {
                preUni = 0;
            }
            double cant;
            try
            {
                cant = Convert.ToDouble(txtcantidad.Text);
            }
            catch
            {
                cant = 0;
            }
            if (!preUni.Equals(0) && !cant.Equals(0))
            {
                txtimporte_total_articulo.Text = Convert.ToString(Math.Round(preUni * cant, 2));
            }
            double imptot = Convert.ToDouble(txtimporte_total_articulo.Text);
            double alic = Convert.ToDouble(ddl.SelectedValue);
            if (!imptot.Equals(0) && !alic.Equals(99))
            {
                double aux = imptot * alic / 100;
                txtimporte_alicuota_articulo.Text = Convert.ToString(Math.Round(aux, 2));
            }
            if (alic.Equals(99))
            {
                txtimporte_alicuota_articulo.Text = string.Empty;
            }

            if (!puntoDeVenta.Equals(string.Empty))
            {
                System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                {
                    return pv.IdTipoPuntoVta == "RG2904" && pv.Nro == Convert.ToInt32(puntoDeVenta);
                });
                if (listaPV.Count != 0)
                {
                    txtimporte_total_articulo.Text = Convert.ToString(Convert.ToDouble(txtimporte_total_articulo.Text) + Convert.ToDouble(txtimporte_alicuota_articulo.Text));
                }
            }
        }
    }
}
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class DetalleCT : System.Web.UI.UserControl
    {
        System.Collections.Generic.List<FeaEntidades.Turismo.linea> lineas;
        private System.Globalization.CultureInfo cedeiraCultura;
        string puntoDeVenta;
        string idListaPrecio;

        protected void Page_Load(object sender, EventArgs e)
        {
            puntoDeVenta = Convert.ToString(ViewState["puntoDeVenta"]);
            idListaPrecio = Convert.ToString(ViewState["idListaPrecio"]);
            if (!this.IsPostBack)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    ViewState["articulolista"] = RN.Articulo.ListaPorCuit(true, true, ((Entidades.Sesion)Session["Sesion"]));
                    Object o = Session["ComprobanteATratar"];
                    if (o == null || ((Entidades.ComprobanteATratar)o).Tratamiento == Entidades.Enum.TratamientoComprobante.Alta)
                    {
                        ResetearGrillas();
                    }
                    else
                    {
                        BindearDropDownLists();
                    }
                }
            }
        }
        public void ResetearGrillas()
        {
            lineas = new System.Collections.Generic.List<FeaEntidades.Turismo.linea>();
            FeaEntidades.Turismo.linea linea = new FeaEntidades.Turismo.linea();
            lineas.Add(linea);
            detalleGridView.DataSource = lineas;
            ViewState["lineas"] = lineas;
            detalleGridView.DataBind();
            BindearDropDownLists();
        }
        public System.Collections.Generic.List<FeaEntidades.Turismo.linea> Lineas
        {
            get
            {
                System.Collections.Generic.List<FeaEntidades.Turismo.linea> refs = ((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"]);
                return refs;
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
        public string IdListaPrecio
        {
            set
            {
                ViewState["idListaPrecio"] = value;
                idListaPrecio = value;
            }
        }
        public string IdNaturalezaComprobante
        {
            set
            {
                ViewState["idNaturalezaComprobante"] = value;
            }
        }
        public void CompletarDetallesWS(org.dyndns.cedweb.consulta.ConsultarResult lc)
        {
            lineas = new System.Collections.Generic.List<FeaEntidades.Turismo.linea>();
            foreach (org.dyndns.cedweb.consulta.ConsultarResultComprobanteDetalleLinea l in lc.comprobante[0].detalle.linea)
            {
                FeaEntidades.Turismo.linea linea = new FeaEntidades.Turismo.linea();
                //Compatibilidad con archivos xml viejos. Verificar si la descripcion está en Hexa.
                if (l.descripcion.Substring(0, 1) == "%")
                {
                    linea.descripcion = RN.Funciones.HexToString(l.descripcion).Replace("<br>", System.Environment.NewLine);
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
        public void CompletarDetalles(FeaEntidades.Turismo.comprobante lc)
        {
            lineas = new System.Collections.Generic.List<FeaEntidades.Turismo.linea>();
            foreach (FeaEntidades.Turismo.linea l in lc.detalle.linea)
            {
                FeaEntidades.Turismo.linea linea = new FeaEntidades.Turismo.linea();
                if (l.GTINSpecified)
                {
                    linea.GTIN = l.GTIN;
                    linea.GTINSpecified = true;
                }
                //Compatibilidad con archivos xml viejos. Verificar si la descripcion está en Hexa.
                if (l.descripcion.Substring(0, 1) == "%")
                {
                    linea.descripcion = RN.Funciones.HexToString(l.descripcion).Replace("<br>", System.Environment.NewLine);
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
                linea.codigo_Turismo = l.codigo_Turismo;
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

                    FeaEntidades.Turismo.linea l = new FeaEntidades.Turismo.linea();

                    ValidarYAsignarPropiedades(l);

                    ((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"]).Add(l);


                    //Me fijo si elimino la fila automática
                    System.Collections.Generic.List<FeaEntidades.Turismo.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"]);
                    FeaEntidades.Turismo.linea lineaInicial = lineas[0];
                    if (lineaInicial.descripcion == null)
                    {
                        ((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"]).Remove(lineaInicial);
                    }

                    //Saco de edición la fila que estén modificando
                    if (!detalleGridView.EditIndex.Equals(-1))
                    {
                        detalleGridView.EditIndex = -1;
                    }

                    detalleGridView.DataSource = ViewState["lineas"];
                    detalleGridView.DataBind();
                    BindearDropDownLists();
                    Session["FaltaCalcularTotales"] = true;
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
                }
            }
        }

        private void ValidarYAsignarPropiedades(FeaEntidades.Turismo.linea l)
        {
            ValidarGTIN(l, (TextBox)detalleGridView.FooterRow.FindControl("txtGTIN"));
            ValidarDescripcion(l, (TextBox)detalleGridView.FooterRow.FindControl("txtdescripcion"));
            ValidarImporte(l, (TextBox)detalleGridView.FooterRow.FindControl("txtimporte_total_articulo"));
            ValidarImporteIVA(l, (TextBox)detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo"));
            ValidarIndicacionExentoGravado(l, (DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado"));
            ValidarAlicuotaIVA(l, (DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo"));
            ValidarUnidad(l, (DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad"));
            ValidarCodigoTurismo(l, (DropDownList)detalleGridView.FooterRow.FindControl("ddlcodigoTurismo"));
            ValidarCantidad(l, (TextBox)detalleGridView.FooterRow.FindControl("txtcantidad"));
            ValidarCodigoProductoComprador(l, (TextBox)detalleGridView.FooterRow.FindControl("txtcpcomprador"));
            ValidarCodigoProductoVendedor(l, (TextBox)detalleGridView.FooterRow.FindControl("txtcpvendedor"));
            ValidarPrecioUnitario(l, (TextBox)detalleGridView.FooterRow.FindControl("txtprecio_unitario"));
        }

        private void ValidarGTIN(FeaEntidades.Turismo.linea l, TextBox txtGTIN)
        {
            string auxGTIN = txtGTIN.Text;
            if (!auxGTIN.Equals(string.Empty) && !auxGTIN.Equals("0"))
            {
                Int64 auxNroGTIN = Convert.ToInt64(auxGTIN, cedeiraCultura);
                l.GTIN = auxNroGTIN;
                l.GTINSpecified = true;
            }
            else
            {
                l.GTIN = 0;
                l.GTINSpecified = false;
            }
        }

        private void ValidarCodigoProductoVendedor(FeaEntidades.Turismo.linea l, TextBox txtcpvendedor)
        {
            string auxcpvendedor = txtcpvendedor.Text;
            l.codigo_producto_vendedor = auxcpvendedor;
        }

        private void ValidarImporteIVA(FeaEntidades.Turismo.linea l, TextBox txtimporte_alicuota_articulo)
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
                l.importe_ivaSpecified = true;
                l.importe_iva = 0;
            }
        }

        private void ValidarImporte(FeaEntidades.Turismo.linea l, TextBox txtimporte_total_articulo)
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

        private void ValidarDescripcion(FeaEntidades.Turismo.linea l, TextBox txtdescripcion)
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

        private void ValidarAlicuotaIVA(FeaEntidades.Turismo.linea l, DropDownList ddl)
        {
            double auxAliIVA = Convert.ToDouble(ddl.SelectedValue);
            string auxDescAliIVA = ddl.SelectedItem.Text;
            if (!auxDescAliIVA.Equals(string.Empty))
            {
                l.alicuota_ivaSpecified = true;
                l.alicuota_iva = auxAliIVA;
            }
            else
            {
                l.alicuota_ivaSpecified = false;
                l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
            }
        }
        
        private void ValidarUnidad(FeaEntidades.Turismo.linea l, DropDownList ddlunidad)
        {
            string auxUnidad = ddlunidad.SelectedItem.Value;
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                l.unidad = auxUnidad;
            }
        }

        private void ValidarCodigoTurismo(FeaEntidades.Turismo.linea l, DropDownList ddlcodigoTurismo)
        {
            string auxCodigoTurismo = ddlcodigoTurismo.SelectedItem.Value;
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                l.codigo_Turismo = Convert.ToInt16(auxCodigoTurismo);
            }
        }

        private void ValidarCantidad(FeaEntidades.Turismo.linea l, TextBox txtCantidad)
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
                    l.cantidadSpecified = false;
                    l.cantidad = 0;
                }
            }
            else
            {
                throw new Exception("El separador de decimales debe ser el punto");
            }
        }

        private void ValidarIndicacionExentoGravado(FeaEntidades.Turismo.linea l, DropDownList ddlindicacion_exento_gravado)
        {
            string auxindicacion_exento_gravado = ddlindicacion_exento_gravado.SelectedItem.Value;
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                l.indicacion_exento_gravado = auxindicacion_exento_gravado;
            }
        }

        private void ValidarPrecioUnitario(FeaEntidades.Turismo.linea l, TextBox txtprecio_unitario)
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
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    l.precio_unitario = 0;
                    l.precio_unitarioSpecified = true;
                }
            }
        }

        protected void detalleGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                if (puntoDeVenta.Equals(string.Empty) && ViewState["idNaturalezaComprobante"].ToString() != "Compra")
                {
                    throw new Exception("Debe definir el punto de venta antes de editar un detalle");
                }

                cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);

                System.Collections.Generic.List<FeaEntidades.Turismo.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"]);

                FeaEntidades.Turismo.linea l = lineas[e.RowIndex];

                ValidarDescripcion(l, (TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtdescripcion"));
                ValidarImporte(l, (TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtimporte_total_articulo"));
                ValidarImporteIVA(l, (TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtimporte_alicuota_articulo"));
                ValidarIndicacionExentoGravado(l, (DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlindicacion_exento_gravado"));
                ValidarAlicuotaIVA(l, (DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlalicuota_articulo"));
                ValidarUnidad(l, (DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlunidad"));
                ValidarCodigoTurismo(l, (DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlcodigoTurismo"));
                ValidarCantidad(l, (TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtcantidad"));
                ValidarCodigoProductoComprador(l, (TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtcpcomprador"));
                ValidarCodigoProductoVendedor(l, (TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtcpvendedor"));
                ValidarPrecioUnitario(l, (TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtprecio_unitario"));
                ValidarGTIN(l, (TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtGTIN"));

                detalleGridView.EditIndex = -1;
                detalleGridView.DataSource = lineas;
                detalleGridView.DataBind();
                BindearDropDownLists();
                ViewState["lineas"] = lineas;
                Session["FaltaCalcularTotales"] = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
            }
        }
        protected void detalleGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(e.Exception.Message), false);
                e.ExceptionHandled = true;
            }
        }
        protected void detalleGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            detalleGridView.EditIndex = e.NewEditIndex;
            detalleGridView.DataSource = ViewState["lineas"];
            detalleGridView.DataBind();
            BindearDropDownLists();

            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articulo")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articulo")).DataTextField = "Descr";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articulo")).DataSource = FeaEntidades.IVA.IVA.ListaTuristas();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articulo")).DataBind();
            try
            {
                ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articulo")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"])[e.NewEditIndex].alicuota_iva.ToString());
                li.Selected = true;
            }
            catch
            {
            }

            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidad")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidad")).DataTextField = "Descr";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidad")).DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.ListaTurismo();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidad")).DataBind();
            try
            {
                ListItem liUnidad = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidad")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"])[e.NewEditIndex].unidad.ToString());
                liUnidad.Selected = true;
            }
            catch
            {
            }

            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravado")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravado")).DataTextField = "Descr";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravado")).DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.ListaDetalle();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravado")).DataBind();
            try
            {
                ListItem liIndExento = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravado")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"])[e.NewEditIndex].indicacion_exento_gravado.ToString());
                liIndExento.Selected = true;
            }
            catch
            {
            }

            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigoTurismo")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigoTurismo")).DataTextField = "Descr";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigoTurismo")).DataSource = FeaEntidades.CodigosTurismo.CodigoTurismo.Lista();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigoTurismo")).DataBind();
            try
            {
                ListItem liUnidad = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigoTurismo")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"])[e.NewEditIndex].codigo_Turismo.ToString());
                liUnidad.Selected = true;
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
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlarticulosel")).DataValueField = "Id";
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlarticulosel")).DataTextField = "DescrConStockeIdArticulo";
                System.Collections.Generic.List<Entidades.Articulo> articuloslist = new System.Collections.Generic.List<Entidades.Articulo>();
                Entidades.Articulo articulo = new Entidades.Articulo();
                articulo.Id = "(Elegir artículo)";
                articulo.Descr = "(Elegir artículo)";
                articuloslist.Add(articulo);
                articulo = new Entidades.Articulo();
                articulo.Id = "(Buscar)";
                articulo.Descr = "(Buscar)";
                articuloslist.Add(articulo);
                if (ViewState["articulolista"] != null)
                {
                    articuloslist.AddRange(((System.Collections.Generic.List<Entidades.Articulo>)ViewState["articulolista"]));
                }
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlarticulosel")).DataSource = articuloslist;
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlarticulosel")).DataBind();

                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataValueField = "Codigo";
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataTextField = "Descr";
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataSource = FeaEntidades.IVA.IVA.ListaTuristas();
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataBind();

                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataValueField = "Codigo";
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataTextField = "Descr";
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.ListaTurismo();
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataBind();
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).AppendDataBoundItems = false;

                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataValueField = "Codigo";
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataTextField = "Descr";
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.ListaDetalle();
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataBind();

                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlcodigoTurismo")).DataValueField = "Codigo";
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlcodigoTurismo")).DataTextField = "Descr";
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlcodigoTurismo")).DataSource = FeaEntidades.CodigosTurismo.CodigoTurismo.Lista();
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlcodigoTurismo")).DataBind();
                ((DropDownList)detalleGridView.FooterRow.FindControl("ddlcodigoTurismo")).AppendDataBoundItems = false;
            }
            if (!detalleGridView.EditIndex.Equals(-1))
            {
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlarticuloselEdit")).DataValueField = "Id";
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlarticuloselEdit")).DataTextField = "Descr";
                System.Collections.Generic.List<Entidades.Articulo> articuloslist = new System.Collections.Generic.List<Entidades.Articulo>();
                Entidades.Articulo articulo = new Entidades.Articulo();
                articulo.Id = "(Elegir artículo)";
                articulo.Descr = "(Elegir artículo)";
                articuloslist.Add(articulo);
                articulo = new Entidades.Articulo();
                articulo.Id = "(Buscar)";
                articulo.Descr = "(Buscar)";
                articuloslist.Add(articulo);
                articuloslist.AddRange(((System.Collections.Generic.List<Entidades.Articulo>)ViewState["articulolista"]));
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlarticuloselEdit")).DataSource = articuloslist;
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlarticuloselEdit")).DataBind();

                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articulo")).DataValueField = "Codigo";
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articulo")).DataTextField = "Descr";
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articulo")).DataSource = FeaEntidades.IVA.IVA.ListaTuristas();
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articulo")).DataBind();

                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidad")).DataValueField = "Codigo";
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidad")).DataTextField = "Descr";
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidad")).DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.ListaTurismo();
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlunidad")).DataBind();

                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravado")).DataValueField = "Codigo";
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravado")).DataTextField = "Descr";
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravado")).DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.ListaDetalle();
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlindicacion_exento_gravado")).DataBind();

                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlcodigoTurismo")).DataValueField = "Codigo";
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlcodigoTurismo")).DataTextField = "Descr";
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlcodigoTurismo")).DataSource = FeaEntidades.CodigosTurismo.CodigoTurismo.Lista();
                ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlcodigoTurismo")).DataBind();
            }
        }
        protected void detalleGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                System.Collections.Generic.List<FeaEntidades.Turismo.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"]);
                FeaEntidades.Turismo.linea l = lineas[e.RowIndex];
                lineas.Remove(l);

                if (lineas.Count.Equals(0))
                {
                    FeaEntidades.Turismo.linea nueva = new FeaEntidades.Turismo.linea();
                    lineas.Add(nueva);
                }

                detalleGridView.EditIndex = -1;

                detalleGridView.DataSource = ViewState["lineas"];
                detalleGridView.DataBind();
                BindearDropDownLists();
                Session["FaltaCalcularTotales"] = true;
            }
            catch
            {
            }

        }
        protected void detalleGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", Funciones.TextoScript(e.Exception.Message), false);
                e.ExceptionHandled = true;
            }
        }
        private void ValidarCodigoProductoComprador(FeaEntidades.Turismo.linea l, TextBox txtcpcomprador)
        {
            string auxcpcomprador = txtcpcomprador.Text;
            l.codigo_producto_comprador = auxcpcomprador;
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

        public void CalcularTotalesLineas(ref double totalGravado, ref double totalNoGravado, ref double totalIVA, ref double total_Operaciones_Exentas, ref double total_Reintegros)
        {
            System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"];
            for (int i = 0; i < listadelineas.Count; i++)
            {
                double imptotdiscr = 0;
                try
                {
                    if (listadelineas[i].descripcion == null)
                    {
                        throw new Exception("Debe informar al menos un artículo");
                    }
                    imptotdiscr = listadelineas[i].importe_total_articulo;
                    if (listadelineas[i].indicacion_exento_gravado != null && listadelineas[i].indicacion_exento_gravado.Trim().ToUpper() == "G")
                    {
                        totalGravado += imptotdiscr;
                        if (listadelineas[i].codigo_Turismo == 1 || listadelineas[i].codigo_Turismo == 2)
                        {
                            total_Reintegros -= listadelineas[i].importe_iva;
                        }
                    }
                    else if (listadelineas[i].indicacion_exento_gravado != null && listadelineas[i].indicacion_exento_gravado.Equals("E"))
                    {
                        total_Operaciones_Exentas += imptotdiscr;
                    }
                    else
                    {
                        totalNoGravado += imptotdiscr;
                    }
                }
                catch (NullReferenceException)
                {
                    totalNoGravado += listadelineas[i].importe_total_articulo;
                }
                if (!listadelineas[i].alicuota_iva.Equals(99)) totalIVA += imptotdiscr * listadelineas[i].alicuota_iva / 100; //listadelineas[i].importe_iva;
            }
            totalIVA = Math.Round(totalIVA, 2);
        }

        public double CalcularTotalImporte()
        {
            System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"];
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

        public FeaEntidades.Turismo.detalle GenerarDetalles(string MonedaComprobante, string TipoDeCambio, string TipoPtoVta, string TipoCbte, bool EsParaImprimirPDF)
        {
            FeaEntidades.Turismo.detalle det = new FeaEntidades.Turismo.detalle();
            System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"];
            for (int i = 0; i < listadelineas.Count; i++)
            {
                det.linea[i] = new FeaEntidades.Turismo.linea();
                det.linea[i].numeroLinea = i + 1;
                if (listadelineas[i].descripcion == null)
                {
                    throw new Exception("Debe informar al menos un artículo");
                }
                string textoSinSaltoDeLinea = listadelineas[i].descripcion.Replace("\n", "<br>").Replace("\r", string.Empty);
                det.linea[i].descripcion = textoSinSaltoDeLinea;

                GenerarDetallesAlicuotaIVA(TipoPtoVta, TipoCbte, det, listadelineas, i);

                if (!listadelineas[i].unidad.Equals(Convert.ToString(new FeaEntidades.CodigosUnidad.SinInformar().Codigo)))
                {
                    det.linea[i].unidad = listadelineas[i].unidad;
                }
                det.linea[i].codigo_Turismo = listadelineas[i].codigo_Turismo;
                det.linea[i].cantidad = listadelineas[i].cantidad;
                det.linea[i].cantidadSpecified = listadelineas[i].cantidadSpecified;
                det.linea[i].GTIN = listadelineas[i].GTIN;
                det.linea[i].GTINSpecified = listadelineas[i].GTINSpecified;
                det.linea[i].codigo_producto_comprador = listadelineas[i].codigo_producto_comprador;
                det.linea[i].codigo_producto_vendedor = listadelineas[i].codigo_producto_vendedor;

                GenerarDetallesIndExGravado(TipoPtoVta, TipoCbte, det, listadelineas, i);

                if (MonedaComprobante.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
                {

                    GenerarDetalleMonedaLocal(TipoCbte, det, listadelineas, i, TipoPtoVta);
                }
                else
                {
                    GenerarDetalleMonedaExtranjera(TipoDeCambio, TipoCbte, det, listadelineas, i, TipoPtoVta);
                }
            }
            return det;
        }

        private static void GenerarDetalleMonedaExtranjera(string TipoDeCambio, string TipoCbte, FeaEntidades.Turismo.detalle det, System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas, int i, string TipoPtoVta)
        {
            det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
            det.linea[i].importe_iva = Math.Round(listadelineas[i].importe_iva * Convert.ToDouble(TipoDeCambio), 2);
            det.linea[i].importe_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
            det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * Convert.ToDouble(TipoDeCambio), 3);
            det.linea[i].importe_total_articulo = Math.Round(listadelineas[i].importe_total_articulo * Convert.ToDouble(TipoDeCambio), 2);

            FeaEntidades.InterFacturas.lineaImportes_moneda_origen limo = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
            limo.importe_total_articuloSpecified = true;

            limo.precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
            limo.importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
            limo.importe_iva = listadelineas[i].importe_iva;
            limo.precio_unitario = listadelineas[i].precio_unitario;
            limo.importe_total_articulo = listadelineas[i].importe_total_articulo;

            det.linea[i].importes_moneda_origen = limo;
        }

        private static void GenerarDetalleMonedaLocal(string TipoCbte, FeaEntidades.Turismo.detalle det, System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas, int i, string TipoPtoVta)
        {
            det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
            det.linea[i].precio_unitario = listadelineas[i].precio_unitario;
            det.linea[i].importe_total_articulo = listadelineas[i].importe_total_articulo;
            det.linea[i].importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
            det.linea[i].importe_iva = listadelineas[i].importe_iva;
        }

        private static void GenerarDetallesIndExGravado(string TipoPtoVta, string TipoCbte, FeaEntidades.Turismo.detalle det, System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas, int i)
        {
            if (listadelineas[i].indicacion_exento_gravado != null)
            {
                if (!listadelineas[i].indicacion_exento_gravado.Equals(string.Empty))
                {
                    det.linea[i].indicacion_exento_gravado = listadelineas[i].indicacion_exento_gravado;
                }
            }
        }

        private static void GenerarDetallesAlicuotaIVA(string TipoPtoVta, string TipoCbte, FeaEntidades.Turismo.detalle det, System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas, int i)
        {
            if (listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
            {
                //throw new Exception("La alícuota de IVA es obligatoria");
                det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
                det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
            }
            else
            {
                det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
                det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
            }
        }
        public void ActualizarTipoDeCambio(string MonedaComprobante)
        {
            System.Collections.Generic.List<FeaEntidades.Turismo.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.Turismo.linea>)ViewState["lineas"];
            if (listadelineas != null)
            {
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
        }
        protected void CalcularImporteArtEnEdicion(object sender, EventArgs e)
        {
            try
            {
                TextBox txtimporte_total_articulo = ((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_total_articulo")));
                TextBox txtimporte_alicuota_articulo = ((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_alicuota_articulo")));
                DropDownList ddl = ((DropDownList)detalleGridView.Rows[detalleGridView.EditIndex].FindControl("ddlalicuota_articulo"));
                TextBox txtprecio_unitario = ((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtprecio_unitario")));
                TextBox txtcantidad = ((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtcantidad")));
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    RecalcularLinea(txtimporte_alicuota_articulo, puntoDeVenta, (Entidades.Sesion)Session["Sesion"], txtimporte_total_articulo, ddl, txtprecio_unitario, txtcantidad);
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
                TextBox txtprecio_unitario = ((TextBox)(detalleGridView.FooterRow.FindControl("txtprecio_unitario")));
                TextBox txtcantidad = ((TextBox)(detalleGridView.FooterRow.FindControl("txtcantidad")));
                DropDownList ddl = ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo"));
                TextBox txtimporte_total_articulo = (TextBox)detalleGridView.FooterRow.FindControl("txtimporte_total_articulo");
                TextBox txtimporte_alicuota_articulo = (TextBox)detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo");
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    RecalcularLinea(txtimporte_alicuota_articulo, puntoDeVenta, (Entidades.Sesion)Session["Sesion"], txtimporte_total_articulo, ddl, txtprecio_unitario, txtcantidad);
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
                TextBox txtimporte_alicuota_articulo = (TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_alicuota_articulo"));
                TextBox txtimporte_total_articulo = (TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtimporte_total_articulo"));
                DropDownList ddl = (DropDownList)sender;
                TextBox txtprecio_unitario = ((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtprecio_unitario")));
                TextBox txtcantidad = ((TextBox)(detalleGridView.Rows[detalleGridView.EditIndex].FindControl("txtcantidad")));
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    RecalcularLinea(txtimporte_alicuota_articulo, puntoDeVenta, (Entidades.Sesion)Session["Sesion"], txtimporte_total_articulo, ddl, txtprecio_unitario, txtcantidad);
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
                TextBox txtprecio_unitario = ((TextBox)(detalleGridView.FooterRow.FindControl("txtprecio_unitario")));
                TextBox txtcantidad = (TextBox)(detalleGridView.FooterRow.FindControl("txtcantidad"));
                DropDownList ddl = (DropDownList)sender;
                TextBox txtimporte_alicuota_articulo = (TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo"));
                TextBox txtimporte_total_articulo = (TextBox)(detalleGridView.FooterRow.FindControl("txtimporte_total_articulo"));
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    RecalcularLinea(txtimporte_alicuota_articulo, puntoDeVenta, (Entidades.Sesion)Session["Sesion"], txtimporte_total_articulo, ddl, txtprecio_unitario, txtcantidad);
                }
            }
            catch
            {
            }
        }
        protected void RecalcularLinea(TextBox txtimporte_alicuota_articulo, string puntoDeVenta, Entidades.Sesion sesion, TextBox txtimporte_total_articulo, DropDownList ddlalicuota_articulo, TextBox txtprecio_unitario, TextBox txtcantidad)
        {
            if (!puntoDeVenta.Equals(string.Empty))
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
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
                    double imptot;
                    try
                    {
                        imptot = Convert.ToDouble(txtimporte_total_articulo.Text);
                    }
                    catch
                    {
                        imptot = 0;
                    }
                    double alic;
                    try
                    {
                        alic = Convert.ToDouble(ddlalicuota_articulo.SelectedValue);
                    }
                    catch
                    {
                        alic = 0;
                    }
                    if (!imptot.Equals(0) && !alic.Equals(0))
                    {
                        if (alic.Equals(99))
                        {
                            txtimporte_alicuota_articulo.Text = string.Empty;
                        }
                        else
                        {
                            double aux = imptot * alic / 100;
                            txtimporte_alicuota_articulo.Text = Convert.ToString(Math.Round(aux, 2));
                        }
                    }
                }
            }
        }

        protected void ddlarticuloselEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            try
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    if (ddl.SelectedValue == "(Buscar)")
                    {
                        ViewState["rowOrigen"] = detalleGridView.EditIndex.ToString();
                        Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                        CUITTextBox.Text = sesion.Cuit.Nro;
                        CUITTextBox.Enabled = false;
                        DescrRadioButton.Checked = true;
                        AjustarPorTipoBusqueda();
                        ddl.SelectedValue = "(Elegir artículo)";
                        DescrTextBox.Focus();
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        AsignarArticuloBuscado(ddl, detalleGridView.Rows[detalleGridView.EditIndex]);
                    }
                }
            }
            catch
            {
                ddl.SelectedValue = "(Elegir artículo)";
            }
        }
        protected void ddlarticuloselFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            try
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    if (ddl.SelectedValue == "(Buscar)")
                    {
                        ViewState["rowOrigen"] = "Footer";
                        Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                        CUITTextBox.Text = sesion.Cuit.Nro;
                        CUITTextBox.Enabled = false;
                        DescrRadioButton.Checked = true;
                        AjustarPorTipoBusqueda();
                        ddl.SelectedValue = "(Elegir artículo)";
                        DescrTextBox.Focus();
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        AsignarArticuloBuscado(ddl, detalleGridView.FooterRow);
                    }
                }
            }
            catch
            {
                ddl.SelectedValue = "(Elegir artículo)";
            }
        }
        protected void TipoBusquedaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AjustarPorTipoBusqueda();
            ModalPopupExtender1.Show();
        }
        protected void AjustarPorTipoBusqueda()
        {
            ArticulosGridView.DataSource = null;
            ArticulosGridView.DataBind();
            MensajeLabel.Text = String.Empty;
            if (IdRadioButton.Checked)
            {
                DescrTextBox.Text = String.Empty;
                IdTextBox.Visible = true;
                DescrTextBox.Visible = false;
            }
            else
            {
                IdTextBox.Text = String.Empty;
                IdTextBox.Visible = false;
                DescrTextBox.Visible = true;
            }
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
                MensajeLabel.Text = String.Empty;
                if (IdRadioButton.Checked)
                {
                    if (IdTextBox.Text.Equals(String.Empty))
                    {
                        MensajeLabel.Text = IdRadioButton.Text + " no informada";
                        return;
                    }
                    else
                    {
                        lista = RN.Articulo.ListaPorCuityId(sesion.Cuit.Nro, IdTextBox.Text, true, sesion);
                    }
                }
                else
                {
                    if (DescrTextBox.Text.Equals(String.Empty))
                    {
                        MensajeLabel.Text = DescrRadioButton.Text + " no informada";
                        return;
                    }
                    else
                    {
                        lista = RN.Articulo.ListaPorCuityDescr(sesion.Cuit.Nro, DescrTextBox.Text, true, sesion);
                    }
                }
                if (lista.Count == 0)
                {
                    ArticulosGridView.DataSource = null;
                    ArticulosGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado artículos que satisfagan la busqueda";
                    ModalPopupExtender1.Show();
                }
                else
                {
                    ArticulosGridView.DataSource = lista;
                    ViewState["ArticulosBuscados"] = lista;
                    ArticulosGridView.DataBind();
                    if (lista.Count == 1)
                    {
                        DropDownList ddl;
                        GridViewRow row;
                        if (ViewState["rowOrigen"].ToString() == "Footer")
                        {
                            ddl = (DropDownList)detalleGridView.FooterRow.FindControl("ddlarticulosel");
                            row = detalleGridView.FooterRow;
                        }
                        else
                        {
                            int rowIndex = Convert.ToInt32(ViewState["rowOrigen"].ToString());
                            ddl = (DropDownList)detalleGridView.Rows[rowIndex].FindControl("ddlarticuloselEdit");
                            row = detalleGridView.Rows[rowIndex];
                        }
                        ddl.SelectedValue = lista[0].Id;
                        AsignarArticuloBuscado(ddl, row);
                        ModalPopupExtender1.Hide();
                    }
                    else
                    {
                        ModalPopupExtender1.Show();
                    }
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        protected void ArticulosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.Articulo> lista = (List<Entidades.Articulo>)ViewState["ArticulosBuscados"];
            Entidades.Articulo articulo = lista[item];
            if (e.CommandName == "Seleccionar")
            {
                DropDownList ddl;
                GridViewRow row;
                if (ViewState["rowOrigen"].ToString() == "Footer")
                {
                    ddl = (DropDownList)detalleGridView.FooterRow.FindControl("ddlarticulosel");
                    row = detalleGridView.FooterRow;
                }
                else
                {
                    int rowIndex = Convert.ToInt32(ViewState["rowOrigen"].ToString());
                    ddl = (DropDownList)detalleGridView.Rows[rowIndex].FindControl("ddlarticuloselEdit");
                    row = detalleGridView.Rows[rowIndex];
                }
                ddl.SelectedValue = articulo.Id;
                AsignarArticuloBuscado(ddl, row);
                ModalPopupExtender1.Hide();
            }
            else
            {
                ModalPopupExtender1.Show();
            }
        }
        protected void ArticulosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
            ModalPopupExtender1.Show();
        }
        protected void AsignarArticuloBuscado(DropDownList ddl, GridViewRow row)
        {
            System.Collections.Generic.List<Entidades.Articulo> listaArt = ((System.Collections.Generic.List<Entidades.Articulo>)ViewState["articulolista"]).FindAll(delegate(Entidades.Articulo art)
            {
                return art.Id == ddl.SelectedValue;
            });
            if (listaArt.Count != 0)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                ((TextBox)(row.FindControl("txtcpvendedor"))).Text = listaArt[0].Id;
                ((TextBox)(row.FindControl("txtGTIN"))).Text = listaArt[0].GTIN;
                ((TextBox)(row.FindControl("txtdescripcion"))).Text = listaArt[0].Descr;
                ((DropDownList)(row.FindControl("ddlindicacion_exento_gravado"))).SelectedValue = listaArt[0].IndicacionExentoGravado;
                ((DropDownList)(row.FindControl("ddlunidad"))).SelectedValue = listaArt[0].Unidad.Id;
                //((DropDownList)(row.FindControl("ddlcodigoTurismo"))).SelectedValue = "" //no existe aun
                if (idListaPrecio != string.Empty)
                {
                    double precio = RN.Precio.Valor(listaArt[0].Id, idListaPrecio, sesion);
                    if (precio != 0)
                    {
                        ((TextBox)(row.FindControl("txtprecio_unitario"))).Text = precio.ToString();
                    }
                }
                ((DropDownList)(row.FindControl("ddlalicuota_articulo"))).SelectedValue = Convert.ToString(listaArt[0].AlicuotaIVA);
                DropDownList ddlalicuota_articulo = ((DropDownList)(row.FindControl("ddlalicuota_articulo")));
                TextBox txtprecio_unitario = ((TextBox)(row.FindControl("txtprecio_unitario")));
                TextBox txtcantidad = (TextBox)(row.FindControl("txtcantidad"));
                TextBox txtimporte_alicuota_articulo = (TextBox)(row.FindControl("txtimporte_alicuota_articulo"));
                TextBox txtimporte_total_articulo = (TextBox)(row.FindControl("txtimporte_total_articulo"));
                RecalcularLinea(txtimporte_alicuota_articulo, puntoDeVenta, sesion, txtimporte_total_articulo, ddlalicuota_articulo, txtprecio_unitario, txtcantidad);
                ddl.SelectedValue = "(Elegir artículo)";
            }
        }
   }
}
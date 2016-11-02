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
using System.Xml.Serialization;
using System.Text;
using System.IO;

namespace CedServicios.Site.Facturacion.Electronica.Reportes
{
    public partial class FacturaWebForm : System.Web.UI.Page
    {
        CrystalDecisions.CrystalReports.Engine.ReportDocument facturaRpt;
        CrystalDecisions.CrystalReports.Engine.ReportDocument imagenRpt;
        CrystalDecisions.CrystalReports.Engine.ReportDocument codigobarrasRpt;
        DataSet dsImages = new DataSet();
        protected void Page_Unload(object sender, EventArgs e)
        {
            Session.Remove("EsComprobanteOriginal");
            if (facturaRpt != null)
            {
                facturaRpt.Dispose();
            }
            if (imagenRpt != null)
            {
                imagenRpt.Dispose();
            }
            if (codigobarrasRpt != null)
            {
                codigobarrasRpt.Dispose();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
            culture.NumberFormat.CurrencySymbol = string.Empty;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            base.InitializeCulture();

            if (Session["lote"] == null)
            {
                Response.Redirect("~/Inicio.aspx");
            }
            else
            {
                try
                {
                    string lcomp = Server.MapPath("~/Facturacion/Electronica/Reportes/lote_comprobantes.xsd");
                    System.IO.File.Copy(lcomp, @System.IO.Path.GetTempPath() + "lote_comprobantes.xsd", true);

                    string imagen = Server.MapPath("~/Facturacion/Electronica/Reportes/Imagen.xsd");
                    System.IO.File.Copy(imagen, @System.IO.Path.GetTempPath() + "Imagen.xsd", true);

                    facturaRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    string reportPath = Server.MapPath("~/Facturacion/Electronica/Reportes/Factura.rpt");
                    facturaRpt.Load(reportPath);

                    FeaEntidades.InterFacturas.lote_comprobantes lc = (FeaEntidades.InterFacturas.lote_comprobantes)Session["lote"];
                    AsignarCamposOpcionales(lc);
					ReemplarResumenImportesMonedaExtranjera(lc);
					DataSet ds = new DataSet();

                    XmlSerializer objXS = new XmlSerializer(lc.GetType());
                    StringWriter objSW = new StringWriter();
                    objXS.Serialize(objSW, lc);
                    StringReader objSR = new StringReader(objSW.ToString());
                    ds.ReadXml(objSR);

                    bool original = true;
                    try
                    {
                        original = (bool)Session["EsComprobanteOriginal"];
                        if (original == false)
                        {
                            facturaRpt.DataDefinition.FormulaFields["Borrador"].Text = "'BORRADOR'";
                        }
                    }
                    catch
                    { 
                    }

					facturaRpt.SetDataSource(ds);
                    facturaRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    facturaRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                    IncrustarLogo(lc.cabecera_lote.cuit_vendedor.ToString(), lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString());
					string cae = lc.comprobante[0].cabecera.informacion_comprobante.cae;
					if (cae.Replace(" ",string.Empty).Equals(string.Empty))
					{
						cae = "99999999999999";
					}
					GenerarCodigoBarras(lc.cabecera_lote.cuit_vendedor + lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00") + lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString("0000") + cae +System.DateTime.Now.ToString("yyyyMMdd"));
					AsignarParametros(lc.comprobante[0].resumen.importe_total_factura);

                    facturaRpt.Subreports["impuestos"].DataDefinition.FormulaFields["TipoDeComprobante"].Text = "'" + lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString() + "'"; 
                    facturaRpt.Subreports["resumen"].DataDefinition.FormulaFields["TipoDeComprobante"].Text = "'" + lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString() + "'"; 

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(lc.cabecera_lote.cuit_vendedor);
                    sb.Append("-");
                    sb.Append(lc.cabecera_lote.punto_de_venta.ToString("0000"));
                    sb.Append("-");
                    sb.Append(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00"));
                    sb.Append("-");
                    sb.Append(lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000"));
                    if (original == false)
                    {
                        sb.Append("-BORRADOR");
                    }

                    CrystalDecisions.Shared.ExportOptions exportOpts = new CrystalDecisions.Shared.ExportOptions();
                    CrystalDecisions.Shared.PdfRtfWordFormatOptions pdfOpts = CrystalDecisions.Shared.ExportOptions.CreatePdfRtfWordFormatOptions();
                    exportOpts.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                    exportOpts.ExportFormatOptions = pdfOpts;
                    facturaRpt.ExportToHttpResponse(exportOpts, Response, true, sb.ToString());
                }
                catch (System.Threading.ThreadAbortException)
                {
                    Trace.Warn("Thread abortado");
                }
                catch (Exception ex)
                {
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Reporte: " + ex.Message + " " + ex.StackTrace);
                    throw new Exception(ex.Message); 
                    //WebForms.Excepciones.Redireccionar(ex, "~/Excepciones/Excepciones.aspx");
                }
            }
        }

		private void AsignarParametros(double p)
		{
			CrystalDecisions.Shared.ParameterValues myVals = new CrystalDecisions.Shared.ParameterValues();
			CrystalDecisions.Shared.ParameterDiscreteValue myDiscrete = new CrystalDecisions.Shared.ParameterDiscreteValue();
			myDiscrete.Value = NumALet.ToCardinal(Convert.ToDecimal(p));
			myVals.Add(myDiscrete);
			facturaRpt.DataDefinition.ParameterFields[0].ApplyCurrentValues(myVals);
            
            facturaRpt.Subreports["resumen"].DataDefinition.FormulaFields["ImpTotTexto"].Text = "'" + NumALet.ToCardinal(Convert.ToDecimal(p)) + "'";
 	    }

        private void AsignarCamposOpcionales(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            if (lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago == null)
            {
                lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago = string.Empty;
            }
            if(lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae==null)
            {
                lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae = string.Empty;
            }
            lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pagoSpecified = true;
            if (lc.comprobante[0].cabecera.informacion_comprobante.codigo_conceptoSpecified == false)
            {
                lc.comprobante[0].cabecera.informacion_comprobante.codigo_conceptoSpecified = true;
            }

            lc.comprobante[0].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified=true;
            lc.comprobante[0].cabecera.informacion_vendedor.condicion_IVASpecified = true;
            if (lc.comprobante[0].cabecera.informacion_vendedor.provincia == null)
            {
                lc.comprobante[0].cabecera.informacion_vendedor.provincia = string.Empty;
            }

            lc.comprobante[0].cabecera.informacion_comprador.condicion_ingresos_brutosSpecified = true;
            lc.comprobante[0].cabecera.informacion_comprador.condicion_IVASpecified = true;
            if (lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.provincia == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.provincia = string.Empty;
            }
            
            lc.comprobante[0].resumen.cant_alicuotas_ivaSpecified = true;
            lc.comprobante[0].resumen.importe_total_impuestos_internosSpecified=true;
            lc.comprobante[0].resumen.importe_total_impuestos_municipalesSpecified = true;
            lc.comprobante[0].resumen.importe_total_impuestos_nacionalesSpecified = true;
            lc.comprobante[0].resumen.importe_total_ingresos_brutosSpecified = true;
            if (lc.comprobante[0].resumen.descuentos != null)
            {
                for (int i = 0; i < lc.comprobante[0].resumen.descuentos.Length; i++)
                {
                    if (lc.comprobante[0].resumen.descuentos[i] != null)
                    {
                        if (lc.comprobante[0].resumen.descuentos[i].importe_iva_descuentoSpecified.Equals(false))
                        {
                            lc.comprobante[0].resumen.descuentos[i].importe_iva_descuentoSpecified = true;
                        }
                        if (lc.comprobante[0].resumen.descuentos[i].alicuota_iva_descuentoSpecified.Equals(false))
                        {
                            lc.comprobante[0].resumen.descuentos[i].alicuota_iva_descuentoSpecified = true;
                        }
                        if (lc.comprobante[0].resumen.descuentos[i].porcentaje_descuentoSpecified.Equals(false))
                        {
                            lc.comprobante[0].resumen.descuentos[i].porcentaje_descuentoSpecified = true;
                        }
                    }
                }
            }
            for (int i = 0; i < lc.comprobante[0].detalle.linea.Length;i++)
            {
                if (lc.comprobante[0].detalle.linea[i]!=null)
                {
                    lc.comprobante[0].detalle.linea[i].precio_unitarioSpecified = true;
                    lc.comprobante[0].detalle.linea[i].importe_ivaSpecified = true;
                    if (lc.comprobante[0].detalle.linea[i].alicuota_ivaSpecified.Equals(false))
                    {
                        lc.comprobante[0].detalle.linea[i].alicuota_ivaSpecified = true;
                        lc.comprobante[0].detalle.linea[i].alicuota_iva = 99;
                    }
                    lc.comprobante[0].detalle.linea[i].cantidadSpecified = true;

                    if (lc.comprobante[0].detalle.linea[i].unidad == null)
                    {
                        lc.comprobante[0].detalle.linea[i].unidad = string.Empty;
                    }
                    if (lc.comprobante[0].detalle.linea[i].indicacion_exento_gravado == null)
                    {
                        lc.comprobante[0].detalle.linea[i].indicacion_exento_gravado = string.Empty;
                    }
					if (lc.comprobante[0].detalle.linea[i].importes_moneda_origen != null)
					{
						lc.comprobante[0].detalle.linea[i].importes_moneda_origen.importe_ivaSpecified = true;
						lc.comprobante[0].detalle.linea[i].importes_moneda_origen.importe_total_articuloSpecified = true;
						lc.comprobante[0].detalle.linea[i].importes_moneda_origen.importe_total_descuentosSpecified = true;
						lc.comprobante[0].detalle.linea[i].importes_moneda_origen.importe_total_impuestosSpecified = true;
						lc.comprobante[0].detalle.linea[i].importes_moneda_origen.precio_unitarioSpecified = true;
					}
                    if (lc.comprobante[0].detalle.linea[i].GTINSpecified.Equals(false))
                    {
                        lc.comprobante[0].detalle.linea[i].GTINSpecified = true;
                        lc.comprobante[0].detalle.linea[i].GTIN = 0;
                    }
                }
                else
                {
                    break;
                }
            }
        }

		private static void ReemplarResumenImportesMonedaExtranjera(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			if (!lc.comprobante[0].resumen.codigo_moneda.Equals("PES"))
			{
				lc.comprobante[0].resumen.importe_total_neto_gravado = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_neto_gravado;

				lc.comprobante[0].resumen.importe_total_concepto_no_gravado = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_concepto_no_gravado;
				lc.comprobante[0].resumen.importe_operaciones_exentas = lc.comprobante[0].resumen.importes_moneda_origen.importe_operaciones_exentas;
				lc.comprobante[0].resumen.impuesto_liq = lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq;
				lc.comprobante[0].resumen.impuesto_liq_rni = lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq_rni;
				lc.comprobante[0].resumen.importe_total_impuestos_municipales = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_municipales;
				lc.comprobante[0].resumen.importe_total_impuestos_nacionales = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_nacionales;
				lc.comprobante[0].resumen.importe_total_ingresos_brutos = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_ingresos_brutos;
				lc.comprobante[0].resumen.importe_total_impuestos_internos = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_internos;

				lc.comprobante[0].resumen.importe_total_factura = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura;

				if (lc.comprobante[0].resumen.descuentos != null)
				{
					for (int i = 0; i < lc.comprobante[0].resumen.descuentos.Length; i++)
					{
						if (lc.comprobante[0].resumen.descuentos[i] != null)
						{
							lc.comprobante[0].resumen.descuentos[i].importe_descuento = lc.comprobante[0].resumen.descuentos[i].importe_descuento_moneda_origen;
                            lc.comprobante[0].resumen.descuentos[i].importe_iva_descuento = lc.comprobante[0].resumen.descuentos[i].importe_iva_descuento_moneda_origen;
						}
					}
				}
			}
		}

        private void GenerarCodigoBarras(string code)
        {
            if (code != null)
            {
                Reportes.Code39 c39 = new Reportes.Code39();
                MemoryStream ms = new MemoryStream();
                c39.FontFamilyName = "Free 3 of 9";
                c39.FontFileName = Server.MapPath("FREE3OF9.TTF");
                c39.FontSize = 30;
                c39.ShowCodeString = true;
                System.Drawing.Bitmap objBitmap = c39.GenerateBarcode(code);
                objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                codigobarrasRpt = facturaRpt.OpenSubreport("CodigoBarra.rpt");

                CrearTabla();

                DataRow dr = this.dsImages.Tables["images"].NewRow();
                dr["path"] = "ninguno";
                dr["image"] = ms.ToArray();
                this.dsImages.Tables["images"].Rows.Add(dr);

                codigobarrasRpt.SetDataSource(this.dsImages);
            }
        }

        private void IncrustarLogo(string cuit, string PtoVta)
        {
            try
            {
                String path = Server.MapPath("~/ImagenesSubidas/");

                string[] archivos = System.IO.Directory.GetFiles(path, cuit + "-" + PtoVta + ".*", System.IO.SearchOption.TopDirectoryOnly);
                string imagenCUIT = "";
                if (archivos.Length > 0)
                {
                    imagenCUIT = "~/ImagenesSubidas/" + archivos[0].Replace(Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                }
                else
                {
                    archivos = System.IO.Directory.GetFiles(path, cuit + ".*", System.IO.SearchOption.TopDirectoryOnly);
                    imagenCUIT = "";
                    if (archivos.Length > 0)
                    {
                        imagenCUIT = "~/ImagenesSubidas/" + archivos[0].Replace(Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                    }
                }

                if (imagenCUIT != "")
                {
                    FileStream FilStr = new FileStream(Server.MapPath(imagenCUIT), FileMode.Open);
                    CrearTabla();
                    BinaryReader BinRed = new BinaryReader(FilStr);
                    DataRow dr = this.dsImages.Tables["images"].NewRow();
                    dr["path"] = Server.MapPath(imagenCUIT);
                    dr["image"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                    this.dsImages.Tables["images"].Rows.Add(dr);
                    FilStr.Close();
                    BinRed.Close();

                    imagenRpt = facturaRpt.OpenSubreport("Imagen.rpt");
                    imagenRpt.SetDataSource(this.dsImages);
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Reporte: Imagen OK"  );
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message.ToString().Replace("'", " ");
                a = a.Replace("<", " ");
                a = a.Replace(">", " ");
                a = a.Replace("/", " ");
                a = a.Replace(@"\", " ");
                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Reporte: Imagen NOT OK " + a);
            }
        }

        private void CrearTabla()
        {
            this.dsImages = new DataSet();
            DataTable imageTable = new DataTable("Images");
            imageTable.Columns.Add(new DataColumn("path", typeof(string)));
            imageTable.Columns.Add(new DataColumn("image", typeof(System.Byte[])));
            this.dsImages.Tables.Add(imageTable);
        }
    }
}

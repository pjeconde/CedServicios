using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ComprobanteSeleccionArchivoXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void FileUploadButton_Click(object sender, EventArgs e)
        {
            if (((Button)sender).ID == "FileUploadButton" && ((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
            {
                MensajeLabel.Text = "Su sesión ha caducado por inactividad. Por favor vuelva a loguearse.";
            }
            else
            {
                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                if (XMLFileUpload.HasFile)
                {
                    try
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(XMLFileUpload.FileBytes);
                        ms.Seek(0, System.IO.SeekOrigin.Begin);

                        try
                        {
                            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lc.GetType());
                            lc = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                            if (((Entidades.Sesion)Session["Sesion"]).Cuit.Nro != lc.comprobante[0].cabecera.informacion_vendedor.cuit.ToString())
                            {
                                MensajeLabel.Text = "El CUIT del vendedor: " + lc.comprobante[0].cabecera.informacion_vendedor.cuit.ToString() + " que figura en el archivo XML, no coincide con el CUIT que usted está operando.";
                                return;
                            }
                            if (((Entidades.Sesion)Session["Sesion"]).Cuit.Nro != lc.cabecera_lote.cuit_vendedor.ToString())
                            {
                                MensajeLabel.Text = "El CUIT del lote: " + lc.cabecera_lote.cuit_vendedor.ToString() + " que figura en el archivo XML, no coincide con el CUIT que usted está operando.";
                                return;
                            }
                            System.Collections.Generic.List<Entidades.PuntoVta> listaPV = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.Nro == lc.cabecera_lote.punto_de_venta;
                            });
                            if (listaPV.Count == 0)
                            {
                                MensajeLabel.Text = "El Punto de Venta: " + lc.cabecera_lote.punto_de_venta.ToString() + " que figura en el archivo XML, no coincide con los definidos para la UN que usted está operando.";
                                return;
                            }
                            Cache["ComprobanteAConsultar"] = lc;
                            string script = "window.open('/ComprobanteConsulta.aspx', '');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                        }
                        catch (InvalidOperationException)
                        {
                            try
                            {
                                LeerFormatoDetalleIBK(e, lc, ms);
                            }
                            catch (InvalidOperationException)
                            {
                                LeerFormatoLoteIBK(e, lc, ms);
                            }
                        }
                    }
                    catch
                    {
                        MensajeLabel.Text = "El archivo no cumple con el esquema de Interfacturas";
                    }
                }
                else
                {
                    MensajeLabel.Text = "Debe seleccionar un archivo";
                }
            }
        }
        private void LeerFormatoDetalleIBK(EventArgs e, FeaEntidades.InterFacturas.lote_comprobantes lc, System.IO.MemoryStream ms)
        {
            //Formato detalle_factura IBK
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            FeaEntidades.InterFacturas.comprobante c = new FeaEntidades.InterFacturas.comprobante();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(c.GetType());
            c = (FeaEntidades.InterFacturas.comprobante)x.Deserialize(ms);
            FeaEntidades.InterFacturas.comprobante[] cArray = new FeaEntidades.InterFacturas.comprobante[1];
            cArray[0] = c;
            lc.comprobante = cArray;
            Cache["ComprobanteAConsultar"] = lc;
            string script = "window.open('/ComprobanteConsulta.aspx', '');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
        }

        private void LeerFormatoLoteIBK(EventArgs e, FeaEntidades.InterFacturas.lote_comprobantes lc, System.IO.MemoryStream ms)
        {
            try
            {
                //Formato Lote IBK
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                FeaEntidades.InterFacturas.XML.consulta_lote_comprobantes_response clr = new FeaEntidades.InterFacturas.XML.consulta_lote_comprobantes_response();
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(clr.GetType());
                clr = (FeaEntidades.InterFacturas.XML.consulta_lote_comprobantes_response)x.Deserialize(ms);
                lc = clr.consulta_lote_response.lote_comprobantes;
                Cache["ComprobanteAConsultar"] = lc;
                string script = "window.open('/ComprobanteConsulta.aspx', '');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
            }
            catch
            {
                MensajeLabel.Text = "El archivo no cumple con el esquema de Interfacturas";
            }
        }
    }
}
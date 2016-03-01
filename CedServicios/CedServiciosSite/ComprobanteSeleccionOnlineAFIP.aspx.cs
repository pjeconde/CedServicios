using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

namespace CedServicios.Site
{
    public partial class ComprobanteSeleccionOnlineAFIP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                System.Collections.Generic.List<Entidades.PuntoVta> listaPuntoVta = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta;
                System.Collections.Generic.List<Entidades.PuntoVta> puntoVtalist = new System.Collections.Generic.List<Entidades.PuntoVta>();
                Entidades.PuntoVta puntoVta = new Entidades.PuntoVta();
                puntoVta.Nro = 0;
                puntoVtalist.Add(puntoVta);
                if (listaPuntoVta != null)
                {
                    puntoVtalist.AddRange(listaPuntoVta);
                }
                PtoVtaConsultaDropDownList.DataValueField = "Nro";
                PtoVtaConsultaDropDownList.DataTextField = "DescrCombo";
                PtoVtaConsultaDropDownList.DataSource = puntoVtalist;
                PtoVtaConsultaDropDownList.DataBind();

                TipoComprobanteDropDownList.DataValueField = "Codigo";
                TipoComprobanteDropDownList.DataTextField = "Descr";
                TipoComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompletaAFIP();

                TicketCompletarInfo();

                DataBind();

            }
        }

        protected void ConsultarLoteAFIPButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
            {
                MensajeLabel.Text = "Su sesión ha caducado por inactividad. Por favor vuelva a loguearse";
            }
            else
            {
                try
                {
                    if (TipoComprobanteDropDownList.SelectedValue.Equals("0") || TipoComprobanteDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el tipo de comprobante";
                        return;
                    }
                    if (NroComprobanteTextBox.Text.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el nro de comprobante";
                        return;
                    }
                    if (PtoVtaConsultaDropDownList.SelectedValue.Equals("0") || PtoVtaConsultaDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el punto de venta";
                        return;
                    }
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Lote CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro + "  Tipo.Comprobante: " + TipoComprobanteDropDownList.SelectedValue + "  Nro.Comprobante: " + NroComprobanteTextBox.Text + "  Nro. Punto de Vta.: " + PtoVtaConsultaDropDownList.SelectedValue);

                    FeaEntidades.InterFacturas.lote_comprobantes lcFea = new FeaEntidades.InterFacturas.lote_comprobantes();
                    lcFea.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
                    lcFea.cabecera_lote.punto_de_venta = Convert.ToInt32(PtoVtaConsultaDropDownList.SelectedValue);
                    lcFea.comprobante[0] = new FeaEntidades.InterFacturas.comprobante();
                    lcFea.comprobante[0].cabecera = new FeaEntidades.InterFacturas.cabecera();
                    lcFea.comprobante[0].cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                    lcFea.comprobante[0].cabecera.informacion_comprobante.punto_de_venta = Convert.ToInt32(PtoVtaConsultaDropDownList.SelectedValue);
                    lcFea.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante = Convert.ToInt32(TipoComprobanteDropDownList.SelectedValue);
                    lcFea.comprobante[0].cabecera.informacion_comprobante.numero_comprobante = Convert.ToInt32(NroComprobanteTextBox.Text);

                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPSerializer(lcFea, (Entidades.Sesion)Session["Sesion"]);
                    TicketCompletarInfo();

                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.FEV1/", "");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                }
                catch (Exception ex)
                {
                    string errormsg = ex.Message.Replace("\n", "");
                    if (ex.InnerException != null)
                    {
                        try
                        {
                            errormsg = errormsg + " " + ((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode;
                        }
                        catch
                        {
                        }
                        errormsg = errormsg + " " + ex.InnerException.Message.Replace("\n", "");

                    }
                    errormsg = errormsg.Replace("'", "").Replace("\r", " ");
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\\n " + errormsg;
                }
            }
        }

        protected void ConsultarUltNroLoteAFIPButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
            {
                MensajeLabel.Text = "Su sesión ha caducado por inactividad. Por favor vuelva a loguearse";
            }
            else
            {
                try
                {
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Ult. Nro. Lote CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);

                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPUltNroLote((Entidades.Sesion)Session["Sesion"]);
                    TicketCompletarInfo();

                    respuesta = respuesta.Replace("\r\n", "\\n");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                }
                catch (Exception ex)
                {
                    string errormsg = ex.Message.Replace("\n", "");
                    if (ex.InnerException != null)
                    {
                        try
                        {
                            errormsg = errormsg + " " + ((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode;
                        }
                        catch
                        {
                        }
                        errormsg = errormsg + " " + ex.InnerException.Message.Replace("\n", "");

                    }
                    errormsg = errormsg.Replace("'", "").Replace("\r", " ");
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\\n " + errormsg;
                }
            }
        }

        protected void ConsultarDocTipoAFIPButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
            {
                MensajeLabel.Text = "Su sesión ha caducado por inactividad. Por favor vuelva a loguearse";
            }
            else
            {
                try
                {
                    GrabarLogTexto("~/Consultar.txt", "Consultar los Tipos de Documentos válidos en AFIP (FEv1) para el CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);

                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposDoc((Entidades.Sesion)Session["Sesion"]);
                    TicketCompletarInfo();

                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.FEV1/\"", "");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                }
                catch (Exception ex)
                {
                    string errormsg = ex.Message.Replace("\n", "");
                    if (ex.InnerException != null)
                    {
                        try
                        {
                            errormsg = errormsg + " " + ((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode;
                        }
                        catch
                        {
                        }
                        errormsg = errormsg + " " + ex.InnerException.Message.Replace("\n", "");

                    }
                    errormsg = errormsg.Replace("'", "").Replace("\r", " ");
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\\n " + errormsg;
                }
            }
        }

        protected void ConsultarUltNroComprobanteAFIPButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
            {
                MensajeLabel.Text = "Su sesión ha caducado por inactividad. Por favor vuelva a loguearse";
            }
            else
            {
                try
                {
                    if (TipoComprobanteDropDownList.SelectedValue.Equals("0") || TipoComprobanteDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el tipo de comprobante";
                        return;
                    }
                    if (PtoVtaConsultaDropDownList.SelectedValue.Equals("0") || PtoVtaConsultaDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el punto de venta";
                        return;
                    }
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Ult. Nro. Comprobante CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro + "  Tipo.Comprobante: " + TipoComprobanteDropDownList.SelectedValue + "  Nro.Comprobante: " + NroComprobanteTextBox.Text + "  Nro. Punto de Vta.: " + PtoVtaConsultaDropDownList.SelectedValue);

                    FeaEntidades.InterFacturas.lote_comprobantes lcFea = new FeaEntidades.InterFacturas.lote_comprobantes();
                    lcFea.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
                    lcFea.cabecera_lote.punto_de_venta = Convert.ToInt32(PtoVtaConsultaDropDownList.SelectedValue);
                    lcFea.comprobante[0] = new FeaEntidades.InterFacturas.comprobante();
                    lcFea.comprobante[0].cabecera = new FeaEntidades.InterFacturas.cabecera();
                    lcFea.comprobante[0].cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                    lcFea.comprobante[0].cabecera.informacion_comprobante.punto_de_venta = Convert.ToInt32(PtoVtaConsultaDropDownList.SelectedValue);
                    lcFea.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante = Convert.ToInt32(TipoComprobanteDropDownList.SelectedValue);

                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPUltNroComprobante(lcFea, (Entidades.Sesion)Session["Sesion"]);
                    TicketCompletarInfo();

                    respuesta = respuesta.Replace("\r\n", "\\n");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                }
                catch (Exception ex)
                {
                    string errormsg = ex.Message.Replace("\n", "");
                    if (ex.InnerException != null)
                    {
                        try
                        {
                            errormsg = errormsg + " " + ((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode;
                        }
                        catch
                        {
                        }
                        errormsg = errormsg + " " + ex.InnerException.Message.Replace("\n", "");

                    }
                    errormsg = errormsg.Replace("'", "").Replace("\r", " ");
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\\n " + errormsg;
                }
            }
        }

        protected void ConsultarTipoComprobantesAFIPButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
            {
                MensajeLabel.Text = "Su sesión ha caducado por inactividad. Por favor vuelva a loguearse";
            }
            else
            {
                try
                {
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de Comprobante CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);

                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposComprobantes((Entidades.Sesion)Session["Sesion"]);
                    TicketCompletarInfo();

                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.FEV1/\"", "");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                }
                catch (Exception ex)
                {
                    string errormsg = ex.Message.Replace("\n", "");
                    if (ex.InnerException != null)
                    {
                        try
                        {
                            errormsg = errormsg + " " + ((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode;
                        }
                        catch
                        {
                        }
                        errormsg = errormsg + " " + ex.InnerException.Message.Replace("\n", "");

                    }
                    errormsg = errormsg.Replace("'", "").Replace("\r", " ");
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\\n " + errormsg;
                }
            }
        }

        protected void ConsultarCAEAFIPButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
            {
                MensajeLabel.Text = "Su sesión ha caducado por inactividad. Por favor vuelva a loguearse";
            }
            else
            {
                try
                {
                    //ValidarCampos();
                    GrabarLogTexto("~/Consultar.txt", "Consulta de CAE. CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);

                    string respuesta;

                    FeaEntidades.InterFacturas.lote_comprobantes lcFea = new FeaEntidades.InterFacturas.lote_comprobantes();
                    lcFea.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
                    lcFea.cabecera_lote.punto_de_venta = Convert.ToInt32(PtoVtaConsultaDropDownList.SelectedValue);
                    lcFea.comprobante[0] = new FeaEntidades.InterFacturas.comprobante();
                    lcFea.comprobante[0].cabecera = new FeaEntidades.InterFacturas.cabecera();
                    lcFea.comprobante[0].cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                    lcFea.comprobante[0].cabecera.informacion_comprobante.punto_de_venta = Convert.ToInt32(PtoVtaConsultaDropDownList.SelectedValue);
                    lcFea.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante = Convert.ToInt32(TipoComprobanteDropDownList.SelectedValue);
                    lcFea.comprobante[0].cabecera.informacion_comprobante.numero_comprobante = Convert.ToInt32(NroComprobanteTextBox.Text);
                    lcFea.comprobante[0].cabecera.informacion_comprobante.cae = NroCAETextBox.Text;
                    lcFea.comprobante[0].cabecera.informacion_comprobante.caeSpecified = true;
                    lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_emision = FecEmisionTextBox.Text;
                    lcFea.comprobante[0].cabecera.informacion_vendedor = new FeaEntidades.InterFacturas.informacion_vendedor();
                    lcFea.comprobante[0].cabecera.informacion_vendedor.cuit = Convert.ToInt64(CuitEmisorTextBox.Text);
                    lcFea.comprobante[0].resumen = new FeaEntidades.InterFacturas.resumen();
                    //lcFea.comprobante[0].resumen.importe_total_factura = Convert.ToDouble(ImporteTotalTextBox.Text);

                    respuesta = RN.ComprobanteAFIP.ValidarAFIPNroCae(lcFea, ((Entidades.Sesion)Session["Sesion"]));
                    TicketCompletarInfo();

                    respuesta = respuesta.Replace("\r\n", "\\n");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                }
                catch (Exception ex)
                {
                    string errormsg = ex.Message.Replace("\n", "");
                    if (ex.InnerException != null)
                    {
                        try
                        {
                            errormsg = errormsg + " " + ((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode;
                        }
                        catch
                        {
                        }
                        errormsg = errormsg + " " + ex.InnerException.Message.Replace("\n", "");

                    }
                    errormsg = errormsg.Replace("'", "").Replace("\r", " ");
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\\n " + errormsg;
                }
            }
        }

        private void TicketCompletarInfo()
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            if (sesion.Ticket != null)
            {
                TicketInfoTextBox.Text = "Ticket CUIT: " + sesion.Ticket.Cuit + "   Unique Id.: " + sesion.Ticket.UniqueId + "\nExpiration Time: " + sesion.Ticket.ExpirationTime.ToString() + "   Generation Time: " + sesion.Ticket.GenerationTime.ToString();
            }
            else
            {
                TicketInfoTextBox.Text = "No hay ticket. La información del ticket se completará cuando se ejecute alguna consulta.";
            }
        }

        private void GrabarLogTexto(string archivo, string mensaje)
        {
            try
            {
                using (FileStream fs = File.Open(Server.MapPath(archivo), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + "  " + mensaje);
                    }
                }
            }
            catch
            {
            }
        }


        protected void ConsultarDatosFiscalesButton_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = RN.ServiciosAFIP.DatosFiscales(CuitAConsultarTextBox.Text, ((Entidades.Sesion)Session["Sesion"]));
                respuesta = respuesta.Replace("\n", "\\n");
                respuesta = respuesta.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" ,"");
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message.Replace("\n", "");
                if (ex.InnerException != null)
                {
                    try
                    {
                        errormsg = errormsg + " " + ((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode;
                    }
                    catch
                    {
                    }
                    errormsg = errormsg + " " + ex.InnerException.Message.Replace("\n", "");

                }
                errormsg = errormsg.Replace("'", "").Replace("\r", " ");
                MensajeLabel.Text = "Problemas al consultar en AFIP.\\n " + errormsg;
            }
        }
    }
}
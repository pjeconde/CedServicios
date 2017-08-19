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
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
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

                    PtoVtaConsultaUltNroCompDropDownList.DataValueField = "Nro";
                    PtoVtaConsultaUltNroCompDropDownList.DataTextField = "DescrCombo";
                    PtoVtaConsultaUltNroCompDropDownList.DataSource = puntoVtalist;
                    PtoVtaConsultaUltNroCompDropDownList.DataBind();

                    PtoVtaConsultaValidarCAEDropDownList.DataValueField = "Nro";
                    PtoVtaConsultaValidarCAEDropDownList.DataTextField = "DescrCombo";
                    PtoVtaConsultaValidarCAEDropDownList.DataSource = puntoVtalist;
                    PtoVtaConsultaValidarCAEDropDownList.DataBind();

                    TipoComprobanteDropDownList.DataValueField = "Codigo";
                    TipoComprobanteDropDownList.DataTextField = "Descr";
                    TipoComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompletaAFIPTurismo();
                    TipoComprobanteDropDownList.DataBind();

                    TipoComprobanteUltNroCompDropDownList.DataValueField = "Codigo";
                    TipoComprobanteUltNroCompDropDownList.DataTextField = "Descr";
                    TipoComprobanteUltNroCompDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompletaAFIP();
                    TipoComprobanteUltNroCompDropDownList.DataBind();

                    TipoComprobanteValidarCAEDropDownList.DataValueField = "Codigo";
                    TipoComprobanteValidarCAEDropDownList.DataTextField = "Descr";
                    TipoComprobanteValidarCAEDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompletaAFIP();
                    TipoComprobanteValidarCAEDropDownList.DataBind();

                    TicketCompletarInfo();

                    DataBind();
                }
            }
            else
            {
                TabName.Value = Request.Form[TabName.UniqueID];
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
                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.FEV1/", "");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.fexv1/", "");
                    respuesta = respuesta.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
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
                    if (TipoComprobanteUltNroCompDropDownList.SelectedValue.Equals("0") || TipoComprobanteUltNroCompDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el tipo de comprobante";
                        return;
                    }
                    if (PtoVtaConsultaUltNroCompDropDownList.SelectedValue.Equals("0") || PtoVtaConsultaUltNroCompDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el punto de venta";
                        return;
                    }
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Ult. Nro. Comprobante CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro + "  Tipo.Comprobante: " + TipoComprobanteDropDownList.SelectedValue + "  Nro.Comprobante: " + NroComprobanteTextBox.Text + "  Nro. Punto de Vta.: " + PtoVtaConsultaDropDownList.SelectedValue);

                    FeaEntidades.InterFacturas.lote_comprobantes lcFea = new FeaEntidades.InterFacturas.lote_comprobantes();
                    lcFea.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
                    lcFea.cabecera_lote.punto_de_venta = Convert.ToInt32(PtoVtaConsultaUltNroCompDropDownList.SelectedValue);
                    lcFea.comprobante[0] = new FeaEntidades.InterFacturas.comprobante();
                    lcFea.comprobante[0].cabecera = new FeaEntidades.InterFacturas.cabecera();
                    lcFea.comprobante[0].cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                    lcFea.comprobante[0].cabecera.informacion_comprobante.punto_de_venta = Convert.ToInt32(PtoVtaConsultaUltNroCompDropDownList.SelectedValue);
                    lcFea.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante = Convert.ToInt32(TipoComprobanteUltNroCompDropDownList.SelectedValue);

                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPUltNroComprobante(lcFea, (Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
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
                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.FEV1/\"", "");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                    //MensajeLabel.Text = Funciones.TextoScript(respuesta);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarTipoComprobantesAFIPEXPOButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de Comprobante (EXPO) CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);

                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposComprobantesEXPO((Entidades.Sesion)Session["Sesion"]);

                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace("\n<", "<");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.fexv1/", "");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                    //MensajeLabel.Text = Funciones.TextoScript(respuesta);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }
        protected void ConsultarTiposDeExportacionAFIPEXPOButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de exportación posibles (EXPO) CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposDeEXPO((Entidades.Sesion)Session["Sesion"]);
                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.fexv1/", "");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                    //MensajeLabel.Text = Funciones.TextoScript(respuesta);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }
        protected void ConsultarUnidadesDeMedidaAFIPEXPOButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Unidades de Medida (EXPO) CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPUnidadesDeMedidaEXPO((Entidades.Sesion)Session["Sesion"]);
                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.fexv1/", "");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                    //MensajeLabel.Text = Funciones.TextoScript(respuesta);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }
        protected void ConsultarIncotermsAFIPEXPOButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Incoterms (EXPO) CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPIncotermsEXPO((Entidades.Sesion)Session["Sesion"]);
                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.fexv1/", "");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                    //InfoRespuestaTextBox.Text = "";
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }
        protected void ConsultarDST_CuitAFIPEXPOButton_click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Destinos cuit (EXPO) CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPDST_CuitEXPO((Entidades.Sesion)Session["Sesion"]);
                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.fexv1/", "");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                    //InfoRespuestaTextBox.Text = "";
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }
        protected void ConsultarDST_PaisAFIPEXPOButton_click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Destinos pais (EXPO) CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPDST_PaisEXPO((Entidades.Sesion)Session["Sesion"]);
                    respuesta = respuesta.Replace("\r\n", "\\n");
                    respuesta = respuesta.Replace(" xmlns=\"http://ar.gov.afip.dif.fexv1/", "");
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
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
                    if (TipoComprobanteValidarCAEDropDownList.SelectedValue.Equals("0") || TipoComprobanteValidarCAEDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el tipo de comprobante";
                        return;
                    }
                    if (PtoVtaConsultaValidarCAEDropDownList.SelectedValue.Equals("0") || PtoVtaConsultaValidarCAEDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el punto de venta";
                        return;
                    }

                    GrabarLogTexto("~/Consultar.txt", "Consulta de CAE. CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    FeaEntidades.InterFacturas.lote_comprobantes lcFea = new FeaEntidades.InterFacturas.lote_comprobantes();
                    lcFea.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
                    lcFea.cabecera_lote.punto_de_venta = Convert.ToInt32(PtoVtaConsultaValidarCAEDropDownList.SelectedValue);
                    lcFea.comprobante[0] = new FeaEntidades.InterFacturas.comprobante();
                    lcFea.comprobante[0].cabecera = new FeaEntidades.InterFacturas.cabecera();
                    lcFea.comprobante[0].cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                    lcFea.comprobante[0].cabecera.informacion_comprobante.punto_de_venta = Convert.ToInt32(PtoVtaConsultaValidarCAEDropDownList.SelectedValue);
                    lcFea.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante = Convert.ToInt32(TipoComprobanteValidarCAEDropDownList.SelectedValue);
                    lcFea.comprobante[0].cabecera.informacion_comprobante.numero_comprobante = Convert.ToInt32(NroComprobanteValidarCAETextBox.Text);
                    lcFea.comprobante[0].cabecera.informacion_comprobante.cae = NroCAETextBox.Text;
                    lcFea.comprobante[0].cabecera.informacion_comprobante.caeSpecified = true;
                    lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_emision = FecEmisionTextBox.Text;
                    lcFea.comprobante[0].cabecera.informacion_vendedor = new FeaEntidades.InterFacturas.informacion_vendedor();
                    lcFea.comprobante[0].cabecera.informacion_vendedor.cuit = Convert.ToInt64(CuitEmisorTextBox.Text);
                    lcFea.comprobante[0].resumen = new FeaEntidades.InterFacturas.resumen();
                    //lcFea.comprobante[0].resumen.importe_total_factura = Convert.ToDouble(ImporteTotalTextBox.Text);

                    respuesta = RN.ComprobanteAFIP.ValidarAFIPNroCae(lcFea, ((Entidades.Sesion)Session["Sesion"]));
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        private void TicketCompletarInfo()
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            if (sesion.Ticket != null)
            {
                if (sesion.Cuit.Nro == sesion.Ticket.Cuit)
                {
                    TicketInfoTextBox.Text = "Ticket CUIT: " + sesion.Ticket.Cuit + "   Unique Id.: " + sesion.Ticket.UniqueId + "   Servicio: "+ sesion.Ticket.Service + "\nGeneration Time: " + sesion.Ticket.GenerationTime.ToString() + "   Expiration Time: " + sesion.Ticket.ExpirationTime.ToString();
                }
                else
                {
                    TicketInfoTextBox.Text = "No hay ticket. La información del ticket se completará cuando se ejecute alguna consulta.";
                }
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

        protected void ConsultarFormasDePagoCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Formas de Pago: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPFormasDePago_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarTiposComprobantesCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de Comprobantes: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposDeComprobantes_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarTiposDocumentoCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de Documento: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposDeDocumento_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarTiposDeIVACTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de IVA: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposDeIVA_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarTiposDeTributosCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de Tributos: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposDeTributos_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarRelacionEmisorReceptorCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de Tributos: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPRelacionEmisorReceptor_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarPaisesCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Paises: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPPaises_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarMonedasCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos Monedas: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPMonedas_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarCondicionesIVACTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de Tributos: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPCondicionesIVA_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarTiposDeTarjetasCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de Tarjetas: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposDeTarjetas_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarNovedadesCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Novedades: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPNovedades_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarTiposDeCuentasCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de Cuentas: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposDeCuentas_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarAFIPTiposItemCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Tipos de Item: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPTiposItem_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarAFIPCodigosItemTurismoCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Códigos de Item Turismo: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPCodigosItemTurismo_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarAFIPCuitPaisesCTButton_Click(object sender, EventArgs e)
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
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Códigos de Cuit Paises: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro);
                    string respuesta;
                    respuesta = RN.ComprobanteAFIP.ConsultarAFIPCuitPaises_CT((Entidades.Sesion)Session["Sesion"]);
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
                    MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
                }
                finally
                {
                    TicketCompletarInfo();
                }
            }
        }

        protected void ConsultarDatosFiscalesButton_Click(object sender, EventArgs e)
        {
            try
            {
                MensajeLabel.Text = "";
                if (CuitAConsultarTextBox.Text == "")
                {
                    MensajeLabel.Text = "Ingrese el CUIT a consultar";
                    return;
                }
                if (!RN.Funciones.IsValidNumeric(CuitAConsultarTextBox.Text))
                {
                    MensajeLabel.Text = "El CUIT a consultar deberá tener solo dígitos numéricos.";
                    return;
                }
                if (CuitAConsultarTextBox.Text.Length != 11)
                {
                    MensajeLabel.Text = "El CUIT a consultar deberá tener 11 dígitos.";
                    return;
                }
                string respuesta = RN.ServiciosAFIP.DatosFiscales(CuitAConsultarTextBox.Text, ((Entidades.Sesion)Session["Sesion"]));
                TicketCompletarInfo();
                respuesta = respuesta.Replace("\n", "\\n");
                respuesta = respuesta.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "");
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
                MensajeLabel.Text = "Problemas al consultar en AFIP.\r\n " + errormsg;
            }
        }
    }
}